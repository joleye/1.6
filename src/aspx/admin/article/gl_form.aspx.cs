using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web;
using System.IO;
using JoleYe.Dal;


namespace JoleYe.Admin
{
    public partial class gl_form : AdminPage
    {
        private int id;
        private string app;
        protected int classid;

        protected void Page_Load(object sender, EventArgs e)
        {
            string toid = Request.QueryString["id"];
            classid = 0;
            gnum(ref classid, "classid");
            if (toid != null)
                id = Int32.Parse(toid);
            app = Request.QueryString["app"];
            if (!IsPostBack)
            {
                ArticleClass dal = new ArticleClass();
                classId.DataSource = dal.view_list();
                classId.DataBind();

                if (app == "edit")
                    editArticle(id);
            }
        }

        //编辑绑定
        private void editArticle(int id)
        {

            ArticleDal red = new ArticleDal();
            red.read(id);
            ArticleTitle.Value = red.title;
            content.Value = red.content;
            articleImg.Src = red.imgPath;
            listImgA.HRef = red.imgPath;
            filePath.Value = red.imgPath;
            //source.Value = red.

            string classid = red.classId;
            foreach (ListItem list in classId.Items)
            {
                if (list.Value.ToString() == classid)
                {
                    list.Selected = true;
                    break;
                }
            }

        }

        //保存
        protected void Submit1_ServerClick(object sender, EventArgs e)
        {
            ArticleDal ar = new ArticleDal();
            ar.classId = classId.Text;
            ar.title = ArticleTitle.Value.ToString();
            ar.content = content.Value.ToString();

            //保存图片
            string imgPath;
            Img img = new Img();
            img.savePathName = "article";
            imgPath = img.saveImage(filePath.Value);
            string err;
            if (img.error != "")
            {
                showMessage(img.error);
                return;
            }
            ar.imgPath = imgPath;
            if (app == "edit")
            {
                ar.edit(id);
                err = "修改成功";
                showMessage(err);
            }
            else
            {
                ar.add();
                err = "添加成功";
                showMessage(err, "gl_manage.aspx?classid=" + classid);
            }

        }
    }
}