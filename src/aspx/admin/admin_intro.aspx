<%@ Page Language="C#" AutoEventWireup="true" EnableSessionState="true" validateRequest="false" CodeFile="admin_intro.aspx.cs" Inherits="JoleYe.Admin.intro" %>
<%=header%>
<div class="page">
    <form id="form1" runat="server">
    <fieldset>
    <legend><asp:Label ID="webtitle" runat="server" Text="Label"></asp:Label></legend>
        <div class="intro">
            <div>
                <input type="hidden" id="content"  runat="server"/>
                <input type="hidden" id="content___Config" value="ToolbarLocation=Out:xToolbar" style="display:none" />
                <iframe id="intro___Frame" src="<%=WEBPATH%>fckeditor/editor/fckeditor.html?InstanceName=content&amp;Toolbar=Default" 
            width="98%" height="400" frameborder="0" scrolling="no"></iframe>
            <br />
文档上传：<iframe name="indeximg_1" src="album/photoAdd.aspx?up_name=insertImg" width="94%" height="30" scrolling="no" marginWidth=1 frameSpacing=0 marginHeight=0 frameBorder=0></iframe>
<input name="insertImg" type="hidden" id="insertImg" value="">
            </div>
            <br />
            <div align="left">
            <asp:Button ID="saveBtn" runat="server" CssClass="button" Text="保存" OnClick="saveBtn_Click" />    
	        <asp:Button CssClass="button" id="reset" runat="server" Text="重置" CommandName="reset" />
            </div>
	    </div>
	</fieldset>
    </form>
</div>
<%=footer%>