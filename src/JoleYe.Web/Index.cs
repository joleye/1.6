using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using System.Collections;
using JoleYe.Bll;

namespace JoleYe.Web
{
    public class Index : Frontend
    {
        public Hashtable auto_page;
        public Index()
        {
            auto_page = new Hashtable();
            init_page();
            pagetitle = "Ê×Ò³";
            flg_nav = "index";
        }

        private void init_page()
        {
            Auto_pageBll info = new Auto_pageBll(2,"auto_text");
            auto_page.Add("width",info.get("width"));
            auto_page.Add("height", info.get("height"));
            auto_page.Add("top", info.get("top"));
            auto_page.Add("left", info.get("left"));
            auto_page.Add("content", info.getcont);

            Auto_pageBll info1 = new Auto_pageBll(8, "auto_pro_scroll");
            auto_page.Add("auto_pro_scroll",info1.get("display"));
        }

        public DataTable get_news()
        {
            DataSet dt = find("article",4,"classId=59","id desc");
            return dt.Tables[0];
        }

        public DataTable get_download()
        {
            DataSet dt = find("article", 20, "classId=66", "id desc");
            return dt.Tables[0];
        }

        public DataTable get_product()
        {
            DataSet dt = find("product", 10, "showHome<>0", "showId,id desc,produceImgUrl desc");
            return dt.Tables[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable info_box(int num, int typeid)
        {
            DataSet dt = find("article", num, "classid="+typeid.ToString(), "id desc");
            return dt.Tables[0];
        }

        public DataTable get_home(int size)
        {
            DataSet dt = find("article", size, "", "id desc");
            return dt.Tables[0];
        }

        public DataTable get_home()
        {
            return get_home(15);
        }



    }
}
