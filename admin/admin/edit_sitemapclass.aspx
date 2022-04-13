<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_sitemapclass.aspx.cs" Inherits="admin_admin_edit_sitemapclass" %>
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
					<td height="30" class="title_top" align="center">修改站点地图分类</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">分类名称：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapClassName" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SitemapClassName"
                            Display="Dynamic" ErrorMessage="请输入类别名称"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        链接网址：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapClassLinkUrl" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
				<TR>
					<TH align="right" bgColor="#dfefff">排序ID：</TH>
					<TD bgColor="#ffffff">
                        <asp:TextBox ID="SitemapClassSortID" runat="server" Columns="10" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SitemapClassSortID"
                            Display="Dynamic" ErrorMessage="请输入排序ID"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SitemapClassSortID"
                            Display="Dynamic" ErrorMessage="排序ID只能为数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TH align="right" bgColor="#dfefff" style="height: 21px"></TH>
					<TD bgColor="#ffffff" style="height: 21px">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Update_Click" 
                            Text="确认修改" style="height: 26px" /></TD>
				</TR>
				</TABLE>
    </form>
</body>
</html>
