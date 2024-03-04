using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace ClientInputSecurity.Models.Painter
{
    public class Painter
    {
		private int id;
		public int ID
        {
			get { return id; }
		}

        private string name;
        public string Name
        {
            get { return name; }
        }

        private int movementID;
        public int MovementID
        {
            get { return movementID; }
        }

        private string internetInfoLink;
        public string InternetInfoLink
        {
            get { return internetInfoLink; }
        }

        private string myComments;
        public string MyComments
        {
            get { return myComments; }
        }

        public Painter(int id, string name, int movementID, string internetInfoLink, string myComments) 
        { 
            this.id = id;
            this.name = name;
            this.movementID = movementID;
            this.internetInfoLink = internetInfoLink;
            this.myComments = myComments;
        }
    }
}