using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Data;
using System.Web;
using System.IO;

//静态版
namespace JoleYe.View
{
    public class Template : Base
    {
        public TemplateInfo j_info;
        public Template(TemplateInfo info)
        {
            j_info = info;
        }


        /// <summary>
        /// 处理结果
        /// </summary>
        /// <returns></returns>
        public TemplateInfo getvalue()
        {
            return j_info;
        }

        
        /// <summary>
        /// 包含 语法{include file="footer.htm"}
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public void do_include()
        {
            new do_template(j_info).include();

            
        }

        /// <summary>
        /// 普通变量处理 语法{$str}
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public void do_var()
        {
            new do_template(j_info).var();
        }

        /// <summary>
        /// 处理条件语句
        /// </summary>
        public void do_if()
        {
            new do_template(j_info).doif();
        }

        
        /// <summary>
        /// 处理循环
        /// </summary>
        public void do_loop()
        {
            new do_template(j_info).loop();
        }

        /// <summary>
        /// foreach
        /// </summary>
        public void do_foreach()
        { 
           new do_template(j_info).for_each();
        }

        /// <summary>
        /// write 语法
        /// </summary>
        public void do_write()
        {
            new do_template(j_info).write();
        }

        public void do_assign()
        {
            new do_template(j_info).assign();
        }

        public void do_display(string filename)
        {
            new do_template(j_info).display(filename);
        }

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public string open(string path)
        {
            if (path != "")
            {
                if (path.IndexOf(":") == -1)
                    path = HttpContext.Current.Server.MapPath(WEBPATH + path);

                string str = "";
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path, Encoding.Default, true);
                    str = sr.ReadToEnd();
                    sr.Dispose();
                }
                return str;
            }
            else
                return "";
        }
    }
}
