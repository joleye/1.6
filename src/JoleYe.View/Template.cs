using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using JoleYe.Data;
using System.Web;
using System.IO;

//��̬��
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
        /// ������
        /// </summary>
        /// <returns></returns>
        public TemplateInfo getvalue()
        {
            return j_info;
        }

        
        /// <summary>
        /// ���� �﷨{include file="footer.htm"}
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public void do_include()
        {
            new do_template(j_info).include();

            
        }

        /// <summary>
        /// ��ͨ�������� �﷨{$str}
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public void do_var()
        {
            new do_template(j_info).var();
        }

        /// <summary>
        /// �����������
        /// </summary>
        public void do_if()
        {
            new do_template(j_info).doif();
        }

        
        /// <summary>
        /// ����ѭ��
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
        /// write �﷨
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
        /// ���ļ�
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
