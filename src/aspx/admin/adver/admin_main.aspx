<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_main.aspx.cs" Inherits="admin_adver_admin_main" %>
<%@ Register Src="../usercontrol/pageer.ascx" TagName="pageer" TagPrefix="uc1" %>
<%=header %>
<div class="page">
    <form id="form1" runat="server">
    <fieldset>
    <legend>广告管理</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
    </table>
    </div>
    <div class="content">
         <table width="98%" align="center"  class="tb">
              <tr height="30">
                <td align="center"><strong>编号</strong></td>
                <td width="250" align="center"><strong>标题</strong></td>
                <td align="center"><strong>链接</strong></td>
                <td align="center"><strong>操作</strong></td>
              </tr>
              <tbody id="tedit" class="mouse"> 
        <asp:repeater id="viewlist" runat="server">
        <itemtemplate>
              <tr height="35" joletype="mouse">
                <td align="center"><%#Eval("id") %></td>
                <td align="center"><a href="<%#Eval("imgUrl")%>" target="_blank"><%#Eval("title")%></a> </td>
                <td align="center"><%#Eval("linkurl")%>&nbsp;</td>
                <td align="center"><a href="admin_edit.aspx?app=edit&id=<%#Eval("id")%>">编辑</a></td>
              </tr>
        </itemtemplate>
        </asp:repeater>
        </tbody>
      </table>
      <uc1:pageer ID="Pageer" runat="server" />
    </div>
    </fieldset>
    </form>
</div>
<%=footer %>
