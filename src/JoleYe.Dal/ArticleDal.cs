using System;
using System.Data;
using System.Web.UI;
using JoleYe.Data;
using System.Data.OleDb;
using System.IO;
using JoleYe.Model;
using System.Collections.Generic;

namespace JoleYe.Dal
{
    public class ArticleDal : Base
    {
        private int j_getcount;
        public ArticleDal()
        {
            j_getcount = 0;
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        public int getcount
        {
            get { return j_getcount; }
        }

        public string title, content, classId,imgPath;

        public bool add()
        {
            string sql;            
            string[,] ds;
            if (imgPath != null)
            {
                sql = "insert into JOLE_article(ArticleTitle,[content],createDate,updateDate,classId,defaultImgUrl) values(@title,@content,@createDate,@updateDate,@classId,@defaultImgUrl)";
                ds = new string[6, 4];
                ds[5, 0] = "@defaultImgUrl";
                ds[5, 1] = imgPath;
                ds[5, 2] = "2";
                ds[5, 3] = "255";
            }
            else
            {
                sql = "insert into JOLE_article(ArticleTitle,[content],createDate,updateDate,classId) values(@title,@content,@createDate,@updateDate,@classId)";
                ds = new string[5, 4];
            }

            ds[0, 0] = "@title";            //参数
            ds[0, 1] = title;               //内容
            ds[0, 2] = "2";                 //类型
            ds[0, 3] = "32";                //大小

            ds[1, 0] = "@content";
            ds[1, 1] = content;
            ds[1, 2] = "2";
            ds[1, 3] = content.Length.ToString();

            ds[2, 0] = "@createDate";
            ds[2, 1] = DateTime.Now.ToString();
            ds[2, 2] = "2";
            ds[2, 3] = "32";

            ds[3, 0] = "@updateDate";
            ds[3, 1] = DateTime.Now.ToString();
            ds[3, 2] = "2";
            ds[3, 3] = "32";

            ds[4, 0] = "@classId";
            ds[4, 1] = classId;
            ds[4, 2] = "1";
            ds[4, 3] = "4";


            

            this.ExecutePrem(sql, ds);
            return true;
        
        }


        /// <summary>
        /// 增加点击量
        /// </summary>
        /// <param name="arid"></param>
        public void set_hits(int arid)
        {
            string sql = "update "+label_table+"article set hitNum = hitNum+1 where id =" + arid;
            execSqlNoneQry(sql);
        }

        //编辑文章
        public void edit(int id)
        {
            string sql;
            string[,] ds;
            if (imgPath != "")
            {
                sql = "update JOLE_article set ArticleTitle = @title,[content] = @content,updateDate=@updateDate,classId=@classId,defaultImgUrl=@defaultImgUrl where id =" + id;
                ds = new string[5, 4];
                ds[4, 0] = "@defaultImgUrl";
                ds[4, 1] = imgPath;
                ds[4, 2] = "2";
                ds[4, 3] = "255";
            }
            else
            {
                sql = "update JOLE_article set ArticleTitle = @title,[content] = @content,updateDate=@updateDate,classId=@classId where id =" + id;
                ds = new string[4, 4];
            }


            ds[0, 0] = "@title";            //参数
            ds[0, 1] = title;               //内容
            ds[0, 2] = "2";                 //类型
            ds[0, 3] = "32";                //大小

            ds[1, 0] = "@content";
            ds[1, 1] = content;
            ds[1, 2] = "2";
            ds[1, 3] = content.Length.ToString();

            ds[2, 0] = "@updateDate";
            ds[2, 1] = DateTime.Now.ToString();
            ds[2, 2] = "2";
            ds[2, 3] = "32";

            ds[3, 0] = "@classId";
            ds[3, 1] = classId;
            ds[3, 2] = "1";
            ds[3, 3] = "4";



            
            ExecutePrem(sql, ds);
        
        }

        //删除文章
        public bool del(int id)
        {
            delImg(id);
            drop("Article",id.ToString());
            return true;
        }
        //删除图片
        public void delImg(int id)
        {
            string ds = getInfo("defaultImgUrl","Article","id =" + id);
            if (ds != "")
            {
                ds = Server.MapPath(ds);
                
                //删除相关格式图片
                Img img = new Img();
                img.dropimg(ds);
                //File.Delete(ds);
            }
        }

        //读取信息编辑
        public void read(int id)
        {
            DataSet ds = find("article", "", "id=" + id);

            DataRow so = ds.Tables[0].Rows[0];
            if (ds.Tables[0].Rows.Count>0)
            {
                title = so["ArticleTitle"].ToString();
                content = so["Content"].ToString();
                classId = so["classId"].ToString();
                imgPath = so["defaultImgUrl"].ToString();
            }
        }

        public List<ArticleInfo> get_list(int classId)
        {
            return get_list(classId,0,0);
        }

        /// <summary>
        /// 根据类型读取资讯列表
        /// </summary>
        /// <param name="classId"></param>
        /// <returns></returns>
        public List<ArticleInfo> get_list(int classId,int page,int pagesize)
        {
            DataTable dt;
            if (classId > 0)
            {
                DataSet ds = DataSetPageFind("VIEW_article","id desc", page, pagesize, "classid", classId);
                dt = ds.Tables[0];
                j_getcount = findcount("article", "classId=" + classId);
            }
            else
            {
                DataSet ds = DataSetPageFind("VIEW_article", "id desc", page, pagesize);
                dt = ds.Tables[0];
                j_getcount = findcount("article");
            }
            List<ArticleInfo> li = new List<ArticleInfo>();

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ArticleInfo info = new ArticleInfo();
                    info.ArticleTitle = dr["ArticleTitle"].ToString();
                    info.content = dr["Content"].ToString();
                    info.classId = int.Parse(dr["classId"].ToString());
                    //info.DefaultImgUrl = dr["defaultImgUrl"].ToString();
                    info.id = int.Parse(dr["id"].ToString());
                    info.className = dr["className"].ToString();
                    info.createDate = cdate(dr["createDate"].ToString());
                    info.UpdateDate = cdate(dr["updateDate"].ToString());
                    li.Add(info);
                }

            }

            return li;
        }

        //上一篇
        public ArticleInfo getupnews(int articleId)
        {
            ArticleInfo li = new ArticleInfo();

            return li;
        }

        //下一篇
        public ArticleInfo getnextnews(int articleId)
        {
            ArticleInfo li = new ArticleInfo();
            return li;
        }

        /// <summary>
        /// 根据资讯ID找classname
        /// </summary>
        /// <param name="aid"></param>
        /// <returns></returns>
        public ArticleClassInfo get_typename(int aid)
        {
            DataSet ds = find("select c.className,c.id from JOLE_articleClass as c left join JOLE_article as a on c.id=a.classId where a.id="+aid.ToString());
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
    }
}
