using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using JoleYe.Model;
using JoleYe.Dal;

namespace JoleYe.Web
{
    public class Join : Frontend
    {
        public Join()
        {
            pagetitle = "代理加盟";
            flg_nav = "join";
            if (!IsPostBack)
            {
                if (HttpContext.Current.Request.HttpMethod.ToString() == "POST")
                {
                    JmInfo info = new JmInfo();
                    info.uname = pform("uname");
                    info.age = pform("age");
                    info.address = pform("address");
                    info.telphone = pform("telphone");
                    info.fax = pform("fax");
                    info.company = pform("company");
                    info.comaddress = pform("comaddress");
                    info.zijin = pform("zijin");
                    info.content = pform("content");

                    JmDal j = new JmDal();
                    j.addnew(info);
                    HttpContext.Current.Response.Write("<script type=\"text/javascript\">alert('提交成功');location.href='join.aspx';</script>");
                    HttpContext.Current.Response.End();

                }
            }
        }
    }
}
