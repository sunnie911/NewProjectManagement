<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_adv.aspx.cs" Inherits="hailiadmin_admin_edit_adv" %>
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
					<td height="30" class="title_top" align="center">修改网站广告</td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">广告名称：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="AdvName" runat="server" Columns="60" MaxLength="255"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入广告名称" ControlToValidate="AdvName" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        广告位置：</th>
                    <td bgcolor="#ffffff"><asp:DropDownList ID="AdvClassID" runat="server">
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">广告图片：</th>
                    <td bgcolor="#ffffff"><INPUT id="myfileAdd" type="file" size="50" name="myfile" runat="server" />&nbsp;&nbsp;<span class="red">如果不上传图片，请留空。</span><br />
                    <asp:Image ID="AdvPic" runat="server" Width="200px" />
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        链接网址：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="LinkUrl" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        广告排序：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="AdvSortID" runat="server" Columns="5">0</asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="AdvSortID" Display="Dynamic" ErrorMessage="请输入数字"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="AdvSortID"
                            Display="Dynamic" ErrorMessage="请输入最大4位数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="btn_Ok" runat="server" Text=" 确认修改 " OnClick="btn_Update_Click" ></asp:button>
                        &nbsp;<input id="Reset1" type="reset" value=" 取消 " /></td>
                </tr>
                </table>
                <br /><br />
    </form>
</body>
</html>
