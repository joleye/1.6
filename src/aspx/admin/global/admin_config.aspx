<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false"  CodeFile="admin_config.aspx.cs" Inherits="JoleYe.Admin.info" %>
<%=header%>
<div class="page">
<fieldset>
<legend>������Ϣ</legend>
<form runat="server">
<table width="100%" border="0" cellspacing="0">
  <tr>
    <td width="20%" height="30" align="right">��վ���ƣ�</td>
    <td width="67%"><asp:TextBox ID="webName" runat="server" CssClass="input" Width="302px"></asp:TextBox>���˴�Ϊ��վ������Ŷ��</td>
  </tr>
  <tr>
    <td align="right" style="height: 32px">��ϵ�ˣ�</td>
    <td style="height: 32px"><asp:TextBox ID="linkMan" runat="server" CssClass="input"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�����ʼ���</td>
    <td><asp:TextBox ID="email" runat="server" CssClass="input" MaxLength="255" Width="328px"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�绰��</td>
    <td><asp:TextBox ID="telphone" runat="server" CssClass="input"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">�ֻ���</td>
    <td><asp:TextBox ID="mobile" runat="server" CssClass="input"></asp:TextBox></td>
  </tr>
  <tr>
    <td height="30" align="right">���棺</td>
    <td>
        <input ID="fax" runat="server" class="input"  /></td>
  </tr>
  <tr>
    <td height="30" align="right">�����У�</td>
    <td><label><input ID="bankName" runat="server" class="input" MaxLength="50" style="width:186px" /></label></td>
  </tr>
  <tr>
    <td height="30" align="right">�����˺ţ�</td>
    <td><label>
      <input name="bankNumber" type="text" class="input" id="bankNumber" value="" size="40" maxlength="50"  runat="server"/>
        </label></td>
  </tr>
  <tr>
    <td height="30" align="right">��ϵ��ַ��</td>
    <td><label>
      <input name="address" type="text" class="input" id="address" value="" size="50" maxlength="255"  runat="server"/>
    </label></td>
  </tr>
  <tr>
    <td height="30" align="right">QQ��</td>
    <td><label>
      <input name="qq" type="text" class="input" id="qq" value="" size="20" maxlength="20"  runat="server"/>
    </label></td>
  </tr>
  <tr>
    <td height="30" align="right">MSN��</td>
    <td><input name="msn" type="text" class="input" id="msn" value="" size="30" maxlength="50"  runat="server"/></td>
  </tr>
  <tr>
    <td height="30" align="right">֧�����˺ţ�</td>
    <td><input name="zhifubao" type="text" class="input" id="zhifubao" value="" size="30" maxlength="50"  runat="server"/></td>
  </tr>
  <tr>
    <td height="30" align="right">����������</td>
    <td><input name="wangwang" type="text" class="input" id="wangwang" value="" size="30" maxlength="50"  runat="server"/></td>
  </tr>
  <tr>
    <td height="30" align="right">�ؼ����Ż���</td>
    <td><textarea name="webKeyword" cols="50" rows="10" class="input" id="webKeyword" style="height:80px"  runat="server"></textarea></td>
  </tr>
  <tr>
    <td height="30" align="right">���˴���</td>
    <td><input name="lawName" type="text" class="input" id="lawName" value="" size="20" maxlength="20"  runat="server"/></td>
  </tr>
  <tr>
    <td height="30" align="right">������Ϣ��</td>
    <td><label>
      <input name="icp" type="text" class="input" id="icp" size="50" maxlength="255"  value="" runat="server" />
    </label></td>
  </tr>
  <tr>
    <td height="80" align="right">ͳ����Ϣ��</td>
    <td><label>
      <textarea name="webNum" cols="50" rows="10" class="input" id="webNum" style="height:80px"  runat="server"></textarea>
    </label>    </td>
  </tr>
  <tr>
    <td height="30" align="right">��վ·����</td>
    <td><div ><input name="webPath" type="text" class="input" id="webPath" value="" size="20" maxlength="20"  runat="server"/> <label style="width:250px;padding-top: 2px;">��Ϊ����Ŀ¼��Ϊ��</label></div></td>
  </tr>
  <tr>
    <td height="80" align="right">&nbsp;</td>
    <td><label>
        &nbsp;<asp:Button ID="btn1" runat="server" CssClass="button" Text="����" OnClick="saveInfo" />
      <input name="button2" type="reset" class="button" id="button2" value="����" />
    </label></td>
  </tr>
</table>
</form>
</fieldset>
</div>
<%=footer%>