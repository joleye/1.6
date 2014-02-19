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
using System.Collections.Generic;
using JoleYe.Dal;
using JoleYe;
using JoleYe.Admin;

public partial class admin_tool_make_thumbs : AdminPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void create_auto_thumbs_Click(object sender, EventArgs e)
    {
        List<ProductInfo> list = new List<ProductInfo>();
        ProductDal dal = new ProductDal();

        list = dal.view_list();

        foreach (ProductInfo info in list)
        {
            if (dal.set_thumbs_img(info.Id, 80))
            {
                dal.set_thumbs_img(info.Id, 279, "small");
                Response.Write("成功 <a target=\"_blank\" href=\"" + cimg(info.productImgUrl, "80") + "\">" + info.productImgUrl + "</a><br/>");
            }
            else
                Response.Write("<font color=red>失败</font> " + info.productImgUrl + "<br/>");
        }
    }
    protected void create_279_thumbs_Click(object sender, EventArgs e)
    {
        List<ProductInfo> list = new List<ProductInfo>();
        ProductDal dal = new ProductDal();

        list = dal.view_list();

        foreach (ProductInfo info in list)
        {
            if (dal.set_thumbs_img(info.Id, 279, "small"))
            {
                Response.Write("成功 <a target=\"_blank\" href=\"" + cimg(info.productImgUrl, "small") + "\">" + cimg(info.productImgUrl, "small") + "</a><br/>");
            }
            else
                Response.Write("<font color=red>失败</font> " + info.productImgUrl + "<br/>");
        }
    }
}
