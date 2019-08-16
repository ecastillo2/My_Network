using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNetwork.Models
{
    public class ContactGroup
    {
        private static string _CompanyAddress;
        public string CompanyAddress
        {
            get { return _CompanyAddress; }
            set { _CompanyAddress = value; }
        }

        private static List<string> _Group = new List<string>();
        public List<string> Group
        {
            get { return _Group; }
            set { _Group = value; }
        }

    }
}