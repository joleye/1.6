using System;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

/// <summary>
/// OldDb 的摘要说明
/// </summary>
/// 
namespace JoleYe.Data
{
    public class OldDb:GetConn
    {

        #region "获取系统变量"

        protected static string dbType = ConfigurationManager.AppSettings["dbType"].ToString();
        protected static string accStrConn = ConfigurationManager.AppSettings["accStr"].ToString();
        protected static string msStrConn = ConfigurationManager.AppSettings["msStr"].ToString();
        protected static string acceccPath = System.Web.HttpContext.Current.Server.MapPath(JoleYe.Obj.WEBPATH + ConfigurationManager.AppSettings["AccessDbPath"].ToString());

        protected static string strSQL;

        #endregion

        public OldDb()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        //建立Access数据库连接
        public OleDbConnection get()
        {
            OleDbConnection con;
            con = new OleDbConnection(accStrConn.ToString() + acceccPath.ToString());
            con.Open();
            return con;
        }

        //执行无返回类型 sql
        public void Execute(string sql)
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = get();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
        }

        //返回dataset类型数据
        public DataSet GetDataSet(string sql)
        {
            OleDbConnection cn = get();
            OleDbDataAdapter dr = new OleDbDataAdapter(sql, cn);
            DataSet ds = new DataSet();
            dr.Fill(ds);
            dr.Dispose();
            cn.Close();
            return ds;
        }

        //返回表数据
        public DataTable GetDataTable(string sql)
        {            
            return GetDataSet(sql).Tables[0];
        }

    }

}