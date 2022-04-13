<%@ Page Language="C#" AutoEventWireup="true" CodeFile="feedback_detail.aspx.cs" Inherits="enet0769_admin_feedback_detail" %>
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
					<td height="30" class="title_top" align="center">查看反馈意见</td>
				</tr>
			</table>
<table cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">类型：</th>
    <td style="background-color:#ffffff;"><%#FBStyle%></td>
  </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">内容：</th>
    <td style="background-color:#ffffff;"><%#FBContent%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">公司名称：</th>
    <td style="background-color:#ffffff;"><%#CompanyName%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">姓名：</th>
    <td style="background-color:#ffffff;"><%#FBName%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">E-mail：</th>
    <td style="background-color:#ffffff;"><%#Email%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">传真：</th>
    <td style="background-color:#ffffff;"><%#Fax%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">电话：</th>
    <td style="background-color:#ffffff;"><%#Tel%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">邮编：</th>
    <td style="background-color:#ffffff;"><%#ZipCode%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">地址：</th>
    <td style="background-color:#ffffff;"><%#Address%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">反馈时间：</th>
    <td style="background-color:#ffffff;"><%#AddTime%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">&nbsp;</th>
    <td style="background-color:#ffffff;"><a href="Javascript:window.history.go(-1)">返回</a></td>
  </tr>
</table>
    </form>
</body>
</html>
