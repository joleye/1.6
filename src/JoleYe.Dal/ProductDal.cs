using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using JoleYe.Model;
using System.Data;
using System.IO;

namespace JoleYe.Dal
{
    public class ProductDal : Base
    {
        private int j_recordcount;
        public ProductDal()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 读取产品信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductInfo read(int id)
        {
            ProductInfo pro = new ProductInfo();

            DataSet so = getData("select * from " + queryT("product") + " where id =" + id);

            if (so.Tables.Count == 0)
                return pro;

            if (so.Tables[0].Rows.Count == 0)
                return pro;

            DataTable dt = so.Tables[0];
            DataRow dr = dt.Rows[0];
            //DataColumn dc = dt.Rows[0];

            pro.Id = Int32.Parse(dr["id"].ToString());
            pro.productName = dr["productName"].ToString();

            pro.TypeId = Int32.Parse(dr["TypeId"].ToString());
            pro.productImgUrl = dr["productImgUrl"].ToString();
            pro.productImgUrl_S = dr["productImgUrl_S"].ToString();
            pro.title1 = dr["title1"].ToString();
            pro.title2 = dr["title2"].ToString();

            pro.content = dr["content"].ToString();
            pro.content1 = dr["content1"].ToString();
            pro.content2 = dr["content2"].ToString();
            pro.content3 = dr["content3"].ToString();

            pro.showHome = bool.Parse(dr["showHome"].ToString());

            pro.price = new Price(dr["price"].ToString());
            pro.HitNum = cint(dr["hitNum"].ToString());
            return pro;
        }

        public ProductInfo view(int id)
        {
            Execute("update " + queryT("product") + " set hitNum=hitNum+1 where id=" + id);
            return read(id);
        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool del(int id)
        {
            delImg(id);
            drop("JOLE_Product", id.ToString());
            return true;
        }

        /// <summary>
        /// 删除图片
        /// </summary>
        /// <param name="id"></param>
        public void delImg(int id)
        {
            try
            {
                string ds = getInfo("productImgUrl", "Produce", "id =" + id);
                if (ds != "")
                {
                    ds = Server.MapPath(ds);
                    //删除相关格式图片
                    if (File.Exists(ds))
                        File.Delete(ds);
                }

                string ds1 = getInfo("productImgUrl_S", "Produce", "id =" + id);
                if (ds1 != "")
                {
                    ds1 = Server.MapPath(ds);
                    //删除相关格式图片
                    if (File.Exists(ds1))
                        File.Delete(ds1);
                }
            }
            catch { }

        }

        /// <summary>
        /// 创建一条产品信息
        /// </summary>
        /// <param name="proinfo"></param>
        public void createProduct(ProductInfo proinfo)
        {
            DataSetExecuteAddText("product",
                "productName",proinfo.productName,
                "typeId",proinfo.TypeId,
                "content",proinfo.content,
                "productImgUrl",proinfo.productImgUrl,
                "productImgUrl_S",proinfo.productImgUrl_S,
                "title1",proinfo.title1,
                "title2",proinfo.title2,
                "content1",proinfo.content1,
                "content2",proinfo.content2,
                "content3",proinfo.content3
            );
        }

        /// <summary>
        /// 修改产品信息
        /// </summary>
        /// <param name="proinfo"></param>
        public void updateProduct(ProductInfo proinfo)
        {
            DataSetExecuteEditText("product", "id=" + proinfo.Id.ToString(),
                "productName", proinfo.productName,
                "typeId", proinfo.TypeId,
                "content", proinfo.content,
                "productImgUrl", proinfo.productImgUrl,
                "productImgUrl_S", proinfo.productImgUrl_S,
                "title1", proinfo.title1,
                "title2", proinfo.title2,
                "content1", proinfo.content1,
                "content2", proinfo.content2,
                "content3", proinfo.content3
                );
        }

        /// <summary>
        /// 首页显示
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool setShowHome(int id, ProductInfo info)
        {
            edit("product", id.ToString(),
                "showHome", 5, 1, info.showHome
                );
            return true;
        }

        public DataTable view_list(int page,int pagesize,int typeid,string wd)
        {
            if (pagesize == 0)
                pagesize = 10;

            string sql = "select p.*,t.typename from " + label_table + "product p left join "+
                label_table+"producttype t on t.id=p.typeid"
                +" where productName like '%"+wd+"%'";
            DataSet ds = DataSetcmdText(sql,page,pagesize,"@wd",wd);
            j_recordcount = findcount("product", "");


            return ds.Tables[0];


        }

        /// <summary>
        /// 产品列表
        /// </summary>
        /// <returns></returns>
        public List<ProductInfo> view_list()
        {
            List<ProductInfo> list = new List<ProductInfo>();
            string sql = "select * from " + label_table + "product";
            DataSet ds = DataSetcmdText(sql);
            j_recordcount = findcount("product", "");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductInfo info = new ProductInfo();
                        info.Id = int.Parse(dr["id"].ToString());
                        info.productName = dr["productName"].ToString();
                        info.content = dr["content"].ToString();
                        info.productImgUrl = dr["productImgUrl"].ToString();
                        info.productImgUrl_S = dr["productImgUrl_S"].ToString();
                        list.Add(info);
                    }
                }
            }
            return list;
        }



        /// <summary>
        /// 像下查找产品列表
        /// </summary>
        /// <param name="typeid"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <returns></returns>
        public List<ProductInfo> view_list(int typeid, int page, int pagesize)
        {
            List<ProductInfo> list = new List<ProductInfo>();
            string conditions = "typeId in (select id from " + label_table + "productType where id=" + typeid.ToString() + " or parentId=" + typeid.ToString() + ")";
            string sql = "select * from " + label_table + "product where " + conditions + " order by showId asc,id asc";
            DataSet ds = DataSetcmdText(sql, page, pagesize);
            j_recordcount = findcount("product", conditions);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductInfo info = new ProductInfo();
                        info.Id = int.Parse(dr["id"].ToString());
                        info.productName = dr["productName"].ToString();
                        info.content = dr["content"].ToString();
                        info.productImgUrl = dr["productImgUrl"].ToString();
                        info.productImgUrl_S = dr["productImgUrl_S"].ToString();
                        list.Add(info);
                    }
                }
            }
            return list;
        }

        public int recordcount
        {
            get { return j_recordcount; }
        }


        public void setOrder(int id, int showId)
        {
            DataSetEdit("product", id.ToString(), "showId", showId);
        }

        /// <summary>
        /// 生成小图片
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool set_thumbs_img(int Id, int size)
        {
            return set_thumbs_img(Id, size, size.ToString());
        }

        /// <summary>
        /// 生成小图片
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="size"></param>
        /// <param name="flg"></param>
        /// <returns></returns>
        public bool set_thumbs_img(int Id, int size, string flg)
        {
            Img img = new Img();
            ProductInfo info = read(Id);
            return img.MakeThumbnail(System.Web.HttpContext.Current.Server.MapPath(info.productImgUrl),
                cimg(System.Web.HttpContext.Current.Server.MapPath(info.productImgUrl), flg), size, size, "save");
        }


        public bool set_attr(int Id, int typeid)
        {
            DataSetEdit("product", Id.ToString(), "typeId", typeid);
            return true;
        }

        /// <summary>
        /// 读取基类类名
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public string get_first_type(int Id)
        {
            DataSet ds = DataSetExecuteText("select typeName from jole_producttype where id = (select typeId from jole_product where id = @Id)",
                "@Id", Id);

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return ds.Tables[0].Rows[0]["typeName"].ToString();
                }
            }
            return "";
        }
    }
}
