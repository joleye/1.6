<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_user.aspx.cs" Inherits="JoleYe.Admin.Admin_user" %>
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
        <form id="form1" runat="server" method="post">
       <table width="98%" align="center" border="0"  class="tb">
        <tr>
          <td width="10%" height="30" align="center">&nbsp;</td>
          <td width="30%" align="center">名称</td>
          <td width="20%" align="center">真实姓名</td>
          <td width="20%" align="center">联系电话</td>
          <td align="center">操作</td>
        </tr>
      <asp:Repeater runat="server" id="list">
        <ItemTemplate>
        <tr  class="mouse" joletype="mouse">
          <td height="30" align="center"><label>
            <input type="checkbox" name="id" class="checkitem" value="<%#Eval("id")%>"  runat="server"/>
          </label></td>
          <td align="center"><%#Eval("username")%></td>
          <td width="20%" align="center"><%#Eval("truename")%></td>
          <td width="20%" align="center"><%#Eval("telphone")%></td>
          <td align="center"><a href="admin_form.aspx?id=<%#Eval("id") %>">编辑</a> | <a href="?app=drop&id=<%#Eval("id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>

        </tr>
        </ItemTemplate>
      </asp:Repeater>
              <tr>
          <td height="30" align="left" colspan="5">
            <input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;
              <asp:button id="drop" runat="server" text="删除" OnClick="drop_Click" />
          </td>
        </tr>
      </table>
      <div class="pageBox"><%=pageBox %></div>
    </form>
    </div>
    </fieldset>
</div>
<%=footer%>