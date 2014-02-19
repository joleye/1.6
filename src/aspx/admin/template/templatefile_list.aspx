<%@ Page Language="C#" EnableViewState="false" AutoEventWireup="true" CodeFile="templatefile_list.aspx.cs" Inherits="JoleYe.Admin.Templatefile_list" %>
<%=header%>
<script type="text/javascript" src="../javascript/checkbox.js"></script>
<div class="page">
<fieldset>
<legend><a href="template_list.aspx">所有界面</a> &gt; 界面文件</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            <a href="template_edit.aspx?do=app&templateid=<%=templateid%>">添加页面</a> | 管理页面 |
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="content">
    <form method="post">
        <asp:repeater runat="server" id="datalist">
            <headerTemplate>
            <table width="98%"  align="center" border="0"  class="tb">
              <tr height="30">
                <td align="center">编号</td>
                <td width="250" align="center">标题</td>
                <td align="center">文件名</td>
                <td width="150" align="center">操作</td>
              </tr>
            </headerTemplate>
            <itemtemplate >
              <tr height="30" joletype="mouse" class="mouse">
                <td align="center"><input name="id" class="checkitem" type="checkbox" value="<%#DataBinder.Eval(Container.DataItem,"id") %>" /></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem,"title") %> </td>
                <td><%#DataBinder.Eval(Container.DataItem, "templatePath")%>&nbsp;</td>
                <td align="center"><a href="template_edit.aspx?do=edit&templateid=<%=templateid%>&amp;id=<%# DataBinder.Eval(Container.DataItem,"id") %>">编辑</a> 
                | <a href="retemplate.aspx?id=<%# DataBinder.Eval(Container.DataItem,"id") %>&amp;templateid=<%=templateid%>">生成</a>
                | <a href="?do=drop&id=<%# DataBinder.Eval(Container.DataItem,"id") %>&amp;templateid=<%=templateid%>" onclick="return confirm_box('确认要删除吗？');">删除</a>
                </td>
              </tr>
            </itemtemplate>

	
            <footertemplate>
            <tr>
            	<td height="30" colspan="4"><input id="checkAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" onclick="this.form.action='?do=del'" value="删除" /><input type="submit" id="button" value="生成" onclick="this.form.action='?do=reset'" /></td>
            </tr>
      </table>
            </footertemplate>
        </asp:repeater>
        </form>
    </div>
</fieldset>
</div>
<%=footer%>
