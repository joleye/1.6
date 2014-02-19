using System;

/// <summary>
/// ProductTypeInfo 的摘要说明
/// </summary>
/// 
namespace JoleYe.Model
{
    public class ProductTypeInfo
    {
        private int j_id;
        private string j_typeName;
        private int j_orderId;
        private string j_imgUrl;
        private int j_parentId;
        private string j_content;

        /// <summary>
        /// 类型ID
        /// </summary>
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        /// <summary>
        /// 类型名称
        /// </summary>
        public string typeName
        {
            get { return j_typeName; }
            set { j_typeName = value; }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string imgUrl
        {
            set { j_imgUrl = value; }
            get { return j_imgUrl; }
        }

        /// <summary>
        /// 上一级
        /// </summary>
        public int parentId
        {
            set { j_parentId = value; }
            get { return j_parentId; }
        }

        public int orderId
        {
            set { j_orderId = value; }
            get { return j_orderId; }
        }

        public string content
        {
            set { j_content = value; }
            get { return j_content; }
        }

    }
}