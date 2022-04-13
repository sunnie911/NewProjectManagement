<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestbook.aspx.cs" Inherits="guestbook" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv6.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="renderer" content="webkit|ie-comp|ie-stand" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<title>客户留言 - GOODNET CMS网站模板</title>
<link href="/templets/bluesite/images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>
<script type="text/javascript" src="js/menushow.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    
    <uc1:top ID="top1" runat="server" />
    <uc2:adv1 ID="adv1" runat="server" />
<!--content-->
<div class="zhengwen">
      <div  class="left">
      <uc3:left ID="left2" runat="server" />
	  </div>
	  
	  <div class="right">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft">客户留言</div><div class="sright">当前位置：<a href="/">首页</a> &gt; 客户留言</div></div>
		   <div class="rig-com-cen">
		       
          <div style="margin-top:2px;text-align:center"></div><br />

          <div class="contenttext" style=" margin-bottom:20px; line-height:24px; padding-top:10px;">
            <div class="contenttext_overflow" id="fontzoom">
             <!-- 填写留言 -->
<div class="blank10"></div>
<asp:Label ID="ShowTipMessage" runat="server" Text="" CssClass="red"></asp:Label>
<table width="100%" border="0" cellspacing="1" cellpadding="4">
  <tr>
    <th width="80" height="27">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名：</th>
    <td><asp:TextBox ID="GuestName" runat="server" Columns="38" MaxLength="50"></asp:TextBox> *
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="GuestName"
            Display="Dynamic" ErrorMessage="请输入您的姓名"></asp:RequiredFieldValidator></td>
  </tr>
   <tr>
    <th height="27">职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;位：</th>
    <td>
        <asp:TextBox ID="GuestPosition" runat="server" Columns="38" MaxLength="50"></asp:TextBox></td>
  </tr>
  <tr>
    <th height="27">性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别：</th>
    <td><asp:RadioButtonList ID="Sex" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:RadioButtonList></td>
  </tr>
  <tr>
    <th height="27">公司名称：</th>
    <td>
        <asp:TextBox ID="CompanyName" runat="server" Columns="50" MaxLength="255"></asp:TextBox> *<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="CompanyName"
            Display="Dynamic" ErrorMessage="请输入公司名称"></asp:RequiredFieldValidator></td>
  </tr>
  <tr>
    <th height="27">联系电话：</th>
    <td>
        <asp:TextBox ID="Tel" runat="server" Columns="38" MaxLength="50"></asp:TextBox></td>
  </tr>
  <tr>
    <th height="27">电子邮箱：</th>
    <td>
        <asp:TextBox ID="Email" runat="server" Columns="38" MaxLength="50"></asp:TextBox> 
        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="邮箱格式不正确" ControlToValidate="Email" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <th height="27">网&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址：</th>
    <td>
        <asp:TextBox ID="WebSite" runat="server" Columns="38" MaxLength="50">http://</asp:TextBox>
        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="WebSite"
            Display="Dynamic" ErrorMessage="网址格式不正确" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?"></asp:RegularExpressionValidator></td>
  </tr>
  <tr>
    <th valign="top" height="27">留言内容：</th>
    <td>
        <asp:TextBox ID="GuestContent" runat="server" Columns="45" Rows="6" TextMode="MultiLine"></asp:TextBox></td>
  </tr>
  <tr>
    <th valign="top" height="27">验&nbsp;证&nbsp;码：</th>
    <td><asp:TextBox ID="ValidaCode" runat="server" Height="23px" MaxLength="5" 
                              Width="80px"></asp:TextBox><asp:Image ID="Image1" runat="server" ImageUrl="/validate.ashx" /></td>
  </tr>
  <tr>
    <th height="32">&nbsp;</th>
    <td><asp:Button ID="Button1" runat="server" Text="确认留言" OnClick="Button1_Click" />　<input type="reset" name="Submit" value="重新填写"/></td>
  </tr>
  <tr>
    <th>&nbsp;</th>
    <td>&nbsp;</td>
  </tr>
</table>
<!-- 填写留言 -->
            </div>
          </div>

		   </div>
		 </div>
		 
	 </div>
	  <div class="clear"></div>
   </div>



<div class="clear"></div>
<div class="blank10"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
