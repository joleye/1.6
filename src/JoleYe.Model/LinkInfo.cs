using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///  基本LinkInfo 类型
/// </summary> 

namespace JoleYe.Model
{
    public class LinkInfo
    {
        private string j_linkName, j_linkUrl,j_imgUrl;
        private int j_id;

        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        public string linkName
        {
            get { return j_linkName; }
            set { j_linkName = value; }
        }

        public string linkUrl
        {
            get { return j_linkUrl; }
            set { j_linkUrl = value; }
        }

        public string imgUrl
        {
            get { return j_imgUrl; }
            set { j_imgUrl = value; }
        }
    }
}
