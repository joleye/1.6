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
        /// id��
        /// </summary>
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        /// <summary>
        /// ����ID
        /// </summary>
        public int classId
        {
            get { return j_classId; }
            set { j_classId = value; }
        }

        /// <summary>
        /// ����ԱID
        /// </summary>
        public int adminId
        {
            get { return j_adminId; }
            set { j_adminId = value; }
        }

        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public string ArticleTitle
        {
            get { return j_ArticleTitle; }
            set { j_ArticleTitle = value; }
        }

        /// <summary>
        /// ��Ѷ����
        /// </summary>
        public string content
        {
            get { return j_content; }
            set { j_content = value; }
        }

        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime createDate
        {
            get { return j_createDate; }
            set { j_createDate = value; }
        }

        /// <summary>
        /// �޸�ʱ��
        /// </summary>
        public DateTime UpdateDate
        {
            get { return j_UpdateDate; }
            set { j_UpdateDate = value; }
        }

        /// <summary>
        /// �����
        /// </summary>
        public int HitNum
        {
            get { return j_HitNum; }
            set { j_HitNum = value; }
        }

        /// <summary>
        /// ��ҳͼƬ
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
