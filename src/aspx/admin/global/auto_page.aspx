<%@ Page Language="C#" AutoEventWireup="true" CodeFile="auto_page.aspx.cs" Inherits="JoleYe.Admin.Global_Auto_page" %>
<%=header%>
<div class="page">
    <fieldset>
        <legend>自定义页面</legend>
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
        <form id="form1" runat="server" method="post">
      <asp:Repeater runat="server" id="list">
      <HeaderTemplate>
      <table width="98%" align="center" class="tb">
        <tr>
          <td width="10%" height="30" align="center">&nbsp;</td>
          <td width="30%" align="center">名称</td>
          <td align="center">操作</td>
        </tr>
        </HeaderTemplate>
        <ItemTemplate>
        <tr  class="mouse" joletype="mouse">
          <td height="30" align="center"><label>
            <input type="checkbox" name="checkbox" id="checkbox" />
          </label></td>
          <td align="center"><%#Eval("page_name")%></td>
          <td align="center"><a href="auto_page_form.aspx?id=<%#Eval("id") %>">编辑</a> | <a href="?app=drop&id=<%#Eval("id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>
        </tr>
        </ItemTemplate>
        <FooterTemplate>
        <tr>
          <td height="30" align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
          <td align="center">&nbsp;</td>
        </tr>
      </table>
      </FooterTemplate>
      </asp:Repeater>
    </form>
    </div>
    </fieldset>
</div>
<%=footer%>
