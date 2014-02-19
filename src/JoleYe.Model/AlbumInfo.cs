using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class AlbumInfo
    {
        private int j_id;
        private string j_album_name;
        private string j_imgUrl;
        private string j_postDate;
        private string j_linkUrl;
        private bool j_showHome;

        public int id
        {
            set { j_id = value; }
            get { return j_id; }
        }

        /// <summary>
        /// 标题说明
        /// </summary>
        public string album_name
        {
            set { j_album_name = value; }
            get { return j_album_name; }
        }

        /// <summary>
        /// 地址
        /// </summary>
        public string imgUrl
        {
            set { j_imgUrl = value; }
            get { return j_imgUrl; }
        }

        /// <summary>
        /// 上传时间
        /// </summary>
        public string postDate
        {
            set { j_postDate = value; }
            get { return j_postDate; }
        }

        public string linkUrl
        {
            get { return j_linkUrl; }
            set { j_linkUrl = value; }
        }

        public bool showHome
        {
            get { return j_showHome; }
            set { j_showHome = value; }
        }

    }
}
