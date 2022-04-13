<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manage_adv.aspx.cs" Inherits="hailiadmin_admin_manage_adv" %>
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
					<td height="30" class="title_top" align="center">网站广告管理</td>
				</tr>
			</table>
						<table width="96%" border="1" align="center" cellpadding="0" cellspacing="0" bgcolor="#DFEFFF" bordercolorlight="#77AEEE">
    <tr>
	<td height="32" style="padding-left:8px;">
        <asp:TextBox ID="Keywords" runat="server" Columns="30"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text=" 搜 索 " OnClick="Button1_Click" />&nbsp;<span class="gray">请输入广告名称</span></td>
    </tr>
</table>
			<table width="96%" border="0" align="center" cellpadding="0" cellspacing="0">
				<tr>
					<td>
					<asp:GridView ID="GridView1" runat="server" Width="100%"  DataKeyNames ="AdvID" CellPadding ="4" AutoGenerateColumns="False" BackColor="#77aeee" BorderColor="#77aeee" BorderStyle="Solid">
                            <Columns>
                                <asp:BoundField DataField="AdvID" HeaderText="广告ID" >
                                    <ControlStyle Width="60px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="广告图片">
                                <ItemTemplate>
                                <a href='<%#"../../upimage/" + Eval("AdvPicUrl")%>' target="_blank"><asp:Image ID="Image1" runat="server" ImageUrl='<%#"../../upimage/" + Eval("AdvPicUrl")%>' Width="300" /></a>
								</ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="广告名称">
                                <ItemTemplate>                               
								<%#Eval("AdvName")%>
								</ItemTemplate></asp:TemplateField> 
                                <asp:TemplateField HeaderText="广告分类">
                                <ItemTemplate>
										<%#Eval("AdvClassName")%>
								</ItemTemplate></asp:TemplateField>                                                    
                               <asp:BoundField DataField="AddTime" DataFormatString="{0:yyyy-M-d}" HeaderText="加入时间" >
                                    <ControlStyle Width="100px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="操作">
                                <ItemTemplate>
										<a href='edit_adv.aspx?Action=EditAdv&AdvID=<%#Eval("AdvID")%>' >编辑</a>&nbsp;&nbsp;
										<a href='edit_adv.aspx?Action=DeleteAdv&AdvID=<%#Eval("AdvID")%>' onclick="javascript:if(confirm('您确定要删除吗？')){return true;}else{return false;}">删除</a>
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
        CustomInfoHTML="一共有<b><font color='red'>%RecordCount%</font></b>条记录 当前页<font color='red'><b>%CurrentPageIndex%/%PageCount%</b></font>   次序 %StartRecordIndex%-%EndRecordIndex%" AlwaysShow="True" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="12" PrevPageText="上一页" CustomInfoStyle="FONT-SIZE: 12px"></webdiyer:aspnetpager></td>
				</tr>
			</table>
    <br /><br />
    </form>
</body>
</html>
