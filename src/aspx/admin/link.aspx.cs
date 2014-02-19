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
using JoleYe.Model;

namespace JoleYe.Admin
{
    public partial class link : AdminPage
    {
        public string act;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            act = gform("act");
            if(isAt("id"))
            id = getId("id");

            if (!IsPostBack)
            {
                if (act == "" || act == null)
                {
                    setBind();
                }

                if (act == "edit")
                {
                    LinksDal lk = new LinksDal();
                    LinkInfo info = lk.read(id);
                    linkName.Value = info.linkName;
                    linkUrl.Value = info.linkUrl;
                    imgUrl.Value = info.imgUrl;

                    if(info.imgUrl!="")
                    view_img.InnerHtml = "<a href=\""+info.imgUrl+"\" target=\"_blank\">查看</a>";
                }
            }
        }

        protected void setBind()
        { 
            DataSet ds = getData("select * from JOLE_link");
            detail.DataSource = ds;
            detail.DataBind(); 
        }

        protected void DataGrid_Del(object sender, DataGridCommandEventArgs e)
        {
            id = (int)detail.DataKeys[e.Item.ItemIndex];

            LinksDal li = new LinksDal();
            li.del(id);

            setBind();

        }

        protected void MyDataGrid_Page(object sender, DataGridPageChangedEventArgs e)
        {
            int startIndex;
            startIndex = detail.CurrentPageIndex * detail.PageSize;
            detail.CurrentPageIndex = e.NewPageIndex;
            setBind();
        }

        protected void btn_ServerClick(object sender, EventArgs e)
        {
            LinksDal li = new LinksDal();
            LinkInfo info = new LinkInfo();
            info.linkName = linkName.Value;
            info.linkUrl = linkUrl.Value;

            Img img = new Img();
            img.savePathName = "links";

            string delimg = pform("delimg");
            if (delimg == "1")
            {
                img.dropimg(imgUrl.Value);
                info.imgUrl = "";
            }
            else
            {
                info.imgUrl = img.saveImage(imgUrl.Value);
                if (info.imgUrl == "1")
                {
                    img.dropimg(imgUrl.Value);
                }
            }

            

            if (img.error != "")
                showMessage(img.error);

            if (id.ToString() == "0")
            {
                li.addnew(info);
                showMessage("添加成功");
            }
            else
            {
                info.id = id;
                li.edit(info);
                showMessage("修改成功");
                Response.End();
            }
            
        }
}
}