<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_sitemap.aspx.cs" Inherits="admin_admin_manage_sitemap" %>
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
					<td height="30" class="title_top" align="center">管理站点地图链接</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="SitemapID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="SitemapID" HeaderText="链接ID" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="SitemapLinkUrl" DataNavigateUrlFormatString="../..{0}"
                                    DataTextField="SitemapTitle" HeaderText="标题名称" Target="_blank" >
                                    <ControlStyle Width="150px" />
                                </asp:HyperLinkField>
                                <asp:BoundField DataField="SitemapLinkUrl" HeaderText="链接网址" >
                                    <ControlStyle Width="120px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="SitemapPriority" HeaderText="Google权值" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField> 
                                  <asp:BoundField DataField="SitemapChangeFreq" HeaderText="Google更新频率" >
                                    <ControlStyle Width="120px" />
                                </asp:BoundField> 
                                 <asp:BoundField DataField="SitemapClassName" HeaderText="所属分类" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField> 
                                <asp:BoundField DataField="SitemapSortID" HeaderText="排序" >
                                    <ControlStyle Width="50px" />
                                </asp:BoundField>                                                            
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="发布时间" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='edit_sitemap.aspx?Action=EditSitemap&SitemapID=<%#Eval("SitemapID")%>' >编辑</a>&nbsp;&nbsp;
										<a href='edit_sitemap.aspx?Action=DeleteSitemap&SitemapID=<%#Eval("SitemapID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
        CustomInfoHTML="一共有<b><font color='red'>%RecordCount%</font></b>条记录 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="25" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px"></webdiyer:aspnetpager></td>
				</tr>
			</table>
    </form>
</body>
</html>
