using System;
using System.Collections.Generic;
using System.Text;
using JoleYe;
using System.Configuration;

namespace JoleYe.Data
{
    public class DbSqlstring : Obj
    {
        protected string j_sql;
        protected string j_table;
        protected string j_insert_files;
        protected string j_insert_values;

        protected string j_update_files;
        protected string j_update_conditions;
        protected string label_table = ConfigurationManager.AppSettings["PreTable"];



        #region "sql insert 语句快捷方法"

        //表
        protected void add_table(string tables)
        {
            j_table = label_table + tables;
        }

        //插入
        protected void insert_file(string querySql)
        {
            if (j_insert_files != "" && j_insert_files != null)
            {
                j_insert_files += "," + querySql;
            }
            else
            {
                j_insert_files = querySql;
            }

            insert_value(querySql);

        }

        //插入值
        protected void insert_value(string querySql)
        {
            if (j_insert_values != "" && j_insert_values != null)
            {
                j_insert_values += ",@" + querySql;
            }
            else
            {
                j_insert_values = "@" + querySql;
            }
        }

        protected string get_insert_sql()
        {
            return "insert into " + j_table + "(" + j_insert_files + ") values(" + j_insert_values + ")";
        }

        #endregion

        #region "sql update 快捷方法"
        protected void update_file(string querySql)
        {
            if (j_update_files != "" && j_update_files != null)
            {
                j_update_files += "," + querySql + "=" + "@" + querySql;
            }
            else
            {
                j_update_files += querySql + "=" + "@" + querySql;
            }

        }

        protected void update_conditions(string querySql)
        {
            j_update_conditions = querySql + "=@" + querySql;
        }

        /// <summary>
        ///  获取修改sql
        /// </summary>
        protected string get_update_sql()
        {
            return "update " + j_table + " set " + j_update_files + " where " + j_update_conditions;
        }

        #endregion

        public string query_select(string table, params object[] obj)
        {
            return query_select(table, "", obj);
        }

