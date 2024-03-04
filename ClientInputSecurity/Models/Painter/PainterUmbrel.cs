using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using CheckMalicious;


namespace ClientInputSecurity.Models.Painter
{
    public class PainterUmbrel : MaliciousUmbrel<Painter>
    {
        public PainterUmbrel(Painter entity) : base(entity) { }

        public override MaliciousInfo ReportMalicious()
        {
            int entityMaxID = Convert.ToInt32(ConfigurationManager.AppSettings["EntityMaxID"]);
            int dictionaryMaxID = Convert.ToInt32(ConfigurationManager.AppSettings["DictionaryMaxID"]);
            int entityNameMaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["EntityNameMaxLength"]);
            int entityDescriptionMaxLength = Convert.ToInt32(ConfigurationManager.AppSettings["EntityDescriptionMaxLength"]);

            MaliciousCheck maliciousCheck = new MaliciousCheck(entityMaxID, dictionaryMaxID, entityNameMaxLength, entityDescriptionMaxLength);
            MaliciousInfoBuilder infoBuilder = new MaliciousInfoBuilder();

            if (maliciousCheck.IsNotID(entity.ID) || (entity.ID > entityMaxID))
            {
                infoBuilder.AppendMalicious("Painter ID field is not valid");
            }

            if (maliciousCheck.IsNotEntityName(entity.Name))
            {
                infoBuilder.AppendMalicious("Painter Name field is malicious");
            }            

            if (maliciousCheck.IsNotID(entity.MovementID) || (entity.MovementID > dictionaryMaxID))
            {
                infoBuilder.AppendMalicious("Painter Movement ID field is not valid");
            }            

            if (maliciousCheck.IsSQLInjection(entity.InternetInfoLink))
            {
                infoBuilder.AppendMalicious("Internet Info Link field is malicious");
            }

            if (maliciousCheck.IsNotEntityDescription(entity.MyComments))
            {
                infoBuilder.AppendMalicious("My Comments field is malicious");
            }

            int maliciousCount = infoBuilder.MaliciousInfoCount;

            MaliciousInfo maliciousInfo = new MaliciousInfo(infoBuilder.MaliciousInfoCount > 0, infoBuilder.MaliciousInfoString);
            return maliciousInfo;
        }
    }
}