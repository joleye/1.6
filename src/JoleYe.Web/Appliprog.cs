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
            pagetitle = "Ӧ���뷽��";
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
                HttpContext.Current.Response.Write("key����û�и���Ŀ");
                HttpContext.Current.Response.End();
            }

        }
    }
}
