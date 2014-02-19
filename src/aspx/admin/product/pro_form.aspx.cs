using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using JoleYe.Dal;
using JoleYe.Model;


namespace JoleYe.Admin
{
    public partial class gl_form : AdminPage
    {
        private int id;
        private string app;

        protected void Page_Load(object sender, EventArgs e)
        {
            string toid = Request.QueryString["id"];
            
            if (toid != null)
                id = Int32.Parse(toid);
            app = gform("app");
            if (!IsPostBack)
            {
                
                DataSet ds = find("productType", "", "parentId desc");

                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (dr["parentId"].ToString() == "0")
                    {
                        ListItem li = new ListItem(dr["typeName"].ToString(), dr["id"].ToString(), true);
                        li.Attributes.Add("disabled", "disabled");
                        typeId.Items.Add(li);
                        
                        foreach (DataRow dr1 in dt.Rows)
                        {
                            if (dr["id"].ToString() == dr1["parentId"].ToString())
                            typeId.Items.Add(new ListItem("------"+dr["typeName"].ToString()+"->" + dr1["typeName"].ToString(), dr1["id"].ToString(), true));
                        }
                    }
                }

                if (app == "edit")
                {
                    typeId.Items[0].Selected = false;
                    editProduct(id);
                }
            }
        }

        //编辑绑定
        private void editProduct(int id)
        {

            ProductDal red = new ProductDal();
            ProductInfo pro = red.read(id);
            ProductName.Value = pro.productName;
            title1.Value = pro.title1;
            //title2.Value = "";//pro.title2;
            content.Value = pro.content;
            content1.Value = pro.content1;
            content2.Value = pro.content2;
            content3.Value = pro.content3;
            articleImg.Src = pro.productImgUrl;
            listImgA.HRef = pro.productImgUrl;
            filePath.Value = pro.productImgUrl;

            int TypeId = pro.TypeId;
            foreach (ListItem list in typeId.Items)
            {
                if (list.Value.ToString() == TypeId.ToString())
                {
                    list.Selected = true;
                    break;
                }
            }

        }

        //保存
        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            ProductInfo proinfo = new ProductInfo();
            
            proinfo.productName = ProductName.Value.ToString();
            proinfo.title1 = title1.Value.ToString();
            proinfo.title2 = "";//title2.Value.ToString();
            proinfo.TypeId = Int32.Parse(typeId.Text);
            proinfo.content = content.Value.ToString();
            proinfo.content1 = content1.Value.ToString();
            proinfo.content2 = content2.Value.ToString();
            proinfo.content3 = content3.Value.ToString();

            Img im = new Img();
            im.savePathName = "products";

            proinfo.productImgUrl = im.saveImage(filePath.Value);


            if (string.IsNullOrEmpty(im.error))
            {
                ProductDal dal = new ProductDal();
                if (app == "edit")
                {
                    proinfo.Id = id;
                    dal.updateProduct(proinfo);
                    editProduct(id);
                }
                else
                {
                    
                    dal.createProduct(proinfo);
                }

                showMessage("保存成功", "manage.aspx");
            }
            else
            {
                showMessage("出现了错误："+im.error);
            }
        }
    }
}