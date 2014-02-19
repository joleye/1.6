using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;


/// <summary>
/// SqlDb 的摘要说明
/// 
/// </summary>
/// 
namespace JoleYe.Data
{
    public class SqlDb
    {
        #region "获取系统变量"

        protected static string dbType = ConfigurationManager.AppSettings["dbType"].ToString();
        protected static string accStrConn = ConfigurationManager.AppSettings["accStr"].ToString();
        protected static string msStrConn = ConfigurationManager.AppSettings["msStr"].ToString();
        protected static string acceccPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["AccessDbPath"].ToString());
        protected static string strSQL;

        #endregion
	    public SqlDb()
	    {
		    //
		    // TODO: 在此处添加构造函数逻辑
		    //
	    }

        //关闭OleDb
        //建立MSSQL数据库连接
        private SqlConnection getMsConn()
        {
            SqlConnection conn = new SqlConnection(msStrConn.ToString());
            conn.Open();
            return conn;
        }

    }
}