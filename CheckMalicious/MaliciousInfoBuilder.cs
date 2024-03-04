using CheckMalicious;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMalicious
{
    public class MaliciousInfoBuilder
    {
        private const string IsMaliciousWarning = "The input is malicious!!!";
        private const string IsNotMaliciousComment = "The input is not malicious :-)";        

        private int maliciousCount;
        public int MaliciousInfoCount
        {
            get { return maliciousCount; }
        }

        private StringBuilder sbMaliciousDescription;

        public MaliciousInfoBuilder()
        {            
            maliciousCount = 0;
            sbMaliciousDescription = new StringBuilder();
        }

        public void AppendMalicious(string maliciousTitle)
        {
            maliciousCount++;
            sbMaliciousDescription.AppendLine(String.Format("malicious {0}: {1}", maliciousCount, maliciousTitle));
        }

        private string maliciousInfoString()
        {
            StringBuilder sbResult = new StringBuilder();
            sbResult.AppendLine("******************************");
            sbResult.AppendLine("Malicious Check Total Info:");
            sbResult.AppendLine("******************************");
            sbResult.AppendLine("");
            sbResult.AppendLine($"--- Malicious Count: {maliciousCount} ---");
            sbResult.AppendLine($"---------------------------------");

            if (maliciousCount == 0)
            {
                sbResult.AppendLine(IsNotMaliciousComment);
            }
            else
            {
                sbResult.Append(sbMaliciousDescription);
            }

            return sbResult.ToString();
        }
        public string MaliciousInfoString
        {
            get { return maliciousInfoString(); }
        }
    }
}
