<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_member.aspx.cs" Inherits="enet0769_admin_manage_member" %>
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
					<td height="30" class="title_top" align="center">管理会员</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="MemberID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid" OnRowDataBound="GridView1_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="MemberID" HeaderText="会员ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MemberAccount" HeaderText="帐号" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="MemberPassword" HeaderText="密码" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="MemberID" DataNavigateUrlFormatString="member_detail.aspx?Action=ViewMember&MemberID={0}"
                                    DataTextField="CompanyName" HeaderText="公司名称">
                                    <ControlStyle Width="250px" />
                                </asp:HyperLinkField>  
                               <asp:BoundField DataField="Contactor" HeaderText="联系人" >
                                    <ControlStyle Width="120px" />
                                </asp:BoundField>                                                        
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="注册时间" >
                                    <ControlStyle Width="150px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="审核状态">
                                    <ItemTemplate><asp:Label ID="lblCheckState" runat="server" Text='<%# Bind("CheckState") %>'></asp:Label></ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
                                        <a href='member_detail.aspx?Action=CheckMemberOK&MemberID=<%#Eval("MemberID")%>' >通过</a>&nbsp;&nbsp;
                                        <a href='member_detail.aspx?Action=CheckMemberNO&MemberID=<%#Eval("MemberID")%>' >不通过</a>&nbsp;&nbsp;
										<a href='member_detail.aspx?Action=ViewMember&MemberID=<%#Eval("MemberID")%>' >查看</a>&nbsp;&nbsp;
										<a href='member_detail.aspx?Action=DeleteMember&MemberID=<%#Eval("MemberID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
