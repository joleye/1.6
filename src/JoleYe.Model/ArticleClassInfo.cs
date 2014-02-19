using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Model
{
    public class ArticleClassInfo
    {
        private int j_Id;
        private string j_ClassName;
        private int j_pid;
        private int j_orderId;

        public int id
        {
            get { return j_Id; }
            set { j_Id = value; }
        }

        public string ClassName
        {
            get { return j_ClassName; }
            set { j_ClassName = value; }
        }

        public int pid
        {
            get { return j_pid; }
            set { j_pid = value; }
        }

        public int orderId
        {
            get { return j_orderId; }
            set { j_orderId = value; }
        }
    }
}
