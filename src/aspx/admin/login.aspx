<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" EnableViewState="false" Inherits="admin_login" ValidateRequest="false" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server" enableviewstate="false">
    <title>用户登陆</title>
    <link href="css/config.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
<!--
.body { text-align: center; width: 600px; margin-top: 30px; margin-right: auto; margin-bottom: auto; margin-left: auto; }
td { padding: 2px; }
table { width: 600px; margin: auto; }
-->
    </style>
    <script type="text/javascript" src="../javascript/JOLEfrom.js"></script>
    <script type="text/javascript" src="javascript/JoleYe.js"></script>
</head>
<body>
<script language="javascript">
$ = function(objName)
{
	return document.getElementById(objName);
}
var img_str = "getcode.aspx"
var  Mycode = 
{
	check_img:function()
	{
		$("y_img").src = img_str + "?t=" + Math.random();
	}

}
</script>

<form id="form1" runat="server" enableviewstate="false">
<div class="body">
<table width="800" border="0" align="center" cellpadding="0" cellspacing="0" bgcolor="#CCCCCC">
  <tr>
    <td height="10" colspan="2" align="center" valign="middle" background="images/admin_login_01.jpg" bgcolor="#A2E0FF"></td>
    </tr>
  <tr>
    <td align="right" valign="middle" background="images/admin_login_02.jpg" bgcolor="#A2E0FF"><label>
      <img src="images/logo.jpg" />
    </label></td>
    <td align="left" valign="middle" background="images/admin_login_02.jpg" bgcolor="#A2E0FF"><strong>系统管理 用户登陆区</strong>
      <asp:Label ID="error" runat="server" Font-Size="14pt" ForeColor="Red" ></asp:Label></td>
  </tr>
            <tr>
                <td width="220" height="35" align="right" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">
                    用户名：</td>
  <td width="400" align="left" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">
          <asp:TextBox ID="adminName" runat="server" CssClass="input"></asp:TextBox></td>
      </tr>
            <tr>
                <td height="35" align="right" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">
                    密码：</td>
  <td align="left" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">
          <asp:TextBox ID="password" runat="server" TextMode="Password" CssClass="input"></asp:TextBox></td>
      </tr>
      <%
          if (p_adminlogincode)
          {%>
    <tr>
        <td align="right" background="images/admin_login_02.jpg" bgcolor="#FFFFFF" style="height: 35px">
            验证码：</td>
      <td align="left" background="images/admin_login_02.jpg" bgcolor="#FFFFFF" style="height: 35px">
        <asp:TextBox ID="code" runat="server" CssClass="input" Width="63px" MaxLength="6" onclick="this.className='inputOnclick'" onblur="this.className='input'"></asp:TextBox>
            <img src="getcode.aspx" id="y_img" /> <a href="javascript:Mycode.check_img();">看不清楚，换一张</a>            </td>
      </tr><%} %>
            <tr>
                <td height="40" align="right" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">                </td>
<td align="left" background="images/admin_login_02.jpg" bgcolor="#FFFFFF">
<asp:Button ID="btnSubmit" runat="server" Text="登陆" CssClass="button" OnClick="btnSubmit_Click"/>
                    &nbsp;
                    <input id="Reset1" type="reset" value="重置" class="button" /></td>
      </tr>
            <tr>
              <td height="12" colspan="2" align="center" background="images/admin_login_04.jpg" bgcolor="#FFFFFF"></td>
            </tr>
        </table>
  </div>
</form>
<script type="text/javascript">
$("btnSubmit").onclick = function(){
	return checkForm();
}
function checkForm()
{
	if($("code").value=="")
	{
		alert("请输入验证码");
		return false;
	}
}
</script>
</body>
</html>
