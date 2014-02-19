using System;
using System.Collections.Generic;
using System.Text;

namespace JoleYe.Admin
{
    public class Ajax_edit : AdminPage
    {
        private string aj_table;
        public Ajax_edit(string table)
        {
            aj_table = table;
        }

        public bool auto_edit(string id,string field,string val)
        {
            DataSetEdit(aj_table, id,
                field, val);
            return true;
        }

        public bool product_edit(string table,int id,string field,string val)
        {
            DataSetEdit(table, id.ToString(),
                field, val);
            return true;
        }
    }
}
