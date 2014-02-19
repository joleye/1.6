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
    public partial class admin_main : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string app = gform("app");
            
            int id = 0;
            gnum(ref id, "id");
            if (!IsPostBack)
            {
                switch (app)
                {
                    case "del":
                        bind_del(id);
                        break;
                    case "update":
                        string showHome = gform("showHome");
                        bind_update(id, showHome);
                        break;
                    default:
                        break;

                }
                setBind(sender, e);
            }
        }

        private void bind_update(int id, string showHome)
        {
            AlbumInfo info = new AlbumInfo();
            if (showHome == "True")
                info.showHome = true;
            else
                info.showHome = false;
            AlbumDal al = new AlbumDal();
            al.updateShomeHome(id, info);
            //throw new Exception("The method or operation is not implemented.");
        }

        private void bind_del(int id)
        {
            AlbumDal al = new AlbumDal();
            if (al.del(id))
                showMessage("删除成功");
            else
                showMessage("删除失败");
        }

        protected void setBind(object sender, EventArgs e)
        {
            AlbumDal al = new AlbumDal();
            int page = 1;
            int pagesize = 10;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            DataTable dt = al.GetList(page, pagesize);
            int recordcount = findcount("album");
            Pageer.value = pc.page_list("?page=", pagesize, recordcount);
            detail.DataSource = dt;
            detail.DataBind();
        }
    }
}