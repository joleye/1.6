using System;
using JoleYe.View;
using JoleYe.Model;
using JoleYe.Dal;
using System.IO;
using System.Text;

namespace JoleYe.Admin
{
    public class TemplateAdmin : AdminPage
    {
        public TemplateAdmin(TemplateInfo info)
        {
            new TemplateCompiled(info);
        }

        public TemplateAdmin(int id)
        {
            TemplateDal tm = new TemplateDal();
            TemplateInfo info = tm.read(id);

            StreamReader sr = new StreamReader(Server.MapPath(WEBPATH + info.templatePath), Encoding.Default);
            info.content = sr.ReadToEnd();
            sr.Dispose();
            sr.Close();

            //模板存回数据库
            TemplateDal t = new TemplateDal();
            t.Update(info, info.id);

            new TemplateCompiled(info);
        }
    }
}
