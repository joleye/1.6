<%@ Page Language="C#" AutoEventWireup="true" CodeFile="site_config.aspx.cs" Inherits="admin_global_site_config" %>
<%=header%>
<style type="text/css">
td{
	border-right:1px solid #0066cc;
	border-bottom:1px solid #0066cc;
}
table{
	border-collapse:collapse;
	width:100%;
	border:1px solid #0066cc;
	
}
tbody td+td+td+td+td+td{border-right:1px solid #0066cc}
</style>
<div class="page">
<fieldset>
<legend>基本信息</legend>
<form id="Form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td width="200" height="30" align="right"><label for="site_state">网站状态：</label>      </td>
    <td valign="middle"><select name="site_state" id="site_state" runat="server" onchange="if(this.value==0) ye.g('site_state_text').style.display='none';else ye.g('site_state_text').style.display='';">
      <option value="0">开启</option>
      <option value="1">关闭</option>
      </select>
      <label for="webhost"></label>
      <textarea name="site_state_text" cols="50" rows="4" id="site_state_text" runat="server">网站正在升级，系统暂时关闭，请稍候访问。</textarea></td>
  </tr>
  <tr>
    <td height="30" align="right"><label for="selectyzm">后台登陆验证码：</label></td>
    <td><select name="select" id="adminlogincode" runat="server">
        <option value="0">开启验证码</option>
        <option value="1">关闭验证码</option>
      </select>    </td>
  </tr>
  <tr>
    <td height="30" align="right">用户注册：</td>
    <td><input name="allowreg" type="radio" id="allow_reg" value="0" runat="server" />
      <label for="allow_reg">允许注册</label>
      <input type="radio" name="allowreg" id="notallow_reg" value="1" runat="server" />
      <label for="notallow_reg">不允许注册</label></td>
  </tr>
  <tr>
    <td height="30" align="right">网站域名：      </td>
    <td><label for="webhost">
      <input type="text" name="webhost" id="webhost" style="width:300px;" class="input" runat="server" /></label>
      如：http://www.joleye.com</td>
  </tr>
  <tr>
    <td height="30" align="right">&nbsp;</td>
    <td>&nbsp;</td>
  </tr>
  <tr>
    <td height="30" align="right">&nbsp;</td>
    <td><label for="button"></label>
      <input type="submit" name="button" id="save_btn" class="button" value="保存" onserverclick="save_btn_ServerClick" runat="server" /></td>
  </tr>
</table>

</form>
</fieldset>
</div>
<%=footer%>