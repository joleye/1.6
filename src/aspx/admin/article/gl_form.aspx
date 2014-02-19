<%@ Page Language="C#" AutoEventWireup="true" aspcompat="true" CodeFile="gl_form.aspx.cs" Inherits="JoleYe.Admin.gl_form" validateRequest="false" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
    <fieldset><legend>添加资讯</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;"><b>&nbsp;管理导航：</b> <a href="gl_form.aspx?classid=<%=classid %>&act=add">添加新资讯</a>
            | <a href="gl_manage.aspx?classid=<%=classid %>">管理资讯</a> | <a href="javascript:history.back()">返回</a></td>
      </tr>
    </table>
    </div>
    <div class="blank5"></div>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  		<tr height="25"> 
            <td height="35" align="center" bgcolor="#f6f6f6">信息标题：</td>
            <td align="left" ><input name="ArticleTitle" type="text" class="input" id="ArticleTitle" style="width: 420;" size="40" runat="server"/> <font color="#FF0000">*</font> </td>
          </tr>
          <tr height="25">
            <td height="35" align="center" bgcolor="#f6f6f6">信息类别：</td>
            <td align="left" >

                <asp:dropdownlist id="classId" runat="server" Width="114px" DataTextField="className" DataValueField="id"><asp:ListItem Selected="True" Value="OOO">请选择信息类目</asp:ListItem>
</asp:dropdownlist>

              <font color="#FF0000">*</font></td>
          </tr>
        <tr height="25">
            <td align="center" bgcolor="#f6f6f6" height="35">
                出处：</td>
            <td align="left"><input type="text" class="input" name="source" id="source" runat="server" />
            </td>
        </tr>
          <tr height="25"> 
            <td height="35" align="center" bgcolor="#f6f6f6">相关图片：</td>
            <td align="left">
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
              <tr>
                <td width="400"><input name="bigImg" type="file" class="input" id="imgUrl" size="40" /></td>
                <td><div class="listImg">
                <a href="javascript:;" id="listImgA" runat="server" onmouseover="$('listImg').style.display = 'block';" onmouseout="$('listImg').style.display = 'none';" target="_blank">查看</a><span class="img" id="listImg"><img src="../../images/Logo.gif" runat="server" id="articleImg"/></span></div></td>
              </tr>
            </table></td>
          </tr>
          
          <tr height="25">
            <td height="300" align="center" bgcolor="#f6f6f6">详细信息</td>
            <td align="left">
            <input name="content" type="hidden" value="" id="content" runat="server" />
            <input type="hidden" id="content___Config" value="ToolbarLocation=Out:xToolbar" style="display:none" />
<iframe id="content___Frame" src="<%=WEBPATH%>fckeditor/editor/fckeditor.html?InstanceName=content&amp;Toolbar=Default" 
width="80%" height="350" frameborder="0" scrolling="no"></iframe>
<br />
文档上传：<iframe name="indeximg_1" src="../album/photoAdd.aspx?up_name=insertImg" width="94%" height="30" scrolling="no" marginWidth=1 frameSpacing=0 marginHeight=0 frameBorder=0></iframe>
<input name="insertImg" type="hidden" id="insertImg" value="">
</td>
          </tr>
          <tr height="25"> 
            <td height="40" colspan="2" align="left">
            &nbsp;&nbsp;&nbsp;<input name="B1" type="submit" class="button" value=" 确 定" id="Submit1" onserverclick="Submit1_ServerClick" runat="server">
            <input name="Submit" type="reset" class="button" value="重 设" id="Submit2" onserverclick="Submit1_ServerClick" runat="server" />
            <input type="hidden" runat="server" name="filePath" id="filePath" /></td>
        </tr>
     </table>
    </div>
    </fieldset>
    </form>
</div> 
<%=footer%>

