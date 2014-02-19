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
                showMessage("ע�Ṧ���Ѿ��ر�");
            }

            if (ISPOST)
            {
                MemberInfo info = new MemberInfo();
                info.username = pform("username");
                if (info.username == "")
                {
                    showMessage("�û�������Ϊ��","javascript:history.back();");
                    return;
                }
                info.password = pform("pwd");
                if (info.password != pform("repwd"))
                {
                    showMessage("������������벻ͬ", "javascript:history.back();");
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
                    showMessage("email����Ϊ��", "javascript:history.back();");
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
                    die("<script type=\"text/javascript\">alert('ע��ɹ�');location.href='" + url + "'</script>");
                }
                else
                    die("<script type=\"text/javascript\">alert('ע��ʧ��');history.back();</script>");
            }
        }
    }
}
