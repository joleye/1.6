using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using JoleYe.Dal;
using JoleYe.Model;

namespace JoleYe.Web
{
    public class Search : Frontend
    {
        public string pageBox;
        public string type_name;
        public Search()
        {
            flg_nav = "product";
            
            int id = 0;
            gnum(ref id, "tid");
            type_name = getInfo("typeName","produceType","id="+id.ToString());
            pagetitle = type_name;
        }

        public DataTable get_list()
        {
            int id = 0;
            gnum(ref id,"tid");
            int page = 1;
            int pagesize = 12;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");

            int recordcount = findcount("produce","typeId="+id);

            pageBox = pc.page_list("?page=", pagesize, recordcount);
            DataTable dt = find("produce", page, pagesize,"showId,id desc",
                "typeId",1,8,id.ToString());
            //DataTable dt = new DataTable();
            return dt;
        }

        public List<ProductInfo> search()
        {
            ProductDal pro = new ProductDal();
            int id = 0;
            gnum(ref id, "tid");
            int page = 1;
            int pagesize = 12;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            List<JoleYe.Model.ProductInfo> list = pro.view_list(id,page,pagesize);

            int recordcount = pro.recordcount;
            pageBox = pc.page_list("?page=", pagesize, recordcount);

            return list;
        }




    }
}
