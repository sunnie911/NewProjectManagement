﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_sitemap_class.aspx.cs" Inherits="admin_admin_manage_sitemap_class" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
					<td height="30" class="title_top" align="center">管理站点地图分类</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="SitemapClassID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="SitemapClassID" HeaderText="分类ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="SitemapClassID" DataNavigateUrlFormatString="edit_sitemapclass.aspx?Action=EditSitemapClass&SitemapClassID={0}"
                                    DataTextField="SitemapClassName" HeaderText="分类名称" >
                                    <ControlStyle Width="150px" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="SitemapClassLinkUrl" HeaderText="链接网址" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>  
                               <asp:BoundField DataField="SitemapClassSortID" HeaderText="排序ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>                                                                                          
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="发布时间" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='edit_sitemapclass.aspx?Action=EditSitemapClass&SitemapClassID=<%#Eval("SitemapClassID")%>' >编辑</a>&nbsp;&nbsp;
										<a href='edit_sitemapclass.aspx?Action=DeleteSitemapClass&SitemapClassID=<%#Eval("SitemapClassID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
					<td height="30" class="title_top" align="center">增加站点地图分类</td>
				</tr>
			</table>
			<table cellspacing="1" cellpadding="3" width="96%" align="center" bgcolor="#77aeee" border="0">
                <tr>
                    <th align="right" bgcolor="#dfefff" width="120" style="height:25px">类别名称：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapClassName" runat="server" Columns="35" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="SitemapClassName"
                            Display="Dynamic" ErrorMessage="请输入站点地图分类名称"></asp:RequiredFieldValidator></td>
                </tr>
                                <tr>
                    <th align="right" bgcolor="#dfefff" style="height:25px; padding-top:7px;">
                        链接网址：</th>
                    <td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapClassLinkUrl" runat="server" Columns="60" MaxLength="255"></asp:TextBox>
                    </td>
                </tr>
				<tr>
					<th align="right" bgcolor="#dfefff">排序ID：</th>
					<td bgcolor="#ffffff">
                        <asp:TextBox ID="SitemapClassSortID" runat="server" Columns="10" MaxLength="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="SitemapClassSortID"
                            Display="Dynamic" ErrorMessage="请输入排序ID"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="SitemapClassSortID"
                            Display="Dynamic" ErrorMessage="排序ID只能为数字" ValidationExpression="[0-9]{1,4}"></asp:RegularExpressionValidator></td>
				</tr>
				<tr>
					<th align="right" bgcolor="#dfefff" style="height: 21px"></th>
					<td bgcolor="#ffffff" style="height: 21px">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认添加" /></td>
				</tr>
			</table>
            <br /><br />
    </form>
</body>
</html>
