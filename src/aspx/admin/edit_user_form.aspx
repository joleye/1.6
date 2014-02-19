<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_user_form.aspx.cs" Inherits="JoleYe.Admin.UserForm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>用户管理</title>
<link href="css/config.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="javascript/JoleYe.js"></script>
</head>
<body>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>用户管理</legend>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="?act=addUser">添加用户</a> | <a href="edit_user_info.aspx">管理信息</a>  | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    <div class="content"><br />
      <table width="100%" border="0" cellspacing="0">
     <tr>
             <td width="40%" height="35" align="right">用 户 名：</td>
             <td><asp:TextBox CssClass="input" ID="adminName" runat="server"></asp:TextBox></td>
           </tr>
           <tr>
             <td height="35" align="right">密 码：</td>
             <td><asp:TextBox CssClass="input" ID="pwd" runat="server" TextMode="Password"></asp:TextBox></td>
           </tr>
           <tr>
             <td height="35" align="right">重复密码：</td>
             <td><asp:TextBox CssClass="input" ID="repwd" runat="server" TextMode="Password"></asp:TextBox></td>
           </tr>
           <tr>
             <td height="45" align="right">&nbsp;</td>
             <td><asp:Button CssClass="button" ID="btn" runat="server" Text="添加" OnClick="userName_Click" />
                 <asp:Label ID="ERROR_MESSAGE" runat="server" ForeColor="Red"></asp:Label></td>
           </tr>
         </table>
<br />
<br />
    </div>
    </fieldset>
    </form>
</div>
<%=footer%>
