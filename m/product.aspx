<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="m_product" EnableViewState="false" %>
<%@ Register src="UserControls/adv.ascx" tagname="adv" tagprefix="uc2" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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


<div class="c">
	<!-- product show -->
	<div class="mt10">
		<dl class="title">
	  <h3>产品中心</h3></dl>
		<dl class="index_p_list">
			<ul>
      <asp:Repeater ID="ProductList" runat="server">
      <ItemTemplate>  
               <li><a href="pdetail-<%#Eval("ProductID")%>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProductName") %>"></a><p><a title="<%#Eval("ProductName") %>" href="pdetail-<%#Eval("ProductID")%>.html"><%#cutstr(Eval("ProductName").ToString(), 10)%></a></p></li>
      </ItemTemplate>
    </asp:Repeater>
			</ul>
			<div class="clear"></div>
		</dl>
	</div>
</div>


   <div class="blank22"></div>
<div class="fym">
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共<b><font color='red'>%RecordCount%</font></b>条"  CustomInfoSectionWidth="14%"
      FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px" LastPageText="尾页"
      meta:resourceKey="AspNetPager1" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
      PageSize="12" PrevPageText="上一页" ShowCustomInfoSection="Left" Style="font-size: 12px"
      Width="86%" CustomInfoTextAlign="Left" UrlPaging="True" EnableUrlRewriting="True" 
                   UrlRewritePattern="product_%action%_%MajorID%_%SubID%_{0}.html">
</webdiyer:AspNetPager>     
</div>                    
<div class="clear"></div>

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
