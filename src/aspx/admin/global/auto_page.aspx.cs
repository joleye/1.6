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

namespace JoleYe.Admin
{
    public partial class Global_Auto_page : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("app");
            Auto_pageDal au = new Auto_pageDal();
            if (app == "drop")
            {
                int id = 0;
                gnum(ref id,"id");
                au.drop(id);
                showMessage("删除成功");
            }
            
            list.DataSource = au.read();
            list.DataBind();
        }
    }
}
