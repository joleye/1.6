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
using System.Text;
using System.Xml;

namespace JoleYe.Admin
{
    public partial class top : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            StringBuilder li = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/tree.xml"));
            XmlElement myElement = doc.DocumentElement;

            XmlNodeList child = myElement.ChildNodes;
            for (int j = 0; j < child.Count; j++)
            {
                if (child.Item(j).Attributes["show"].Value == "1")
                {
                    li.Append(addAtt(child.Item(j).Attributes["title"].Value, child.Item(j).Attributes["href"].Value));
                }
            }

            list.InnerHtml = li.ToString();
		}

        private string addAtt(string title, string href)
        {
            return "        <li><a href=\"" + href + "\">" + title + "</a></li>\n";
        }
    }
}