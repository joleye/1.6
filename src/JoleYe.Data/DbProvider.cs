using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.OleDb;
using System.Web;
using JoleYe;


/// <summary>
///  数据库库操作类
/// </summary> 

namespace JoleYe.Data
{
    public interface GetConn
    {
        OleDbConnection get();
        void Execute(string sql);
    }
    
    public interface JoleDbCommand
    {
        OleDbCommand dbCommand();
    }

    public class Base : DbSqlstring, JoleYe.Data.IBase
    {
        private int j_read_db_num = 0;
        private string dbType = "1";
        //private string j_sql;
        //private string j_table;
        //private string j_insert_files;
        //private string j_insert_values;

        //private string j_update_files;
        //private string j_update_conditions;


        #region "Properties of base class"

        public Base()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        private GetConn getConn()
        {
            return new OldDb();
        }

        /// <summary>
        ///  执行 无返回sql操作
        /// </summary>
        public void Execute(string sql)
        {
            j_read_db_num++;
            getConn().Execute(sql);
        }

        /// <summary>
        ///  执行带参数SQL语句
        /// </summary>
        public void ExecuteDataSet(string commandText, params object[] list)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = getConn().get();
            cmd.CommandText = commandText;

            for (int i = 0; i < list.Length; i = i + 4)
            {
                string len = list[i + 2].ToString();
                int leng;
                if (len != "")
                    leng = Int32.Parse(len);
                else
                    leng = 255;

                cmd.Parameters.Add(list[i].ToString(), chtype(list[i + 1].ToString()), leng);
                cmd.Parameters[list[i].ToString()].Value = list[i + 3].ToString();
            }
            cmd.ExecuteNonQuery();
            cmd.Cancel();
            cmd.Connection.Close();
            cmd.Dispose();
            j_read_db_num++;
        }

        /// <summary>
        /// 快捷添加
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        public int add(string table,params object[] list)
        {
            OleDbCommand cmd = new OleDbCommand();
            try
            {
                cmd.Connection = getConn().get();
                string commandText = query_insert(table, list);
                cmd.CommandText = commandText;

                for (int i = 0; i < list.Length; i = i + 4)
                {
                    string len = list[i + 2].ToString();
                    int leng;
                    if (len != "")
                        leng = Int32.Parse(len);
                    else
                        leng = 255;

                    //HttpContext.Current.Response.Write(list[i].ToString() + " " + list[i + 3].ToString()+" \r");
                    cmd.Parameters.Add(list[i].ToString(), chtype(list[i + 1].ToString()), leng);
                    cmd.Parameters[list[i].ToString()].Value = list[i + 3].ToString();
                }

                //HttpContext.Current.Response.End();
                object obj = cmd.ExecuteScalar();
                //object obj = cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                cmd.Dispose();
                j_read_db_num++;

                //access 不支持
                //if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                //{
                //    return 0;
                //}
                //else
                //{
                //    return int.Parse(obj.ToString());
                //}
            }
            catch
            {
                cmd.Connection.Close();
                cmd.Dispose();
                //throw;
            }
            string nid = getInfo("top 1 id", table, "1=1 order by id desc");
            if (!nid.Equals(""))
                return int.Parse(nid);
            else
                return -1;
        }


        public bool edit(string table, string condition, params object[] query)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = getConn().get();
            string commandText = query_update(table,condition,query);
            cmd.CommandText = commandText;

            for (int i = 0; i < query.Length; i = i + 4)
            {
                string len = query[i + 2].ToString();
                int leng;
                if (len != "")
                    leng = Int32.Parse(len);
                else
                    leng = 255;

                cmd.Parameters.Add(query[i].ToString(), chtype(query[i + 1].ToString()), leng);
                cmd.Parameters[query[i].ToString()].Value = query[i + 3].ToString();
            }
            object obj = cmd.ExecuteScalar();
            cmd.Connection.Close();
            cmd.Dispose();
            j_read_db_num++;

