<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news_detail.aspx.cs" Inherits="news_detail" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv3.ascx" tagname="adv1" tagprefix="uc2" %>
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
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt; <a href="news_<%#ClassID%>_1.html">资讯中心</a> &gt; <%#NewsTitle%></div>
    <div style="margin-top:50px;text-align:center"> 
		   <h1 class="contitle"> 
           <%#NewsTitle%>
			</h1>
            </div>
            <div class="blank12"></div>
			<div class="conAuthor"> 
            资讯来源：五金公司&nbsp;&nbsp;&nbsp;　发布时间：<%#ReleaseTime%>
            </div>
          <div class="blank12"></div>
          <div class="contenttext" style="margin-bottom:10px; line-height:28px; padding-top:10px;">
            <div class="contenttext_overflow" id="fontzoom">
            <%#NewsContent%>
            <br />
            </div>
          </div>

           <div class="pre_next">
            <span style="float:left;">上一条：<asp:Label ID="pre_p" runat="server"></asp:Label></span>
            <span style="float:right">下一条：<asp:Label ID="next_p" runat="server"></asp:Label></span>
              <br />
		  </div>



</div>


   <div class="blank10"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
