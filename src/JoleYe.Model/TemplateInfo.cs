using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
///  ����TemplateInfo ����
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
        /// ID��
        /// </summary>
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        /// <summary>
        /// ����
        /// </summary>
        public string title
        {
            get { return j_title; }
            set { j_title = value; }
        }

        /// <summary>
        /// ʵ��·��
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
        /// ģ��·��
        /// </summary>
        public string templatePath
        {
            get { return j_templatePath; }
            set { j_templatePath = value; }
        }

        /// <summary>
        /// ģ������
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
