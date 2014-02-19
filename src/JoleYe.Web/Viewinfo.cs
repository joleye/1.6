using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using JoleYe.Dal;

namespace JoleYe.Web
{
    public class Viewinfo : Frontend
    {
        public DataRow view;
        public string typetitle;
        public Viewinfo()
        {
            flg_nav = "listinfo";
            int id = 0;
            gnum(ref id, "id");
            DataSet ds = find("article", "id=" + id);
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                view = ds.Tables[0].Rows[0];
                pagetitle = view["articletitle"].ToString();
                
            }
            else
            {
                HttpContext.Current.Response.Write("没有任何信息");
                HttpContext.Current.Response.End();
            }

            ArticleDal dal = new ArticleDal();
            dal.set_hits(id);
            typetitle = dal.get_typename(id).ClassName;
        }
    }
}
