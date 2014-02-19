using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using JoleYe;
using JoleYe.Dal;

namespace JoleYe.Admin
{
    public partial class ArticleList : AdminPage
    {
        protected int classid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("app");
            int id = 0;
            gnum(ref id, "id");
            classid = 0;
            gnum(ref classid, "classid");
            if (ISPOST)
            {
                string fid = pform("id");
                string[] nid = fid.Split(',');
                foreach(string did in nid)
                {
                    bind_del(Int32.Parse(did));
                }
                showMessage("删除成功");
            }

            if (!IsPostBack)
            {
                switch (app)
                { 
                    case "del":
                        if(bind_del(id))
                            showMessage("删除成功");
                         else
                            showMessage("删除失败");
                        break;
                    default:
                        break;

                }
                setBind(sender,e);
            }
        }

        private void setBind(object sender, EventArgs e)
        {
            int pagesize = 10;
            int page = 1;

            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            int classid = 0;
            gnum(ref classid, "classid");

            ArticleDal dal = new ArticleDal();
            detail.DataSource = dal.get_list(classid, page, pagesize);
            detail.DataBind();

            int recordcount = dal.getcount;

            Pageer.value = pc.page_list("?classid=" + classid + "&page=", pagesize, recordcount);  
        }

        public bool bind_del(int id)
        {

            ArticleDal sd = new ArticleDal();
            return sd.del(id);
;
        }
}
}