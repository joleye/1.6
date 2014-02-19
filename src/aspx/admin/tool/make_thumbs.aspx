<%@ Page Language="C#" AutoEventWireup="true" CodeFile="make_thumbs.aspx.cs" Inherits="admin_tool_make_thumbs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="create_auto_thumbs" runat="server" OnClick="create_auto_thumbs_Click"
            Text="生成80小图片" />
            <br />
            <asp:Button ID="create_279_thumbs" runat="server" 
            Text="生成279小图片" OnClick="create_279_thumbs_Click" /></div>
    </form>
</body>
</html>
