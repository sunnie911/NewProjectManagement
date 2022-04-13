<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_sitemap.aspx.cs" Inherits="admin_admin_edit_sitemap" %>
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
					<td height="30" class="title_top" align="center">修改站点地图链接</td>
				</tr>
			</table>
<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">标题名称：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="SitemapTitle" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SitemapTitle"
            Display="Dynamic" ErrorMessage="请输入网站地图标题名称"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
     <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">所属分类：</th>
          <td bgcolor="#ffffff"><asp:DropDownList ID="SitemapClassID" runat="server">
          </asp:DropDownList></td>
   </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">链接网址：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="SitemapLinkUrl" runat="server" Columns="65" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SitemapLinkUrl"
            Display="Dynamic" ErrorMessage="请输入链接网址"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
     <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">优先权比值：</th>
          <td bgcolor="#ffffff"><asp:DropDownList ID="SitemapPriority" runat="server" 
                  Width="80px">
              <asp:ListItem>0.0</asp:ListItem>
              <asp:ListItem>0.1</asp:ListItem>
              <asp:ListItem>0.2</asp:ListItem>
              <asp:ListItem>0.3</asp:ListItem>
              <asp:ListItem>0.4</asp:ListItem>
              <asp:ListItem>0.5</asp:ListItem>
              <asp:ListItem>0.6</asp:ListItem>
              <asp:ListItem>0.7</asp:ListItem>
              <asp:ListItem>0.8</asp:ListItem>
              <asp:ListItem>0.9</asp:ListItem>
              <asp:ListItem>1.0</asp:ListItem>
          </asp:DropDownList>
          <br />
          <span class="gray">
          (Google权值，数字越大，则Google认为该网站地图超链接越重要。设置时遵循2/8定律，20%的超链接设置高权重，80%设置成较低权重。)
          </span>
          </td>
   </tr>
   <tr>
     <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">更新频率：</th>
          <td bgcolor="#ffffff"><asp:DropDownList ID="SitemapChangeFreq" runat="server" 
                  Width="126px">
              <asp:ListItem Value="always">页面总是在更新</asp:ListItem>
              <asp:ListItem Value="hourly">每小时更新一次</asp:ListItem>
              <asp:ListItem Value="daily">每天更新一次</asp:ListItem>
              <asp:ListItem Value="weekly">每星期更新一次</asp:ListItem>
              <asp:ListItem Value="monthly">每月更新一次</asp:ListItem>
              <asp:ListItem Value="yearly">每年更新一次</asp:ListItem>
          </asp:DropDownList>
          <br />
          <span class="gray">
          (Google更新频率，如果设置经常更新，则Google将会认为您的网站经常修改，Google将会经常到您的网站找到当前页面进行重新收录。)
          </span>
          </td>
   </tr>
  <tr>
	<th align="right" bgcolor="#dfefff">排序ID：</th>
	<td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapSortID" runat="server" Columns="10" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="SitemapSortID"
                            Display="Dynamic" ErrorMessage="请输入排序ID"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SitemapSortID"
                            Display="Dynamic" ErrorMessage="排序ID只能为数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;"></th>
    <td style="background-color:#ffffff;">
        <asp:Button ID="Button1" runat="server" Text="确认修改" OnClick="Button1_Click" /></td>
  </tr>
</table>
<br /><br />
    </form>
</body>
</html>
