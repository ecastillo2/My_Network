using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNetwork.Models
{
    public class User
    {
        private static string _UserID;
        public string UserID
        {
            get { return _UserID; }
            set { _UserID = value; }
        }
       
    }
}