<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_product2.aspx.cs" Inherits="enet0769_admin_manage_product2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
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
					<td height="30" class="title_top" align="center">管理公司产品</td>
				</tr>
			</table>
			<table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF" bordercolorlight="#77AEEE">
    <tr>
	<td height="32" style="padding-left:8px;">
        <asp:TextBox ID="Keywords" runat="server" Columns="30"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text=" 搜 索 " OnClick="Button1_Click" />&nbsp;<span class="gray">请输入产品名称</span></td>
    </tr>
</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="ProductID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="产品图片">
                                <ItemTemplate>
                                    <a href='<%#"../../upimage/" + Eval("PicPathBig")%>' target="_blank"><asp:Image ID="Image1" runat="server" ImageUrl='<%#"../../upimage/" + Eval("PicPathSmall")%>' Width="150" /></a>
								</ItemTemplate>
								</asp:TemplateField>
                                <asp:HyperLinkField DataNavigateUrlFields="ProductID" DataNavigateUrlFormatString="../../product_detail-{0}.html"
                                    DataTextField="ProductName" HeaderText="产品名称" Target="_blank" >
                                    <ControlStyle Width="200px" />
                                </asp:HyperLinkField>   
                                <asp:BoundField DataField="MajorName" HeaderText="产品大类" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>                                                    
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="加入时间" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="推荐">
                                    <ItemTemplate><asp:Label ID="lblIsRecommended" runat="server" Text='<%# Bind("IsRecommended") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                        <a href='edit_product2.aspx?Action=EditProduct2&ProductID=<%#Eval("ProductID")%>'>编辑</a>&nbsp;&nbsp;
                                        <a href='edit_product2.aspx?Action=IsRecommended&ProductID=<%#Eval("ProductID")%>'>推荐</a>&nbsp;&nbsp;<br /><br />                              
                                        <a href='edit_product2.aspx?Action=NoRecommended&ProductID=<%#Eval("ProductID")%>'>取消</a>&nbsp;&nbsp;								
										<a href='edit_product2.aspx?Action=DeleteProduct2&ProductID=<%#Eval("ProductID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
        CustomInfoHTML="一共有<b><font color='red'>%RecordCount%</font></b>条记录 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="15" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px"></webdiyer:aspnetpager></td>
				</tr>
			</table>
			<br /><br />
    </form>
</body>
</html>
