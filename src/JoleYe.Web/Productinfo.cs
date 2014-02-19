using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JoleYe.Dal;
using JoleYe.Model;

namespace JoleYe.Web
{
    public class Productinfo : Frontend
    {
        public DataRow datarow;
        public string p_typename;
        public string p_parenttypename;
        public string page_proup,page_pronext;
        public ProductInfo info;

        public Productinfo()
        {
            flg_nav = "product";
            int pid = 0;
            gnum(ref pid,"id");
            info = new ProductDal().view(pid);
            pagetitle = info.productName;


            //datarow = get_info("product","id", 1, 8, pid);
            //pagetitle = datarow["productName"].ToString();

            get_productType(info.TypeId);
            page_proup = get_sametypeup();
            page_pronext = get_sametypenext();

        }

        /// <summary>
        /// 其他同类产品
        /// </summary>
        /// <returns></returns>
        public string get_sametypeup()
        {
            DataSet ds = find("product",1, "id>"+info.Id+" and typeId=" +info.TypeId, "id");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    return "<a href=\"productinfo-"+dr["id"].ToString()+".aspx\">"+dr["productName"].ToString()+"</a>";
                }
            }
            return "已经没有了";
        }

        public string get_sametypenext()
        {
            DataSet ds = find("product", 1, "id<" + info.Id + " and typeId=" + info.TypeId, "id desc");

            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    return "<a href=\"productinfo-" + dr["id"].ToString() + ".aspx\">" + dr["productName"].ToString() + "</a>";
                }
            }
            return "已经没有了";
        }

        public void get_productType(int typeId)
        {
            ProductTypeDal type = new ProductTypeDal();
            ProductTypeInfo info =  type.read(typeId);
            p_typename = info.typeName;
            p_parenttypename = type.read(info.parentId).typeName;
        }

    }
}
