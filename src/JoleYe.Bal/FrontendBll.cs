using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JoleYe.Data;
using System.Web;
using System.IO;

namespace JoleYe.Bll
{
    public class FrontendBll : BllBase
    {
        //public new System.Web.SessionState.HttpSessionState Session
        //{
        //    get { return HttpContext.Current.Session; }
        //    //set { }
        //}

        public FrontendBll()
        {


        }

        /// <summary>
        /// ÷±Ω”sql”Ôæ‰
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable get_sql(string sql)
        {
            sql = new DbSqlstring().format_sql(sql);
            return DataSetExecuteText(sql).Tables[0] ;
        }

        public new HttpResponse Response
        {
            get { return HttpContext.Current.Response; }
        }

        public new HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }

        

    }
}
