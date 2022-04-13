<%@ Control Language="C#" AutoEventWireup="true" CodeFile="top.ascx.cs" Inherits="UserControls_top" %>
<div class="topbg1">
    <div class="hander">
    <div style="float:left"><a href="/"><img src="/upimage/<%#LogoPicUrl%>" alt="<%#LogoAlt%>" /></a></div>
    <div style="float:right; padding-top:20px;"><img src="/skin/images/tel400.jpg" width="300" height="47" alt="400电话图片" /></div>
    </div>
</div>
<div class="menu">
    <div id="nav"> 
    <ul>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="0"){ %>class="cmenu"<% } %> ><a href="/" title="网站首页">网站首页</a></li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="2"){ %>class="cmenu"<% } %> ><a href="/about_1.html" title="关于我们">关于我们</a>
       <ul>
        <li class="top"><a href="/about_1.html" title="公司简介">公司简介</a></li>
        <li><a href="/partner_1.html" title="合作伙伴">合作伙伴</a></li>
        <li><a href="/cert_1.html" title="资质证书">资质证书</a></li>
        <li><a href="/customers_1.html" title="企业风采">企业风采</a></li>
        <li><a href="/job.html" rel="nofollow" title="人才招聘">人才招聘</a></li>
        <li><a href="/contact.html" title="联系我们">联系我们</a></li>
       </ul>
     </li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="1"){ %>class="cmenu"<% } %> ><a href="/product____1.html" title="产品展示">产品展示</a></li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="3"){ %>class="cmenu"<% } %> ><a href="/news__1.html" title="资讯中心">资讯中心</a>
       <ul>
        <li class="top"><a href="/news_1_1.html" title="公司新闻">公司新闻</a></li>
        <li><a href="/news_2_1.html" title="行业资讯">行业资讯</a></li>
        <li><a href="/news_3_1.html" title="技术支持">技术支持</a></li>
       </ul>
     </li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="4"){ %>class="cmenu"<% } %> ><a href="/factorypic_1.html" title="厂房设备">厂房设备</a></li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="6"){ %>class="cmenu"<% } %> ><a href="/job.html" title="人才招聘">人才招聘</a></li>
     <li <% if(HttpContext.Current.Session["MUID"].ToString()=="8"){ %>class="cmenu"<% } %> ><a href="/contact.html" title="联系我们">联系我们</a></li>
    </ul>
    </div>
  </div>
  <div class="clear"></div>
