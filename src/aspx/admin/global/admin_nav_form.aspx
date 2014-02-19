<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_nav_form.aspx.cs" Inherits="JoleYe.Admin.nav_form" %>
<%=header %>
<div class="page">
<fieldset>
<legend>基本信息</legend>
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="admin_nav.aspx">管理导航</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
<form id="form1" runat="server">
    <table width="99%" border="1" cellpadding="0" cellspacing="0">
      <tr>
        <td height="30" align="center">名称</td>
        <td><label>
          <input type="text" id="title" runat="server" class="input" maxlength="50" />
        </label></td>
      </tr>
      <tr>
        <td height="30" align="center">key</td>
        <td><label>
          <input type="text" id="key" runat="server" maxlength="50" class="input"  />
            <asp:Label ID="keyl" runat="server" ForeColor="Red" Text=""></asp:Label></label></td>
      </tr>
        <tr>
            <td align="center" style="height: 30px">
                url</td>
      <td id="url" style="height: 30px">
                <input name="url" type="text" class="input" id="url" size="40" maxlength="50"  runat="server" /></td>
        </tr>
      <tr>
        <td height="30" align="center">&nbsp;</td>
        <td><label>
          <input type="submit" name="button" id="button" value="提交" onserverclick="button_ServerClick" runat="server" class="button" />
        </label></td>
      </tr>
    </table>

    <div>

    
    </div>
    </form>
</fieldset>
</div>
<%=footer %>
