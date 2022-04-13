<%@ Page Language="C#" AutoEventWireup="true" CodeFile="morepic_product2.aspx.cs" Inherits="enet0769_admin_morepic_product2" ValidateRequest="false" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>管理产品多图</title>
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
					<td height="30" class="title_top" align="center">管理产品多图&nbsp;&nbsp;&nbsp;&nbsp;<a href="manage_product2.aspx">返回管理公司产品</a></td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
            <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称：</th>
                    <td bgcolor="#ffffff"><%#ProductName%>（图2）</td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><input id="myfileAdd" type="file" size="50" name="myfile" runat="server" /><br />
                    <asp:Image ID="pimg1" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="btn1_Ok" runat="server" Text=" 修改 " OnClick="btn1_Ok_Click" ></asp:button></td>
                </tr>
            </table>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="Label1" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
            <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称：</th>
                    <td bgcolor="#ffffff"><%#ProductName%>（图3）</td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><input id="File2" type="file" size="50" name="myfile2" runat="server" /><br />
                    <asp:Image ID="pimg2" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="btn2_Ok" runat="server" Text=" 修改 " OnClick="btn2_Ok_Click" ></asp:button></td>
                </tr>
            </table>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="Label2" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
            <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称：</th>
                    <td bgcolor="#ffffff"><%#ProductName%>（图4）</td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><input id="File3" type="file" size="50" name="myfile3" runat="server" /><br />
                    <asp:Image ID="pimg3" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="Button3" runat="server" Text=" 修改 " OnClick="btn3_Ok_Click" ></asp:button></td>
                </tr>
            </table>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="Label3" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
            <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称：</th>
                    <td bgcolor="#ffffff"><%#ProductName%>（图5）</td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><input id="File4" type="file" size="50" name="myfile4" runat="server" /><br />
                    <asp:Image ID="pimg4" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="Button4" runat="server" Text=" 修改 " OnClick="btn4_Ok_Click" ></asp:button></td>
                </tr>
            </table>
             <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="Label4" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
            <table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称：</th>
                    <td bgcolor="#ffffff"><%#ProductName%>（图6）</td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><input id="File5" type="file" size="50" name="myfile5" runat="server" /><br />
                    <asp:Image ID="pimg5" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="Button5" runat="server" Text=" 修改 " OnClick="btn5_Ok_Click" ></asp:button></td>
                </tr>
            </table>
            <table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="36"></td>
				</tr>
			</table>
    </form>
</body>
</html>
