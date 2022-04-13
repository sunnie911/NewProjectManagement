<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestbook_detail.aspx.cs" Inherits="enet0769_admin_guestbook_detail" %>
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
					<td height="30" class="title_top" align="center">查看留言</td>
				</tr>
			</table>
			<table cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">姓名：</th>
    <td style="background-color:#ffffff;"><%#GuestName%></td>
  </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">职位：</th>
    <td style="background-color:#ffffff;"><%#GuestPosition%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">性别：</th>
    <td style="background-color:#ffffff;"><%#Sex%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">单位：</th>
    <td style="background-color:#ffffff;"><%#CompanyName%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">电话：</th>
    <td style="background-color:#ffffff;"><%#Tel%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">邮箱：</th>
    <td style="background-color:#ffffff;"><%#Email%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">网址：</th>
    <td style="background-color:#ffffff;"><%#WebSite%></td>
  </tr>
  <tr>
    <th valign="top" align="right" style="height:25px; background-color:#dfefff; padding-top:10px">内容：</th>
    <td style="background-color:#ffffff;"><%#GuestContent%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">&nbsp;</th>
    <td style="background-color:#ffffff;"><a href="Javascript:window.history.go(-1)">返回</a></td>
  </tr>
</table>
    </form>
</body>
</html>
