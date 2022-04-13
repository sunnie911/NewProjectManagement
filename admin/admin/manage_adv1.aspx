<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_adv1.aspx.cs" Inherits="enet0769_admin_manage_adv1" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
					<td height="30" class="title_top" align="center">网站广告管理</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <td style="background-color:#ffffff; height:23px;">您没有删除Banner广告的权限。<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="manage_adv.aspx">返回</asp:HyperLink></td>
                </tr>
                </TABLE>
    </form>
</body>
</html>
