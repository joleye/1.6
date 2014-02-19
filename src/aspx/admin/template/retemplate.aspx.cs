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

namespace JoleYe.Admin
{
    public partial class Retemplate : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = getId("id");

            TemplateAdmin ta = new TemplateAdmin(id);
            showMessage("操作成功");

        }
    }
}
