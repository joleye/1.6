using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Model;
using System.Data;
using System.Data.SqlClient;
using JoleYe.Data;

namespace JoleYe.Dal
{
    public class AlbumDal : Base
    {

        /// <summary>
        /// 读取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public AlbumInfo GetModel(int id)
        {
            DataRow dr = get_info("Album", id.ToString());
            AlbumInfo info = new AlbumInfo();
            if (!dr.IsNull("id"))
            {
                info.id = int.Parse(dr["id"].ToString());
                info.album_name = dr["album_name"].ToString();
                info.imgUrl = dr["imgUrl"].ToString();
                info.postDate = dr["postDate"].ToString();
                info.linkUrl = dr["linkUrl"].ToString();
                info.showHome = bool.Parse(dr["showHome"].ToString());
            }
            return info;
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int add(AlbumInfo info)
        {
            int id = add("album",
                "album_name", 2, 50, info.album_name,
                "imgUrl", 2, 255, info.imgUrl,
                "linkUrl",2,255,info.linkUrl,
                "showHome",5,1,info.showHome
                );
            return id;
        }

        /// <summary>
        /// 读取列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public DataTable GetList(int page,int pagesize)
        {
            return find("album", page, pagesize,"orderId,id desc");
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool del(int id)
        {
            string path = getInfo("imgUrl", "album", id.ToString());
            new Img().dropimg(path);
            drop("album", id.ToString());
            return true;
        }

        /// <summary>
        /// 是否首页显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool updateShomeHome(int id,AlbumInfo info)
        {
            return edit("Album",id.ToString(),
                "showHome",5,8,info.showHome
                );
        }

        //public AlbumInfo view(int id)
        //{
        //    //DataSet ds = ExecuteDataSet(queryT("article"),"@id",id);

        //}

    }
}
