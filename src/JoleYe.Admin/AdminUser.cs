using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JoleYe.Data;
using System.Data.OleDb;

/// <summary>
/// AdminUser 的摘要说明
/// </summary>
/// 
namespace JoleYe.Admin
{
    public class AdminUser : AdminPage
    {
        public AdminUser()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //


        }

        //添加用户

        public bool adduser(string adminName, string pwd)
        {

            string sql;
            sql = "insert into JOLE_AdminUser(UserName,[PassWord]) values(@UserName,@pwd)";
            string[,] ds = new string[2, 4];
            ds[0, 0] = "@UserName";         //参数
            ds[0, 1] = adminName;           //内容
            ds[0, 2] = "2";                 //类型
            ds[0, 3] = "32";                //大小

            ds[1, 0] = "@pwd";              //参数
            ds[1, 1] = pwd;                 //内容
            ds[1, 2] = "2";                 //类型
            ds[1, 3] = "32";                //大小

            ExecutePrem(sql, ds);
            return true;

        }

        //修改密码
        public bool UpdatePwd(string adminName, string pwd)
        {

            string sql;
            sql = "update JOLE_AdminUser set [PassWord] = @pwd where [UserName] = @UserName";
            DataSetExecuteText(sql, "@pwd", pwd, "@username", adminName);
            return true;

        }


        //检查用户名是否存在

        public bool checkUserdone(string user)
        {
            if (user != "")
            {
                string sql;
                sql = "select id from JOLE_AdminUser where UserName = '" + user + "'";
                OleDbDataReader me = Record1(sql);
                if (!me.HasRows)
                {
                    return true;
                }
                else
                    return false;

            }
            else
                return false;
        }

        //删除用户

        public bool DelUser(string user)
        {
            if (user != "" && user != "admin")
            {
                string sql;
                sql = "delete from JOLE_adminUser where UserName = '" + user + "'";
                Execute(sql);
                return true;
            }
            else
                return false;

        }
        //删除用户
        public bool DelUser(int id)
        {

            if (id != 1)
            {
                string sql;
                sql = "delete from jole_adminuser where id = " + id;
                Execute(sql);
                return true;
            }
            else
            {
                return false;
            }
        }

        //取得用户名
        public string getUser(int id)
        {
            string str = "";
            OleDbDataReader rs1 = Record1("select UserName from JOLE_AdminUser where id = " + id);

            if (rs1.Read())
            {
                str = rs1.GetValue(0).ToString(); ;
            }
            rs1.Close();

            return str;
        }
        ~AdminUser()
        {

        }
    }
}
