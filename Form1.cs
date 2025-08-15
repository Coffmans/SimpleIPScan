using System.Diagnostics;
using System.Net;
using System.Net.NetworkInformation;
using System.Text;
using DnsClient;
using SimpleIPScan.Properties;

namespace SimpleIPScan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private IPAddress _startIpAddress = IPAddress.Parse("127.0.0.1");
        private IPAddress _endIpAddress = IPAddress.Parse("127.0.0.1");
        private Stopwatch _overallWatch = new Stopwatch();
        private int _reachableAddresses;
        private int _unreachableAddresses;
        private int _totalAddresses;

        ImageList _imageList = new ImageList();

        private bool _bPingBackup;

        private delegate void InvokeToListViewDelegate(ListViewItem lvItem);
        private delegate void InvokeToListViewBatchDelegate(ListViewItem lvItem);

        private async Task ScanIpRangeViaPing(IPAddress startIp, IPAddress endIp)
        {
            var startIpString = startIp.ToString().Split('.');
            var startIpAddress = Array.ConvertAll(startIpString, int.Parse); //Change string array to int array
            var endIpString = endIp.ToString().Split('.');
            var endIpAddress = Array.ConvertAll(endIpString, int.Parse);

            _overallWatch = new Stopwatch();
            _overallWatch.Start();

            _reachableAddresses = 0;
            _unreachableAddresses = 0;
            _totalAddresses = 0;

            int totalIps = 0;
            for (int i = startIpAddress[2]; i <= endIpAddress[2]; i++)
            {
                int startJ = (i == startIpAddress[2]) ? startIpAddress[3] : 0;
                int endJ = (i == endIpAddress[2]) ? endIpAddress[3] : 255;
                totalIps += (endJ - startJ + 1);
            }
            InvokeProgressBarUpdate(0, totalIps);

            var lookUpOption = new LookupClientOptions
            {
                UseTcpFallback = true,
                UseTcpOnly = true,
            };
            Ping pingSender = new Ping();
            var batchItems = new List<ListViewItem>();
            int batchSize = totalIps < 200 ? 10 : 25;

            for (var i = startIpAddress[2]; i <= endIpAddress[2]; i++)
            {
                var dnsLookup = new LookupClient(lookUpOption);

                int startJ = (i == startIpAddress[2]) ? startIpAddress[3] : 0;
                int endJ = (i == endIpAddress[2]) ? endIpAddress[3] : 255;
                for (var j = startJ; j <= endJ; j++)
                {
                    _totalAddresses++;

                    var ipAddress = $"{startIpAddress[0]}.{startIpAddress[1]}.{i}.{j}";
                    InvokeStatuslabelUpdate(ipAddress);

                    var lvItem = new ListViewItem
                    {
                        Text = ipAddress
                    };

                    try
                    {
                        try
                        {
                            string? hostName = null;
                            var pingWatch = new Stopwatch();

                            pingWatch.Start();
                            var pingResult = await dnsLookup.QueryReverseAsync(IPAddress.Parse(ipAddress)).ConfigureAwait(false);
                            pingWatch.Stop();
                            if (pingResult != null)
                            {
                                if (pingResult.Answers != null && pingResult.Answers.Any())
                                {
                                    hostName = pingResult.Answers.PtrRecords().First().PtrDomainName;
                                }
                                else if (_bPingBackup)
                                {
                                    // Create a buffer of 32 bytes of data to be transmitted.
                                    string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
                                    Encoding.ASCII.GetBytes(data);
                                    pingWatch.Start();
                                    PingReply reply = await pingSender.SendPingAsync(IPAddress.Parse(ipAddress), 50);
                                    pingWatch.Stop();
                                    if (reply.Status == IPStatus.Success)
                                    {
                                        hostName = "Unable to retrieve hostname";
                                    }
                                }
                            }

                            if (hostName != null)
                            {
                                lvItem.SubItems.Add(hostName);
                                if (hostName.Equals("Unable to retrieve hostname"))
                                {
                                    lvItem.ImageIndex = 2;
                                }
                                else
                                {
                                    lvItem.ImageIndex = 1;
                                }

                                lvItem.SubItems.Add(pingWatch.ElapsedMilliseconds.ToString() + " ms");
                                _reachableAddresses++;
                            }
                            else
                            {
                                lvItem.ImageIndex = 0;
                                lvItem.SubItems.Add("N/A");
                                lvItem.SubItems.Add("N/A");
                                _unreachableAddresses++;
                            }
                        }
                        catch (Exception)
                        {
                            lvItem.ImageIndex = 0;
                            lvItem.SubItems.Add("");
                            lvItem.SubItems.Add("N/A");


                            _unreachableAddresses++;
                        }

                        batchItems.Add(lvItem);

                        InvokeProgressBarUpdate(_totalAddresses, totalIps);

                        // Update ListView when batch size is reached
                        if (batchItems.Count >= batchSize)
                        {
                            InvokeToListViewBatch(batchItems);
                            batchItems.Clear();
                        }

                        //InvokeToListView(lvItem);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }

            }

            // Add any remaining items
            if (batchItems.Any())
            {
                InvokeToListViewBatch(batchItems);
            }

            InvokeStatuslabelUpdate("Scan Complete!");
            InvokeProgressBarUpdate(totalIps, totalIps);
            _overallWatch.Stop();
        }

        private void InvokeProgressBarUpdate(int value, int maximum)
        {
            if (progressBar1.InvokeRequired)
            {
                Invoke(new Action<int, int>(InvokeProgressBarUpdate), value, maximum);
                return;
            }

            progressBar1.Maximum = maximum;
            progressBar1.Value = value;
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            _startIpAddress = IPAddress.Parse(maskedStartIP.Text);
            _endIpAddress = IPAddress.Parse(maskedEndIP.Text);

            lvIPAddresses.Items.Clear();

            _bPingBackup = chkPingBackup.Checked;


            EnableDisableControls(false);
            await ScanIpRangeViaPing(_startIpAddress, _endIpAddress);

            ResultsWindow result = new ResultsWindow(maskedStartIP.Text, maskedEndIP.Text, _totalAddresses, _overallWatch.ElapsedMilliseconds, _reachableAddresses, _unreachableAddresses);
            result.ShowDialog();
            EnableDisableControls(true);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            maskedStartIP.ValidatingType = typeof(IPAddress);
            maskedEndIP.ValidatingType = typeof(IPAddress);


            _imageList.Images.Add("error", Resources.error);
            _imageList.Images.Add("success", Resources.success);
            _imageList.Images.Add("maybe", Resources.maybe);


            lvIPAddresses.SmallImageList = _imageList;

        }

        private void EnableDisableControls(bool bEnable)
        {
            btnScan.Enabled = bEnable;
            maskedStartIP.Enabled = bEnable;
            maskedEndIP.Enabled = bEnable;
            chkPingBackup.Enabled = bEnable;
        }

        private void InvokeToListView(ListViewItem lvItem)
        {
            if (lvIPAddresses.InvokeRequired)
            {
                Invoke(new InvokeToListViewDelegate(InvokeToListView), lvItem);
                return;
            }

            lvIPAddresses.Items.Add(lvItem);

        }

        private void InvokeToListViewBatch(List<ListViewItem> items)
        {
            if (lvIPAddresses.InvokeRequired)
            {
                Invoke(new Action<List<ListViewItem>>(InvokeToListViewBatch), items);
                return;
            }

            lvIPAddresses.BeginUpdate();
            try
            {
                foreach (var item in items)
                {
                    lvIPAddresses.Items.Add(item);
                }
            }
            finally
            {
                lvIPAddresses.EndUpdate();
            }

        }

        private void InvokeStatuslabelUpdate(string text)
        {
            if (lblStatus.InvokeRequired)
            {
                Invoke(new Action<string>(InvokeStatuslabelUpdate), text);
                return;
            }

            lblStatus.Text = "Scanning IP Address: " + text;
        }
    }
}