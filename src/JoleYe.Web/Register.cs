using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Dal;
using JoleYe.Bll;
using System.Web;
using JoleYe.Conf;

namespace JoleYe.Web
{
    public class Register : Frontend
    {

        public Register()
        {
            WebConf conf = new WebConf();
            if (conf.getVal("userreg") == "1")
            {
                showMessage("注册功能已经关闭");
            }

            if (ISPOST)
            {
                MemberInfo info = new MemberInfo();
                info.username = pform("username");
                if (info.username == "")
                {
                    showMessage("用户名不能为空","javascript:history.back();");
                    return;
                }
                info.password = pform("pwd");
                if (info.password != pform("repwd"))
                {
                    showMessage("两次输入的密码不同", "javascript:history.back();");
                    return;
                }
                if (pform("sex") == "1")
                    info.sex = true;
                else
                    info.sex = false;

                info.truename = pform("truename");
                info.email = pform("email");
                if (info.email == "")
                {
                    showMessage("email不能为空", "javascript:history.back();");
                    return;
                }
                info.telphone = pform("telphone");
                info.mobile = pform("mobile");
                info.qq = pform("qq");
                info.birth = pform("birth");
                info.ip = "ip";

                info.address = pform("address");
                PassportBll pb = new PassportBll();
                if (pb.register(info))
                {
                    string url = HttpContext.Current.Request.UrlReferrer.ToString();
                    die("<script type=\"text/javascript\">alert('注册成功');location.href='" + url + "'</script>");
                }
                else
                    die("<script type=\"text/javascript\">alert('注册失败');history.back();</script>");
            }
        }
    }
}
