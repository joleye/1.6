<%@ Page Language="C#" AutoEventWireup="true" CodeFile="template_list.aspx.cs" Inherits="JoleYe.Admin.Template_list" %>
<%=header%>
<div class="page">
<fieldset>
<legend>所有界面</legend>
    <form id="form1" runat="server">
    <div>
      <table width="98%" border="0" align="center" cellspacing="0" class="tb">
        <tr>
          <th width="10%" height="30" align="center">&nbsp;</th>
          <th width="30%" align="center">界面名称</th>
          <th width="10%" align="center">版本</th>
          <th width="20%" align="center">作者</th>
          <th align="center">操作</th>
        </tr>
        <asp:repeater runat="server" id="temp_list">
        <ItemTemplate>
        <tr joletype="mouse">
          <td height="30" align="center"><label>
            <input type="checkbox" name="checkbox" id="checkbox" />
          </label></td>
          <td align="center"><%#Eval("name") %></td>
          <td align="center"><%#Eval("version") %></td>
          <td align="center"><%#Eval("author") %></td>
          <td align="center"><a href="templatefile_list.aspx?templateid=<%#Eval("id") %>">编辑</a> | <a href="system.aspx?app=resettemplate&id=<%#Eval("id") %>">使用</a></td>
        </tr>
        </ItemTemplate>
        </asp:repeater>
      </table>
    </div>
    </form>
</fieldset>
</div>
<%=footer%>
