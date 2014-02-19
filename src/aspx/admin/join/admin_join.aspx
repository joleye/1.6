<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_join.aspx.cs" Inherits="JoleYe.Admin.admin_join" %>
<%@ Register Src="../usercontrol/pageer.ascx" TagName="pageer" TagPrefix="uc1" %>
<%=header%>
<div class="page">
<fieldset>
<legend>管理加盟申请表</legend>
    <form enctype="multipart/form-data" id="form1" runat="server">
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr>
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b>  管理加盟申请表 |  <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
        <asp:repeater id="list" runat="server">
            <headertemplate>
              <table width="98%" align="center" class="tb">
              <tr height="30">
                <td align="center">编号</td>
                <td width="250" align="center">姓名</td>
                <td align="center">联系电话</td>
                <td align="center">留言时间</td>
                <td align="center">操作</td>
              </tr>
            </headertemplate>
            <itemtemplate>
              <tr height="30" joletype="mouse">
                <td align="center"><input name="id" class="checkitem" type="checkbox" value="<%#DataBinder.Eval(Container.DataItem,"id") %>" /></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "uname")%></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "telphone")%></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "jm_date")%></td>
                <td align="center"><a href="view.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>">查看</a> | <a href="?app=del&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>
              </tr>
            </itemtemplate>
            <footertemplate>
              <tr>
            	<td height="30" colspan="5"><input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" value="删除" /></td>
              </tr>
             </table>
            </footertemplate>
        </asp:repeater>
        <uc1:pageer ID="Pageer" runat="server" />
    </div>
  </form>
</fieldset>
</div>
<%=footer%>
