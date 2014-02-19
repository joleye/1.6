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
using System.Web.Configuration;

namespace JoleYe.Admin
{
    public partial class admin_template_system : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app = gform("app");
            int tempid = 0;
            gnum(ref tempid, "id");
            switch (app)
            { 
                case "resettemplate":
                    reset_template(tempid);
                    showMessage("使用成功，刷新全部模板成功");
                    break;
                default:
                    break;

            }

            if (!IsPostBack)
            {
                TemplateTypeDal dal = new TemplateTypeDal();
                foreach (TemplateTypeInfo info in dal.view_list())
                {
                    ListItem item = new ListItem(info.templateName, info.templateName);

                    if ("template/"+info.templateName == TEMPLATEPATH)
                    {
                        item.Selected = true;
                    }
                    main_template.Items.Add(item);
                    //else
                    //main_template.Items.Add(new ListItem(info.templateName, info.templateName));
                }
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }
        protected void ResetAllTemplate_Click(object sender, EventArgs e)
        {
            int tempid = 1;// = getId("tempid");

            reset_template(tempid);

            showMessage("操作成功");
        }

        private void reset_template(int tempid)
        {
            TemplateDal tm = new TemplateDal();
            ArrayList ids = tm.GetAllId(tempid);

            foreach (int kid in ids)
            {
                TemplateInfo info = tm.read(kid);
                TemplateAdmin ta = new TemplateAdmin(info);
            }
        }
        protected void button_ServerClick(object sender, EventArgs e)
        {
            Configuration config = WebConfigurationManager.OpenWebConfiguration("~");
            //获取appsettings节点
            AppSettingsSection appsection = (AppSettingsSection)config.GetSection("appSettings");

            //修改appsettings节点中的元素
            //die(appsection.Settings["templatepath"].Value);
            //die(main_template.Items[main_template.SelectedIndex].Value);
            appsection.Settings["templatepath"].Value = "template/"+main_template.Items[main_template.SelectedIndex].Value;
            config.Save();
            showMessage("设置成功");

            //ConfigurationManager.AppSettings["templatepath"] = main_template.Items[main_template.SelectedIndex].Value;
        }
}
}