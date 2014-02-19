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
using JoleYe;
using JoleYe.Bll;
using System.Text;
using System.IO;
using JoleYe.Model;
using System.Text.RegularExpressions;
using JoleYe.Web;
using JoleYe.Conf;

public partial class account_qq_callback : Frontend
{
    protected void Page_Load(object sender, EventArgs e)
    {

        //QQ登录成功后的回调地址,主要保存access token
        qq_callback();

        //获取用户标示id
        get_openid();


        //注册
        do_reg();

        string ret_url = conf.getVal("webhost")+WEBPATH+"userinfo.aspx";

        if (!string.IsNullOrEmpty(getCookie("backurl")))
        {
            ret_url = getCookie("backurl");
            setCookie("backurl", "");
        }

        Response.Redirect(ret_url);

    }
    private void qq_callback()
    { 
        string callback = conf.getVal("webhost")+"/account/qq_callback.aspx";//Session["callback"].ToString();
        string token_url = "https://graph.qq.com/oauth2.0/token?grant_type=authorization_code&"
            + "client_id=" + Session["appid"] + "&redirect_uri=" + Server.UrlEncode(callback)
            + "&client_secret=" + Session["appkey"] + "&code=" + Request.QueryString["code"];


        HttpClient http = new HttpClient();
        http.do_get(token_url);

        StringUrl url = new StringUrl(http.value);
        if (url.get("access_token") != "")
        {
            Session["access_token"] = url.get("access_token");
            Session["expires_in"] = url.get("expires_in");
        }
    }

    private void get_openid()
    {
        string graph_url = "https://graph.qq.com/oauth2.0/me?access_token=" + Session["access_token"];
        HttpClient http = new HttpClient(graph_url);

        StringUrl url = new StringUrl(http.value);
        if (url.jget("openid") != "")
        {
            Session["openid"] = url.jget("openid");
            Session["client_id"] = url.jget("client_id");
        }
    }


    protected void do_reg()
    {
        string getuser_url = "https://graph.qq.com/user/get_user_info?"
        + "access_token=" + Session["access_token"]
        + "&oauth_consumer_key=" + Session["appid"]
        + "&openid=" + Session["openid"]
        + "&format=json";

        HttpClient http = new HttpClient();
        http.do_get(getuser_url, CHARSET);

        StringUrl url = new StringUrl(http.value);

        
        //注册临时账号
        PassportBll bll = new PassportBll();

        MemberInfo info = new MemberInfo();
        info.username = Session["access_token"].ToString();
        info.nickname = url.jget("nickname");
        info.password = Session["access_token"].ToString();

        bll.register(info.username,info.nickname,info.password);


    }
}
