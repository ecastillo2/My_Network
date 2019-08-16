using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyNetwork.Models
{
    public class Image
    {


        private static string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private static string _ImagePath;
        public string ImagePath
        {
            get { return _ImagePath; }
            set { _ImagePath = value; }
        }

        private static string _ImageType;
        public string ImageType
        {
            get { return _ImageType; }
            set { _ImageType = value; }
        }

    }
}