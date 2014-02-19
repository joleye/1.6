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
using JoleYe;
using JoleYe.Dal;
using JoleYe.Model;

public partial class admin_adver_admin_edit : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_ServerClick(object sender, EventArgs e)
    {
        Img img = new Img();
        int id = 0;
        gnum(ref id, "id");
        img.savePathName = "adver";
        string path = img.saveImage("");
        if (img.error == "")
        {
            AdverInfo info = new AdverInfo();
            info.imgurl = path;
            info.linkurl = linkUrl.Value;

            AdverDal al = new AdverDal();
            al.edit(info,id);
            showMessage("保存成功");
        }
        else
        {
            showMessage(img.error);
        }
    }
}
