using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JoleYe.Dal;
using JoleYe.Model;
using JoleYe.Bll;

namespace JoleYe.Admin
{
    public partial class Admin_form : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = 0;
            gnum(ref id,"id");
            if (!IsPostBack)
            {
                MemberDal mb = new MemberDal();
                MemberInfo info = new MemberInfo();
                info = mb.view(id);
                username.Value = info.username;
                truename.Value = info.truename;
                birth.Value = info.birth;
                if (info.sex)
                    sex1.Checked = true;
                else
                    sex2.Checked = true;

                email.Value = info.email;
                telphone.Value = info.telphone;
                mobile.Value = info.mobile;
                qq.Value = info.qq;
                address.Value = info.address;
                nickname.Value = info.nickname;
            }

        }
        protected void btn_ServerClick(object sender, EventArgs e)
        {
            int id = 0;
            gnum(ref id, "id");
            MemberInfo info = new MemberInfo();
            info.username = pform("username");
            info.password = md5(pform("pwd"));
            if (pform("sex") == "1")
                info.sex = true;
            else
                info.sex = false;

            info.truename = pform("truename");
            info.email = pform("email");
            info.telphone = pform("telphone");
            info.mobile = pform("mobile");
            info.qq = pform("qq");
            info.birth = pform("birth");

            info.address = pform("address");
            info.nickname = pform("nickname");
            MemberDal mb = new MemberDal();
            mb.edit(info, id);
            showMessage("修改成功");
        }
}
}