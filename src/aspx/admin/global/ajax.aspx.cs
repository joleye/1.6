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
    public partial class Global_ajax : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string table = gform("table");
            string field = gform("field");
            int id = 0;
            gnum(ref id, "id");

            string val = gform("val");
            auto_edit(table, id, field, val);

            //if (!IsPostBack)
            //{
            //    switch (app)
            //    {
            //        case "product":
            //            string val = gform("val");
            //            if(act=="proname")
            //            product_edit(id, val);
            //        if (act == "order")
            //            product_order(id, val);
            //            break;
            //        default:
            //            break;

            //    }
            //}
        }

        private void product_edit(int id, string productName)
        {
            Ajax_edit ae = new Ajax_edit("product");
            ae.auto_edit(id.ToString(), "productName", productName);
            Response.Write("ok");
            Response.End();
        }

        private void auto_edit(string tablename,int id, string field, string val)
        {
            //die(Request.QueryString.ToString());
            Ajax_edit ae = new Ajax_edit(tablename);
            ae.auto_edit(id.ToString(), field, val);
            Response.Write("ok");
            Response.End();
        }

        private void product_order(int id, string showId)
        { 
        
        }
    }
}