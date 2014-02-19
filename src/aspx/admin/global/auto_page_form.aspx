<%@ Page Language="C#" AutoEventWireup="true" CodeFile="auto_page_form.aspx.cs" Inherits="JoleYe.Admin.Global_auto_page_form" validateRequest="false" %>

<%=header%>
<div class="page">
    <fieldset>
        <legend>自定义页面</legend>
    <form id="form1" runat="server">
        <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            <a href="auto_page_form.aspx?app=add">添加页面</a> | <a href="auto_page.aspx">管理页面</a> |
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="content">
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center">名称：</td>
    <td><asp:TextBox ID="page_name"  class="input" runat="server" Width="350px"></asp:TextBox></td>
  </tr>
  <tr>
    <td align="center">设置：</td>
    <td><textarea name="setting"  class="input" id="setting" style="width: 450px; height: 80px" runat="server"></textarea>
      <br />
      <label for="lt">
      <input type="radio" name="rad" id="lt" onclick="$('setting').value=this.value;" value="auto_text:{width:370;height:20;left:20;top:20;}" />
左上 </label>
      <label for="rt">
      <input type="radio" name="rad" id="rt"  onclick="$('setting').value=this.value;" value="auto_text:{width:370;height:20;left:600;top:20;}" />
右上 </label>
      <label for="cc">
      <input type="radio" name="rad" id="cc" onclick="$('setting').value=this.value;" value="auto_text:{width:370;height:20;left:300;top:180;}" />
中间 </label>
      <label for="lb">
      <input type="radio" name="rad" id="lb" onclick="$('setting').value=this.value;" value="auto_text:{width:370;height:20;left:20;top:340;}" />
左下 </label>
      <label for="rb">
      <input name="rad" type="radio" id="rb" onclick="$('setting').value=this.value;" value="auto_text:{width:370;height:20;left:600;top:340;}" /></label>
右下 <br />
<label for="ad">
      <input name="rad" type="radio" id="ad" onclick="$('setting').value=this.value;" value="auto_pro_scroll:{display:auto;}" /> 显示</label>
      <label for="adis">
      <input name="rad" type="radio" id="adis" onclick="$('setting').value=this.value;" value="auto_pro_scroll:{display:none;}" />不显示</label>
<br /><br />
      </td>
  </tr>
  <tr>
    <td align="center">内容：</td>
    <td><input name="content" type="hidden" id="content" runat="server" />
        <input type="hidden" id="content___Config" value="ToolbarLocation=Out:xToolbar" style="display:none" />
<iframe id="content___Frame" src="<%=WEBPATH%>fckeditor/editor/fckeditor.html?InstanceName=content&amp;Toolbar=Default" 
width="650" height="200" frameborder="0" scrolling="no"></iframe><br /><br />

    </td>
  </tr>
  <tr>
    <td align="center">&nbsp;</td>
    <td><asp:Button ID="btn" runat="server" Text="提交" class="button" OnClick="btn_Click" /></td>
  </tr>
</table>
    </div>
    </form>
    </fieldset>
 </div>
<%=footer%>
