using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace CheckMalicious
{
    public class MaliciousCheck
    {
        private static class MaliciousState
        {
            public static readonly bool IsMalicious = true;
            public static readonly bool IsNotMalicious = false;
        }

        private int entityMaxID;
        public int EntityMaxID
        {
            get { return entityMaxID; }
        }

        private int dictionaryMaxID;
        public int DictionaryMaxID
        {
            get { return dictionaryMaxID; }
        }

        private int entityNameMaxLength;
        public int EntityNameMaxLength
        {
            get { return entityNameMaxLength; }
        }

        private int entityDescriptionMaxLength;
        public int EntityDescriptionMaxLength
        {
            get { return entityDescriptionMaxLength; }
        }

        public MaliciousCheck(int entityMaxID, int dictionaryMaxID, int entityNameMaxLength, int entityDescriptionMaxLength)
        {
            this.entityMaxID = entityMaxID;
            this.dictionaryMaxID = dictionaryMaxID;
            this.entityNameMaxLength = entityNameMaxLength;
            this.entityDescriptionMaxLength = entityDescriptionMaxLength;
        }

        public bool IsNotID(int id)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            if (id > 0)
            {
                isMalicious = MaliciousState.IsNotMalicious;
            }

            return isMalicious;
        }                        

        public bool IsNotDictionaryID(int dictionaryID)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            if (!IsNotID(dictionaryID) && (dictionaryID <= dictionaryMaxID))
            {
                isMalicious = false;
            }

            return isMalicious;
        }

        public bool IsSQLInjection(string input)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            string[] sqlCheckList = {
                    "--",
                    ";--",
                    ";",
                    "/*",
                    "*/",
                    "@@",
                    "@",
                    "char",
                    "nchar",
                    "varchar",
                    "nvarchar",
                    "alter",
                    "begin",
                    "cast",
                    "create",
                    "cursor",
                    "declare",
                    "delete",
                    "drop",
                    "end",
                    "exec",
                    "execute",
                    "fetch",
                    "insert",
                    "kill",
                    "select",
                    "sys",
                    "sysobjects",
                    "syscolumns",
                    "table",
                    "update"
            };

            string checkString = input.Replace("'", "''");

            for (int i = 0; i <= sqlCheckList.Length - 1; i++)
            {
                if ((checkString.IndexOf(sqlCheckList[i], StringComparison.OrdinalIgnoreCase) < 0))
                {
                    isMalicious = MaliciousState.IsNotMalicious;
                }
            }

            return isMalicious;
        }

        public bool IsHTMLInjection(string userInput)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            string[] checkList = {
                    "--",
                    ";--",
                    //";",
                    "/*",
                    "*/",
                    "@@",
                    "@",
                    "char",
                    "nchar",
                    "varchar",
                    "nvarchar",
                    "alter",
                    "begin",
                    "cast",
                    "create",
                    "cursor",
                    "declare",
                    "delete",
                    "drop",
                    "end",
                    "exec",
                    "execute",
                    "fetch",
                    "insert",
                    "kill",
                    "select",
                    //"sys",
                    "sysobjects",
                    "syscolumns",
                    //"table",
                    "update"
            };

            string CheckString = userInput.Replace("'", "''");

            for (int i = 0; i <= checkList.Length - 1; i++)
            {
                if ((CheckString.IndexOf(checkList[i], StringComparison.OrdinalIgnoreCase) < 0))
                {
                    isMalicious = MaliciousState.IsNotMalicious;
                }
            }

            return isMalicious;
        }

        public bool IsNotEntityName(string name)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            if ((name == null) || (name == String.Empty))
            {
                return MaliciousState.IsNotMalicious;
            }

            if (name.Length <= EntityNameMaxLength)
            {
                if (!IsSQLInjection(name))
                {
                    isMalicious = MaliciousState.IsNotMalicious;
                }
            }

            return isMalicious;
        }

        public bool IsNotEntityDescription(string description)
        {
            bool isMalicious = MaliciousState.IsMalicious;

            if ((description == null) || (description == String.Empty))
            {
                return MaliciousState.IsNotMalicious;
            }

            if (description.Length <= entityDescriptionMaxLength)
            {
                if (!IsSQLInjection(description))
                {
                    isMalicious = MaliciousState.IsNotMalicious;
                }
            }

            return isMalicious;
        }

    }
}