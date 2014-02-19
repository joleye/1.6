<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_edit.aspx.cs" Inherits="admin_adver_admin_edit" %>
<%=header%>
<script type="text/javascript">
function button_onclick()
{
    if($("upname").value=="")
    {
        alert("请先选择");
        return false;
    }
}
</script>
<div class="page">
    <fieldset><legend>添加图片</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b><a href="admin_main.aspx">管理广告</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
    <form enctype="multipart/form-data" id="form1" runat="server">
	  <table width="98%" align="center" class="tb">
  <tr>
    <td align="center" style="height: 30px">选择文件</td>
    <td style="height: 30px"><label>
      <input type="file" class="input" size="30" name="upname" id="upname" /> 支持图片格式：<%=ALLOWIMGTYPE%>
    </label></td>
    </tr>
    
   <tr>
    <td align="center" style="height: 30px">链接地址</td>
    <td style="height: 30px"><label>
      <input type="text" class="input" value="http://" size="50" name="linkUrl" runat="server" id="linkUrl" />
    </label></td>
    </tr>
  <tr>
    <td align="center" style="height: 30px">操作</td>
    <td style="height: 30px"><label>
      <input type="submit" name="button" id="btn" value="上传" language="javascript" onClick="return button_onclick()" onserverclick="btn_ServerClick" runat="server" />
    </label></td>
    </tr>
</table>
</form>
    </div>
    </fieldset>
    
</div>
<%=footer%>
