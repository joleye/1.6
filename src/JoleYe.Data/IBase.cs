using System;
namespace JoleYe.Data
{
    interface IBase
    {
        int add(string table, params object[] list);
        System.Data.DataSet DataSetExecuteText(string cmdText, params object[] obj);
        void drop(string table, string conditions);
        bool edit(string table, string condition, params object[] query);
        void execSqlNoneQry(string sql);
        void Execute(string sql);
        void ExecuteDataSet(string commandText, params object[] list);
        void ExecutePrem(string sql, string[,] dbtv);
        System.Data.DataSet find(string table, int top, string conditions, string order);
        System.Data.DataSet find(string table, string conditions, string order);
        System.Data.DataTable find(string table, params object[] obj);
        System.Data.DataTable find(string table, int page, int pagesize, string order, params object[] obj);
        System.Data.DataTable find(string table, int page, int pagesize, params object[] obj);
        System.Data.DataSet find(string sql);
        System.Data.DataSet find(string sql, int maxRecords);
        System.Data.DataSet find(string table, string conditions);
        System.Data.DataSet findAll(string table, string conditions);
        int findcount(string table, string conditions);
        int findcount(string table);
        System.Data.DataRow get_info(string table, params object[] obj);
        System.Data.DataRow get_info(string sql);
        System.Data.DataRow get_info(string table, string conditions);
        //GetConn getConn();
        System.Data.DataSet getData(string sql);
        string getInfo(string sql);
        string getInfo(string files, string table, string conditions);
        string getSite(int id);
        string getTitle(int id);
        int read_db_num { get; }
        System.Data.OleDb.OleDbDataReader Record1(string sql);
        System.Data.OleDb.OleDbDataReader Record2(string sql);
    }
}
