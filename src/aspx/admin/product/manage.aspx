<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage.aspx.cs" Inherits="JoleYe.Admin.ProductManage" %>
<%@ Register Src="../usercontrol/pageer.ascx" TagName="pageer" TagPrefix="uc1" %>
<%=header%>
<script type="text/javascript">
ye.ready(function(){
    ye.g('search').onclick = function(){
        location.href = "?app=search&wd="+ye.g("wd").value;
    }
})
</script>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>产品管理</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="left" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;">产品名称：
         <input type="text" name="wd" id="wd" runat="server" />
          <input type="button" name="search" id="search" value="搜索" /></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> <a href="pro_form.aspx?act=add">添加产品</a> 
            | <a href="manage.aspx">管理产品</a> | <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="content">
        <asp:repeater ID="detail" runat="server">
            <headertemplate>
              <table width="98%" align="center" border="0"  class="tb">
              <tr height="30">
                <td align="center"><strong>编号</strong></td>
                <td width="100" align="center"><strong>图片</strong></td>
                <td width="230" align="center"><strong>标题</strong></td>
                <td width="150" align="center"><strong>产品类型</strong></td>
                <td align="center"><strong>添加时间</strong></td>
                <td align="center"><strong>排序</strong></td>
                <td align="center"><strong>首页显示</strong></td>
                <td align="center"><strong>操作</strong></td>
              </tr>
              <tbody class="mouse" id="tedit">
            </headertemplate>
            <itemtemplate>
              <tr height="70" joletype="mouse">
                <td align="center"><input name="id" class="checkitem" type="checkbox" value="<%#DataBinder.Eval(Container.DataItem,"id") %>" /></td>
                <td align="center"><a href="<%=WEBPATH%>productinfo-<%#DataBinder.Eval(Container.DataItem,"id") %>.aspx" target="_blank"><img height="60" src="<%#csmallimg(DataBinder.Eval(Container.DataItem, "productImgUrl").ToString())%>"/></a></td>
                <td align="center"><span class="edit" table="product" field="productName" valid="<%#Eval("id")%>"><%#DataBinder.Eval(Container.DataItem, "productName")%></span></td>
                <td align="center"><a href="manage.aspx?tyid=<%#Eval("typeid")%>"><%#DataBinder.Eval(Container.DataItem, "typeName")%></a></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "postDate")%></td>
                <td align="center"><span class="edit" table="product" field="showId" valid="<%#Eval("Id")%>" width="50" type="int"><%#Eval("showId")%></span></td>
                <td align="center"><span class="edit" table="product" field="showHome" valid="<%#Eval("Id")%>" type="bool"><%#BollToZh(Eval("showHome").ToString())%></span></td>
                <td align="center"><a href="pro_form.aspx?app=edit&amp;id=<%# DataBinder.Eval(Container.DataItem,"id") %>">编辑</a> | <a href="?app=del&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>
              </tr>
            </itemtemplate>
            <footertemplate>
            </tbody>
              <tr>
            	<td height="30" colspan="8"><input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" value="删除" /></td>
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
