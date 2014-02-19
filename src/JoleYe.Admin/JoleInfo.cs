using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using JoleYe.Data;

/// <summary>
/// JoleInfo 的摘要说明
/// </summary>
/// 
namespace JoleYe.Admin
{
    public class JoleInfo:AdminPage
    {
        public JoleInfo()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        public void setInfo(int id,string str)
        {

            Base sd = new Base();
            string sql = "update JOLE_webSite set content = @content where id = @id";
            string [,] ds = new string[2,4];
            ds[1, 0] = "@id";
            ds[1, 1] = id.ToString();
            ds[1, 2] = "1";
            ds[1, 3] = "4";

            ds[0, 0] = "@content";          //参数
            ds[0, 1] = str;                 //内容
            ds[0, 2] = "2";                 //类型
            ds[0, 3] = "4000";              //大小

            sd.ExecutePrem(sql,ds);

        }
    }
}