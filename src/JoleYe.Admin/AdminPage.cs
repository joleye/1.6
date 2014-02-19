using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using System.IO;
using JoleYe.Data;


/// <summary>
/// JolePage 的摘要说明
/// </summary>
/// 
namespace JoleYe.Admin
{
    public class AdminPage : Base
    {
        public string footer = "";
        public string header = "";
        public string pagetitle = "";
        public const string charset = "utf-8";

        public AdminPage()
        {
            #region 
            
            //加载尾部信息
            footer += "<div class=\"footer\">\n";

            footer += "Powered by <a href=\"http://www.joleye.com\" target=\"_blank\">JoleYe</a> Copyright &copy;2012 JoleYe.com <br/>版本：" + version + " 2011 <br/>";
            
            footer += "</div>\n";

            footer += "</body>\n</html>";

            /*加载头部信息*/

            header += "<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\n";
            header += "<html xmlns=\"http://www.w3.org/1999/xhtml\" >\n";
            header += "<!--系统执行时间："+DateTime.Now+"-->\n";
            header += "<head>\n";
            header += "<title>";
            header += "后台管理 Powered by JoleYe";
            header += "</title>\n";
            header += "<link href=\"" + WEBPATH + "admin/css/config.css?" + DateTime.Now + "\" rel=\"stylesheet\" type=\"text/css\" />\n";
            header += "<script type=\"text/javascript\" src=\"" + WEBPATH + "javascript/UserJs.js?"+DateTime.Now+"\"></script>\n";
            header += "<script type=\"text/javascript\" src=\"" + WEBPATH + ADMINPATH + "javascript/JoleYe.js?" + DateTime.Now + "\"></script>\n";
            header += "</head>\n";
            header += "<body>";

            #endregion
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                if (Request.Cookies["joleAdmin"].Value.ToString() == "")
                    Response.Redirect("login.aspx");
            }
            catch
            {
                Response.Redirect("login.aspx");
            }
        }

        public void getsession()
        {
            

        }

        //显示信息
        public void showMessage(string str)
        {
            showMessage(str, Request.UrlReferrer.ToString());
        }
        
        //显示提示信息
        public void showMessage(string str, string url)
        {
            if (url != null)
            {
                try
                {
                    StreamReader sr = new StreamReader(Server.MapPath(WEBPATH+templatePath + "showMessage.html"));
                    string line;
                    line = sr.ReadToEnd();
                    line = line.Replace("{system.message}", str);
                    line = line.Replace("{system.url}", url);
                    Response.Write(line);
                    sr.Dispose();
                }
                catch (Exception e)
                {
                    Response.Write(e.Message+"adminpage.cs");
                }

                Response.End();

            }
            else
                Response.End();

        }

        //替换标签
        private string replaceStr(string str, string restr)
        {

            if (str.IndexOf("restr") > 0)
                return str.Replace(str, restr);
            else
                return str+"\r";
        
        }


        public void setAttInput(params TextBox[] o)
        {
            for (int i = 0; i < o.Length; i++)
            {
                o[i].Attributes.Add("onclick", "this.className='inputOnclick';");
                o[i].Attributes.Add("onblur", "this.className='input'");
            }
        }

        public string BollToZh(string str)
        {
            if (str == "True")
                return "是";
            else
                return "否";
        }

        ~AdminPage()
        {
            //echo("读取数据库 <font color=red>" + this.read_db_num + "</font>次");
        }

    }
}