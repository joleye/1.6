using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;

namespace JoleYe.Web
{
    public class Intro : Frontend
    {
        public string key;
        public Intro()
        {
            pagetitle = "产品介绍";
            flg_nav = "intro";

            key = gform("key");
            if (key == "")
                key = "intro";
            

           try
           {
               string key1 = config_site[key].ToString();
           }
            catch
           {
               HttpContext.Current.Response.Write("key错误，没有该项目");
               HttpContext.Current.Response.End();
           }

            flg_nav = "intro";

        }
    }
}
