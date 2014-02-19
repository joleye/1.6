<%@ Page Language="C#" AutoEventWireup="true" ValidateRequest="false" CodeFile="pro_type_form.aspx.cs" Inherits="JoleYe.Admin.ProductTypeForm" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset><legend>添加产品类型</legend>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr> 
        <td align="center" background="../../images/admin_top_bg.jpg" style="border-left: 1 solid #C0C0C0;border-top: 1 solid #C0C0C0;border-right: 1 solid #C0C0C0; height: 25px;"></td>
      </tr>
      <tr> 
      
        <td bgcolor="#F7F7F7" style="border: 1 solid #C0C0C0; height: 30px;">
            <b>&nbsp;管理导航：</b> 
            添加新类别 | 
            <a href="pro_type.aspx" runat="server" id="manage_type">管理类别</a> | 
            <a href="javascript:history.back()">返回</a>
        </td>
      </tr>
    </table>
    </div>
    <div class="blank5"></div>
    <div class="content">
    <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
  		<tr height="25"> 
            <td height="35" align="center" bgcolor="#f6f6f6" style="width: 205px">信息标题：</td>
            <td align="left" ><input name="ProductTypeName" type="text" class="input" id="ProductTypeName" style="width: 265px;" onblur="this.className='input'" onclick="this.className='inputOnclick'" runat="server"/> <font color="#FF0000">*</font>
            <asp:label runat="server" id="labelErr" text=""></asp:label></td>
        </tr>
        
  		<tr height="25"> 
            <td height="35" align="center" bgcolor="#f6f6f6">排序：</td>
            <td align="left" ><input name="orderId" type="text" class="input" id="orderId" style="width: 100px;" value="255" runat="server"/> <font color="#FF0000">*</font>
            </td>
        </tr>
        <tr height="25">
            <td align="center" bgcolor="#f6f6f6" height="35" style="width: 205px">
                图片：</td>
            <td align="left">
                <input id="fileimg" class="input" type="file" runat="server" />
                <input type="checkbox" name="delimg" id="delimg" value="1"/>
          删除? <span id="view_img" runat="server"></span>
            </td>
        </tr>
        <tr height="25">
            <td align="center" bgcolor="#f6f6f6" height="35" style="width: 205px">
                说明：</td>
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
            &nbsp;&nbsp;&nbsp;
            <input type="hidden" name="imgUrl" id="imgUrl" runat="server" />
            <input name="B1" type="submit" class="button" value=" 确 定" id="save" runat="server" onserverclick="save_ServerClick">
            <input name="Submit" type="reset" class="button" value="重 设" />
            </td>
        </tr>
     </table>
     </div>
    </fieldset>
    </form>
</div>
<%=footer %>
