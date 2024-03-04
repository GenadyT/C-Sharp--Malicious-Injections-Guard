using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMalicious
{
    public class MaliciousInfo
    {
		private bool isMalicious;
		public bool IsMalicious
        {
			get { return isMalicious; }
		}

        private string reportMalicious;
        public string ReportMalicious
        {
            get { return reportMalicious; }
        }

        public MaliciousInfo(bool isMalicious, string reportMalicious)
        {
            this.isMalicious = isMalicious;
            this.reportMalicious= reportMalicious;
        }
    }
}
