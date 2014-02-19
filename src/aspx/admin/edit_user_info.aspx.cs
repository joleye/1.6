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
using System.Data.OleDb;
using JoleYe.Data;

namespace JoleYe.Admin
{

    public partial class user_info : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // string action = "";
            
            string action = HttpContext.Current.Request.QueryString["act"];
            if (!IsPostBack)
            {
                setUserInfo();
            }
        }

        private void setUserInfo()
        {
            OleDbDataReader rs1 = Record1("select * from JOLE_adminUser");

            if (rs1.HasRows)
            {
                content.DataSource = rs1;
                content.DataBind();
            }
        
        }


        public void DataGrid_Del(object sender, DataGridCommandEventArgs e)
        {
            int id = (int)content.DataKeys[e.Item.ItemIndex];
            AdminUser sd = new AdminUser();

            if (sd.DelUser(id))
            {
                setUserInfo();
                showMessage("删除成功", Request.UrlReferrer.ToString());
            }
            else
                showMessage("该用户不能删除", Request.UrlReferrer.ToString());
        }
}
}