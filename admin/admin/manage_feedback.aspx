<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_feedback.aspx.cs" Inherits="enet0769_admin_manage_feedback" %>
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
					<td height="30" class="title_top" align="center">反馈意见管理</td>
				</tr>
			</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="FeedbackID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="FeedbackID" HeaderText="ID编号" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:HyperLinkField DataNavigateUrlFields="FeedbackID" DataNavigateUrlFormatString="feedback_detail.aspx?Action=ViewFeedback&FeedbackID={0}"
                                    DataTextField="FBStyle" HeaderText="反馈意见类型">
                                    <ControlStyle Width="100px" />
                                </asp:HyperLinkField>  
                               <asp:BoundField DataField="FBName" HeaderText="反馈人" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>    
                               <asp:BoundField DataField="CompanyName" HeaderText="公司名称" >
                                    <ControlStyle Width="250px" />
                                </asp:BoundField>                                                        
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="申请时间" >
                                    <ControlStyle Width="200px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='feedback_detail.aspx?Action=ViewFeedback&FeedbackID=<%#Eval("FeedbackID")%>' >查看</a>&nbsp;&nbsp;
										<a href='feedback_detail.aspx?Action=DeleteFeedback&FeedbackID=<%#Eval("FeedbackID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
