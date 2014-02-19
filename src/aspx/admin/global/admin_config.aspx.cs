using System;
using System.Data;
using System.Data.OleDb;
using System.Web;
using System.Web.UI;
using JoleYe.Data;

namespace JoleYe.Admin
{
    public partial class info : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Base re = new Base();

                webName.Text = re.getSite(1);

                linkMan.Text = re.getSite(4);

                email.Text = re.getSite(5);

                telphone.Text = re.getSite(6);

                mobile.Text = re.getSite(7);

                fax.Value = re.getSite(8);

                bankName.Value = re.getSite(9);

                bankNumber.Value = re.getSite(10);

                address.Value = re.getSite(11);

                qq.Value = re.getSite(51);

                msn.Value = re.getSite(13);

                zhifubao.Value = re.getSite(14);

                webKeyword.Value = re.getSite(15);

                lawName.Value = re.getSite(16);

                icp.Value = re.getSite(2);

                webNum.Value = re.getSite(3);
                wangwang.Value = re.getSite(48);

                webPath.Value = WEBPATH;
                //dr.Clone;
                //rs.Close;

            }

        }

        protected void saveInfo(object sender, EventArgs e)
        {
            JoleInfo sd = new JoleInfo();
            sd.setInfo(1, webName.Text.ToString());     //网站名称
            sd.setInfo(4, linkMan.Text.ToString());     //联系人
            sd.setInfo(5, email.Text.ToString());       //电子邮件
            sd.setInfo(6, telphone.Text.ToString());
            sd.setInfo(7, mobile.Text.ToString());
            sd.setInfo(8, fax.Value.ToString());
            sd.setInfo(9, bankName.Value.ToString());
            sd.setInfo(10, bankNumber.Value.ToString());
            sd.setInfo(11, address.Value.ToString());
            sd.setInfo(51, qq.Value.ToString());
            sd.setInfo(13, msn.Value.ToString());
            sd.setInfo(14, zhifubao.Value.ToString());
            sd.setInfo(15, webKeyword.Value.ToString());
            sd.setInfo(16, lawName.Value.ToString());
            sd.setInfo(2, icp.Value.ToString());
            sd.setInfo(3, webNum.Value.ToString());
            sd.setInfo(48, wangwang.Value.ToString());


            showMessage("修改成功", Request.UrlReferrer.ToString());
        }
    }
}

