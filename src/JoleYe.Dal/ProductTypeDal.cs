using System;
using System.Collections.Generic;
using System.Text;
using JoleYe.Data;
using JoleYe.Model;
using System.Data;

namespace JoleYe.Dal
{
    public class ProductTypeDal : Base
    {
        string tableName;

        public ProductTypeDal()
        {
            tableName = "JOLE_productType";
        }

        /// <summary>
        /// 读取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductTypeInfo read(int id)
        {
            ProductTypeInfo tp = new ProductTypeInfo();
            DataSet ds = find("productType", id.ToString());

            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    tp.typeName = dr["typeName"].ToString();
                    tp.imgUrl = dr["imgUrl"].ToString();
                    tp.parentId = Int32.Parse(dr["parentId"].ToString());
                    tp.orderId = int.Parse(dr["orderId"].ToString());
                    tp.content = dr["content"].ToString();
                    tp.id = id;
                }
            }
            return tp;
        }


        /// <summary>
        /// 添加产品小类
        /// </summary>
        /// <param name="id"></param>
        /// <param name="info"></param>
        /// <returns></returns>
        public int AddType(ProductTypeInfo info)
        {
            int id = add(tableName,
                "parentId",1,8,info.parentId,
                "typeName",2,255,info.typeName,
                "imgUrl",2,255,info.imgUrl,
                "orderId",1,8,info.orderId,
                "content",2,info.content.Length,info.content
                );
            return id;
        }
        
        /// <summary>
        /// 修改产品类型
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public bool Update(ProductTypeInfo info)
        {
//            DataSetExecuteText(@"update JOLE_produceType set typeName=@typeName,
//            imgUrl=@imgUrl,orderId=@orderId,content=@content where id=@id",
//                            "@id", info.id,
//                            "@typeName", info.typeName,
//                            "@imgUrl", info.imgUrl,
//                            "@orderId", info.orderId,
//                            "@content", info.content);

            edit(tableName, info.id.ToString(),
                "typeName", 2, 255, info.typeName,
                "imgUrl", 2, 255, info.imgUrl,
                "orderId", 1, 8, info.orderId,
                "content", 2, info.content.Length, info.content
                );
            return true;
        }
        
        /// <summary>
        /// 删除产品类型
        /// </summary>
        /// <param name="typeId"></param>
        public void DelType(int typeId)
        {
            //删除下一级分类
            drop(tableName, "parentId="+typeId.ToString());
            //删除分类
            drop(tableName, typeId.ToString());
        }

        /// <summary>
        /// 读父类数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductTypeInfo load_parent(int id)
        {
            ProductTypeInfo tp = new ProductTypeInfo();
            DataRow dr = get_info("productType", "parentId="+id.ToString());
            if (!dr.IsNull("id"))
            {
                tp.typeName = dr["typeName"].ToString();
                tp.imgUrl = dr["imgUrl"].ToString();
                tp.parentId = Int32.Parse(dr["parentId"].ToString());
                tp.orderId = int.Parse(dr["orderId"].ToString());
                tp.id = id;
            }
            return tp;
        }

        /// <summary>
        /// 大类列表
        /// </summary>
        /// <returns></returns>
        public List<ProductTypeInfo> Getbigtypelist()
        {
            List<ProductTypeInfo> list = new List<ProductTypeInfo>();

            DataSet ds = find("productType", "parentId=0");
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ProductTypeInfo info = new ProductTypeInfo();
                        info.typeName = dr["typeName"].ToString();
                        info.imgUrl = dr["imgUrl"].ToString();
                        info.parentId = Int32.Parse(dr["parentId"].ToString());
                        info.orderId = int.Parse(dr["orderId"].ToString());
                        info.id = int.Parse(dr["id"].ToString()) ;
                        list.Add(info);
                    }
                }
            }
            return list;
        }
    }
}
