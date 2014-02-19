using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using JoleYe.Dal;

namespace JoleYe.Web
{
    public class Listinfo : Frontend
    {
        public string pageBox;
        public int typeId = 0;
        public string typetitle;
        public Listinfo()
        {
            gnum(ref typeId, "typeid");

            ArticleClass dal = new ArticleClass();
            typetitle = dal.get_typename(typeId).ClassName;
            flg_nav = "listinfo";
            pagetitle = "在线资料";
        }

        public DataTable get_list()
        {
            return get_list(10);
        }

        public DataTable get_list(int psize)
        {
            int page = 1;
            int pagesize = psize;
            PageCurrent pc = new PageCurrent();
            page = pc.get("page");
            DataTable dt;
            if (typeId > 0)
            {
                int recordcount = findcount("article", "classId=" + typeId.ToString());

                pageBox = pc.page_list("?page=", pagesize, recordcount);


                dt = find("article", page, pagesize, "id desc",
                    "classId", 1, 8, typeId
                    );

            }
            else
            {
                int recordcount = findcount("article", "");

                pageBox = pc.page_list("?page=", pagesize, recordcount);


                dt = find("article", page, pagesize, "id desc"
                    );
            }
            return dt;
            
        }
    }
}
