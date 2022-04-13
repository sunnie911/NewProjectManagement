<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sitemap.aspx.cs" Inherits="sitemap" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv2.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title>网站地图 - GOODNET CMS系统</title>
<link rel="shortcut icon" href="/skin/images/logo.ico" />
<link href="/skin/css/style.css" rel="stylesheet" />
<link href="/skin/css/reset.css" rel="stylesheet" />
<link href="skin/css/sitemap.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="/skin/js/jquery.min.js"></script>
<script src="skin/js/js2020.js" type="text/javascript"></script>
<!--[if lt IE 9]>
<script src="/skin/js/html5shiv.min.js"></script>
<script src="/skin/js/respond.min.js"></script>
<![endif]-->
</head>

<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <uc2:adv1 ID="adv1" runat="server" />    
<!--content-->
<div class="plistkp">
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt; <a href="sitemap.html">网站地图</a></div>
    <div class="clear blank20"></div>

    <div class="blk-md">
        <div class="p12-sitemap-1 blk blk">
            <div class="p12-sitemap-1-xml">
                <a href="/sitemap.xml" target="_blank">XML地图</a> | <a href="/sitemap.html">
                    HTML地图</a>&nbsp;&nbsp;&nbsp;&nbsp;
            </div>
<asp:Repeater ID="ShowSitemapClass" runat="server" OnItemDataBound="ShowSitemapClass_ItemDataBind">
      <ItemTemplate>
<h4>
<a href="<%#DataBinder.Eval(Container.DataItem, "SitemapClassLinkUrl")%>" title="<%#DataBinder.Eval(Container.DataItem, "SitemapClassName")%>" target="_blank"><%#DataBinder.Eval(Container.DataItem, "SitemapClassName")%></a>
<asp:HiddenField ID="hidSitemapClassID" runat="server" Value='<%# Eval("SitemapClassID")%>'/>
</h4>
<div class="b4">
<ul>
<asp:Repeater ID="ShowSitemap" runat="server">
<ItemTemplate>
<li><a href="<%#DataBinder.Eval(Container.DataItem, "SitemapLinkUrl")%>" title="<%#DataBinder.Eval(Container.DataItem, "SitemapTitle")%>" target="_blank"><%#DataBinder.Eval(Container.DataItem, "SitemapTitle")%></a></li>
</ItemTemplate>
</asp:Repeater>
</ul>
<div class="clear"></div>
</div>
      </ItemTemplate>
</asp:Repeater>

            <div class="clear">
            </div>
        </div>
    </div>



</div>
<div class="clear blank10"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    </form>
</body>
</html>
