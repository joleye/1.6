using System;
using System.Data;
using System.Web.UI;




//添加和管理用户信息
//auter JOLE
//date 2009-11-8

namespace JoleYe.Admin
{
    public partial class UserForm : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string act = Request.QueryString["act"].ToString();
            if (act == "repwd")
            {
                if(!IsPostBack)
                repwdBind();
            }
        }
        protected void userName_Click(object sender, EventArgs e)
        {
            if (adminName.Text != "" && pwd.Text != "")
            {
                if (pwd.Text == repwd.Text)
                {
                    bindAddUser(adminName.Text,pwd.Text);
                }
                else
                {
                    ERROR_MESSAGE.Text = " 两次填写的密码不同。";
                }
            }
            else
            {
                ERROR_MESSAGE.Text = " 错误，用户名和密码是必填项";
            }

        }

        /*
         添加用户
         */
        private void bindAddUser(string adminName,string pwd)
        {
            AdminUser sa = new AdminUser();

            if (btn.Text == "添加")
            {
                if (sa.checkUserdone(adminName))
                {
                    sa.adduser(adminName, pwd);
                    showMessage("添加成功", "edit_user_info.aspx");
                }
                else
                    showMessage("该用户已经存在，请使用其他用户名。", Request.UrlReferrer.ToString());
            }
            else
            {
                sa.UpdatePwd(adminName,pwd);
                showMessage("修改成功", Request.UrlReferrer.ToString());
            }
        }




        //修改密码

        private void repwdBind()
        {
            int id = Int32.Parse(Request.QueryString["id"]);
            AdminUser sd = new AdminUser(); 
            adminName.Text = sd.getUser(id);
            btn.Text = "修改";
            adminName.ReadOnly = true;

        }

    }
}
