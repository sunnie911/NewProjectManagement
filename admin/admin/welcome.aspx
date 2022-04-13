<%@ Page Language="C#" AutoEventWireup="true" CodeFile="welcome.aspx.cs" Inherits="enet0769_admin_welcome" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>无标题页</title>
<link href="../../skin/css/admin.css" rel="stylesheet" type="text/css" />
<style type="text/css">
ul,li,p{ list-style:none; margin:0; padding:0;}
a { color: #000000;  }
a:hover { color: #000000; text-decoration: underline; font-weight:bold; }
a:link { color: #000000; }
a:visited { color:#000000; }
.pro-right-cen{ width:100%;height:auto;}
.pro-right-cen ul{ width:100%; padding:0px 0px; height:auto;}
.pro-right-cen ul li{ background:url(css/80.gif) no-repeat left center; padding-left:16px; border-bottom:dashed 1px #D1D2D4; line-height:28px; height:28px;font-size:12px;}
.pro-right-cen ul li span{ float:right; padding-right:5px;}
.pro-right-cen ul li a { text-decoration:none; }
</style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <table width="98%" border="0" align="center" cellpadding="4" cellspacing="1">
      <tr>
        <td bgcolor="#FFFFFF" width="50%" valign="top">
        <table width="100%" border="0" align="center" cellpadding="6" cellspacing="1" style="background-color:#cccccc;">
        <tr><td colspan="2" bgcolor="#eeeeee"><b>站点管理</b></td></tr>
       <tr>
        <td width="100" bgcolor="#FFFFFF">站点信息管理</td>
        <td bgcolor="#FFFFFF"><a href="manage_site_info_class.aspx">站点信息分类</a>&nbsp;&nbsp;<a href="add_site_info.aspx">增加站点信息</a>&nbsp;&nbsp;<a href="manage_site_info.aspx">管理站点信息</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">新闻资讯管理</td>
        <td bgcolor="#FFFFFF"><a href="manage_news_class.aspx">管理新闻分类</a>&nbsp;&nbsp;<a href="add_news.aspx">增加新闻资讯</a>&nbsp;&nbsp;<a href="manage_news.aspx">管理新闻资讯</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">产品管理</td>
        <td bgcolor="#FFFFFF"><a href="manage_majorclass.aspx">管理产品大类</a>&nbsp;&nbsp;<a href="manage_subclass.aspx">管理产品小类</a>&nbsp;&nbsp;<a href="add_product2.aspx">发布公司产品</a>&nbsp;&nbsp;<a href="manage_product2.aspx">管理公司产品</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">应用案例管理</td>
        <td bgcolor="#FFFFFF"><a href="manage_pic_class.aspx">管理案例分类</a>&nbsp;&nbsp;<a href="add_facpic.aspx">增加案例图片</a>&nbsp;&nbsp;<a href="manage_facpic.aspx">管理案例图片</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">友情链接管理</td>
        <td bgcolor="#FFFFFF"><a href="add_friendlink.aspx">增加友情链接</a>&nbsp;&nbsp;<a href="manage_friendlink.aspx">管理友情链接</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">SEO设置</td>
        <td bgcolor="#FFFFFF"><a href="seo_home.aspx">网站首页</a>&nbsp;&nbsp;<a href="seo_product.aspx">产品中心首页</a>&nbsp;&nbsp;<a href="manage_majorclass.aspx">产品大类</a>&nbsp;&nbsp;<a href="manage_subclass.aspx">产品小类</a>&nbsp;&nbsp;<a href="manage_news_class.aspx">新闻分类</a>&nbsp;&nbsp;<a href="add_kwds.aspx">增加关键词</a>&nbsp;&nbsp;<a href="manage_kwds.aspx">管理关键词</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">站点地图管理</td>
        <td bgcolor="#FFFFFF"><a href="manage_sitemap_class.aspx">管理站点地图分类</a>&nbsp;&nbsp;<a href="add_sitemap.aspx">增加站点地图链接</a>&nbsp;&nbsp;<a href="manage_sitemap.aspx">管理站点地图链接</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">网站广告管理</td>
        <td bgcolor="#FFFFFF"><a href="add_adv.aspx">增加广告</a>&nbsp;&nbsp;<a href="manage_adv.aspx">管理广告</a></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF">网站配置</td>
        <td bgcolor="#FFFFFF"><a href="site_config.aspx">网站配置</a></td>
      </tr>
      </table>
        </td>
        <td bgcolor="#FFFFFF" width="50%" valign="top">
        <table width="100%" border="0" align="center" cellpadding="6" cellspacing="1" style="background-color:#cccccc;">
        <tr><td bgcolor="#eeeeee"><b>最新产品</b></td></tr>
		<asp:Repeater ID="rp_p1" runat="server">
        <ItemTemplate>
        <tr>
        <td bgcolor="#FFFFFF">● <a href="/product_detail-<%#Eval("ProductID")%>.html" title="<%#Eval("ProductName") %>" target="_blank" style="text-decoration:none;"><%#cutstr(Eval("ProductName").ToString(), 36)%></a><span style="float:right"><%#Eval("AddTime","{0:MM-dd}") %></span></td>
      </tr>
       </ItemTemplate>
       </asp:Repeater>	
      </table>
        
        </td>
      </tr>
    </table>

     <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td bgcolor="#FFFFFF" height="32" valign="middle"><b>服务器信息</b></td>
      </tr>
    </table>
    <table width="97%" border="0" align="center" cellpadding="5" cellspacing="1" style="background-color:#cccccc;">
      <tr>
        <td bgcolor="#FFFFFF">
            <table width="100%" border="0" align="center" cellpadding="1" cellspacing="0" style="background-color:#cccccc;">
      <tr>
        <td bgcolor="#FFFFFF" width="33%" height="20">服务器IP：<%=Request.ServerVariables["LOCAL_ADDR"]%></td>
        <td bgcolor="#FFFFFF" width="33%">服务器名：<%=Server.MachineName%></td>
        <td bgcolor="#FFFFFF" width="33%">操作系统信息：<%=Environment.OSVersion.ToString()%></td>
      </tr>
      <tr>
        <td bgcolor="#FFFFFF" width="33%" height="20">物理路径：<%=HttpRuntime.AppDomainAppPath%></td>
        <td bgcolor="#FFFFFF" width="33%">ASP.NET版本：<%=Environment.Version.ToString()%></td>
        <td bgcolor="#FFFFFF" width="33%">服务器时间：<%=DateTime.Now%></td>
      </tr>
      </table>
        </td>
      </tr>
      </table>

     <table width="97%" border="0" align="center" cellpadding="0" cellspacing="0">
      <tr>
        <td bgcolor="#FFFFFF" height="32" valign="middle"><b>技术支持</b></td>
      </tr>
    </table>
    <table width="97%" border="0" align="center" cellpadding="5" cellspacing="1" style="background-color:#cccccc;">
      <tr>
        <td bgcolor="#FFFFFF">技术支持QQ：1783497774<br /><a href="http://www.goodnetcms.com/" target="_blank">GOODNET CMS网站管理系统 V3.0</a></td>
      </tr>
      </table>
    <br /><br />
    </form>
</body>
</html>
