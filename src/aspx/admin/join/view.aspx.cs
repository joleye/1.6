using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using JoleYe.Model;
using JoleYe.Dal;

namespace JoleYe.Admin
{
    public partial class join_view : AdminPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = 0;
                gnum(ref id, "id");
                JmInfo info = new JmInfo();
                JmDal jm = new JmDal();
                info = jm.read(id);

                uname.Text = info.uname;
                sex.Text = info.sex;
                address.Text = info.address;
                age.Text = info.age;
                telphone.Text = info.telphone;
                fax.Text = info.fax;
                company.Text = info.company;
                comaddress.Text = info.comaddress;
                zijin.Text = info.zijin;
                content.Text = info.content;
            }
        }
    }
}