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

            die("<p align=center>JoleYe��װ�ɹ�����ʼ�û�����admin ���룺123456 <a href=\"admin/\">�����̨����</a>��<a href=\"index.aspx\">����ǰ̨</a> <a href=\"˵��.txt\">�鿴˵��</a></p>");
        }
    }
}
