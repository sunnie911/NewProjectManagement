<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modify_password.aspx.cs" Inherits="enet0769_admin_modify_password" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
					<td height="30" class="title_top" align="center">修改管理员密码</td>
				</tr>
			</table>
			<asp:Panel runat="server" ID="ModifyPasswordPanel" Visible="True" Width="100%">
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">用户名：</th>
                    <td bgcolor="#ffffff">
                        <asp:Label ID="ShowAdminAccount" runat="server"></asp:Label></td>
                </tr>
				<TR>
					<TH align="right" bgColor="#dfefff">
						旧密码：</TH>
					<TD bgColor="#ffffff">
						<asp:TextBox id="Password" runat="server" TextMode="Password" MaxLength="20" Columns="30"></asp:TextBox><BR>
						<asp:RequiredFieldValidator id="Requiredfieldvalidator1" runat="server" Display="Dynamic" ErrorMessage="请输入旧密码。"
							ControlToValidate="Password"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator id="Regularexpressionvalidator1" runat="server" Display="Dynamic" ErrorMessage="旧密码输入错误。密码长度为6-20位，可使用的字符为（A-Z a-z 0-9 ）以及下划线“_”，注意不要使用空格。"
							ControlToValidate="Password" ValidationExpression="[a-zA-Z0-9_]{6,20}"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TH align="right" bgColor="#dfefff">
						新密码：</TH>
					<TD bgColor="#ffffff">
						<asp:TextBox id="Password1" runat="server" TextMode="Password" MaxLength="20" Columns="30"></asp:TextBox><BR>
						<asp:RequiredFieldValidator id="Requiredfieldvalidator2" runat="server" Display="Dynamic" ErrorMessage="请输入新密码。"
							ControlToValidate="Password1"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator id="Regularexpressionvalidator2" runat="server" Display="Dynamic" ErrorMessage="新密码输入错误。密码长度为6-20位，可使用的字符为（A-Z a-z 0-9 ）以及下划线“_”，注意不要使用空格。"
							ControlToValidate="Password1" ValidationExpression="[a-zA-Z0-9_]{6,20}"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TH align="right" bgColor="#dfefff">
						确认新密码：</TH>
					<TD bgColor="#ffffff">
						<asp:TextBox id="Password2" runat="server" TextMode="Password" MaxLength="20" Columns="30"></asp:TextBox><BR>
						<asp:RequiredFieldValidator id="Requiredfieldvalidator3" runat="server" Display="Dynamic" ErrorMessage="请输入确认密码。"
							ControlToValidate="Password2"></asp:RequiredFieldValidator>
						<asp:RegularExpressionValidator id="Regularexpressionvalidator3" runat="server" Display="Dynamic" ErrorMessage="确认密码输入错误。密码长度为6-20位，可使用的字符为（A-Z a-z 0-9 ）以及下划线“_”，注意不要使用空格。"
							ControlToValidate="Password2" ValidationExpression="[a-zA-Z0-9_]{6,20}"></asp:RegularExpressionValidator>
						<asp:CompareValidator id="Comparevalidator1" runat="server" Display="Dynamic" ErrorMessage="两次输入的密码不一致，请重新输入。"
							ControlToValidate="Password2" Operator="Equal" ControlToCompare="Password1"></asp:CompareValidator></TD>
				</TR>
				<TR>
					<TH align="right" bgColor="#dfefff" style="height: 33px">
						&nbsp;</TH>
					<TD bgColor="#ffffff" style="height: 33px">
						<asp:Button id="Button1" runat="server" Text="确认修改" OnClick="Button1_Click"></asp:Button></TD>
				</TR>
			</TABLE>
			</asp:Panel>
			<asp:Panel runat="server" ID="ModifyPasswordResultPanel" Visible="False" Width="100%">
				<TABLE cellSpacing="1" cellPadding="4" width="96%" align="center" bgColor="#77aeee" border="0">
					<TR>
						<TD bgColor="#ffffff">
							<asp:label id="Message" runat="server" CssClass="red_bold"></asp:label></TD>
					</TR>
				</TABLE>
			</asp:Panel>
    </form>
</body>
</html>
