<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_project_case.aspx.cs" Inherits="enet0769_admin_edit_project_case" ValidateRequest="false"  %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../kindeditor/themes/default/default.css" />
	<link rel="stylesheet" href="../kindeditor/plugins/code/prettify.css" />
	<script charset="utf-8" src="../kindeditor/kindeditor-all.js"></script>
	<script charset="utf-8" src="../kindeditor/lang/zh-CN.js"></script>
	<script charset="utf-8" src="../kindeditor/plugins/code/prettify.js"></script>
	<script>
	    KindEditor.ready(function (K) {
	        var editor1 = K.create('#content1', {
	            cssPath: '../kindeditor/plugins/code/prettify.css',
	            uploadJson: '../kindeditor/asp.net/upload_json.ashx',
	            fileManagerJson: '../kindeditor/asp.net/file_manager_json.ashx',
	            allowFileManager: true,
	            filterMode: false,
	            afterCreate: function () {
	                var self = this;
	                K.ctrl(document, 13, function () {
	                    self.sync();
	                    K('form[name=form1]')[0].submit();
	                });
	                K.ctrl(self.edit.doc, 13, function () {
	                    self.sync();
	                    K('form[name=form1]')[0].submit();
	                });
	            }
	        });
	        prettyPrint();
	    });
	</script>
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
					<td height="30" class="title_top" align="center">修改喷嘴视频</td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">视频名称：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="ProjectName" runat="server" Columns="60" MaxLength="255"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入产品视频名称" ControlToValidate="ProjectName" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">视频缩略图：</th>
                    <td bgcolor="#ffffff"><input id="myfileAdd" type="file" size="50" name="myfile" runat="server" /> &nbsp;<span class="red">如果不上传文件，请留空。</span><br />
                    <asp:Image ID="NewsPic" runat="server" Width="80px" />
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">视频说明：</th>
                    <td bgcolor="#ffffff">
                    <textarea id="content1" cols="100" rows="8" style="width:100%;height:400px;visibility:hidden;" runat="server"></textarea>
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
