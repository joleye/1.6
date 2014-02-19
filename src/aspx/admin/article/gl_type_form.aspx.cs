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

    public partial class Gl_type_form : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = Request.QueryString["act"].ToString().Trim();
            if (!IsPostBack)
            {
                if (action == "edit")
                {
                    editBind();
                }
            }
        }

        protected void save_ServerClick(object sender, EventArgs e)
        {
            ArticleClass tp = new ArticleClass();
            ArticleClassInfo info = new ArticleClassInfo();

            info.ClassName = className.Value.ToString();

            string txt;
            if (!isAt("id"))
            {
                tp.addType(info);
                txt = "添加成功";
            }
            else
            {
                info.ClassName = className.Value.ToString();
                info.id = getId("id");
                tp.editType(info);
                txt = "修改成功";
            }
            showMessage(txt, "gl_type.aspx");
        }

        //编辑读取数据
        private void editBind()
        {
            int id = getId("id");
            className.Value = getInfo("className","articleClass",id.ToString());
            
        }
}
}