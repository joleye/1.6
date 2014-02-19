<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gl_manage.aspx.cs" Inherits="JoleYe.Admin.ArticleList" EnableEventValidation="false"%>
<%@ Register Src="../usercontrol/pageer.ascx" TagName="pageer" TagPrefix="uc1" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>资讯管理</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="gl_form.aspx?classid=<%=classid %>&act=add">添加新资讯</a>
            | <a href="gl_manage.aspx?classid=<%=classid %>">管理资讯</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
        <asp:repeater id="detail" runat="server">
        <headertemplate>
              <table width="98%" align="center" border="0" class="tb">
              <tr height="30">
                <td align="center">编号</td>
                <td width="250" align="center">标题</td>
                <td align="center">类别</td>
                <td align="center">修改时间</td>
                <td width="150" align="center">操作</td>
              </tr>
            <tbody id="tedit" class="mouse">  
        </headertemplate>
        <itemtemplate>
              <tr height="35" joletype="mouse">
                <td align="center"><input name="id" class="checkitem" type="checkbox" value="<%#DataBinder.Eval(Container.DataItem,"id") %>" /></td>
                <td><span class="edit" table="article" field="ArticleTitle" valid="<%#Eval("id")%>"><%#Eval("ArticleTitle")%></span></td>
                <td><a href="gl_manage.aspx?classid=<%#Eval("classid") %>"><%#DataBinder.Eval(Container.DataItem, "className")%></a>&nbsp;</td>
                <td><%#DataBinder.Eval(Container.DataItem, "updateDate")%>&nbsp;</td>
                <td align="center"><a href="gl_form.aspx?classid=<%=classid %>&app=edit&id=<%# DataBinder.Eval(Container.DataItem,"id") %>">编辑</a> | <a href="?classid=<%=classid %>&app=del&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>
              </tr>
        </itemtemplate>
        <footertemplate>
            </tbody>
            <tr>
            	<td height="30" colspan="5"><input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" value="删除" />
            	</td>
            </tr>
      </table>
        </footertemplate>
        </asp:repeater>
        <uc1:pageer ID="Pageer" runat="server" />
    </div>
    </fieldset>
    </form>
</div>
<%=footer%>
