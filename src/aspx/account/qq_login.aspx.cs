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
using JoleYe.Web;

public partial class account_qq_login: Frontend
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string callback = conf.getVal("webhost")+"/account/qq_callback.aspx";
        string appid = conf.getApiAttr("qq", "app_id");
        string scope = "get_user_info,add_share,list_album,add_album,upload_pic,add_topic,add_one_blog,add_weibo";

        Session["state"] = "1";
        Session["callback"] = callback;
        Session["appid"] = appid;
        Session["appkey"] = conf.getApiAttr("qq", "app_key");

        string url = "https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id="
        + appid + "&redirect_uri=" + Server.UrlEncode(callback)
        + "&state="
        + "&scope=" + scope;

        Response.Redirect(url);
    }
}
