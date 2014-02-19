using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Web;

namespace JoleYe.Admin
{
    class NavTree
    {
        //public DataTable top()
        //{
        //    StringBuilder li = new StringBuilder();
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(System.Web.HttpContext.Current.Server.MapPath(JoleYe.Obj.WEBPATH + JoleYe.Obj.ADMINPATH + "xml/tree.xml"));
        //    XmlElement myElement = doc.DocumentElement;
        //    int thisId;
        //    XmlNodeList child = myElement.ChildNodes.Item(thisId).ChildNodes;
        //    for (int j = 0; j < child.Count; j++)
        //    {
        //        if (child.Item(j).Attributes["show"].Value == "1")
        //            li.Append(addAtt(child.Item(j).Attributes["title"].Value, child.Item(j).Attributes["href"].Value));
        //    }
        //    return li.ToString();
        //}

        private char[] addAtt(string p, string p_2)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
