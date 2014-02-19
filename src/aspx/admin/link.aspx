<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeFile="link.aspx.cs" Inherits="JoleYe.Admin.link" %>
<%=header%>
<div class="page">
<fieldset>
<legend>基本信息</legend>
    <form enctype="multipart/form-data" id="form1" runat="server">
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="?act=add">添加新链接</a> | <a href="?">管理链接</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    
    <div class="content">
    <p>
    <%
            if (act == "add" || act == "edit")
            {
    %>
      </p>
      <p>&nbsp;</p>
      <table width="100%" border="0" align="center" cellspacing="1" bgcolor="#999999">
        <tr>
          <td width="34%" height="35" align="right" bgcolor="#FFFFFF">网站名称：</td>
          <td width="66%" align="left" bgcolor="#FFFFFF"><label>
            <input type="text" id="linkName" class="input" runat="server" />
          </label></td>
        </tr>
        <tr>
          <td height="35" align="right" bgcolor="#FFFFFF">网站地址：</td>
          <td align="left" bgcolor="#FFFFFF"><label>
            <input type="text" id="linkUrl" class="input" runat="server" />
          </label></td>
        </tr>
        <tr>
          <td height="35" align="right" bgcolor="#FFFFFF">网站LOGO：</td>
          <td align="left" bgcolor="#FFFFFF"><label>
            <input type="file" id="fileField" name="fileFiledImg" class="input" />
            <input type="checkbox" name="delimg" id="delimg" value="1"/>
          删除? <span id="view_img" runat="server"></span></label></td>
        </tr>
        <tr>
          <td height="35" bgcolor="#FFFFFF">&nbsp;</td>
          <td bgcolor="#FFFFFF"><label>
          <input type="hidden" name="imgUrl" id="imgUrl" runat="server" />
            <input type="submit" name="button" id="btn" class="button" value="提交" onserverclick="btn_ServerClick" runat="server" />
            <input type="reset" name="button2" id="button2" class="button" value="重置" />
          </label></td>
        </tr>
      </table>
      <p>
        <%
            }
            else
            { 
        %>
		<asp:DataGrid ID="detail" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="0" 
		GridLines="Horizontal"
		BorderWidth="1px"
		OnDeleteCommand="DataGrid_Del"
		DataGrid1_PageIndexChanged="DataGrid_page"
		OnPageIndexChanged="MyDataGrid_Page"
		DataKeyField="id"
		Font-Bold="False" 
		Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" AllowPaging="True"
		>
<PagerStyle Mode="NumericPages"></PagerStyle>

<ItemStyle CssClass="Line30"></ItemStyle>

<HeaderStyle BackColor="#CCCCFF" ForeColor="Blue" CssClass="Line30" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
<Columns>
<asp:BoundColumn>
<HeaderStyle Width="50px"></HeaderStyle>
</asp:BoundColumn>
<asp:BoundColumn DataField="linkName" HeaderText="名称">
<HeaderStyle Width="50%"></HeaderStyle>
</asp:BoundColumn>
<asp:HyperLinkColumn HeaderText="操作" DataNavigateUrlFormatString="?act=edit&amp;id={0}" DataNavigateUrlField="id" Text="编辑">
<HeaderStyle Width="30px"></HeaderStyle>
</asp:HyperLinkColumn>
<asp:ButtonColumn CommandName="Delete" Text="删除"></asp:ButtonColumn>
</Columns>
</asp:DataGrid>
        <%
            }
        %>
        </p>
    </div>
  </form>
</fieldset>
</div>
<%=footer%>
