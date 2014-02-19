using System;
using System.Data;
using System.Configuration;
using System.IO;
using System.Collections;
using JoleYe.Data;
using JoleYe.Model;
using System.Text;

namespace JoleYe.Dal
{
    /// <summary>
    /// 模板操作
    /// </summary>
    public class TemplateDal : Base
    {
        private string tableName;

        public TemplateDal()
        {
            tableName = label_table+"template";
        }

        public TemplateInfo read(int typeid, string activePath)
        {
            DataSet ds = DataSetFind("Template", "typeId", typeid,"activePath",activePath);

            if (ds.Tables[0].Rows.Count > 0)
                return read(cint(ds.Tables[0].Rows[0]["id"].ToString()));
            else
                return new TemplateInfo();
        }

        //读取模板内容
        public TemplateInfo read(int id)
        {
            DataSet ds = getData("select * from "+tableName+" where id=" + id);
            DataRow dr = ds.Tables[0].Rows[0];
            TemplateInfo info = new TemplateInfo();
            info.id = id;
            info.title = dr["title"].ToString();
            info.content = dr["content"].ToString();
            
            info.filePath = dr["filePath"].ToString();
            info.activePath = dr["activePath"].ToString();
            info.templatePath = dr["templatePath"].ToString();
            return info;
        }

        //修改模板文件
        public void Update(TemplateInfo info,int id)
        {
            string sql = "update " + tableName + " set title = @title,filePath = @filePath,activePath=@activePath,templatePath = @templatePath,content=@content where id = @id";
            ExecuteDataSet(sql,
                "@title",2,50,info.title,
                "@filePath", 2, 50, info.filePath,
                "@activePath",2,50,info.activePath,
                "@templatePath", 2, 50, info.templatePath,
                "@content", 2, info.content.Length, info.content,
                "@id",1,8,id
                );

            //saveFile(info.templatePath, info.content);
            //同时保存
            //saveFile(info.filePath, info.content);
        }

        /// <summary>
        /// 添加新页面
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int add(TemplateInfo info)
        {
            int tid = add(tableName,
                "title", 2, 50, info.title,
                "filePath", 2, 50, info.filePath,
                "activePath", 2, 50, info.activePath,
                "templatePath", 2, 50, info.templatePath,
                "content", 2, info.content.Length, info.content,
                "typeId",1,8,info.typeId
                );

            //保存模板文件
            //saveFile(info.templatePath, info.content);
            //保存静态文件
            //saveFile(info.filePath, info.content);

            return tid;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool del(int id)
        {
            TemplateInfo info = read(id);
            dropfile(info.filePath);
            dropfile(info.templatePath);
            dropfile(info.activePath);
            drop(tableName, id.ToString());
            return true;
        }

        /// <summary>
        /// 修改文件
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="content"></param>

        public void saveFile(string filepath,string content)
        {
            string path = Server.MapPath(WEBPATH + filepath);
            if (filepath != "")
            {
                if (!File.Exists(path))
                    File.AppendAllText(path,"");
                
                StreamWriter sw = new StreamWriter(path,false,Encoding.UTF8);
                sw.Write(content);
                sw.Close();
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        private bool dropfile(string filepath)
        {
            string path = Server.MapPath(WEBPATH + filepath);
            if (filepath != "")
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }



        /// <summary>
        /// 获得所有有效ID
        /// </summary>
        /// <returns></returns>
        public ArrayList GetAllId(int tempid)
        {
            DataSet ds = getData("select * from " + tableName + " where typeId=" + tempid);
            DataRowCollection dr = ds.Tables[0].Rows;
            ArrayList al = new ArrayList();

            if (dr.Count > 0)
            {
                for(int i=0;i<dr.Count;i++)
                {
                    al.Add(dr[i]["id"]);
                }
            }
            return al;
        }

    }
}