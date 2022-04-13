<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_union.aspx.cs" Inherits="enet0769_admin_manage_union" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
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
					<td height="30" class="title_top" align="center">加盟信息管理</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="JoinInID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="JoinInID" HeaderText="ID编号" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="JoinInID" DataNavigateUrlFormatString="joinin_detail.aspx?Action=ViewJoinIn&JoinInID={0}"
                                    DataTextField="UserName" HeaderText="用户名">
                                    <ControlStyle Width="200px" />
                                </asp:HyperLinkField>  
                               <asp:BoundField DataField="CompanyName" HeaderText="公司(个人)" >
                                    <ControlStyle Width="250px" />
                                </asp:BoundField>                                                        
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="申请时间" >
                                    <ControlStyle Width="200px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='joinin_detail.aspx?Action=ViewJoinIn&JoinInID=<%#Eval("JoinInID")%>' >查看</a>&nbsp;&nbsp;
										<a href='joinin_detail.aspx?Action=DeleteJoinIn&JoinInID=<%#Eval("JoinInID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
    </form>
</body>
</html>
