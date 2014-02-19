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
using JoleYe.Conf;

public partial class admin_global_site_config : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            WebConf conf = new WebConf();
            string webstate = conf.getAttr("webstate", "state");
            for (int i = 0; i < site_state.Items.Count; i++)
            {
                if (site_state.Items[i].Value == webstate)
                {
                    site_state.Items[i].Selected = true;
                    break;
                }
            }
            site_state_text.Value = conf.getVal("webstate");
            webhost.Value = conf.getVal("webhost");
            if (webstate == "0")
                site_state_text.Attributes.Add("style", "display:none;");
            else
                site_state_text.Attributes.Add("style", "display:black;");

            string allowreg = conf.getVal("userreg");
            if (allowreg == "0")
                allow_reg.Checked = true;
            else
                notallow_reg.Checked = true;
            if (conf.getVal("adminlogincode") == "0")
            {
                adminlogincode.Items[0].Selected = true;
            }
            else
            {
                adminlogincode.Items[1].Selected = true;
            }
        }

    }
    protected void save_btn_ServerClick(object sender, EventArgs e)
    {
        WebConf conf = new WebConf();
        conf.setAttr("webstate","state",site_state.Value);
        conf.setVal("webstate", site_state_text.Value);

        conf.setVal("adminlogincode", adminlogincode.Value) ;
        conf.setVal("webhost",webhost.Value);

        string allowreg = "1";
        if(allow_reg.Checked)
            allowreg = "0";

        conf.setVal("userreg", allowreg);

        showMessage("设置成功");
    }
}
