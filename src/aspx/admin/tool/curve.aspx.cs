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
using JoleYe.Object;
using System.Drawing;
using System.Drawing.Imaging;

public partial class aspx_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "Curve.jpg";
        Image1.Visible = false;
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Curve curve2d = new Curve(); //定义一个画图类实例

        curve2d.Title = "马王堆";
        curve2d.Height = 100;
        curve2d.TextColor = Color.Red;
        curve2d.BgColor = Color.White;
        curve2d.TextColor = Color.Red;
        curve2d.Keys = new String[]{"1","2","5"};
        Bitmap bmp = curve2d.CreateImage();
        bmp.Save(Server.MapPath("Curve.jpg"), ImageFormat.Jpeg);

        Image1.Visible = true;

    }
}
