<%@ Page Language="C#" AutoEventWireup="true" CodeFile="send_job.aspx.cs" Inherits="enet0769_admin_send_job" ValidateRequest="false" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
					<td height="30" class="title_top" align="center">发布招聘信息</td>
				</tr>
			</table>
<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
  <tr>
    <th align="right" style="width:120px;height:25px; background-color:#dfefff">职位名称：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="JobPosition" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="JobPosition"
            Display="Dynamic" ErrorMessage="请输入职位名称"></asp:RequiredFieldValidator></td>
  </tr>
   <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">招骋部门：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="JobDepartment" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="JobDepartment"
            Display="Dynamic" ErrorMessage="请输入招聘部门"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;">工作地点：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="WorkAddress" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="WorkAddress"
            Display="Dynamic" ErrorMessage="请输入工作地点"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th align="right" style="height:31px; background-color:#dfefff;">有效期限：</th>
    <td style="background-color:#ffffff; height: 31px;">
        <asp:TextBox ID="AttermTime" runat="server" Columns="45" MaxLength="50"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="AttermTime"
            Display="Dynamic" ErrorMessage="请输入有效期限"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th valign="top" align="right" style="height:25px; background-color:#dfefff; padding-top:10px">职位要求：</th>
    <td style="background-color:#ffffff;">
        <asp:TextBox ID="JobDemand" runat="server" Columns="42" Rows="6" 
            TextMode="MultiLine"></asp:TextBox>
            </td>
  </tr>
  <tr>
    <th align="right" style="height:25px; background-color:#dfefff;"></th>
    <td style="background-color:#ffffff;">
        <asp:Button ID="Button1" runat="server" Text="确认发布" OnClick="Button1_Click" /></td>
  </tr>
</table>
<br /><br />
    </form>
</body>
</html>
