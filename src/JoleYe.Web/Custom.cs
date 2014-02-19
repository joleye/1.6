using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Web
{
    public class Custom : Frontend
    {
        string key;
        public string custom_title;
        public string custom_content;
        public Custom()
        {
            key = gform("key");
            if (key == "")
                key = "intro";


            try
            {
                custom_content = config_site[key].ToString();
                custom_title = config_title[key].ToString();
            }
            catch
            {
                custom_content = "key错误，没有该项目";
                custom_title = "页面出错了";
            }

            pagetitle = custom_title;
            flg_nav = "custom";
        }
    }
}
