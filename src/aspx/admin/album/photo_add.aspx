<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photo_add.aspx.cs" Inherits="JoleYe.Admin.album_photo_add" %>
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
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="photo_add.aspx">添加图片</a>
            | <a href="admin_main.aspx">管理图片</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="content">
    <form enctype="multipart/form-data" id="form1" runat="server">
	  <table width="98%" align="center" border="0"  class="tb">
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
      <input type="checkbox" runat="server" value="1" id="showHome"/>首页显示？
    </label></td>
    </tr>
  <tr>
    <td align="center" style="height: 30px">操作</td>
    <td style="height: 30px"><label>
      <input type="submit" name="button" id="btn" value="上传" language="javascript" onclick="return button_onclick()" onserverclick="btn_ServerClick" runat="server" />
    </label></td>
    </tr>
</table>

    </fieldset>
    </div>
    </form>
</div>
<%=footer%>
