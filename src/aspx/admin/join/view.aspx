<%@ Page Language="C#" AutoEventWireup="true" CodeFile="view.aspx.cs" Inherits="JoleYe.Admin.join_view" %>
<%=header%>
<div class="page">
<fieldset>
<legend>浏览管理加盟申请表</legend>
    <form enctype="multipart/form-data" id="form1" runat="server">
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr>
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="admin_join.aspx">管理加盟申请表</a> |  <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
    <table width="700" border="0" align="center" cellpadding="0" cellspacing="1" bgcolor="#003366">
                  
                  <tr>
                    <td width="88" height="35" align="center" bgcolor="#ffcc66">姓 &nbsp;名</td>
                  <td width="168" bgcolor="#ffffff"><label>
                      &nbsp;<asp:label id="uname" runat="server"></asp:label></label></td>
                    <td width="87" align="center" bgcolor="#ffcc66">性别</td>
                    <td colspan="2" style="width: 279px" bgcolor="#ffffff">
                        <asp:label id="sex" runat="server"></asp:label>
                    </td>
                  </tr>
                  <tr>
                    <td height="35" align="center" bgcolor="#ffcc66">居住地</td>
                    <td bgcolor="#ffffff">
                        &nbsp;<asp:label id="address" runat="server"></asp:label></td>
                    <td align="center" bgcolor="#ffcc66">年龄</td>
                    <td colspan="2" style="width: 279px" bgcolor="#ffffff">
                        <asp:label id="age" runat="server"></asp:label>
                    </td>
                  </tr>
                  <tr>
                    <td align="center" style="height: 35px" bgcolor="#ffcc66">电 &nbsp;话</td>
                    <td style="height: 35px" bgcolor="#ffffff">
                        &nbsp;<asp:label id="telphone" runat="server"></asp:label></td>
                    <td align="center" style="height: 35px" bgcolor="#ffcc66">传真</td>
                    <td colspan="2" style="width: 279px; height: 35px" bgcolor="#ffffff">
                        &nbsp;<asp:label id="fax" runat="server"></asp:label></td>
                  </tr>
                  <tr>
                    <td align="center" style="height: 35px" bgcolor="#ffcc66">公司名称</td>
                    <td colspan="4" style="height: 35px" bgcolor="#ffffff">
                        <asp:label id="company" runat="server"></asp:label>
                    </td>
                  </tr>
                  <tr>
                    <td height="35" align="center" bgcolor="#ffcc66">公司地址</td>
                    <td colspan="4" bgcolor="#ffffff">
                        &nbsp;<asp:label id="comaddress" runat="server"></asp:label></td>
                  </tr>
                  <tr>
                    <td align="center" style="height: 35px" bgcolor="#ffcc66">资金状况</td>
                      <td colspan="4" style="height: 35px" bgcolor="#ffffff">
                          <asp:label id="zijin" runat="server"></asp:label>
                      </td>
                  </tr>
        <tr>
            <td align="center" height="35" bgcolor="#ffcc66">
                留言内容</td>
            <td colspan="4" bgcolor="#ffffff">
                <asp:label id="content" runat="server"></asp:label>
            </td>
        </tr>
                </table>
    </div>
  </form>
</fieldset>
</div>
<%=footer%>
