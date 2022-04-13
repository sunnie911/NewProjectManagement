<%@ Page Language="C#" AutoEventWireup="true" CodeFile="web_seo.aspx.cs" Inherits="hailiadmin_admin_web_seo" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>无标题页</title>
<link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
<style type="text/css">
a { color: #515151; text-decoration: none }
a:hover { color: #ff0000; text-decoration: underline; font-weight:bold; }
a.link { color: #515151; }
</style>
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
					<td height="30" class="title_top" align="center">SEO配置</td>
				</tr>
			</table>
    <table width="96%" border="0" align="center" cellpadding="5" cellspacing="1" style="background-color:#cccccc;">
      <tr>
        <td width="100" bgcolor="#FFFFFF">网站首页</td>
        <td bgcolor="#FFFFFF"><a href="seo_home.aspx">SEO设置</a></td>
      </tr>
      <tr>
        <td width="100" bgcolor="#FFFFFF">产品中心首页</td>
        <td bgcolor="#FFFFFF"><a href="seo_product.aspx">SEO设置</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">产品大类</td>
        <td bgcolor="#FFFFFF"><a href="manage_majorclass.aspx">SEO设置</a> <span class="gray">(请在管理产品大类里设置)</span></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">产品小类</td>
        <td bgcolor="#FFFFFF"><a href="manage_subclass.aspx">SEO设置</a> <span class="gray">(请在管理产品小类里设置)</span></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">新闻分类</td>
        <td bgcolor="#FFFFFF"><a href="manage_news_class.aspx">SEO设置</a> <span class="gray">(请在管理新闻分类里设置)</span></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">关键词管理</td>
        <td bgcolor="#FFFFFF"><a href="add_kwds.aspx">增加关键词</a>&nbsp;&nbsp;<a href="manage_kwds.aspx">管理关键词</a></td>
      </tr>
      </table>
    <br /><br />
    </form>
</body>
</html>
