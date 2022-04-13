<%@ Page Language="C#" AutoEventWireup="true" CodeFile="top.aspx.cs" Inherits="admin2016_admin_top" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>企业网站后台管理系统</title>
    <link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
<div class="admin_head">
    <div class="admin_top">

    <div class="admin_top_logo">
        <img height="47" width="380" alt="后台Logo图片" src="img/admin_logo.jpg"/>
    </div>
    <div class="admin_top_link">欢迎您，管理员：<asp:Label runat="server" ID="AdminTopAccount" />&nbsp;&nbsp;<a href="login_out.aspx" target="_parent">退出</a>&nbsp;&nbsp;<a href="/" target="_blank">首页</a>&nbsp;&nbsp;<a href="/m/" target="_blank">手机版</a></div>

   </div>
</div>
    </form>
</body>
</html>
