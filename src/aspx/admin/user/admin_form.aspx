<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_form.aspx.cs" Inherits="JoleYe.Admin.Admin_form" %>
<%=header%>
<div class="page">
    <fieldset>
        <legend>自定义页面</legend>
        <div class="content">
        <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0"> 
        <tr>     
            <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
                <b>&nbsp;管理导航：</b> 
                <a href="admin_user.aspx">管理会员</a> |
                <a href="javascript:history.back()">返回</a>
            </td>
          </tr>
        </table>
        </div>
        <div class="content">
    <form id="form1" runat="server">
    <div>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="30%" height="30" align="right">用户名：</td>
    <td><label>
      <input type="text" name="username" id="username" class="input" runat="server">
    </label></td>
  </tr>
  <tr>
    <td height="30" align="right">昵称：</td>
    <td><input type="text" name="nickname" id="nickname" class="input" runat="server" /></td>
  </tr>
  <tr>
    <td height="30" align="right">密码：</td>
    <td><label>
      <input name="pwd" type="password" id="pwd" class="input" size="20" runat="server">
      为空表示不修改
    </label></td>
  </tr>
  <tr>
    <td height="30" align="right">真实姓名：</td>
    <td><label>
      <input name="truename" type="text" id="truename" class="input" size="20" runat="server">
    </label></td>
  </tr>
  <tr>
    <td height="30" align="right">性别：</td>
    <td><label for="sex1">
      <input name="sex" type="radio" id="sex1" value="1" runat="server">
    男</label>
    <label for="sex2">
    <input type="radio" name="sex" id="sex2" value="0" runat="server">
    女</label></td>
  </tr>
  <tr>
    <td height="30" align="right">出生日期：</td>
    <td><input name="birth" type="text" class="input" id="birth" size="20" runat="server"></td>
  </tr>
  <tr>
    <td height="30" align="right">邮件：</td>
    <td><input type="text" name="email" class="input" id="email" runat="server"></td>
  </tr>
  <tr>
    <td height="30" align="right">联系电话：</td>
    <td><input type="text" name="telphone" class="input" id="telphone" runat="server"></td>
  </tr>
  <tr>
    <td height="30" align="right">手机：</td>
    <td><input name="mobile" type="text" class="input" id="mobile" size="20" runat="server"></td>
  </tr>
  <tr>
    <td height="30" align="right">QQ：</td>
    <td><input type="text" name="qq" class="input" id="qq" runat="server"></td>
  </tr>
  <tr>
    <td height="30" align="right">地址：</td>
    <td><input name="address" type="text" class="input" id="address" size="35" runat="server"></td>
  </tr>
  <tr>
    <td height="25" align="right">&nbsp;</td>
    <td><label>
      <input type="submit" name="button" id="btn" value="提交" onserverclick="btn_ServerClick" runat="server">
      <input type="reset" name="button2" id="button2" value="重置">
    </label></td>
  </tr>
</table>
    </div>
    </form>
        </div>
    </fieldset>
</div>
<%=footer%>
