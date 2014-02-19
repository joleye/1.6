using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using System.Data;

namespace JoleYe.Dal
{
    public class Auto_pageDal : DalBase
    {
        public bool add(Auto_pageInfo info)
        {
            DataSetAdd("auto_page", "page_name", info.page_name,
                "setting", info.setting,
                "content", info.content);
            return true;
        }

        public bool drop(int id)
        {
            drop("auto_page", id.ToString());
            return true;
        }

        public bool edit(Auto_pageInfo info, string conditions)
        {
            DataSetEdit("auto_page", conditions,
                "page_name", info.page_name,
                "setting", info.setting,
                "content", info.content);
            return true;
        }

        public Auto_pageInfo view(int id)
        {
            DataSet ds = DataSetFind("auto_page", "id",id.ToString());
            Auto_pageInfo info = new Auto_pageInfo();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count>0)
            {
                DataRow dr = ds.Tables[0].Rows[0];

                info.id = int.Parse(dr["id"].ToString());
                info.page_name = dr["page_name"].ToString();
                info.setting = dr["setting"].ToString();
                info.content = dr["content"].ToString();

            }
            return info;
        }

        public List<Auto_pageInfo> read(params object[] obj)
        {
            List<Auto_pageInfo> list = new List<Auto_pageInfo>();
            DataSet ds = DataSetFind("auto_page",obj);
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Auto_pageInfo info = new Auto_pageInfo();
                    info.id = int.Parse(dr["id"].ToString());
                    info.page_name = dr["page_name"].ToString();
                    info.setting = dr["setting"].ToString();
                    info.content = dr["content"].ToString();
                    list.Add(info);
                }
            }
            return list;
        }
    }
}