            return true;
        }

        //public DataSet DataSetExecuteText(string commText,SqlParameter[] mypar)
        //{
        //    OleDbCommand cmd = new OleDbCommand();
        //    cmd.Connection = getConn().get();
        //    cmd.CommandText = commText;
        //    foreach (SqlParameter par in mypar)
        //    {
        //        cmd.Parameters.Add(par);
        //    }
        //    cmd.ExecuteNonQuery();
            
        //}


        /// <summary>
        ///* 参数化
        ///* sql 语句
        ///* dbtv 数据源标题与内容 Array
        /// </summary>
        public void ExecutePrem(string sql, string[,] dbtv)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = getConn().get();
            cmd.CommandText = sql;

            //try
            {
                for (int dbi = 0; dbi < dbtv.Length / 4; dbi++)
                {
                    //类型
                    OleDbType dbtp;
                    dbtp = chtype(dbtv[dbi, 2]);

                    //大小
                    int intbar;
                    if (dbtv[dbi, 3] != null)
                        intbar = Int32.Parse(dbtv[dbi, 3]);
                    else
                        intbar = 1;

                    //参数化
                    cmd.Parameters.Add(dbtv[dbi, 0], dbtp, intbar);
                    cmd.Parameters[dbtv[dbi, 0]].Value = dbtv[dbi, 1];

                }

                cmd.ExecuteNonQuery();
                cmd.Connection.Close();         //关闭链接
            }
            //catch
            {
                //Response.Write("操作失败");
              //  cmd.Connection.Close();         //关闭链接
            }
            j_read_db_num++;
        }



        //类型对照
        private OleDbType chtype(string tyId)
        {
            switch (tyId)
            {
                    //整形，数字 int
                case "1":
                    return OleDbType.Integer;
                    //自定长字符，varchar
                case "2":
                    return OleDbType.VarChar;
                    //文本
                case "3":
                    return OleDbType.Binary;
                case "4":
                    return OleDbType.DBTime;
                case "5":
                    return OleDbType.Boolean;
                default:
                    return OleDbType.VarChar;
            }
        }

        //执行非查询sql语句
        public void execSqlNoneQry(string sql)
        {
            if (dbType == "1")
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = getConn().get();
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            else
            {
                Response.Write("正在开发中。。。");
                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = getConn().get();
                //cmd.CommandText = sql;
                //cmd.ExecuteNonQuery();
                //cmd.Connection.Close();
            }
        }

        //执行sql查询语句
        public OleDbDataReader Record1(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = getConn().get();
            cmd.CommandText = sql;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            j_read_db_num++;
            //dr.Close();
            //cmd.Connection.Close();
            return dr;
        }

        //执行sql查询语句
        public OleDbDataReader Record2(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = getConn().get();
            cmd.CommandText = sql;

            OleDbDataReader dr;
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            j_read_db_num++;
            return dr;
        }
        
        //返回数据
        public DataSet getData(string sql)
        {
            return find(sql);
        }

        /// <summary>
        ///  返回数据
        /// </summary>
        public DataSet find(string sql)
        {
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr.Dispose();
            cn.Close();
            j_read_db_num++;
            return ds;
        }

        /// <summary>
        /// 查找数据
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="maxRecords"></param>
        /// <returns>DataSet</returns>
        public DataSet find(string sql,int maxRecords)
        {
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr.Dispose();
            cn.Close();
            j_read_db_num++;
            return ds;
        }

        /// <summary>
        /// 根据查询条件
        /// </summary>
        /// <param name="table"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>
        public DataSet find(string table, string conditions)
        {
            string sql = "select * from " + queryT(table);
            if(!string.IsNullOrEmpty(conditions))
                sql += " where " + queryC(conditions);
            return find(sql);
        }

        /// <summary>
        /// 查询条件和order
        /// </summary>
        /// <param name="table"></param>
        /// <param name="conditions"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet find(string table, string conditions, string order)
        {
            string sql = "select * from " + queryT(table);
            if (!string.IsNullOrEmpty(conditions))
                sql += " where " + queryC(conditions);
            if (!string.IsNullOrEmpty(order))
                sql += " order by " + order;
            return find(sql);
        }

        /// <summary>
        /// 带top
        /// </summary>
        /// <param name="table"></param>
        /// <param name="top"></param>
        /// <param name="conditions"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        public DataSet find(string table,int top, string conditions, string order)
        {
            string sql = "select top "+top.ToString()+" * from " + queryT(table);
            if (!string.IsNullOrEmpty(conditions))
                sql += " where " + queryC(conditions);
            if (!string.IsNullOrEmpty(order))
                sql += " order by " + order;
            return find(sql);
        }


        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="table"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataTable find(string table, params object[] obj)
        {
            return find(table, 1, 16, obj);
        }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="table">数据表</param>
        /// <param name="startRecords">开始记录 当前页数*每页显示数量</param>
        /// <param name="sum">每页大小</param>
        /// <param name="obj">查询条件</param>
        /// <returns></returns>
        public DataTable find(string table, int page,int pagesize,params object[] obj)
        {
            return find(table, page, pagesize, "", obj);
        }

        ////////////////////////////////////////////////////////////////////////////////////

        public DataSet DataSetExecuteText(string cmdText,params object[] obj)
        {
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(cmdText, cn);

            for (int i=0;i<obj.Length;i=i+2)
            {
                if (obj[i] != null && obj[i + 1] != null)
                {
                   //print(obj[i].ToString()+"="+obj[i+1].ToString()+"\r\n");
                   dr.SelectCommand.Parameters.Add(new OleDbParameter(obj[i].ToString(), obj[i+1].ToString()));
                }
            }

            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr.Dispose();
            cn.Close();
            cn.Dispose();
            return ds;

        }

        /// <summary>
        /// 添加数据，新
        /// </summary>
        /// <param name="table"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetExecuteAddText(string table,params object[] obj)
        {
            OleDbConnection cn = getConn().get();
            string cmdText = query2_insert(table,obj);
            return DataSetExecuteText(cmdText,obj);
            
        }

        /// <summary>
        /// 修改数据，新
        /// </summary>
        /// <param name="table"></param>
        /// <param name="conditons"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetExecuteEditText(string table, string conditions,params object[] obj)
        {
            OleDbConnection cn = getConn().get();
            string cmdText = query2_update(table, conditions,obj);
            return DataSetExecuteText(cmdText, obj);

        }

        /// <summary>
        /// 带分页的返回dataset
        /// </summary>
        /// <param name="table"></param>
        /// <param name="page"></param>
        /// <param name="pagezise"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetPageFind(string table, int page, int pagezise, params object[] obj)
        {
            return DataSetExecuteText(query2_select(table, "", obj), page, pagezise, obj);
        }


        /// <summary>
        /// 带分页的返回dataset
        /// </summary>
        /// <param name="table"></param>
        /// <param name="order"></param>
        /// <param name="page"></param>
        /// <param name="pagezise"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetPageFind(string table,string order, int page, int pagezise, params object[] obj)
        {
            return DataSetExecuteText(query2_select(table, order, obj), page, pagezise, obj);
        }



        public DataSet DataSetcmdText(string cmdText,int page,int pagesize,params object[] obj)
        {
            int startRecords;
            if (page < 1)
                startRecords = 0;
            else
                startRecords = (page - 1) * pagesize;
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(cmdText, cn);

            for (int i = 0; i < obj.Length; i = i + 2)
            {
                dr.SelectCommand.Parameters.Add(new OleDbParameter("@" + obj[i].ToString(), obj[i + 1].ToString()));
            }

            DataSet ds = new DataSet();
            dr.Fill(ds,startRecords,pagesize,"dr");
            dr.Dispose();
            return ds;
        }

        public DataSet DataSetcmdText(string cmdText, params object[] obj)
        {
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(cmdText, cn);

            for (int i = 0; i < obj.Length; i = i + 2)
            {
                dr.SelectCommand.Parameters.Add(new OleDbParameter("@" + obj[i].ToString(), obj[i + 1].ToString()));
            }

            DataSet ds = new DataSet();
            dr.Fill(ds, "dr");
            dr.Dispose();
            return ds;
        }

        public DataSet DataSetExecuteText(string cmdText,int page,int pagesize, params object[] obj)
        {
            int startRecords;
            if (page < 1)
                startRecords = 0;
            else
                startRecords = (page - 1) * pagesize;

            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(cmdText, cn);

            for (int i = 0; i < obj.Length; i = i + 2)
            {
                dr.SelectCommand.Parameters.Add(new OleDbParameter("@" + obj[i].ToString(), obj[i + 1].ToString()));
            }

            DataSet ds = new DataSet();
            dr.Fill(ds,startRecords,pagesize,"dr");
            dr.Dispose();
            return ds;

        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetFind(string table, params object[] obj)
        {
            return DataSetExecuteText(query2_select(table, "", obj), obj);
        }

        /// <summary>
        /// 根据条件查询数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="order">排序</param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public DataSet DataSetFindOrder(string table, string order, params object[] obj)
        {
            return DataSetExecuteText(query2_select(table, order, obj), obj);
        }

        public bool DataSetEdit(string table, string conditions, params object[] obj)
        {
            OleDbConnection cn = getConn().get();

            OleDbCommand cmd = new OleDbCommand(query2_update(table, conditions, obj), cn);

            for (int i = 0; i < obj.Length; i = i + 2)
            {
                cmd.Parameters.Add(new OleDbParameter("@"+obj[i].ToString(), obj[i + 1].ToString()));
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            return true;
        }


        public bool DataSetAdd(string table, params object[] obj)
        {
            OleDbConnection cn = getConn().get();
            OleDbCommand cmd = new OleDbCommand(query2_insert(table, obj), cn);
            for (int i = 0; i < obj.Length; i = i + 2)
            {
                cmd.Parameters.Add(new OleDbParameter(obj[i].ToString(), obj[i + 1].ToString()));
            }
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            cn.Close();
            cn.Dispose();
            return true;
        }



        public DataTable find(string table, int page, int pagesize,string order, params object[] obj)
        {
            int startRecords;
            if (page < 1)
                startRecords = 0;
            else
                startRecords = (page - 1) * pagesize;

            DbSqlstring dstr = new DbSqlstring();
            string table_sql = dstr.query_select(table,order, obj);

            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(table_sql, cn);
            try
            {
                for (int i = 0; i < obj.Length; i = i + 4)
                {
                    dr.SelectCommand.Parameters.Add("@" + obj[i], chtype(obj[i + 1].ToString()), obj[i + 2].ToString().Length);
                    dr.SelectCommand.Parameters["@" + obj[i]].Value = obj[i + 3].ToString();
                }
            }
            catch (Exception ex)
            {

                die(ex.Message.ToString());
            }

            DataSet ds = new DataSet();
            dr.Fill(ds, startRecords, pagesize, "ds");
            dr.Dispose();
            cn.Close();

            j_read_db_num++;
            return ds.Tables[0];
        }

        //public DataTable find(string table, int page, int pagesize, string conditions,string order)
        //{
        //    int startRecords;
        //    if (page < 1)
        //        startRecords = 0;
        //    else
        //        startRecords = (page - 1) * pagesize;

        //    DbSqlstring dstr = new DbSqlstring();
        //    string table_sql = dstr.query_select(table, order, conditions);
        //    OleDbConnection cn = getConn().get();
        //    OleDbDataAdapter dr = new OleDbDataAdapter(table_sql, cn);
        //    try
        //    {
        //        for (int i = 0; i < obj.Length; i = i + 4)
        //        {
        //            dr.SelectCommand.Parameters.Add("@" + obj[i], chtype(obj[i + 1].ToString()), obj[i + 2].ToString().Length);
        //            dr.SelectCommand.Parameters["@" + obj[i]].Value = obj[i + 3].ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        die(ex.Message.ToString());
        //    }

        //    DataSet ds = new DataSet();
        //    dr.Fill(ds, startRecords, pagesize, "ds");
        //    dr.Dispose();
        //    cn.Close();

        //    j_read_db_num++;
        //    return ds.Tables[0];
        //}

        public int findcount(string table,string conditions)
        {
            return int.Parse(getInfo("count(*)", table, conditions));
        }

        public int findcount(string table)
        {
            return int.Parse(getInfo("count(*)", table,""));
        }
        /// <summary>
        ///  返回数据
        /// </summary>
        public DataSet findAll(string table,string conditions)
        {
            string sql = "select * from " + queryT(table) + " where " + queryC(conditions);
            return find(sql);
        }




 
        /// <summary>
        /// 返回单一数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>string</returns>
        public string getInfo(string sql)
        {
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet("ds");
            dr.Fill(ds);

            //string temp = "";

            if (ds.Tables[0].Rows.Count > 0)
            {
                string temp = ds.Tables[0].Rows[0][0].ToString();
                cn.Close();
                ds.Dispose();
                return temp;
            }
            else
                return "";

            //foreach (DataTable table in ds.Tables)
            //{
            //    foreach (DataRow row in table.Rows)
            //    {
            //        foreach (DataColumn column in table.Columns)
            //        {
            //            temp += row[column].ToString();
            //        }
            //    }
            //}
            ////string str = ds.Tables[0].Rows[1]["className"].ToString();
            ////Response.Write(str);
            //cn.Close();
            //ds.Dispose();
            //j_read_db_num++;
            //return temp;
        }

        /// <summary>
        /// 返回单一数据
        /// </summary>
        /// <param name="files"></param>
        /// <param name="table"></param>
        /// <param name="conditions"></param>
        /// <returns></returns>

        public string getInfo(string files, string table, string conditions)
        {
            string sql;
            sql = "select ";
            if (files != "")
                sql += files;
            else
                sql += "*";
            sql += " from " + queryT(table);

            if(conditions!="")
                sql += " where " + queryC(conditions);

            return getInfo(sql);
            //return sql;

        }

        /// <summary>
        /// 返回单行数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public DataRow get_info(string table, params object[] obj)
        {

            DbSqlstring dstr = new DbSqlstring();
            string table_sql = dstr.query_select(table, obj);
            OleDbConnection cn = getConn().get();
            OleDbDataAdapter dr = new OleDbDataAdapter(table_sql, cn);
            for (int i = 0; i < obj.Length; i = i + 4)
            {
                dr.SelectCommand.Parameters.Add("@" + obj[i], chtype(obj[i + 1].ToString()), obj[i + 2].ToString().Length);
                dr.SelectCommand.Parameters["@" + obj[i]].Value = obj[i + 3].ToString();
            }

            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr.Dispose();
            cn.Close();

            j_read_db_num++;
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            else
            {
                DataTable dt = new DataTable("dt");
                return dt.NewRow();
            }
        }

        /// <summary>
        /// 返回数据单行，sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>DataRow</returns>
        public DataRow get_info(string sql)
        {
            DataSet ds = find(sql);
            return ds.Tables[0].Rows[0];
        }

        /// <summary>
        ///  返回数据行，带条件
        /// </summary>
        /// <returns>DataRow</returns>
        public DataRow get_info(string table, string conditions)
        {
            DataSet ds = findAll(table,conditions);
            if (ds.Tables[0].Rows.Count > 0)
                return ds.Tables[0].Rows[0];
            else
            {
                DataTable dt = new DataTable("dt");
                return dt.NewRow();
            }
        }

        /// <summary>
        ///  删除快捷方式
        /// </summary>
        public void drop(string table,string conditions)
        {
            string sql;
            sql = "delete from ";
            sql += queryT(table);
            sql += " where ";
            if(conditions.IndexOf("=")>0)
                sql += conditions;
            else
                sql += " id ="+conditions;

            //return sql;
            execSqlNoneQry(sql);
        }

        /// <summary>
        ///  JOLE_webSite表操作
        /// </summary>
        public string getSite(int id)
        {
            try
            {
                OleDbDataReader rs1 = new Base().Record1("select content from JOLE_webSite where id =" + id);
                if (rs1.Read())
                {
                    string str;
                    str = rs1.GetValue(0).ToString();
                    rs1.Close();
                    return str;
                }
                else
                    return "0";
            }
            catch (NullReferenceException e)
            {

                Console.WriteLine(e.Message+"操作错误");
                return "操作错误";

            }
            finally
            {
                Console.WriteLine("清理");
            }

        }


        /// <summary>
        ///  获取website标题
        /// </summary>
        public string getTitle(int id)
        {
            OleDbDataReader rs1 = Record1("select title from JOLE_webSite where id =" + id);
            if (rs1.Read())
            {
                string str;
                str = rs1.GetValue(0).ToString();
                j_read_db_num++;
                rs1.Close();
                return str;
            }
            else
                return "0";

        }




        #endregion

        /// <summary>
        /// 统计数据库读取次数
        /// </summary>
        public int read_db_num
        {
            get {return j_read_db_num;}
        }
    }
}