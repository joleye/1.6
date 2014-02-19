using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using JoleYe.Dal;
using JoleYe.Model;


namespace JoleYe.Admin
{
    public partial class ProductTypePage : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("do");  
            int id = 0;
            gnum(ref id, "id");

            if (!IsPostBack)
            {
                if (app == "del")
                {

                    bind_Del(id);
                    showMessage("删除成功");
                }
                else
                {
                    string sid = gform("id");
                    setBind(sid);
                }
                if (id > 0)
                {
                    addnew.HRef = "pro_type_form.aspx?act=add&id=" + id.ToString();
                }
            }
        }

        private void setBind(string id)
        {
            DataSet da = new DataSet();
            if(string.IsNullOrEmpty(id))
                da = find("productType","parentId=0","orderId");
            else
                da = find("productType","parentId="+id,"orderId");
            detail.DataSource = da;
            detail.DataBind();
        }

        public void bind_Del(int id)
        {
            ProductTypeDal tp = new ProductTypeDal();
            tp.DelType(id);
        }

        //protected void DataGrid_Edit(object sender, DataGridCommandEventArgs e)
        //{
        //    detail.EditItemIndex = (int)e.Item.ItemIndex;
        //    setBind();
        //}

        //protected void DataGrid_Cancel(object sender, DataGridCommandEventArgs e)
        //{
        //    detail.EditItemIndex = -1;
        //    setBind();
        //}

        //protected void DataGrid_Update(object sender, DataGridCommandEventArgs e)
        //{
        //    ProductTypeInfo tp = new ProductTypeInfo();

        //    tp.typeName = ((TextBox)e.Item.FindControl("typeName")).Text;
        //    string id = detail.DataKeys[(int)e.Item.ItemIndex].ToString();
        //    tp.id = Int32.Parse(id);
        //    ProductType pt = new ProductType();
        //    pt.Update(tp);
        //    detail.EditItemIndex = -1;
        //    setBind();

        //}

    }
}