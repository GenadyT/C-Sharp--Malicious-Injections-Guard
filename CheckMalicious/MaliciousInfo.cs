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

        private string maliciousDescription;
        public string MaliciousDescription
        {
            get { return maliciousDescription; }
        }

        public MaliciousInfo(bool isMalicious, string maliciousDescription)
        {
            this.isMalicious = isMalicious;
            this.maliciousDescription = maliciousDescription;
        }
    }
}
