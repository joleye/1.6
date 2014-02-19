<%@ Page Language="C#" AutoEventWireup="true"  validateRequest="false"  CodeFile="template_edit.aspx.cs" Inherits="JoleYe.Admin.Template_edit" %>
<%=header%>
<div class="page">
<fieldset>
<legend><a href="template_list.aspx">所有界面</a> &gt;<a href="templatefile_list.aspx?templateid=<%=templateid%>">界面文件</a>&gt; 编辑</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0"> 
    <tr>     
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            添加页面 | <a href="templatefile_list.aspx?templateid=<%=templateid %>">管理页面</a> |
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
  <form id="form1" runat="server">
    <div class="content">
      <table width="100%" border="0" cellspacing="0">
        <tr>
          <td width="10%" height="30" align="center">标题</td>
          <td><asp:textbox id="title" runat="server" CssClass="input"></asp:textbox></td>
        </tr>
<!--        <tr>
          <td height="35" align="center">文件路径</td>
          <td><asp:textbox id="filePath" runat="server" CssClass="input" Width="347px"></asp:textbox></td>
        </tr>-->
        <tr>
          <td height="35" align="center">文件路径</td>
          <td><asp:textbox id="activePath" runat="server" CssClass="input" Width="347px"></asp:textbox></td>
        </tr>
        <tr>
          <td height="35" align="center">模板路径</td>
          <td><asp:textbox id="templatePath" runat="server" CssClass="input" Width="345px"></asp:textbox></td>
        </tr>
        <tr>
            <td align="center">文件内容</td>
            <td><asp:TextBox ID="contentDetail" runat="server" Height="400px" TextMode="MultiLine" Width="600px" CssClass="input"></asp:TextBox></td>
        </tr>
        <tr>
            <td height="40">&nbsp;</td>
            <td><asp:Button ID="Button1" CssClass="button" runat="server" Text="保 存" OnClick="Button1_Click" />
            &nbsp;&nbsp;
            <Button ID="Button2" class="button" OnClick="history.back();">返 回</Button></td>
        </tr>
    </table>

    </div>
  </form>
  
</fieldset>
</div>
<%=footer%>
