<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gl_type.aspx.cs" Inherits="JoleYe.Admin.Article_type" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>管理资讯类型</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            <a href="gl_type_form.aspx?act=add">添加新资讯</a> | 
            <a href="gl_type.aspx">管理资讯</a> | 
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="content">
		<asp:DataGrid ID="detail" runat="server" Width="100%" AutoGenerateColumns="False" CellPadding="0"
		OnDeleteCommand="DataGrid_Del"
		
        OnEditCommand="DataGrid_Edit"
        OnCancelCommand="DataGrid_Cancel"
        OnUpdateCommand="DataGrid_Update"
        
		DataKeyField="id"
		BorderWidth="1px" 
		GridLines="Horizontal" Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False"
		>
           <ItemStyle CssClass="Line30" Font-Italic="False" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="False"></ItemStyle>

           <HeaderStyle BackColor="#CCCCFF" CssClass="Line30" Font-Italic="False" Font-Size="14pt" Font-Strikeout="False" Font-Underline="False" Font-Overline="False" Font-Bold="True"></HeaderStyle>
            <Columns>
            <asp:EditCommandColumn HeaderText="快捷操作" CancelText="取消" UpdateText="更新" EditText="编辑">
            <HeaderStyle Width="15%"></HeaderStyle>
            </asp:EditCommandColumn>
            <asp:TemplateColumn HeaderText="类型名称">
            <ItemStyle Width="60%"></ItemStyle>
            <ItemTemplate>
                <asp:Label runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "className")%>'/>
            </ItemTemplate>
            <EditItemTemplate>
                 <asp:TextBox runat="server" id="className" width="95"
                   Text='<%# DataBinder.Eval(Container.DataItem, "className")%>'/>
            </EditItemTemplate>
            </asp:TemplateColumn>
            <asp:HyperLinkColumn HeaderText="操作" DataNavigateUrlFormatString="gl_type_form.aspx?act=edit&amp;id={0}" DataNavigateUrlField="id" Text="编辑">
            <HeaderStyle Width="10%"></HeaderStyle>
            </asp:HyperLinkColumn>
            <asp:ButtonColumn ButtonType="PushButton" CommandName="Delete" Text="删除">
            <HeaderStyle Width="10%"></HeaderStyle>
            </asp:ButtonColumn>
            </Columns>
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
