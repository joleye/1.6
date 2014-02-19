<%@ Page language="c#" AutoEventWireup="false" EnableViewState="false" Inherits="JoleYe.Web.Contact" %>
<%@ Import namespace="System.Data" %>
<%@ Import namespace="JoleYe.Model" %>
<%
      //此文件由JoleYe系统自动生成生成时间：2012-9-11 23:05:57

  StringBuilder templatestr = new StringBuilder();
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
  templatestr.Append("<div class=\"tool bd\">目前位置 ：首页 > 联系我们</div>\r\n");
  templatestr.Append("<div class=\"heng\"></div>\r\n");
  templatestr.Append("<div class=\"body bd\">\r\n");
  templatestr.Append("	<div class=\"left box\">\r\n");
  templatestr.Append("	    <div class=\"title\">联系我们</div>\r\n");
  templatestr.Append("	    <div class=\"content\">\r\n");
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