using System;
using System.Text;
using System.Xml;

namespace JoleYe.Admin
{
    public partial class admin_nav : AdminPage
    {
        public string xmlpath;
        protected void Page_Load(object sender, EventArgs e)
        {
            xmlpath = Server.MapPath("../xml/tree.xml");
            string app = gform("do");

            if (app == "drop")
            {
                int id = -1;
                int col = -1;
                gnum(ref id, "id");
                gnum(ref col, "col");

                string err = "";

                XmlDocument doc = new XmlDocument();
                doc.Load(xmlpath);
                XmlElement myElement = doc.DocumentElement;
                XmlNodeList root = myElement.ChildNodes;

                int flg;
                for (int i = 0; i < root.Count; i++)
                {
                    if (id == i)
                    {
                        XmlNodeList child = root.Item(i).ChildNodes;
                        for (int j = 0; j < child.Count; j++)
                        {
                            if (col == j)
                            {
                                if (child.Item(j).Attributes["type"].Value != "1")
                                {
                                    if (!string.IsNullOrEmpty(child.Item(j).Attributes["key"].Value))
                                        drop("webSite","[key]='"+child.Item(j).Attributes["key"].Value+"'");

                                    root.Item(i).RemoveChild(child.Item(j));
                                }
                                else
                                {
                                    err = "不能删除";  
                                }
                            }
                        }
                    }
                }
                doc.Save(xmlpath);

                if (string.IsNullOrEmpty(err))
                    showMessage("删除成功");
                else
                    showMessage(err);
            }
            else
                bind();
        }

        private void bind()
        { 
            
            StringBuilder li = new StringBuilder();
            li.Append("<ul>\n");
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlElement myElement = doc.DocumentElement;

            XmlNodeList root = myElement.ChildNodes;

            string str;
            for (int i = 0; i < root.Count; i++)
            {
                XmlNodeList child = root.Item(i).ChildNodes;
                li.Append("<li class=\"span\">");
                li.Append("<input type=checkbox name=\"bshow\" " + selected(root.Item(i).Attributes["show"].Value) + " value=\"" + i + "\" />");
                li.Append(root.Item(i).Attributes["title"].Value + " ---- <a href=\"admin_nav_form.aspx?do=add&id="+i+"\">添加</a></li>\n");
                for (int j = 0; j < child.Count; j++)
                {
                    string keystr = "";
                    if (child.Item(j).Attributes["key"] != null)
                    {
                        
                        if (child.Item(j).Attributes["key"].Value != "")
                        {
                            keystr = "key=";
                            try
                            {
                                keystr += child.Item(j).Attributes["key"].Value;
                            }
                            catch
                            {
                                keystr = "";
                            }
                        }
                    }

                    str = @"<li>"+
                        "<input name=\"show\" type=\"checkbox\" value=\""+i+"|"+j+"\""+
                          selected(child.Item(j).Attributes["show"].Value)+"/> "+
                        "<a href=\"" + WEBPATH + ADMINPATH + child.Item(j).Attributes["href"].Value + "\" target=\"main\">" + child.Item(j).Attributes["title"].Value + "</a>"+
                        " ----------------" + keystr + "------------   <a href = \"admin_nav_form.aspx?do=edit&id=" + i + "|" + j + "\">编辑</a> | <a href = \"?do=drop&id=" + i + "&col=" + j + "\" onclick=\"return confirm_box('确认要删除吗？');\">删除</a></li>\n";
                    li.Append(str);
                }
            }
            li.Append("</ul>\n");
            list.InnerHtml =  li.ToString();
        }

        /*表单*/
        private string selected(string str)
        {
            if (str == "1")
                return " checked=\"checked\"";
            else
                return "";
        }
        
        /*保存*/
        protected void save_btn_Click(object sender, EventArgs e)
        {
            string show =  Request.Form["show"];
            string bshow = Request.Form["bshow"];
            if(show!=null)
            {
                char[] chars = { ','};
                char[] chars1 = { ','};
                string[] str = show.Split(chars);
                string[] str1 = bshow.Split(chars1);
                fither(str,str1);
            }
            else
                showMessage("不能没有","javascript:history.back();");

            showMessage("保存成功", "admin_nav.aspx");
            Response.End();
        }

        /*读取数据*/
        private void fither(string[] str,string[] str1)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(xmlpath);
            XmlElement myElement = doc.DocumentElement;
            XmlNodeList root = myElement.ChildNodes;

            int flg ;
            
            for (int i = 0; i < root.Count; i++)
            {
                XmlNodeList child = root.Item(i).ChildNodes;
                int f = 0;
                for (int j = 0; j < str1.Length; j++)
                {
                    if (i.ToString() == str1[j])
                    {
                        f = 1;
                    }
                }
                root.Item(i).Attributes["show"].Value = f.ToString();
                
                for (int j = 0; j < child.Count; j++)
                {
                    flg = 0;
                    for (int x = 0; x < str.Length; x++)
                    {
                        if (i + "|" + j == str[x])
                        {
                            flg = 1;
                        }
                    }
                    child.Item(j).Attributes["show"].Value = flg.ToString();
                }
            }
            doc.Save(xmlpath);
        }
}
}