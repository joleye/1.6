using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Bll;
using System.Web;

namespace JoleYe.Web
{
    public class Login: Frontend
    {
        public string err_text;
        public Login()
        {
            string app = gform("app");
            if (!string.IsNullOrEmpty(gform("backurl")))
            {
                setCookie("backurl", gform("backurl"));
            }

            if (app == "loginout")
            {
                PassportBll bll = new PassportBll();
                bll.loginout();
                HttpContext.Current.Response.Redirect(HttpContext.Current.Request.UrlReferrer.ToString());
            }

            if (ISPOST)
            {
                PassportBll bll = new PassportBll();
                if (bll.login(pform("username"), pform("password")))
                {
                    string url = HttpContext.Current.Request.UrlReferrer.ToString();
                    if (!string.IsNullOrEmpty(getCookie("backurl")))
                    {
                        url = getCookie("backurl");
                        setCookie("backurl", "");
                    }
                    die("<script type=\"text/javascript\">alert('登陆成功');location.href='"+url+"'</script>");
                }
                else
                {
                    err_text = "用户名和密码错误";
                }
            }
        }
    }
}
