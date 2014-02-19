using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using System.Web;
using System.IO;
using JoleYe.Data;
using JoleYe.Dal;

namespace JoleYe.View
{
    public class TemplateCompiled : Base
    {
        private string templatestr;
        public TemplateCompiled()
        {

        }

        public TemplateCompiled(FileUrl url)
        {
            TemplateTypeDal dal = new TemplateTypeDal();
            TemplateTypeInfo info = dal.view(TEMPLATEPATH.Substring(TEMPLATEPATH.LastIndexOf("/")+1));

            TemplateInfo tinfo = new TemplateDal().read(info.id, "aspx/"+url.name);

            if(this.isEquals(tinfo.templatePath,tinfo.activePath))
            init(tinfo);
        }

        private bool isEquals(string p, string p_2)
        {
            //最后更新时间相差3秒，自动编译
            FileInfo f1 = new FileInfo(Server.MapPath(WEBPATH + p));
            FileInfo f2 = new FileInfo(Server.MapPath(WEBPATH + p_2));

            
            if (f1.LastWriteTime.AddSeconds(3).CompareTo(f2.LastWriteTime)>0)
                return true;
            else
                return false;
        }

        public TemplateCompiled(TemplateInfo info)
        { 

            init(info);
        }

        private void init(TemplateInfo info)
        { 
            templatestr = open(info.templatePath);
            info.content = templatestr;
            string filename = subfilename(info.activePath);
            Template tl = new Template(info);
            tl.do_include();
            tl.do_var();
            tl.do_if();
            tl.do_loop();
            tl.do_foreach();
            tl.do_write();
            tl.do_assign();

            //...
            
            tl.do_display(filename);
            TemplateInfo value = tl.getvalue();
            templatestr = value.content;

            fwrite(info.activePath, templatestr);
        }


        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string open(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                if (path.IndexOf(":") == -1)
                    path = HttpContext.Current.Server.MapPath(WEBPATH + path);


                string str = "";
                if (File.Exists(path))
                {
                    StreamReader sr = new StreamReader(path,Encoding.UTF8);
                    str = sr.ReadToEnd();
                    sr.Dispose();
                }
                return str;
            }
            else
                return "";
        }

        /// <summary>
        /// 写入文件操作
        /// </summary>
        /// <param name="path"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        private void fwrite(string filepath, string content)
        {
            if (!string.IsNullOrEmpty(filepath))
            {
                if (File.Exists(Server.MapPath(WEBPATH + filepath)))
                {
                    
                    
                    FileStream fs = File.Create(Server.MapPath(WEBPATH + filepath));
                    fs.Close();
                    fs.Dispose();

                }
                StreamWriter sw = new StreamWriter(Server.MapPath(WEBPATH + filepath),false,Encoding.UTF8);
                sw.Write(content);
                sw.Close();
                sw.Dispose();
            }
        }

        /// <summary>
        /// 取得文件名并手写第一个字母
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        private string subfilename(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                return "";
            if (filepath.IndexOf('/') > 0)
            {
                int jd = filepath.LastIndexOf('/');
                filepath = filepath.Substring(jd);
                filepath = filepath.Substring(1);
            }
            string filename = filepath.Substring(0, filepath.IndexOf('.'));
            string strone = filename.Substring(0, 1).ToUpper();
            filename = strone + filename.Substring(1);
            return filename;
        }
    }
}
