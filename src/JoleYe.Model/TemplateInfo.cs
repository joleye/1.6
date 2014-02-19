using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///  基本TemplateInfo 类型
/// </summary> 

namespace JoleYe.Model
{
    public class TemplateInfo
    {
        private int j_id;
        private string j_title;
        private string j_filePath;
        private string j_activePath;
        private string j_templatePath;
        private string j_content;
        private int j_typeId;

        /// <summary>
        /// ID号
        /// </summary>
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        /// <summary>
        /// 标题
        /// </summary>
        public string title
        {
            get { return j_title; }
            set { j_title = value; }
        }

        /// <summary>
        /// 实际路径
        /// </summary>
        public string filePath
        {
            get { return j_filePath; }
            set { j_filePath = value; }
        }

        public string activePath
        {
            get { return j_activePath; }
            set { j_activePath = value; }
        }

        /// <summary>
        /// 模板路径
        /// </summary>
        public string templatePath
        {
            get { return j_templatePath; }
            set { j_templatePath = value; }
        }

        /// <summary>
        /// 模板内容
        /// </summary>
        public string content
        {
            get { return j_content; }
            set { j_content = value; }
        }

        public int typeId
        {
            get { return j_typeId; }
            set { j_typeId = value; }
        }
    }
}
