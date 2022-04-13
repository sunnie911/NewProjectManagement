<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_friendlink.aspx.cs" Inherits="enet0769_admin_add_friendlink" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>
    <link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="30" class="title_top" align="center">增加友情链接</td>
				</tr>
			</table>
<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">网站名称：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="LinkKeyword" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LinkKeyword"
            Display="Dynamic" ErrorMessage="请输入网站名称"></asp:RequiredFieldValidator></td>
  </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">链接网址：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="LinkUrl" runat="server" Columns="45" MaxLength="50" Text="http://"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="LinkUrl"
            Display="Dynamic" ErrorMessage="请输入链接网址"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th valign="top" align="right" style="height:25px; background-color:#dfefff; padding-top:10px">备注说明：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="LinkDesc" runat="server" Columns="42" Rows="3" 
            TextMode="MultiLine"></asp:TextBox>
            </td>
  </tr>
  <tr>
	<th align="right" bgcolor="#dfefff">排序ID：</th>
	<td bgcolor="#ffffff">
                        <asp:TextBox ID="LinkSortID" runat="server" Columns="10" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="LinkSortID"
                            Display="Dynamic" ErrorMessage="请输入排序ID"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="LinkSortID"
                            Display="Dynamic" ErrorMessage="排序ID只能为数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;"></th>
    <td style="background-color:#ffffff;">
        <asp:Button ID="Button1" runat="server" Text="确认增加" OnClick="Button1_Click" /></td>
  </tr>
</table>
<br /><br />
    </form>
</body>
</html>
