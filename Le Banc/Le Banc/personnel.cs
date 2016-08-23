using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Banc
{
    public class personnel
    {
        
        public int idPersonnel { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string address { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public int access { get; set; }

        //public override string ToString()
        //{
        //    return idPersonnel.ToString() + " " + userName;
        //}

        public override string ToString()
        {
            return idPersonnel.ToString() + " " + firstName + " " + lastName;
        }

    }
}