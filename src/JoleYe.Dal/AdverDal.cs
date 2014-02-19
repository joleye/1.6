using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using System.Data;
using JoleYe.Model;

namespace JoleYe.Dal
{
    public class AdverDal : Base
    {
        public DataTable view_list()
        {
            DataSet ds = DataSetFind("adver");
            return ds.Tables[0];
        }

        public bool edit(AdverInfo info, int id)
        {
            DataSetEdit("adver", id.ToString(),
                    "linkurl", info.linkurl,
                    "imgurl", info.imgurl);
            return true;
        }
    }
}
