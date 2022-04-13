<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ndetail.aspx.cs" Inherits="m_ndetail" EnableViewState="false" %>
<%@ Register src="UserControls/adv.ascx" tagname="adv" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%#SeoTitle%> - 五金公司网站模板手机版</title>
<meta name="viewport" content="width=device-width, initial-scale=1.0, minimum-scale=1.0, maximum-scale=3.0, user-scalable=no,width=device-width"/>
<link href="css/mobile.css" rel="stylesheet" type="text/css" />
<link href="css/qh2019.css" rel="stylesheet" type="text/css" />
<script src="js/jquery.js" type="text/javascript"></script>
<script src="js/mobile.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
<div class="wrap"> 
   <header class="g-hd clearfix"> 
 <section class="head2"> 
  <a href="/m/">
   <div class="logo">
    <img alt="logo" src="images/logo.png" class="loaded">
   </div></a> 
  <a href="/m/"><h5><img src="images/logo_h.png" class="loaded" alt="logo"><em>专业五金产品定制多年</em></h5></a> 
   
  <span class="menu_btn iconfont"><a class="downmenu"><img src="images/home1.png" class="loaded"></a></span> 
 </section> 
 <!-- 下拉菜单 --> 
 <section class="menu2" id="menu"> 
  <div class="slideMenu" style="display: none;"> 
   <ul> 
     <li> <a href="/m/" title="网站首页"> 网站首页 </a> </li> 
     
     <li> <a href="/m/aboutus.html" title="公司简介"> 公司简介 </a> </li> 
     
     <li> <a href="/m/product____1.html" title="产品中心"> 产品中心 </a> </li> 
     
     <li> <a href="/m/news_1.html" title="资讯中心"> 资讯中心 </a> </li> 
     
     <li> <a href="/m/contact.html" title="联系我们"> 联系我们 </a> </li> 
     
   </ul> 
  </div> 
 </section> 
  
  
</header> 
   <section class="g-bd"> 
     
 <!-- banner adv -->    
<uc2:adv ID="adv1" runat="server" />  


   	<div class="mt10">
		<dl class="title"><h3>资讯中心</h3></dl>
      </div>

   <div style="height:10px"></div>
   

      <div style="line-height:21px; font-size:12px;background:#FFF;">
   <div align="center" style="padding:10px 1px 10px 12px; font-size:16px;"><b><%#NewsTitle%></b></div>

           <div class="blank12"></div>
            <div align="center" style="color:#666666;">&nbsp;&nbsp;资讯来源：五金公司&nbsp;&nbsp;&nbsp;　发布时间：<%#ReleaseTime%></div>
          <div class="blank12"></div>
   
   <div class="mwebcontent"><%#NewsContent%></div>

 <div style="padding:10px;">
           <div align="left" style="line-height:25px;">上一条：<asp:Label ID="pre_p" runat="server"></asp:Label></div>
        
        <div align="left" style="line-height:25px;">下一条：<asp:Label ID="next_p" runat="server"></asp:Label></div>
       </div>
   <div style="padding-bottom:15px; padding-top:10px; "><div class="ph_prolvyuan" style="width:200px; padding-left:15px;"><a href="javascript:history.back(-1)">返回</a>&nbsp;<a href="contact.html">联系我们</a></div></div>
   
   <div class="clear"></div><br /><br />
      
        <footer class="g-ft"> 
  
<div class="flx"> 
  <p> 
    
    <a href="/m/">首页</a> 
    
    <a href="/m/product____1.html">产品中心</a> 
    
    <a href="/m/news_1.html">资讯中心</a>
    
    <a href="/m/contact.html">联系我们</a> 
   </p> 广东省五金制品有限公司
  © 版权所有 翻版必究 
  <em></em>
 </div> 
 <div class="fnav"> 
  <ul> 
   <li><a href="tel:13788889999"><em><img alt="电话咨询" src="images/f1.png" class="loaded"></em>电话咨询</a></li> 
   <li><a href="/m/"><em><img alt="首页" src="images/f2.png" class="loaded"></em>首页</a></li> 
   <li><a href="/m/product____1.html"><em><img alt="产品中心" src="images/f3.png" class="loaded"></em>产品中心</a></li> 
   <li><a href="/m/contact.html"><em><img alt="联系我们" src="images/f4.png" class="loaded" /></em>联系我们</a></li> 
  </ul> 
 </div>  
</footer> 
  </div>
  <script src="js/news.js" type="text/javascript"></script> 
  <script src="js/menu.js" type="text/javascript"></script>
    </form>
</body>
</html>
