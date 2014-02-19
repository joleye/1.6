using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace JoleYe.Web
{
    public class Service : Frontend
    {
        public string key;
        public Service()
        {
            pagetitle = "服务与支持";
            flg_nav = "service";

            key = gform("key");
            if (key == "")
                key = "service";


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
