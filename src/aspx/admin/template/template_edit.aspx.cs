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
    public partial class Template_edit : AdminPage
    {
        protected int templateid;
        protected string app;
        protected void Page_Load(object sender, EventArgs e)
        {
            templateid = getId("templateid");
            app = gform("do");
            if (!IsPostBack)
            {
                if (app == "edit")
                {
                    TemplateDal te = new TemplateDal();
                    TemplateInfo info = new TemplateInfo();
                    info = te.read(getId("id"));
                    contentDetail.Text = info.content;
                    title.Text = info.title;
                    filePath.Text = info.filePath;
                    activePath.Text = info.activePath;
                    templatePath.Text = info.templatePath;
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            
            TemplateInfo info = new TemplateInfo();
            info.title = title.Text.ToString();
            info.filePath = filePath.Text.ToString();
            info.activePath = activePath.Text.ToString();
            info.templatePath = templatePath.Text.ToString();
            info.content = contentDetail.Text.ToString();
            info.typeId = templateid;

            TemplateDal te = new TemplateDal();
            if (app == "edit")
            {
                te.Update(info, getId("id"));
                te.saveFile(info.templatePath, info.content);
                showMessage("修改成功", "templatefile_list.aspx?templateid="+templateid);
            }
            else
            {
                te.add(info);
                te.saveFile(info.templatePath, info.content);
                showMessage("添加成功","templatefile_list.aspx?templateid="+templateid);
            }
            
            
        }
}
}