using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Bll;
using JoleYe.Model;
using System.Web;

namespace JoleYe.Web
{
    public class MemberAdmin : Frontend
    {
        public MemberInfo minfo;
        public MemberAdmin()
        {
            PassportBll p = new PassportBll();
            minfo = p.get();

            string backurl = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            if (HttpContext.Current.Request.QueryString != null)
            {
                backurl += "?"+HttpContext.Current.Request.QueryString.ToString();
                backurl = HttpContext.Current.Server.UrlEncode(backurl);
            }
            if (string.IsNullOrEmpty(minfo.username))
                System.Web.HttpContext.Current.Response.Redirect("/login.aspx?backurl="+backurl);
        }
    }
}
