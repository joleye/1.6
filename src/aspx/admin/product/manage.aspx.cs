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
    public partial class ProductManage : AdminPage
    {
        private int tyid;
        private string keyword;
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("app");
            keyword = gform("wd");
            int id = 0;
            tyid = 0;
            gnum(ref id, "id");
            gnum(ref tyid,"tyid");

            if (IsPostBack && pform("button").Equals("删除"))
            {
                string fid = pform("id");
                string[] nid = fid.Split(',');

                if (nid.Length > 1)
                {
                    foreach (string did in nid)
                    {
                        bind_del(Int32.Parse(did));
                    }
                    showMessage("删除成功");
                }
                else
                {
                    showMessage("请先选择");
                }
                
            }


            if (!IsPostBack)
            {
                switch (app)
                {
                    case "del":
                        if (bind_del(id))
                            showMessage("删除成功");
                        else
                            showMessage("删除失败");
                        break;
                    case "setHome":
                        string showHome = gform("showHome");
                        bind_update(id, showHome);
                        break;
                    default:
                        break;

                }


                setBind();
            }
        }



        private void bind_update(int id, string showHome)
        {
            ProductInfo info = new ProductInfo();
            if (showHome == "True")
                info.showHome = true;
            else
                info.showHome = false;
            ProductDal dal = new ProductDal();
            dal.setShowHome(id, info);
        }

        private void setBind()
        {
            int pagesize = 10;
            int page = 1;
            int recordcount=2;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            wd.Value = keyword;


            //DataTable dt = find("view_product", page, pagesize, " showId ,id desc");
            ProductDal p = new ProductDal();
                


                
            Pageer.value = pc.page_list("?page=", pagesize, recordcount);
            detail.DataSource = p.view_list(page, pagesize, 0, keyword);
            detail.DataBind();
        }

        private void setOrder(int id, int showId)
        {
            ProductDal sd = new ProductDal();
            sd.setOrder(id, showId);
        }

        public bool bind_del(int id)
        {
            ProductDal sd = new ProductDal();
            return sd.del(id);

        }

    }
}