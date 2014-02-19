using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JoleYe.Web
{
    public class Appliprog : Frontend
    {
        public string key;
        public Appliprog()
        {
            pagetitle = "应用与方案";
            flg_nav = "appliprog";

            key = gform("key");
            if (key == "")
                key = "appliserv";


            try
            {
                string key1 = config_site[key].ToString();
            }
            catch
            {
                HttpContext.Current.Response.Write("key错误，没有该项目");
                HttpContext.Current.Response.End();
            }

        }
    }
}
