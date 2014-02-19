using System;
using System.Web;
using System.Web.UI;
using JoleYe.Data;

namespace JoleYe.Admin
{
    public partial class intro : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                int id = Int32.Parse(Request.QueryString["intId"]);
                //string thisTitle;
                webtitle.Text = getTitle(id);
                content.Value = getSite(id);
            }
        }

        protected void saveBtn_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int intId = Int32.Parse(Request.QueryString["intId"]);
                Base sa = new Base();
                String sql;
                string content1;
                content1 = content.Value;

                sql = "update JOLE_webSite set content = @content where Id =" + intId;
                String[,] ds = new String[1, 4];
                ds[0, 0] = "@content";          //参数
                ds[0, 1] = content1;             //内容
                ds[0, 2] = "2";                 //类型
                ds[0, 3] = "4000";              //大小

                sa.ExecutePrem(sql, ds);
                showMessage("修改成功",Request.UrlReferrer.ToString());

            }
            else
            {
                Response.Write("操作错误。");
                Response.End();
            }

        }
    }
}