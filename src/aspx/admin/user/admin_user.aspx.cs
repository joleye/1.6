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
using JoleYe.Web;
using JoleYe.Bll;

namespace JoleYe.Admin
{
    public partial class Admin_user : AdminPage
    {
        public string pageBox;
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("app");

            MemberDal mb = new MemberDal();
            if (app == "drop")
            {
                int id = gformNum("id");
                mb.drop(id);
                showMessage("删除成功");
            }
            int page = 1;
            gnum(ref page, "page");
            int pagesize = 10;
            
            list.DataSource = mb.get_list(page,pagesize);
            list.DataBind();

            int recordcount = mb.findcount("member", "");
            PageCurrent pg = new PageCurrent();
            pageBox = pg.page_list("?page=", pagesize, recordcount);
            
        }
        protected void drop_Click(object sender, EventArgs e)
        {

            int[] ids = pformNums("id");
            MemberBll b = new MemberBll();
            int ret = b.drop(ids);
            showMessage("删除成功");
        }
}
}