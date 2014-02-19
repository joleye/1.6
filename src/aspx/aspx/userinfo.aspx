<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="JoleYe.Web.Userinfo" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="JoleYe.Model" %>
<%
      //此文件由JoleYe系统自动生成生成时间：2012-9-11 23:05:57

  StringBuilder templatestr = new StringBuilder();
  pagetitle="基本信息";
  templatestr.Append("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">\r\n");
  templatestr.Append("<html xmlns=\"http://www.w3.org/1999/xhtml\">\r\n");
  templatestr.Append("<head>\r\n");
  templatestr.Append("<meta http-equiv=\"Content-Type\" content=\"text/html; charset=gb2312\" />\r\n");
  templatestr.Append("<title>");
  templatestr.Append(pagetitle);
  templatestr.Append(" - ");
  templatestr.Append(web_title);
  templatestr.Append(" Powered by JoleYe</title>\r\n");
  templatestr.Append("<link href=\"");
  templatestr.Append(WEBPATH);
  templatestr.Append("fckeditor/editor/skins/default/fck_editor.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
  templatestr.Append("<link href=\"");
  templatestr.Append(WEBPATH);
  templatestr.Append("fckeditor/editor/css/fck_editorarea.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
  templatestr.Append("<link href=\"");
  templatestr.Append(WEBPATH);
  templatestr.Append("fckeditor/editor/css/fck_internal.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
  templatestr.Append("<link href=\"");
  templatestr.Append(WEBPATH);
  templatestr.Append(TEMPLATEPATH);
  templatestr.Append("/css/joleye.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
  templatestr.Append("<script type=\"text/javascript\" src=\"");
  templatestr.Append(WEBPATH);
  templatestr.Append(TEMPLATEPATH);
  templatestr.Append("/javascript/joleye.js\"></script>\r\n");
  templatestr.Append("</head>\r\n");
  templatestr.Append("<body>\r\n");
  templatestr.Append("<div class=\"topnav\">\r\n");
  templatestr.Append("<div class=\"nav\">\r\n");
  if(!islogin)
  {
  templatestr.Append("<span><a href=\"login.aspx\">登陆</a></span> <span><a href=\"register.aspx\">注册</a></span>\r\n");
  }else{
  templatestr.Append("<span>您好：");
  templatestr.Append(user_name);
  templatestr.Append("</span>\r\n");
  templatestr.Append("<span><a href=\"member.aspx?app=loginout\" onclick=\"this.href += '&backurl='+escape(location.href)\">退出</a></span>\r\n");
  templatestr.Append("<span><a href=\"member.aspx\">用户中心</a></span>\r\n");
  }
  templatestr.Append("</div>\r\n");
  templatestr.Append("</div>\r\n");
  templatestr.Append("<div class=\"head bd\">\r\n");
  templatestr.Append("    <div class=\"heng\"></div>\r\n");
  templatestr.Append("    <div class=\"top\">\r\n");
  templatestr.Append("        <dl>\r\n");
  templatestr.Append("            <dt><img src=\"images/logo.jpg\" width=\"200\" height=\"73\" /></dt>\r\n");
  templatestr.Append("            <dd><img src=\"images/index.jpg\" width=\"730\"  height=\"90\"/></dd>\r\n");
  templatestr.Append("        </dl>\r\n");
  templatestr.Append("    </div>\r\n");
  templatestr.Append("    <div class=\"heng\"></div>\r\n");
  templatestr.Append("    <!--导航部分 start-->\r\n");
  templatestr.Append("    <div class=\"nav\">\r\n");
  templatestr.Append("            <ul>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="index")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"index.aspx\">首 页</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="brand")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"brand.aspx\">品牌介绍</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="down")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"down.aspx\">下载中心</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="intro")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"intro.aspx\">产品介绍</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="listinfo")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"listinfo.aspx\">在线资料</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="product")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"productlist.aspx\">产品中心</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="custon")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"custom-zhichi.aspx\">技术支持</a></li>\r\n");
  templatestr.Append("                <li");
  if(flg_nav=="contact")
  {
  templatestr.Append(" class=\"selected\"");
  }
  templatestr.Append("><a href=\"contact.aspx\">联系我们</a></li>\r\n");
  templatestr.Append("            </ul>\r\n");
  templatestr.Append("    </div>\r\n");
  templatestr.Append("    <!--导航部分 over-->\r\n");
  templatestr.Append("    <div class=\"heng\"></div>\r\n");
  templatestr.Append("</div>\r\n");
  templatestr.Append("<div class=\"heng\"></div>\r\n");
  templatestr.Append("<div class=\"tool bd\">目前位置 ：首页 > 用户中心</div>\r\n");
  templatestr.Append("<div class=\"heng\"></div>\r\n");
  templatestr.Append("<div class=\"body bd\">\r\n");
  templatestr.Append("	<div class=\"left box\">\r\n");
  templatestr.Append("	    <div class=\"title\"><a href=\"userinfo.aspx\">基本信息</a> <a href=\"userpass.aspx\">修改密码</a> </div>\r\n");
  templatestr.Append("      <div class=\"content\">\r\n");
  templatestr.Append("<form method=\"post\" class=\"form\" onsubmit=\"return do_check(this);\">\r\n");
  templatestr.Append("<table width=\"100%\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"tb\">\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td width=\"30%\" height=\"25\" align=\"right\">用户名：</td>\r\n");
  templatestr.Append("    <td><label>");
  templatestr.Append(minfo["username"]);
  templatestr.Append("</label></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">真实姓名：</td>\r\n");
  templatestr.Append("    <td><label>\r\n");
  templatestr.Append("      <input name=\"truename\" type=\"text\" id=\"truename\" size=\"20\" value=\"");
  templatestr.Append(minfo["truename"]);
  templatestr.Append("\">\r\n");
  templatestr.Append("    </label></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">性别：</td>\r\n");
  templatestr.Append("    <td><label for=\"radio\">\r\n");
  templatestr.Append("      <input name=\"sex\" type=\"radio\" id=\"radio\" value=\"1\" ");
  if(minfo.sex==true)
  {
  templatestr.Append("checked");
  }
  templatestr.Append(">\r\n");
  templatestr.Append("    男</label>\r\n");
  templatestr.Append("    <label for=\"radio2\"><input type=\"radio\" name=\"sex\" value=\"0\" ");
  if(minfo.sex==false)
  {
  templatestr.Append("checked");
  }
  templatestr.Append(">\r\n");
  templatestr.Append("    女</label></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">出生日期：</td>\r\n");
  templatestr.Append("    <td><input name=\"birth\" type=\"text\" id=\"birth\" size=\"20\" value=\"");
  templatestr.Append(minfo["birth"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">邮件：</td>\r\n");
  templatestr.Append("    <td><input type=\"text\" name=\"email\" id=\"email\" value=\"");
  templatestr.Append(minfo["email"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">联系电话：</td>\r\n");
  templatestr.Append("    <td><input type=\"text\" name=\"telphone\" id=\"telphone\" value=\"");
  templatestr.Append(minfo["telphone"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">手机：</td>\r\n");
  templatestr.Append("    <td><input name=\"mobile\" type=\"text\" id=\"mobile\" size=\"20\" value=\"");
  templatestr.Append(minfo["mobile"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">QQ：</td>\r\n");
  templatestr.Append("    <td><input type=\"text\" name=\"qq\" id=\"qq\" value=\"");
  templatestr.Append(minfo["qq"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">地址：</td>\r\n");
  templatestr.Append("    <td><input name=\"address\" type=\"text\" id=\"address\" size=\"35\" value=\"");
  templatestr.Append(minfo["address"]);
  templatestr.Append("\"></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("  <tr>\r\n");
  templatestr.Append("    <td height=\"25\" align=\"right\">&nbsp;</td>\r\n");
  templatestr.Append("    <td><label>\r\n");
  templatestr.Append("      <input type=\"submit\" name=\"button\" id=\"button\" value=\"保 存\">\r\n");
  templatestr.Append("    </label></td>\r\n");
  templatestr.Append("  </tr>\r\n");
  templatestr.Append("</table>\r\n");
  templatestr.Append("</form>\r\n");
  templatestr.Append("            </div>\r\n");
  templatestr.Append("	</div>\r\n");
  templatestr.Append("    <div class=\"right\">\r\n");
  templatestr.Append("          	<div class=\"box\">\r\n");
  templatestr.Append("         <div class=\"title\">JoleYe产品介绍</div>\r\n");
  templatestr.Append("    	<div class=\"content\">\r\n");
  templatestr.Append("               ");
  templatestr.Append(config_site["intro"]);
  templatestr.Append("        </div>\r\n");
  templatestr.Append("        </div>\r\n");
  templatestr.Append("        <div class=\"blank10\"></div>\r\n");
  templatestr.Append("    	<div class=\"box\">\r\n");
  templatestr.Append("        <div class=\"title\">技术优势</div>\r\n");
  templatestr.Append("        <div class=\"content\">\r\n");
  templatestr.Append("&nbsp;在JoleYe成长的初期，会有很多热心的开发者去维护这个项目，他们都是工作在编程的第一线，并有着多年的开发解决问题的经验，JOLEYE一定会更加的强大。\r\n");
  templatestr.Append("         </div>\r\n");
  templatestr.Append("        </div>\r\n");
  templatestr.Append("        \r\n");
  templatestr.Append("      	<div class=\"blank10\"></div>\r\n");
  templatestr.Append("    	<div class=\"box\">\r\n");
  templatestr.Append("        <div class=\"title\">联系方式</div>\r\n");
  templatestr.Append("        <div class=\"content link\">\r\n");
  templatestr.Append("           		<dl>\r\n");
  templatestr.Append("			<dt>联系人：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["linkMan"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>电话：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["telphone"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>手机：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["mobile"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>Email：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["email"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>QQ：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["qq"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>MSN：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["msn"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>银行账号：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["banknum"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("			<dt>地址：</dt>\r\n");
  templatestr.Append("			<dd>");
  templatestr.Append(config_site["address"]);
  templatestr.Append("</dd>\r\n");
  templatestr.Append("		</dl>\r\n");
  templatestr.Append("<div class=\"clear\"></div>\r\n");
  templatestr.Append("        </div>\r\n");
  templatestr.Append("        </div>\r\n");
  templatestr.Append("    </div>\r\n");
  templatestr.Append("    <div class=\"clear\"></div>\r\n");
  templatestr.Append("</div>\r\n");
  templatestr.Append("<!--底部 start-->\r\n");
  templatestr.Append("<div class=\"blank10\"></div>\r\n");
  templatestr.Append("<div class=\"footer\">\r\n");
  templatestr.Append("    <div class=\"zz\">\r\n");
  templatestr.Append("    <script src=\"http://s175.cnzz.com/stat.php?id=1764696&web_id=1764696\" language=\"JavaScript\" charset=\"gb2312\"></script>\r\n");
  templatestr.Append("    </div>\r\n");
  templatestr.Append("    <div class=\"public\">&copy; 2012 版权所有  Powered by <a href=\"http://www.joleye.com\" target=\"_blank\">JoleYe</a> <a target=\"_blank;\" onclick=\"onclick_qq()\" href=\"http://sighttp.qq.com/cgi-bin/check?sigkey=f9653d52612f95117d0ff0c10f093b20b1a3159a5ba33e85c276719bc8994697\"><img alt=\"\" border=\"0\" src=\"http://wpa.qq.com/pa?p=1:373065349:41\" /></a>\r\n");
  templatestr.Append(" <a href=\"http://www.miibeian.gov.cn/\" target=\"_blank\">湘ICP备10007479</a>\r\n");
  templatestr.Append("</div>\r\n");
  templatestr.Append("</div>\r\n");
  templatestr.Append("<!--底部 over-->\r\n");
  templatestr.Append("</body>\r\n");
  templatestr.Append("</html>\r\n");
  Response.Write(templatestr.ToString());
%>