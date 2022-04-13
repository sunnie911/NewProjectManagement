<%@ Page Language="C#" AutoEventWireup="true" CodeFile="edit_product2.aspx.cs" Inherits="enet0769_admin_edit_product2" ValidateRequest="false" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
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

	        var editor2 = K.create('#content2', {
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
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="30" class="title_top" align="center">修改公司产品</td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品名称(中)：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="ProductName" runat="server" Columns="60" MaxLength="255"></asp:TextBox> 
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="请输入产品名称" ControlToValidate="ProductName" Display="Dynamic"></asp:RequiredFieldValidator></td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品型号：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="ProductModel" runat="server" Columns="40" MaxLength="50"></asp:TextBox>&nbsp;&nbsp;权重：<asp:TextBox 
                            ID="HomeOrder" runat="server" Columns="5">0</asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                            ControlToValidate="HomeOrder" Display="Dynamic" ErrorMessage="请输入数字"></asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="HomeOrder"
                            Display="Dynamic" ErrorMessage="请输入最大4位数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">所属分类：</th>
                    <td bgcolor="#ffffff">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
<asp:DropDownList id="MajorID" runat="server" AutoPostBack="True"></asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">产品图片：</th>
                    <td bgcolor="#ffffff"><INPUT id="myfileAdd" type="file" size="50" name="myfile" runat="server" />&nbsp;&nbsp;<span class="red">如果不上传图片，请留空。</span><br />
                    <asp:Image ID="NewsPic" runat="server" Width="80px" />
                    </td>
                </tr>
                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        SEO标题(中)：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoTitle" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        SEO关键词(中)：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoKeywords" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">
                        SEO描述(中)：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SeoDesc" runat="server" Columns="47" MaxLength="255" Rows="3" 
                            TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">产品说明：</th>
                    <td bgcolor="#ffffff">
                    <textarea id="content1" cols="100" rows="8" style="width:100%;height:400px;visibility:hidden;" runat="server"></textarea>
                    </td>
                </tr>
                 <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">手 机 版：</th>
                    <td bgcolor="#ffffff">
                    <textarea id="content2" cols="100" rows="8" style="width:100%;height:400px;visibility:hidden;" runat="server"></textarea>
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
