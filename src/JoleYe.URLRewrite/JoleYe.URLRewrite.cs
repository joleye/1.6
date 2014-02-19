using System;
using System.Web;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Xml;

namespace JoleYe.URLRewrite
{
    public class RewriterModule : IHttpModule
    {
        private XmlNodeList nodelist;
        private string apppath;
        private string query;
        public void Init(HttpApplication app)
        {
            // WARNING!  This does not work with Windows authentication!
            // If you are using Windows authentication, change to app.BeginRequest
            app.AuthorizeRequest += new EventHandler(this.URLRewriter);
        }
        protected void URLRewriter(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            string requestedPath = app.Request.Path;

            string path = app.Context.Request.Path.ToString();

            string no_dict = @"adldown\/|admin\/|account\/|aspx\/|upload\/|download\/";//特殊文件夹不执行映射


            if (path == "" || path=="~/" || Regex.IsMatch(path,no_dict))
                return;
            int p = path.LastIndexOf("/");

            path = path.Substring(p);
            this.loadconfig(path);

            if (!string.IsNullOrEmpty(this.apppath))
                app.Context.RewritePath("~/aspx/" + this.apppath, "", this.query+"&"+app.Request.QueryString.ToString());
            else
                app.Context.RewritePath("~/aspx/"+path, "", app.Request.QueryString.ToString());
        }

        /// <summary>
        /// 读取映射表
        /// </summary>
        private void loadconfig(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(HttpContext.Current.Server.MapPath("~/config/rewrite.config"));
            XmlElement myElement = doc.DocumentElement;
            XmlNodeList nodelist = myElement.ChildNodes;



            Regex reg = new Regex(@"\-.+?\.");
            if (reg.IsMatch(path))
            {
                Match match = reg.Match(path);
                if (match.Success)
                {
                    int n = path.LastIndexOf("-");
                    string p = path.Substring(1,n-1);

                    for (int i = 0; i < nodelist.Count; i++)
                    {
                        if (p == nodelist.Item(i).Attributes["name"].Value)
                        {
                            string que = match.ToString().Replace("-", "");
                            que = que.Replace(".", "");
                            this.apppath = nodelist.Item(i).Attributes["page"].Value;
                            string str = nodelist.Item(i).Attributes["query"].Value;
                            str = str.Replace("$1", que);
                            this.query = str;
                            return;
                        }
                    }
                }

            }
            this.apppath = "";
            this.query = "";
        }

        /// <summary>
        /// 解析到query
        /// </summary>
        /// 
        private string Analysis_query(string path)
        {
            //Regex reg = new Regex(@"\-.+?\.aspx");
            return "reg";
        }
        //调试方法
        public void echo(string str)
        {
            System.Web.HttpContext.Current.Response.Write(str);
        }
        public void die(string str)
        {
            echo(str);
            System.Web.HttpContext.Current.Response.End();
        }

        #region IHttpModule 成员

        public void Dispose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
    
}
