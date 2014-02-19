using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Dal;
using JoleYe.Bll;
using System.Web;

namespace JoleYe.Web
{
    public class Userinfo : MemberAdmin
    {
        
        public Userinfo()
        {
            
            if (ISPOST)
            {
                MemberInfo info = new MemberInfo();
                info.username = minfo.username;
                info.password = minfo.password;
                if (pform("sex") == "1")
                    info.sex = true;
                else
                    info.sex = false;

                info.truename = pform("truename");
                info.email = pform("email");
                info.telphone = pform("telphone");
                info.mobile = pform("mobile");
                info.qq = "123123";//pform("qq");
                info.birth = pform("birth");
                info.ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];

                info.address = pform("address");
                MemberDal pb = new MemberDal();


                pb.edit(info, minfo.id);
                showMessage("ÐÞ¸Ä³É¹¦");
            }
            
        }
    }
}
