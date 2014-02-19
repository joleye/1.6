<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photoAdd.aspx.cs" Inherits="JoleYe.Admin.photoAdd" %>
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
<form enctype="multipart/form-data" id="form1" runat="server" method="post">
  <input type="file" class="input" size="30" name="fileField" id="upname" />
  <input type="submit" name="button" id="btn" value="上传" onclick="return button_onclick()"  language="javascript" onserverclick="btn_ServerClick" runat="server" />
  支持文件类型：<%=ALLOWIMGTYPE%>
</form>
</body>
</html>