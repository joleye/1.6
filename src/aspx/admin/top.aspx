<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="JoleYe.Admin.top" %>
<%=header%>
<script type="text/javascript">
function goto(str)
{
	parent.document.getElementById("leftFrame").src = "treeLeft.aspx?tp="+str;
}
</script>

    <div class="Main_top">
    <div class="Main_top_left">
        <ul runat="server" id="list">
            <li class="menu_01"><a href="javascript:goto(0);">常规管理</a></li>
            <li><a href="javascript:goto(1);">资讯管理</a></li>
            <li class="menu_03"><a href="javascript:goto(2);">产品管理</a></li>
            <li><a href="javascript:goto(3);">博客相册</a></li>
            <li><a href="javascript:goto(4);">其 他</a></li>
            <li class="NoneBg"></li>
        </ul>
    </div>
    <div class="Main_top_right">
        <a href="<%=WEBPATH %>" target="_blank">网站首页</a>
        <a href="/" target="main">刷新所有模板</a>
        <a href="global/admin_nav.aspx" target="main">管理导航</a>
        <a href="loginout.aspx" target="_top">退出</a>            </div>
    </div>
 </body>
 </html>
