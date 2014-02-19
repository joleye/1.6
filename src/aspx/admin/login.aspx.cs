using System;
using System.Data;
using System.Web.UI;
using System.Data.OleDb;
using JoleYe.Data;
using JoleYe;
using JoleYe.Conf;

public partial class admin_login : Base
{
    public bool p_adminlogincode;
    protected void Page_Load(object sender, EventArgs e)
    {

        WebConf conf = new WebConf();

        if (conf.getVal("adminlogincode") == "0")
            p_adminlogincode = true;
        else
            p_adminlogincode = false;
        try
        {
            if (Session["joleAdmin"] != null)
            {
                Response.Redirect("webMain.aspx");
            }
            String _do = Request.QueryString["err"];
            if (_do != "")
            {
                
                error.Text = "<font color=red>"+_do+"</font>";
            }


        }
        catch(Exception)
        {
            
        }
    }
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        if (p_adminlogincode)
        {
            
            if (Session["ValidateCode"] != null)
            {
                string codeSess = Session["ValidateCode"].ToString();
                if (code.Text.ToLower() != codeSess.ToLower())
                {
                    error.Text = "<font color=red>验证码错误</font>";
                    return;
                }
            }
        }

        Base sd = new Base();
        OleDbDataReader dr = sd.Record1("select id,username,password from JOLE_adminUser where username = '" + adminName.Text + "' and password = '" + password.Text + "'");
        if (dr.Read())
        {
            error.Text = "登陆成功";

            //Session["joleAdmin"] = dr.GetValue(0);
            //Session["password"] = dr.GetValue(1);
            Response.Cookies["joleAdmin"].Value = dr["username"].ToString();
            Response.Cookies["password"].Value = dr["password"].ToString();
            Response.Cookies["adminId"].Value = dr["id"].ToString();

            dr.Close();
            Response.Redirect("webMain.aspx");
        }
        else
            error.Text = "<font color=red>登陆失败，用户名和密码错误</font>";
        dr.Close();


    }
}
