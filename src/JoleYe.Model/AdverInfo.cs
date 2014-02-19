using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class AdverInfo
    {
        private string j_imgurl;
        private string j_linkurl;

        public string imgurl
        {
            get { return j_imgurl; }
            set { j_imgurl = value; }
        }

        public string linkurl
        {
            get { return j_linkurl; }
            set { j_linkurl = value; }
        }
    }
}
