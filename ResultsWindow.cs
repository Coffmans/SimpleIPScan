using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleIPScan
{
    public partial class ResultsWindow : Form
    {
        string _startingIp = string.Empty;
        string _endingIp = string.Empty;
        private long _totaltime = -1;
        long _reachableIps = 0;
        long _unreachableIps = 0;
        long _totalIps = 0;
        public ResultsWindow(string startingIP, string endingIP, long totalAddresses, long totalTime, long reachableIps, long unreachaableIps)
        {
            InitializeComponent();

            _startingIp = startingIP;
            _endingIp = endingIP;
            _totaltime = totalTime;
            _reachableIps = reachableIps;
            _unreachableIps = unreachaableIps;
            _totalIps = totalAddresses;
        }

        private void ResultsWindow_Load(object sender, EventArgs e)
        {
            txtIPRange.Text = _startingIp + " - " + _endingIp;
            txtTotalNumber.Text = _totalIps.ToString();
            txtTotalReachable.Text = _reachableIps.ToString();
            txtTotalUnreachable.Text = _unreachableIps.ToString();
            var totalTime = (_totaltime / 1000).ToString() + "." + (_totaltime % 1000).ToString() + " secs";
            txtTotalTime.Text = totalTime;

        }
    }
}
