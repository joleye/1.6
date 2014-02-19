using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.View
{
    public class FileUrl
    {
        private string _url;
        public FileUrl(string url)
        {

            _url = url;
        }

        public string name
        {
            get { return _url; }
        }
    }
}
