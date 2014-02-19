using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Bll;
using System.Web;

namespace JoleYe.Web
{
    public class Member : Frontend
    {
        public Member()
        {
            if (gform("app") == "loginout")
            {
                PassportBll bll = new PassportBll();
                if (bll.loginout())
                {
                    string backurl = gform("backurl");
                    if (!string.IsNullOrEmpty(backurl))
                        HttpContext.Current.Response.Redirect(backurl);
                }
            }
        }
    }
}
