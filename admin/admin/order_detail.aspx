<%@ Page Language="C#" AutoEventWireup="true" CodeFile="order_detail.aspx.cs" Inherits="enet0769_admin_order_detail" %>
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
					<td height="30" class="title_top" align="center">管理在线订单</td>
				</tr>
			</table>
<table cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">订单主题：</th>
    <td style="background-color:#ffffff;"><%#OrderSubject%></td>
  </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">订单说明：</th>
    <td style="background-color:#ffffff;"><%#OrderDesc%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">公司名称：</th>
    <td style="background-color:#ffffff;"><%#CompanyName%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">负责人姓名：</th>
    <td style="background-color:#ffffff;"><%#Manager%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">联系地址：</th>
    <td style="background-color:#ffffff;"><%#Address%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">邮编：</th>
    <td style="background-color:#ffffff;"><%#ZipCode%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">电话：</th>
    <td style="background-color:#ffffff;"><%#Tel%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">传真：</th>
    <td style="background-color:#ffffff;"><%#Fax%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">手机：</th>
    <td style="background-color:#ffffff;"><%#Mobile%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">网址：</th>
    <td style="background-color:#ffffff;"><%#WebSite%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">E-mail：</th>
    <td style="background-color:#ffffff;"><%#Email%></td>
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
