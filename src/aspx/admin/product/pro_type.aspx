<%@ Page Language="C#" AutoEventWireup="true" CodeFile="pro_type.aspx.cs" Inherits="JoleYe.Admin.ProductTypePage" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>管理产品类型</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            <a href="pro_type_form.aspx?act=add" id="addnew" runat="server">添加新类别</a> | 
            <a href="#">管理类别</a> | 
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="content">
        <asp:repeater id="detail" runat="server">
        <headertemplate>
             <table width="98%" align="center" border="1" cellpadding="0" cellspacing="0" width="100%" bordercolorlight="#000000" bordercolordark="#F7F7F7">
              <tr height="30">
                <td align="center">编号</td>
                <td width="250" align="center">类型名称</td>
                <td align="center">图片</td>
                <td align="center" width="150">排序</td>
                <td align="center">操作</td>
              </tr>
             <tbody class="mouse" id="tedit">
        </headertemplate>
        <itemtemplate>
              <tr height="30">
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "id")%></td>
                <td><a href="?act=viewchild&id=<%#DataBinder.Eval(Container.DataItem,"id")%>"><%#DataBinder.Eval(Container.DataItem, "TypeName")%></a></td>
                <td align="center"><a href="<%#DataBinder.Eval(Container.DataItem, "imgUrl")%>" target="_blank">查看</a></td>
                <td align="center"><span class="edit" table="productType" field="orderId" valid="<%#Eval("Id")%>" type="int" width="40"><%#Eval("orderId")%></span></td>
                <td align="center"><a href="pro_type_form.aspx?act=edit&amp;id=<%#DataBinder.Eval(Container.DataItem, "id")%>">编辑</a> | <a href="?do=del&id=<%#DataBinder.Eval(Container.DataItem, "id")%>">删除</a> | <a href="pro_type_form.aspx?act=add&id=<%# DataBinder.Eval(Container.DataItem, "id")%>">添加下一级分类</td>
              </tr>
        </itemtemplate>
        <footertemplate>
        </tbody>
              <tr>
            	<td height="30" colspan="5"><input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" value="删除" /></td>
              </tr>
             </table>
        </footertemplate>
        </asp:repeater>
    </div>
    </fieldset>
    </form>
</div>
<script type="text/javascript">
del();
$=function(obj){return document.getElementById(obj);}
function del()
{
	var _tg = document.getElementsByTagName("input");
	for(var i=0;i<_tg.length;i++)
	{
		if(_tg[i].value == "删除")
		{
			_tg[i].onclick = function()
			{
				if(!confirm("确定要删除吗？"))
					return false;
			}
		}
	}
}
</script>
<%=footer%>