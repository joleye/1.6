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

namespace JoleYe.Admin
{
    public partial class album_photo_add : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_ServerClick(object sender, EventArgs e)
        {
            Img img = new Img();
            img.savePathName = "album";
            string path = img.saveImage("");
            if (img.error == "")
            {
                AlbumInfo info = new AlbumInfo();
                info.album_name = path;
                info.imgUrl = path;
                if (showHome.Checked)
                    info.showHome = true;
                else
                    info.showHome = false;
                info.linkUrl = linkUrl.Value;

                AlbumDal al = new AlbumDal();
                int id = al.add(info);
                showMessage("上传成功<br/>图片地址：<a href=\"" + path + "\" target=\"_blank\">" + path + "</a>");
            }
            else
            {
                showMessage(img.error);
            }
            
        }
}
}