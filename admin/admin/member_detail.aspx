<%@ Page Language="C#" AutoEventWireup="true" CodeFile="member_detail.aspx.cs" Inherits="enet0769_admin_member_detail" %>
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
					<td height="30" class="title_top" align="center">查看会员信息</td>
				</tr>
			</table>
<table cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">用户帐号：</th>
    <td style="background-color:#ffffff;"><%#MemberAccount%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">用户密码：</th>
    <td style="background-color:#ffffff;"><%#MemberPassword%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">贵公司名称：</th>
    <td style="background-color:#ffffff;"><%#CompanyName%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">通讯地址：</th>
    <td style="background-color:#ffffff;"><%#Address%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">邮政编码：</th>
    <td style="background-color:#ffffff;"><%#ZipCode%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">联系人：</th>
    <td style="background-color:#ffffff;"><%#Contactor%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">联系人职位：</th>
    <td style="background-color:#ffffff;"><%#ContactorDuty%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">联系电话：</th>
    <td style="background-color:#ffffff;"><%#Tel%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">传真：</th>
    <td style="background-color:#ffffff;"><%#Fax%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">手机：</th>
    <td style="background-color:#ffffff;"><%#Mobile%></td>
  </tr>
  <tr>
    <th align="right" style="height:31px; background-color:#dfefff">电子邮箱：</th>
    <td style="background-color:#ffffff; height: 31px;"><%#Email%></td>
  </tr>
  <tr>
    <th align="right" style="height:31px; background-color:#dfefff">贵公司网址：</th>
    <td style="background-color:#ffffff;"><%#WebSite%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff; padding-top:14px;" valign="top">贵公司简介：</th>
    <td style="background-color:#ffffff;"><%#MemberProfile%></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff">注册时间：</th>
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
