using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class TemplateTypeInfo
    {
        private int j_id;
        private string j_templateName;

        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        public string templateName
        {
            get { return j_templateName; }
            set { j_templateName = value; }
        }
    }
}
