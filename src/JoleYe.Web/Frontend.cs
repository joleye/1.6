using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using System.Data;
using System.Web;
using System.Text.RegularExpressions;
using JoleYe.Conf;
using System.IO;
using JoleYe.Bll;
using JoleYe.View;
using JoleYe.Model;

namespace JoleYe.Web
{
    /// <summary>
    /// 前端基类
    /// </summary>
    public class Frontend : FrontendBll
    {
        public string pagetitle = "";
        public string web_title;
        public DataRow config_site;
        public DataRow config_title;
        public string flg_nav = "";
        public DateTime usetimerstart = DateTime.Now;
        public string pagename;
        public bool islogin = false;
        public string user_name = "";
        public WebConf conf;
        public Frontend()
        {
            if (!File.Exists(HttpContext.Current.Server.MapPath(WEBPATH + "/config/install.lock")))
            {
                new InstallBll();
            }

            //检查站点是否关闭
            conf = new WebConf();
            if (conf.getAttr("webstate", "state") == "1")
            {
                die("<div style=\"border:1px solid #ed6501;	margin:10px;background:#ffffcc;padding:10px;\">" + conf.getVal("webstate") + "</div>");
            }


            //检查是否需要编译
            if (conf.getVal("autocompiled") == "1")
            {
                string url = HttpContext.Current.Request.ServerVariables["SCRIPT_NAME"];

                url = url.Substring(url.LastIndexOf("/") + 1);

                TemplateCompiled t = new TemplateCompiled(new FileUrl(url));
            }

            pagename = get_pathinfo();
            DataTable sitet = new DataTable("config_site") ;
            DataTable sitetitle = new DataTable("config_title");

            DataSet ds = find("webSite", "");
            DataTable dt = ds.Tables[0];

            DataColumn dc;
            DataColumn dctitle;
            foreach (DataRow key in dt.Rows)
            {
                if (!string.IsNullOrEmpty(key["key"].ToString()))
                {
                    dc = new DataColumn();
                    dc.DataType = Type.GetType("System.String");
                    dc.AllowDBNull = true;
                    dc.ColumnName = key["key"].ToString().Trim();
                    dc.Caption = key["key"].ToString().Trim();
                    dc.DefaultValue = key["content"].ToString();

                    //print(key["key"].ToString());
                    //print("<!--"+key["content"].ToString()+"-->");
                    //print("<br/>");

                    sitet.Columns.Add(dc);

                    dctitle = new DataColumn();
                    dctitle.DataType = Type.GetType("System.String");
                    dctitle.AllowDBNull = true;
                    dctitle.ColumnName = key["key"].ToString().Trim();
                    dctitle.Caption = key["key"].ToString().Trim();
                    dctitle.DefaultValue = key["title"].ToString();

                    sitetitle.Columns.Add(dctitle);

                }
            }

            DataRow dr1 = sitet.NewRow();
            sitet.Rows.Add(dr1);

            DataRow dr2 = sitetitle.NewRow();
            sitetitle.Rows.Add(dr2);

            config_site = sitet.Rows[0];
            config_title = sitetitle.Rows[0];

            web_title = config_site["website"].ToString();

            //flg_nav 默认文件名
            string path = HttpContext.Current.Request.ServerVariables["Path_Info"];
            string pathname = Regex.Match(path, @"(?!=\/)\w+(?=\.)").Value;
            flg_nav = pathname;

            try
            {
                PassportBll p = new PassportBll();
                if (p.islogin())
                {
                    islogin = true;
                    MemberInfo m = p.get();
                    if (m.nickname != "")
                        user_name = m.nickname;
                    else
                        user_name = m.username;
                }
                else
                    islogin = false;
            }
            catch
            {
                islogin = false;
            }
        }

        

        public DataTable get_typelist()
        {
            DataSet ds = find("productType", "parentId=0", "orderId,id desc");
            return ds.Tables[0];
        }

        public DataTable get_typelist_small(string parentId)
        {
            DataSet ds = find("productType", "parentId=" + parentId, "id desc");
            return ds.Tables[0];
        }

        private string get_pathinfo()
        {
            string str  = HttpContext.Current.Request.ServerVariables["PATH_INFO"].ToString();
            Regex reg = new Regex( @"!?\w+\.aspx",RegexOptions.IgnoreCase);
            string temp = "";
            foreach (Match m in reg.Matches(str))
            {
                temp = m.Value;
                break;
            }
            return temp;
        }

        /// <summary>
        /// 显示广告
        /// </summary>
        /// <param name="id"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public string showad(int id)
        {
            DataSet ds = DataSetFind("adver", "id", id);

            return "<img src=\"" + ds.Tables[0].Rows[0]["imgurl"].ToString() + "\" />";
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="str"></param>

        public void showMessage(string str)
        {
            showMessage(str, HttpContext.Current.Request.UrlReferrer.ToString());
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="str"></param>
        /// <param name="url"></param>

        public void showMessage(string str, string url)
        {
            if (url != null)
            {
                try
                {
                    StreamReader sr = new StreamReader(Server.MapPath(WEBPATH + templatePath + "showMessage.html"));
                    string line;
                    line = sr.ReadToEnd();
                    line = line.Replace("{system.message}", str);
                    line = line.Replace("{system.url}", url);
                    HttpContext.Current.Response.Write(line);
                    sr.Dispose();
                }
                catch (Exception e)
                {
                    HttpContext.Current.Response.Write(e.Message + "adminpage.cs");
                }

                HttpContext.Current.Response.End();

            }
            else
                HttpContext.Current.Response.End();

        }

        //替换标签
        private string replaceStr(string str, string restr)
        {

            if (str.IndexOf("restr") > 0)
                return str.Replace(str, restr);
            else
                return str + "\r";

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <param name="typeid"></param>
        /// <returns></returns>
        public DataTable info_box_list(int num, int typeid)
        {
            string conditions = "";
            if (typeid > 0)
                conditions = "classid=" + typeid.ToString();

            DataSet dt = find("article", num, conditions, "id desc");
            return dt.Tables[0];
        }

        public DataTable info_box_list(int num)
        {
            return info_box_list(num, 0);
        }
    }
}
