<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_main.aspx.cs" Inherits="JoleYe.Admin.admin_main" %>
<%@ Register Src="../usercontrol/pageer.ascx" TagName="pageer" TagPrefix="uc1" %>
<%=header %>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>图片管理</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="photo_add.aspx">添加图片</a>
            | <a href="admin_main.aspx">管理图片</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
        

              <table width="98%" align="center" border="0"  class="tb">
              <tr height="30">
                <td align="center"><strong>编号</strong></td>
                <td width="250" align="center"><strong>标题</strong></td>
                <td align="center"><strong>链接</strong></td>
                <td align="center"><strong>首页显示</strong></td>
                <td align="center"><strong>排序</strong></td>
                <td align="center"><strong>添加时间</strong></td>
                <td align="center"><strong>操作</strong></td>
              </tr>
              <tbody id="tedit">  
        <asp:repeater id="detail" runat="server">
        <itemtemplate>
              <tr height="35" joletype="mouse">
                <td align="center"><input name="id" class="checkitem" type="checkbox" value="<%#DataBinder.Eval(Container.DataItem,"id") %>" /></td>
                <td align="center"><a href="<%#DataBinder.Eval(Container.DataItem, "imgUrl")%>" target="_blank"><%#DataBinder.Eval(Container.DataItem, "album_name")%></a> </td>
                <td align="center"><span class="edit" table="album" field="linkUrl" valid="<%#Eval("id")%>" width="250"><%#Eval("linkUrl") %></span></td>
                <td align="center"><a href="?app=update&id=<%#Eval("id")%>&showHome=<%#!bool.Parse(Eval("showHome").ToString())%>"><%#BollToZh(Eval("showHome").ToString())%></a></td>
                <td align="center"><span class="edit" table="album" field="orderId" valid="<%#Eval("id")%>" width="40" type="int"><%#Eval("orderId")%></span></td>
                <td align="center"><%#DataBinder.Eval(Container.DataItem, "postDate")%>&nbsp;</td>
                <td align="center"><a href="?app=del&id=<%# DataBinder.Eval(Container.DataItem,"id") %>" onclick="return confirm_box('确认要删除吗？');">删除</a></td>
              </tr>
        </itemtemplate>
        </asp:repeater>
        	</tbody>
            <tr>
            	<td height="30" colspan="7"><input id="checkAll" name="ckeckAll" type="checkbox" />&nbsp;&nbsp;<input type="submit" name="button" value="删除" />
            	</td>
            </tr>
      </table>
        
        <uc1:pageer ID="Pageer" runat="server" />
    </div>
    </fieldset>
    </form>
</div>
<%=footer %>
