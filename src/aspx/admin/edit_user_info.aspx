<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_user_info.aspx.cs" Inherits="JoleYe.Admin.user_info" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>用户管理</title>
<link href="css/config.css" rel="stylesheet" type="text/css" />

</head>
<body>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>用户管理</legend>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="edit_user_form.aspx?act=addUser">添加用户</a> | <a href="?none">管理信息</a>  | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    
     <div class="content">
    <asp:DataGrid CellPadding="0" ID="content" runat="server" Width="100%" 
    Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" 
    AutoGenerateColumns="False"
    OnDeleteCommand="DataGrid_Del"
    DataKeyField="id"
    >
            <ItemStyle Height="30px" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" Height="30px" BackColor="ActiveBorder" />
            <FooterStyle BackColor="#8080FF" />
            <Columns>
                <asp:BoundColumn DataField="userName" HeaderText="用户名">
                    <HeaderStyle Width="50%" />
                </asp:BoundColumn>
                <asp:HyperLinkColumn HeaderText="操作" Text="修改密码" DataNavigateUrlField="id" DataNavigateUrlFormatString="edit_user_form.aspx?act=repwd&amp;id={0}">
                    <HeaderStyle Width="25%" />
                </asp:HyperLinkColumn>
                <asp:ButtonColumn CommandName="Delete" Text="删除" ButtonType="PushButton" HeaderText="操作"></asp:ButtonColumn>
            </Columns>
            <EditItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" />
            <SelectedItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="False" />
            <PagerStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False"
                Font-Underline="True" Mode="NumericPages" Visible="False" />
            <AlternatingItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False"
                Font-Strikeout="False" Font-Underline="False" />
        </asp:DataGrid>
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
		_tg[i].onclick = function()
		{
			if(!confirm("确定要删除吗？"))
				return false;
		}
	}
}
</script>
<%=footer%>
