<%@ Page Language="C#" AutoEventWireup="true" CodeFile="job.aspx.cs" Inherits="job" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv6.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>

<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title><%#SeoTitle%> - <%#CompanyName%></title>
<meta name="keywords" content="<%#SeoKeywords%>" />
<meta name="description" content="<%#SeoDesc%>" />
<link rel="shortcut icon" href="/skin/images/logo.ico" />
<link href="/skin/css/style.css" rel="stylesheet" />
<link href="/skin/css/reset.css" rel="stylesheet" />
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
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt;<a href="job.html">人才招聘</a></div>
    <div class="blank10 clear"></div>
    <div class="smc1">
<ul>
<li><a href="/about_1.html" title="公司简介">公司简介</a></li>    
<li><a href="/partner_1.html" title="合作伙伴">合作伙伴</a></li>    
<li><a href="/cert_1.html" title="资质证书">资质证书</a></li> 
<li><a href="/customers_1.html" title="企业风采">企业风采</a></li>
<li class="showmj"><a href="/job.html" title="人才招聘">人才招聘</a></li>
<li><a href="/contact.html" title="联系我们">联系我们</a></li> 
</ul>
</div>
<br />
    <div class="aboutcontent"><%=SiteContent%></div>


</div>


   <div class="clear blank10"></div>

    <uc4:bottom ID="bottom2" runat="server" />


    </form>
</body>
</html>
