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
using JoleYe.Admin;
using JoleYe.Dal;

public partial class admin_adver_admin_main : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        AdverDal dal = new AdverDal();
        viewlist.DataSource = dal.view_list();
        viewlist.DataBind();
    }
}
