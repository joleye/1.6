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
    public partial class treeLeft : AdminPage
    {
        public string response;
        protected void Page_Load(object sender, EventArgs e)
        {
            string action = gform("tp");
            int pageId;
            if (action != "")
                try
                {
                    pageId = Int32.Parse(action);
                }
                catch 
                {
                    pageId = 0;
                }
            else
                pageId = 0;

            response = pageloadxml(pageId);
        }

        protected string pageloadxml(int thisId)
        {
            StringBuilder li = new StringBuilder();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("xml/tree.xml"));
            XmlElement myElement = doc.DocumentElement;
            
            XmlNodeList child = myElement.ChildNodes.Item(thisId).ChildNodes;
            for (int j = 0; j < child.Count; j++)
            {
                if(child.Item(j).Attributes["show"].Value == "1")
                    li.Append(addAtt(child.Item(j).Attributes["title"].Value, child.Item(j).Attributes["href"].Value));
            }
            return li.ToString();
        }
        
        private string addAtt(string title,string href)
        {
            return "        <li><a href=\"" + href + "\" target=\"main\">" + title + "</a></li>\n";
        }
    }
}