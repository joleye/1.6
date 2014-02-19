using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using JoleYe.Model;
using System.Data;

namespace JoleYe.Dal
{
    public class JmDal : Base
    {
        //¶ÁÈ¡
        public JmInfo read(int id)
        {
            DataRow da = get_info("jm", id.ToString());
            JmInfo info = new JmInfo();
            info.Id = Int32.Parse(da["id"].ToString());
            info.uname = da["uname"].ToString();
            info.age = da["age"].ToString();
            info.address = da["address"].ToString();
            info.telphone = da["telphone"].ToString();
            info.fax = da["fax"].ToString();
            info.company = da["company"].ToString();
            info.comaddress = da["comaddress"].ToString();
            info.zijin = da["zijin"].ToString();
            info.content = da["content"].ToString();
            return info;
        }

        public bool addnew(JmInfo info)
        {
            add("jm",
                "uname", 2, 50, info.uname,
                "age", 2, 50, info.age,
                "address", 2, 50, info.address,
                "telphone", 2, 50, info.telphone,
                "fax", 2, 50, info.fax,
                "company", 2, 50, info.company,
                "comaddress", 2, 50, info.comaddress,
                "zijin", 2, 50, info.zijin,
                "content",2,info.content.Length,info.content
                );
            return true;
        }

        //É¾³ý
        public bool del(int id)
        {
            drop("jm", id.ToString());
            return true;
        }

        //ÐÞ¸Ä
        public void edit(JmInfo info)
        {

            edit("jm","id="+info.Id.ToString(),
                "uname", 2, 50, info.uname,
                "age", 2, 50, info.age,
                "address", 2, 50, info.address,
                "telphone", 2, 50, info.telphone,
                "fax", 2, 50, info.fax,
                "company", 2, 50, info.company,
                "comaddress", 2, 50, info.comaddress,
                "zijin", 2, 50, info.zijin,
                "content", 2, info.content.Length, info.content
                );

        }
    }
}
