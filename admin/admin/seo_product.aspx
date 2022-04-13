<%@ Page Language="C#" AutoEventWireup="true" CodeFile="seo_product.aspx.cs" Inherits="hailiadmin_admin_seo_product" %>
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
					<td height="30" class="title_top" align="center">修改产品中心首页SEO设置</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        SEO标题：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoTitle" runat="server" Columns="80" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        SEO关键词：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoKeywords" runat="server" Columns="80" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        SEO描述：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoDesc" runat="server" Columns="67" MaxLength="255" Rows="5" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
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
