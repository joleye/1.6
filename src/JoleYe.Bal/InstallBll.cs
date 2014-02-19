using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;

namespace JoleYe.Bll
{
    public class InstallBll : BllBase
    {
        public InstallBll()
        {
            StreamWriter sw = new StreamWriter(HttpContext.Current.Server.MapPath(WEBPATH + "/config/install.lock"), true, Encoding.Default);
            sw.Dispose();

            die("<p align=center>JoleYe安装成功，初始用户名：admin 密码：123456 <a href=\"admin/\">进入后台管理</a>，<a href=\"index.aspx\">进入前台</a> <a href=\"说明.txt\">查看说明</a></p>");
        }
    }
}
