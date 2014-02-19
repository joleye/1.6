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

namespace JoleYe.Admin
{
    public partial class admin_join : AdminPage
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
                    default:
                        break;

                }
                setBind();
            }
        }

        private void setBind()
        {
            int pagesize = 10;
            int page = 1;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            int recordcount = findcount("JM");

            Pageer.value = pc.page_list("?page=", pagesize, recordcount);

            DataTable dt = find("JM", page, pagesize);
            list.DataSource = dt;
            list.DataBind();
        }

        public void bind_del(int id)
        {
            JmDal sd = new JmDal();
            if (sd.del(id))
                showMessage("删除成功");
            else
                showMessage("删除失败");

        }
    }
}