using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Data;
using JoleYe.Dal;
using JoleYe.Model;

namespace JoleYe.Web
{
    public class Productlist : Frontend
    {
        public string pageBox;
        public Productlist()
        {
            pagetitle = "产品展示";
            flg_nav = "product";
        }

        public DataTable get_list()
        {
            int pagesize = 9;
            PageCurrent pc = new PageCurrent();
            int page = pc.get("page");
            int recordcount = findcount("product");

            pageBox = pc.page_list("?page=", pagesize, recordcount);


            DataTable dt = find("product", page, pagesize,"id desc");
            return dt;

        }

        public List<ProductTypeInfo> getprotypelist()
        {
            ProductTypeDal pt = new ProductTypeDal();
            return pt.Getbigtypelist();
        }

    }
}
