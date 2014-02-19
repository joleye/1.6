<%@ Page Language="C#" AutoEventWireup="true" CodeFile="admin_nav.aspx.cs" Inherits="JoleYe.Admin.admin_nav" %>
<%=header%>
<div class="page">
    <fieldset>
    <legend><asp:Label ID="webtitle" runat="server" Text="管理菜单" Width="150px" Height="37px"></asp:Label></legend>
        <form id="form1" runat="server" method="post">
        <div class="info_nav">
        <div class="title">导航菜单管理，您可以根据您的系统定制系统菜单，把不需要的导航栏目去掉，省去找栏目的时间哦，放心使用吧</div>
        <div runat="server" id="list"></div><br />
        <input onclick="JOLE.checkAll(this,'show');" type="checkbox"/>全选
        <br /><br /><asp:button id="save_btn" runat="server" text="保存" CssClass="button" OnClick="save_btn_Click" /> <input name="重置" type="reset" value="重置" class="button" />
        </div>
        
    </form>
    </fieldset>
</div>
<%=footer%>