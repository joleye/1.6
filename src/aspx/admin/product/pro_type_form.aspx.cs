using System;
using System.Data;
using System.Configuration;
using JoleYe.Dal;
using JoleYe.Model;

namespace JoleYe.Admin
{
    public partial class ProductTypeForm : AdminPage
    {
        string action;
        protected void Page_Load(object sender, EventArgs e)
        {
            action = gform("act");
            if (!IsPostBack)
            {
                if (action == "edit")
                {
                    editBind();
                }

                int id = 0;
                gnum(ref id, "id");
                if (id > 0)
                {
                    manage_type.HRef = "pro_type.aspx?act=viewchild&id=" + id.ToString();
                }
            }

        }

        private void editBind()
        {
            ProductTypeDal da = new ProductTypeDal();
            ProductTypeInfo tpinfo = da.read(getId("id"));
            ProductTypeName.Value = tpinfo.typeName;
            imgUrl.Value = tpinfo.imgUrl;
            orderId.Value = tpinfo.orderId.ToString();
            content.Value = tpinfo.content;
            if (tpinfo.imgUrl != "")
                view_img.InnerHtml = "<a href=\"" + tpinfo.imgUrl + "\" target=\"_blank\">查看</a>";

        }
        protected void save_ServerClick(object sender, EventArgs e)
        {
            string TypeName = ProductTypeName.Value.ToString();
            string err;
            if (TypeName != "")
            {
                ProductTypeInfo info = new ProductTypeInfo();
                ProductTypeDal ad = new ProductTypeDal();

                Img img = new Img();
                img.savePathName = "producttype";
                if (action == "edit")
                {
                    string delimg = pform("delimg");

                    if (delimg == "1")
                    {
                        img.dropimg(imgUrl.Value);
                        info.imgUrl = "";
                    }
                    else
                    {
                        info.imgUrl = img.saveImage(imgUrl.Value);
                    }

                    if (img.error != "")
                        showMessage(img.error);

                    info.typeName = ProductTypeName.Value;
                    info.orderId = int.Parse(orderId.Value);
                    info.id = getId("id");
                    info.content = pform("content");

                    ad.Update(info);
                    err = "修改成功";

                }
                else
                {
                    info.typeName = TypeName;
                    info.orderId = int.Parse(orderId.Value);
                    info.imgUrl = img.saveImage("");
                    info.content = pform("content");

                    if (img.error != "")
                        showMessage(img.error);

                    int id = 0;
                    gnum(ref id, "id");

                    info.parentId = id;
                    ad.AddType(info);
                    err = "添加成功";
                }
                showMessage(err, "pro_type.aspx");
            }
            else
            {
                labelErr.Text = "<font color=red>不能为空</font>";
            }
        }
    }
}