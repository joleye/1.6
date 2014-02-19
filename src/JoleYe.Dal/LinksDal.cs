using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using System.Data;
using JoleYe;
using JoleYe.Model;

namespace JoleYe.Dal
{
    //友情链接操作
    public class LinksDal : DalBase
    {

        //读取
        public LinkInfo read(int id)
        {
            DataRow da = get_info("link", id.ToString());
            LinkInfo info = new LinkInfo();
            info.linkName = da["linkName"].ToString();
            info.linkUrl = da["linkUrl"].ToString();
            info.imgUrl = da["imgUrl"].ToString();
            return info;
        }

        /// <summary>
        /// 添加新地址
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool addnew(LinkInfo info)
        {
            this.add_table("link");
            this.insert_file("linkName");
            this.insert_file("linkUrl");
            this.insert_file("imgUrl");

            ExecuteDataSet(this.get_insert_sql(),
                "@linkName",2,50,info.linkName,
                "@linkUrl",2,50,info.linkUrl,
                "@imgUrl",2,255,info.imgUrl
                );
            return true;
        }

        //删除
        public bool del(int id)
        {
            string path = getInfo("imgUrl","link","id="+id);
            new Img().dropimg(path);
            drop("link", id.ToString());
            return true;
        }

        //修改
        public void edit(LinkInfo info)
        {
            this.add_table("link");
            this.update_file("linkName");
            this.update_file("linkUrl");
            this.update_file("imgUrl");
            this.update_conditions("id");

            ExecuteDataSet(this.get_update_sql(),
                "@linkName", 2, 50, info.linkName,
                "@linkUrl", 2, 50, info.linkUrl,
                "@imgUrl",2,255,info.imgUrl,
                "@id", 1, 4, info.id
                );
            
        }
    }
}
