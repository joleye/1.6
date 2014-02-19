<%@ Page Language="C#" AutoEventWireup="true" CodeFile="system.aspx.cs" Inherits="JoleYe.Admin.admin_template_system" %>
<%=header%>
<div class="page">
<fieldset>
<legend>所有操作</legend>
    <form id="form1" runat="server">
    <div>
     <table width="98%" border="0" align="center" cellpadding="0" cellspacing="0">
            <tr>
                <td width="20%" height="30" align="center">重设缓存</td>
                <td width="30%" align="left" >
                <asp:Button ID="Button1" runat="server" Text="重设所有缓存" class="button" Width="154px" OnClick="Button1_Click" /></td>
                <td width="20%" align="center"></td>
                <td width="30%" align="left"></td>
            </tr>
            <tr>
                <td height="30" align="center">刷新所有模板</td>
                <td align="left" ><label>
                <asp:Button ID="ResetAllTemplate" runat="server" Text="刷新所有模板"  class="button" OnClick="ResetAllTemplate_Click"/>                
                </label></td>
                <td align="center"> </td>
                <td align="left"></td>
            </tr>
            <tr>
                <td height="30" align="center">默认模板</td>
                <td align="left"><label>
                  <select name="main_template" id="main_template" runat="server">
                  </select>
                  <input type="submit" name="button" id="button" value="确定" class="button" runat="server" onserverclick="button_ServerClick" />
                </label></td>
              <td align="center"></td>
                <td align="left"></td>
            </tr>
        </table>
    </div>
    </form>
</fieldset>
</div>
<%=footer%>
