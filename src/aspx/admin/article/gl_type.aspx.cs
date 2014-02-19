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
    public partial class Article_type : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setBind();
            }
        }

        private void setBind()
        {
            //OleDbDataReader rs1 = Record1("select * from JOLE_ArticleClass order by orderId");
            DataTable dt = find("articleClass", 0, 100);
            detail.DataSource = dt;
            detail.DataBind();
        }

        public void DataGrid_Del(object sender, DataGridCommandEventArgs e)
        {
            int id = (int)detail.DataKeys[e.Item.ItemIndex];
            ArticleClass at = new ArticleClass();
            if (at.delType(id))
            {
                setBind();
                showMessage("删除成功");
            }
            else
                showMessage("删除失败");
        }

        protected void DataGrid_Edit(object sender, DataGridCommandEventArgs e)
        {
            detail.EditItemIndex = (int)e.Item.ItemIndex;
            setBind();
        }

        protected void DataGrid_Cancel(object sender, DataGridCommandEventArgs e)
        {
            detail.EditItemIndex = -1;
            setBind();
        }

        protected void DataGrid_Update(object sender, DataGridCommandEventArgs e)
        {
            ArticleClass tp = new ArticleClass();
            ArticleClassInfo info = new ArticleClassInfo();

            info.ClassName = ((TextBox)e.Item.FindControl("className")).Text;
            string id = detail.DataKeys[(int)e.Item.ItemIndex].ToString();
            int idn = Int32.Parse(id);
            info.id = idn;
            tp.editType(info);
            detail.EditItemIndex = -1;
            setBind();
            
        }

    }
}