using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using JoleYe.Model;
using System.Data;

namespace JoleYe.Dal
{
    public class ArticleClass : Base
    {

        public ArticleClass()
        { 
        
        }

        //添加新类型
        public void addType(ArticleClassInfo info)
        {
            string sql;
            sql = "insert into JOLE_articleClass(ClassName) values(@ClassName)";
            string[,] ds = new string[1, 4];
            ds[0, 0] = "@ClassName";
            ds[0, 1] = info.ClassName;
            ds[0, 2] = "2";
            ds[0, 3] = "32";

            ExecutePrem(sql, ds);
        }

        //编辑类型
        public void editType(ArticleClassInfo info)
        {
            string sql;
            sql = "update JOLE_articleClass set ClassName = @ClassName where id = @id";
            string[,] ds = new string[2, 4];
            ds[0, 0] = "@ClassName";
            ds[0, 1] = info.ClassName;
            ds[0, 2] = "2";
            ds[0, 3] = "32";

            ds[1, 0] = "@id";
            ds[1, 1] = info.id.ToString();
            ds[1, 2] = "1";
            ds[1, 3] = "8";

            ExecutePrem(sql, ds);
        }

        //删除类型
        //删除文章
        public bool delType(int id)
        {
            drop("JOLE_ArticleClass", id.ToString());
            return true;
        }

        /// <summary>
        /// 根据ID找classname
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ArticleClassInfo get_typename(int id)
        {
            DataSet ds = find("select className,id from JOLE_articleClass where id=" + id.ToString());
            ArticleClassInfo info = new ArticleClassInfo();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    info.id = int.Parse(dr["id"].ToString());
                    info.ClassName = dr["className"].ToString();
                }
            }
            return info;
        }

        /// <summary>
        /// 类目列表
        /// </summary>
        /// <returns></returns>
        public List<ArticleClassInfo> view_list()
        {
            DataSet ds = find("articleClass", "");
            List<ArticleClassInfo> li = new List<ArticleClassInfo>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                ArticleClassInfo info = new ArticleClassInfo();
                info.ClassName = dr["className"].ToString();
                info.id = cint(dr["id"].ToString());
                info.orderId = cint(dr["orderid"].ToString());
                info.pid = cint(dr["pid"].ToString());
                li.Add(info);
            }
            return li;
        }
    }
}
