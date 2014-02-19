<%@ Page Language="C#" AutoEventWireup="true" CodeFile="webMain.aspx.cs" Inherits="JoleYe.Admin.webMain" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<link href="css/config.css" rel="stylesheet" type="text/css" />
<title>JoleYe!net发布系统 Powered by JoleYe!net</title>
<script type="text/javascript">
function goto(str)
{
	parent.document.getElementById("leftFrame").src = "treeLeft.aspx?tp="+str;
}
</script>
</head>

<frameset rows="63,*" cols="*" frameborder="no" border="0" framespacing="0">
  <frame src="top.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" title="topFrame" />
  <frameset rows="*" cols="170,*" framespacing="1" frameborder="no" border="1">
    <frame src="treeLeft.aspx" name="leftFrame" scrolling="No" noresize="noresize" id="leftFrame" title="leftFrame" />
    <frame src="welcome.aspx" name="main" id="main" title="main" />
  </frameset>
</frameset>
<noframes></noframes>
</html>