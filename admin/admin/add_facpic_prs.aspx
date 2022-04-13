<%@ Page Language="C#" AutoEventWireup="true" CodeFile="add_facpic_prs.aspx.cs" Inherits="enet0769_admin_add_facpic_prs" %>
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
					<td height="30" class="title_top" align="center">增加案例图片</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <td bgcolor="#ffffff">增加案例图片成功。<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="add_facpic.aspx">增加新的案例图片</asp:HyperLink></td>
                </tr>
                </TABLE>
    </form>
</body>
</html>
