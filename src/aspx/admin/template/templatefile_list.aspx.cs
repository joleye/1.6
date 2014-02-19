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
    public partial class Templatefile_list : AdminPage
    {
        public int templateid;
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("do");
            if (ISPOST)
            {
                string sid = pform("id");

                string[] id = sid.Split(',');
                if (app == "del")
                {
                    TemplateDal tl = new TemplateDal();
                    for (int i = 0; i < id.Length; i++)
                    {
                        tl.del(int.Parse(id[i]));
                    }
                    showMessage("批量删除成功"); 
                }

                if (app == "reset")
                {
                    TemplateDal tm = new TemplateDal();
                    for (int i = 0; i < id.Length; i++)
                    {
                        TemplateInfo info = tm.read(int.Parse(id[i]));

                        TemplateAdmin ta = new TemplateAdmin(info);
                    }

                    showMessage("批量更新成功"); 
                }
            }
            if (app == "drop")
            {
                int id = 0;
                gnum(ref id, "id");
                if (id != 0)
                {
                    TemplateDal tl = new TemplateDal();
                    tl.del(id);
                    showMessage("删除成功");
                }
                else
                    showMessage("参数错误");
                
            }
            else
            {
                templateid = getId("templateid");
                setBind();
            }
        }
        protected void setBind()
        {
            DataSet da = getData("select * from JOLE_template where typeId=" + templateid + " order by id");
            datalist.DataSource = da;
            datalist.DataBind();
        }
        protected void MyDataGrid_Page(object sender, DataGridPageChangedEventArgs e)
        {
            //int startIndex;
            //startIndex = detail.CurrentPageIndex * detail.PageSize;
            //detail.CurrentPageIndex = e.NewPageIndex;
            //setBind();
        }
}
}