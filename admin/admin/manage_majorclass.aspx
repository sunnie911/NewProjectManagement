<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_majorclass.aspx.cs" Inherits="enet0769_admin_manage_majorclass" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
					<td height="30" class="title_top" align="center">管理产品分类</td>
				</tr>
			</table>
						<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="MajorID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="MajorID" HeaderText="分类ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="MajorID" DataNavigateUrlFormatString="edit_majorclass.aspx?Action=EditMajorClass&MajorID={0}"
                                    DataTextField="MajorName" HeaderText="分类名称" >
                                    <ControlStyle Width="250px" />
                                </asp:HyperLinkField>
                               <asp:BoundField DataField="MajorSortID" HeaderText="排序ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>                                                                                          
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="发布时间" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='edit_majorclass.aspx?Action=EditMajorClass&MajorID=<%#Eval("MajorID")%>' >编辑</a>&nbsp;&nbsp;
										<a href='edit_majorclass.aspx?Action=DeleteMajorClass&MajorID=<%#Eval("MajorID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
								</ItemTemplate></asp:TemplateField>
                            </Columns>
                            <RowStyle HorizontalAlign="Center" BackColor="White" />
                            <HeaderStyle BackColor="#A5C8F0" Font-Size="13px" />                         
                        </asp:GridView>
					</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td style="height:26px;"><webdiyer:aspnetpager id="AspNetPager1" runat="server" horizontalalign="Center" onpagechanged="AspNetPager1_PageChanged"
        showcustominfosection="Left" width="100%" meta:resourceKey="AspNetPager1" style="font-size:14px" InputBoxStyle="width:19px"
        CustomInfoHTML="一共有<b><font color='red'>%RecordCount%</font></b>条记录 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="10" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px"></webdiyer:aspnetpager></td>
				</tr>
			</table>
			<br /><br />
			<table width="100%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="7"></td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td height="30" class="title_top" align="center">增加产品分类</td>
				</tr>
			</table>
            <table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td><asp:Label ID="PicTip" runat="server" Enabled="False" Font-Bold="True"></asp:Label></td>
				</tr>
			</table>
			<TABLE cellSpacing="1" cellPadding="3" width="96%" align="center" bgColor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">分类名称(中)：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="MajorName" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="MajorName"
                            Display="Dynamic" ErrorMessage="请输入分类名称"></asp:RequiredFieldValidator></td>
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
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">分类图片：</th>
                    <td bgcolor="#ffffff"><INPUT id="myfileAdd" type="file" size="50" name="myfile" runat="server" /></td>
                </tr>
               <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;" valign="top">分类介绍：</th>
                    <td bgcolor="#ffffff">
                    <textarea id="content1" cols="100" rows="8" style="width:100%;height:360px;visibility:hidden;" runat="server"></textarea>
                    </td>
                </tr>
				<TR>
					<TH align="right" bgColor="#dfefff">排序ID：</TH>
					<TD bgColor="#ffffff">
                        <asp:TextBox ID="MajorSortID" runat="server" Columns="10" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="MajorSortID"
                            Display="Dynamic" ErrorMessage="请输入排序ID"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="MajorSortID"
                            Display="Dynamic" ErrorMessage="排序ID只能为数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></TD>
				</TR>
				<TR>
					<TH align="right" bgColor="#dfefff" style="height: 21px"></TH>
					<TD bgColor="#ffffff" style="height: 21px">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认添加" /></TD>
				</TR>
			</TABLE>
            <br /><br />
    </form>
</body>
</html>