        #region "拼接"
        public string query_select(string table,string order, params object[] obj)
        {
            StringBuilder sb = new StringBuilder();
            string fields = "";
            string conditions = "";
            for (int i = 0; i < obj.Length; i = i + 4)
            {
                fields += obj[i];
                conditions += "" + obj[i] + "=@" + obj[i] + " ";
                if ((i + 4) % 4 == 0 && i + 4 < obj.Length)
                {
                    conditions += " and ";
                    fields += ",";
                }
            }
            sb.Append("select ");
            sb.Append("*");
            sb.Append(" from ");
            if (table.IndexOf(label_table) == -1)
                sb.Append(label_table);
            sb.Append(table);
            if (!string.IsNullOrEmpty(conditions))
                sb.Append(" where " + conditions);

            if (!string.IsNullOrEmpty(order))
                sb.Append(" order by " + order);

            //echo(sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 插入快捷方式拼合sql
        /// </summary>
        /// <param name="table"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string query_insert(string table,params object[] obj)
        {
            StringBuilder sb = new StringBuilder();

            string fields = "";
            string values = "";
            for (int i = 0; i < obj.Length; i = i + 4)
            {
                fields += "["+obj[i]+"]";
                values += "@" + obj[i];
                if ((i + 4) % 4 == 0 && i + 4 < obj.Length)
                {
                    fields += ",";
                    values += ",";
                }
            }
            sb.Append("insert into ");
            sb.Append(queryT(table) + "(");

            if (!string.IsNullOrEmpty(fields))
                sb.Append(fields + ")");

            if (!string.IsNullOrEmpty(values))
                sb.Append(" values(" + values + ")");

            //sb.Append("select @@IDENTITY;"); access 不支持

            return sb.ToString();
        }



        /// <summary>
        /// 拼凑修改语句
        /// </summary>
        /// <param name="table"></param>
        /// <param name="condition"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string query_update(string table,string condition, params object[] obj)
        {
            StringBuilder sb = new StringBuilder();

            string values = "";
            for (int i = 0; i < obj.Length; i = i + 4)
            {
                values += "["+obj[i]+"]=@" + obj[i];
                if ((i + 4) % 4 == 0 && i + 4 < obj.Length)
                {
                    values += ",";
                }
            }
            sb.Append("update "+queryT(table)+"  set ");
            sb.Append(values);
            sb.Append(" ");
            if (!string.IsNullOrEmpty(condition))
            {
                sb.Append("where ");
                sb.Append(queryC(condition));
            }
            return sb.ToString();
        }

        #endregion

        /// <summary>
        /// 判别表名
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected string queryT(string table)
        {
            if (table.IndexOf(label_table) == -1)
            {
                return label_table + table;
            }
            else
                return table;
        }

        /// <summary>
        /// 判断条件
        /// </summary>
        /// <param name="conditions"></param>
        /// <returns></returns>
        protected string queryC(string conditions)
        {
            if (conditions.IndexOf("=") == -1 && conditions.IndexOf(">") == -1 && conditions.IndexOf("<") == -1)
            {
                return "id=" + conditions;
            }
            else
                return conditions;
        }




        #region "语法拼接，不用数据类型"
        ///////////////////////////////////
        /// <summary>
        /// 查询语法拼接，不用数据类型
        /// </summary>
        /// <param name="table"></param>
        /// <param name="order"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string query2_select(string table, string order, params object[] obj)
        {
            StringBuilder sb = new StringBuilder();
            string fields = "";
            string conditions = "";
            for (int i = 0; i < obj.Length; i = i + 2)
            {
                fields += obj[i];
                conditions += "" + obj[i] + "=@" + obj[i] + " ";
                if ((i + 2) % 2 == 0 && i + 2 < obj.Length)
                {
                    conditions += " and ";
                    fields += ",";
                }
            }
            sb.Append("select ");
            sb.Append("*");
            sb.Append(" from ");
            sb.Append(queryT(table));
            if (!string.IsNullOrEmpty(conditions))
                sb.Append(" where " + queryC(conditions));

            if (!string.IsNullOrEmpty(order))
                sb.Append(" order by " + order);

            return sb.ToString();
        }

        /// <summary>
        /// 插入数据拼接
        /// </summary>
        /// <param name="table"></param>
        /// <param name="order"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string query2_insert(string table,params object[] obj)
        {
            StringBuilder sb = new StringBuilder();

            string fields = "";
            string values = "";
            for (int i = 0; i < obj.Length; i = i + 2)
            {
                if (obj[i + 1] != null)
                {
                    fields += "[" + obj[i] + "]";
                    values += "@" + obj[i];
                    if ((i + 2) % 2 == 0 && i + 2 < obj.Length)
                    {
                        fields += ",";
                        values += ",";
                    }
                }
            }
            sb.Append("insert into ");
            sb.Append(queryT(table) + "(");

            if (!string.IsNullOrEmpty(fields))
                sb.Append(fields + ")");

            if (!string.IsNullOrEmpty(values))
                sb.Append(" values(" + values + ")");

            //sb.Append("select @@IDENTITY;"); access 不支持

            return sb.ToString();
        }

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <param name="table"></param>
        /// <param name="condition"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected string query2_update(string table, string condition, params object[] obj)
        {
            StringBuilder sb = new StringBuilder();

            string values = "";
            for (int i = 0; i < obj.Length; i = i + 2)
            {
                if (obj[i + 1] != null)
                {
                    values += "[" + obj[i] + "]=@" + obj[i];
                    if ((i + 2) % 2 == 0 && i + 2 < obj.Length)
                    {
                        values += ",";
                    }
                }
            }
            sb.Append("update " + queryT(table) + "  set ");
            sb.Append(values);
            sb.Append(" ");
            if (!string.IsNullOrEmpty(condition))
            {
                sb.Append("where ");
                sb.Append(queryC(condition));
            }
            return sb.ToString();
        }
        #endregion

        public string format_sql(string sql)
        {
            return sql.Replace("@PRE_", label_table);
        }
    }
}
