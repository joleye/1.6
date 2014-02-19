<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gl_type_form.aspx.cs" Inherits="JoleYe.Admin.Gl_type_form" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>添加资讯类型</legend>
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
    <div class="blank5"></div>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  		<tr height="25"> 
            <td height="35" align="center" bgcolor="#f6f6f6">信息标题：</td>
            <td align="left" ><input name="ArticleTitle" type="text" class="input" id="className" style="width: 265px;" onblur="this.className='input'" onclick="this.className='inputOnclick'" runat="server"/> <font color="#FF0000">*</font> </td>
        </tr>
        <tr height="25"> 
            <td height="40" colspan="2" align="left">
            &nbsp;&nbsp;&nbsp;
            <input name="B1" type="submit" class="button" value=" 确 定" id="save" runat="server" onserverclick="save_ServerClick">
            <input name="Submit" type="reset" class="button" value="重 设" id="Submit2" runat="server" />
            </td>
        </tr>
     </table>
     </div>
    </fieldset>
    </form>
</div> 
<%=footer%>
