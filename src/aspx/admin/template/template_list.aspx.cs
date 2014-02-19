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
using System.IO;
using System.Xml;

namespace JoleYe.Admin
{
    public partial class Template_list : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DirectoryInfo dr = new DirectoryInfo(Server.MapPath("../../template/"));
            FileSystemInfo   []   files = dr.GetFileSystemInfos();
            DataTable dt = new DataTable();
            
            DataColumn dc = new DataColumn("name");
            dt.Columns.Add(dc);
            DataColumn dc1 = new DataColumn("version");
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn("author");
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn("id");
            dt.Columns.Add(dc3);

            for (int i = 0; i < files.Length; i++)
            {
                FileInfo finfo = new FileInfo(files[i].FullName+"/info.config");
                if (finfo.Exists)
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(files[i].FullName + "/info.config");
                    XmlElement element = doc.DocumentElement;

                    DataRow drow = dt.NewRow();
                    drow["id"] = element.GetElementsByTagName("id")[0].InnerText;
                    drow["name"] = element.GetElementsByTagName("name")[0].InnerText;
                    drow["version"] = element.GetElementsByTagName("version")[0].InnerText;
                    drow["author"] = element.GetElementsByTagName("author")[0].InnerText;
                    dt.Rows.Add(drow);
                    
                }
            }
            temp_list.DataSource = dt;
            temp_list.DataBind();
        }
    }
}