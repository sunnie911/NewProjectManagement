<%@ Page Language="C#" AutoEventWireup="true" CodeFile="site_config.aspx.cs" Inherits="hailiadmin_admin_site_config" ValidateRequest="false" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<%@ Register assembly="FredCK.FCKeditorV2" namespace="FredCK.FCKeditorV2" tagprefix="FCKeditorV2" %>
    
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
					<td height="30" class="title_top" align="center">网站配置</td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">公司名称：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="CompanyName" runat="server" Columns="60" MaxLength="255"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入公司名称" ControlToValidate="CompanyName" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">公司Logo：</th>
                    <td bgcolor="#ffffff"><input id="myfileAdd" type="file" size="50" name="myfile" runat="server" />&nbsp;&nbsp;<span class="red">如果不上传图片，请留空。</span><br />
                    <asp:Image ID="LogoPicUrl" runat="server" Width="200px" />
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:9px;" valign="top">
                        图片Alt属性：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="LogoAlt" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:28px">公众号图片：</th>
                    <td bgcolor="#ffffff"><input id="myfile1Add" type="file" size="50" name="myfile1" runat="server" />&nbsp;&nbsp;<span class="red">如果不上传图片，请留空。</span><br />
                    <asp:Image ID="ErweimaPicUrl" runat="server" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:9px;" valign="top">
                        公众号说明：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="ErweimaAlt" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:28px">手机版二维码：</th>
                    <td bgcolor="#ffffff"><input id="myfile2Add" type="file" size="50" name="myfile2" runat="server" />&nbsp;&nbsp;<span class="red">如果不上传图片，请留空。</span><br />
                    <asp:Image ID="MobilePicUrl" runat="server" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:9px;" valign="top">
                        手机版说明：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="MobileAlt" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        公司地址：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Address" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        固定电话：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Tel" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        联 系 人：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Contacts" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        400电话：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Tel400" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        手机号码：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Mobile" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        传真号码：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Fax" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        E-mail：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Email" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        网址：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="WebSite" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        备 案 号：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="RecordNumber" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>                
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        统计代码：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="Statistics" runat="server" Columns="60" MaxLength="255" Rows="8" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr> 
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="btn_Ok" runat="server" Text=" 确认修改 " OnClick="btn_Update_Click"></asp:button>
                        &nbsp;<input id="Reset1" type="reset" value=" 取消 " /></td>
                </tr>
                </table>
                <br /><br />
    </form>
</body>
</html>
