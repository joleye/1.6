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
using JoleYe.Model;
using JoleYe.Dal;
using System.Text;

namespace JoleYe.Admin
{
    public partial class photoAdd : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_ServerClick(object sender, EventArgs e)
        {
            Img img = new Img();
            img.savePathName = "files";
            string path = img.saveImage("");
            if (img.error == "")
            {
                AlbumInfo info = new AlbumInfo();
                info.album_name = path;
                info.imgUrl = path;
                info.showHome = false;
                info.linkUrl = "";

                AlbumDal al = new AlbumDal();
                int id = al.add(info);
                StringBuilder sb = new StringBuilder();
                sb.Append("<span style='font-size:12px;BACKGROUND: #F7F7F7;'>上传成功！");
                sb.Append("<a href=\"javascript:;\" onClick=\"parent.addContent(iname);\">插入</a> ");
                sb.Append("<a href=\"javascript:history.back();\">继续上传</a></span>");
                sb.Append("<script language=\"JavaScript\">");
                sb.Append("var iname=\""+gform("up_name")+"\";");
                sb.Append("parent.document.getElementById(iname).value=\"" + path + "\";</script>;");
                die(sb.ToString());
            }
            else
            {
                Response.Write(img.error+" <a href=\"javascript:history.back()\">返回</a>");
                Response.End();
            }
        }
}
}