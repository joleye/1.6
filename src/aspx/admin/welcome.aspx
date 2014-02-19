<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="JoleYe.Admin.Welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<link href="css/config.css" rel="stylesheet" type="text/css" />
<style type="text/css">
<!--
.STYLE1 {color: #FF3300}
-->
</style>
<head runat="server">
    <title>welcome</title>
</head>
<body>
    <div class="page">
      <p>欢迎使用JoleYe网站发布系统</p>
        <p>版本： <%=version%></p>
        <p>官方网站：http://www.joleye.com</p>
        <p>开发团队：JoleYe</p>
        <p>新增功能：</p>
        <p class="STYLE1">1. 支持用户注册，QQ号码登陆</p>
        <p class="STYLE1"> 2. 模板库增加新功能 write 标记</p>
        <p class="STYLE1">3. 产品订单功能</p>
</div>
<script type="text/javascript">
var dom = document.createElement("iframe");
dom.src = "http://www.joleye.com/services/action.aspx?version=<%=version %>";
dom.style.display = 'none';
document.body.appendChild(dom); 
</script>
</body>
</html>
