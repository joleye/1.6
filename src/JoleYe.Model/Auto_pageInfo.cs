using System;
namespace JoleYe.Model
{
    public class Auto_pageInfo
    {
        private int j_id;
        private string j_page_name;
        private string j_setting;
        private string j_content;
        //id
        public int id
        {
            get { return j_id; }
            set { j_id = value; }
        }

        //page_name
        public string page_name
        {
            get { return j_page_name; }
            set { j_page_name = value; }
        }

        //setting
        public string setting
        {
            get { return j_setting; }
            set { j_setting = value; }
        }

        //content
        public string content
        {
            get { return j_content; }
            set { j_content = value; }
        }

    }
}
