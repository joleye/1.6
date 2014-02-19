using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using System.Data;

namespace JoleYe.Dal
{
    public class TemplateTypeDal : DalBase
    {

        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <returns></returns>
        public List<TemplateTypeInfo> view_list()
        {
            List<TemplateTypeInfo> list = new List<TemplateTypeInfo>();
            DataSet ds = DataSetFind("TemplateType");
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TemplateTypeInfo info = new TemplateTypeInfo();
                    info.id = int.Parse(dr["id"].ToString());
                    info.templateName = dr["templateName"].ToString();
                    list.Add(info);
                }
            }
            return list;
        }

        public TemplateTypeInfo view(string path)
        {
            DataSet ds = DataSetFind("TemplateType","templateName",path);
            TemplateTypeInfo info = new TemplateTypeInfo();
            if (ds.Tables[0].Rows.Count > 0)
            {
                info.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                info.templateName = ds.Tables[0].Rows[0]["templateName"].ToString();
            }
            return info;
        }
    }
}
