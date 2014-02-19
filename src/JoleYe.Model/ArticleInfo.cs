using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class ArticleInfo
    {
        private int j_id;
        private int j_classId;
        private int j_adminId;
        private string j_ArticleTitle;
        private string j_content;
        private DateTime j_createDate;
        private DateTime j_UpdateDate;
        private int j_HitNum;
        private string j_DefaultImgUrl;
        private string j_imgUrl;
        private string j_className;

        /// <summary>
        /// id号
        /// </summary>
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        /// <summary>
        /// 类型ID
        /// </summary>
        public int classId
        {
            get { return j_classId; }
            set { j_classId = value; }
        }

        /// <summary>
        /// 管理员ID
        /// </summary>
        public int adminId
        {
            get { return j_adminId; }
            set { j_adminId = value; }
        }

        /// <summary>
        /// 资讯标题
        /// </summary>
        public string ArticleTitle
        {
            get { return j_ArticleTitle; }
            set { j_ArticleTitle = value; }
        }

        /// <summary>
        /// 资讯内容
        /// </summary>
        public string content
        {
            get { return j_content; }
            set { j_content = value; }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime createDate
        {
            get { return j_createDate; }
            set { j_createDate = value; }
        }

        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime UpdateDate
        {
            get { return j_UpdateDate; }
            set { j_UpdateDate = value; }
        }

        /// <summary>
        /// 点击数
        /// </summary>
        public int HitNum
        {
            get { return j_HitNum; }
            set { j_HitNum = value; }
        }

        /// <summary>
        /// 首页图片
        /// </summary>
        public string DefaultImgUrl
        {
            get { return j_DefaultImgUrl; }
            set { j_DefaultImgUrl = value; }
        }

        public string imgUrl
        {
            get { return j_imgUrl; }
            set { j_imgUrl = value; }
        }

        public string className
        {
            get { return j_className; }
            set { j_className = value; }
        }
    }
}
