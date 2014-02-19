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
using System.Xml;

namespace JoleYe.Admin
{
    public partial class nav_form : AdminPage
    {
        private string xmlpath;
        private string act;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("../xml/tree.xml");
            act = gform("do");

            if (!IsPostBack)
            {
                if (act == "edit")
                {
                    string id = gform("id");

                    int rotid = int.Parse(id.Split('|')[0]);
                    int noid = int.Parse(id.Split('|')[1]);

                    XmlDocument doc = new XmlDocument();
                    doc.Load(xmlpath);
                    XmlElement myElement = doc.DocumentElement;
                    XmlNodeList root = myElement.ChildNodes;

                    title.Value = root.Item(rotid).ChildNodes.Item(noid).Attributes["title"].Value;
                    if (root.Item(rotid).ChildNodes.Item(noid).Attributes["key"] != null)
                        key.Value = root.Item(rotid).ChildNodes.Item(noid).Attributes["key"].Value;
                    else
                        key.Value = "";
                    url.Value = root.Item(rotid).ChildNodes.Item(noid).Attributes["href"].Value;
                }
            }
        }

        protected void button_ServerClick(object sender, EventArgs e)
        {
            string err = "";
            int id = -1;
            int noid = 0;
            gnum(ref id, "id");
            if (act == "edit")
            {
                string ids = gform("id");

                id = int.Parse(ids.Split('|')[0]);
                noid = int.Parse(ids.Split('|')[1]);
            }

            //if (string.IsNullOrEmpty(key.Value))
            //{
            //    keyl.Text = "不能为空";
            //    return;
            //}

            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlElement myElement = doc.DocumentElement;
            XmlNodeList root = myElement.ChildNodes;

            int flg;
            for (int i = 0; i < root.Count; i++)
            {
                if (id == i)
                {
                    
                    XmlElement xn = doc.CreateElement("item");

                    
                        if (!string.IsNullOrEmpty(url.Value))
                            xn.SetAttribute("href", url.Value);
                        else
                        {
                            
                            if (!string.IsNullOrEmpty(key.Value))
                            {
                                if (getInfo("key", "webSite", "key='" + key.Value + "'") == key.Value)
                                {
                                    err = "错误，已经存在的key";
                                    break;
                                }
                                else
                                {
                                    int wid = add("webSite",
                                         "key", 2, 50, key.Value,
                                         "title", 2, 50, title.Value);
                                    xn.SetAttribute("href", "admin_intro.aspx?intId=" + wid.ToString());
                                }
                            }
                            else
                                xn.SetAttribute("href", url.Value);
                        }

                        xn.SetAttribute("title", title.Value);
                        xn.SetAttribute("type", "2");
                        xn.SetAttribute("show", "1");
                        xn.SetAttribute("key", key.Value);

                        if (act == "edit")
                        {
                            root.Item(i).ChildNodes.Item(noid).Attributes["title"].Value = title.Value;
                            root.Item(i).ChildNodes.Item(noid).Attributes["key"].Value = key.Value;
                            root.Item(i).ChildNodes.Item(noid).Attributes["href"].Value = url.Value;
                        }
                        else
                            root.Item(i).AppendChild(xn);

                }
            }
            doc.Save(xmlpath);

            if (!string.IsNullOrEmpty(err))
                showMessage(err);
            else if(act=="edit")
                showMessage("修改成功");
            else
                showMessage("添加成功");
        }
}
}