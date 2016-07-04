using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Banc
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string userPassword { get; set; }

        public override string ToString()
        {
            return userID.ToString() + " " + userName;
        }
    }
}