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
    public partial class Global_auto_page_form : AdminPage
    {
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = 0;
            gnum(ref id, "id");
            if (!IsPostBack&&id>0)
            {
                Auto_pageDal au = new Auto_pageDal();
                Auto_pageInfo info = au.view(id);
                page_name.Text = info.page_name;
                setting.Value = info.setting;
                content.Value = info.content;
            }
            string app = gform("app");
            if (app == "add" && IsPostBack)
            {
                Auto_pageDal au = new Auto_pageDal();
                Auto_pageInfo info = new Auto_pageInfo();
                info.page_name = page_name.Text;
                info.setting = setting.Value;
                info.content = content.Value;

                au.add(info);
                showMessage("保存成功");
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Auto_pageDal au = new Auto_pageDal();
            Auto_pageInfo info = new Auto_pageInfo();
            info.page_name = page_name.Text;
            info.setting = setting.Value;
            info.content = content.Value;

            au.edit(info, id.ToString());
            showMessage("保存成功");
        }
    }
}