<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_site_info.aspx.cs" Inherits="enet0769_admin_edit_site_info" ValidateRequest="false" %>
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
					<td height="30" class="title_top" align="center">
                        修改站点信息</td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">信息标题：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SiteInfoTitle" runat="server" Columns="60" MaxLength="255"></asp:TextBox><br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入信息标题" ControlToValidate="SiteInfoTitle" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        信息分类：</th>
                    <td bgcolor="#ffffff"><asp:DropDownList ID="SiteInfoClassID" runat="server">
                        </asp:DropDownList></td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        SEO标题：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoTitle" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        SEO关键词：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoKeywords" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        SEO描述：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoDesc" runat="server" Columns="47" MaxLength="255" Rows="3" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">信息内容：</th>
                    <td bgcolor="#ffffff">
                    <textarea id="content1" cols="100" rows="8" style="width:100%;height:400px;visibility:hidden;" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <th bgcolor="#dfefff"></th>
                    <td bgcolor="#ffffff"><asp:button id="btn_Ok" runat="server" Text="确认修改" OnClick="btn_Update_Click" ></asp:button></td>
                </tr>
                </TABLE>
                <br /><br />
    </form>
</body>
</html>
