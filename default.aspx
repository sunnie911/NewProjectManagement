<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="default.aspx.cs" Inherits="_Default" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv.ascx" tagname="adv" tagprefix="uc2" %>
<%@ Register src="UserControls/left3.ascx" tagname="left3" tagprefix="uc5" %>
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
<script type="text/javascript" src="/skin/js/jquery.min.js"></script>
<script type="text/javascript" src="/skin/js/mobile.js"></script>
<script type="text/javascript" src="/skin/js/ScrollPicLeft.js"></script>
<script src="skin/js/js2020.js" type="text/javascript"></script>
<!--[if lt IE 9]>
<script src="/skin/js/html5shiv.min.js"></script>
<script src="/skin/js/respond.min.js"></script>
<![endif]-->
</head>

<body>
    <form id="form1" runat="server"> 
    <uc1:top ID="top1" runat="server" />
    <uc2:adv ID="adv1" runat="server" />
    <div class="blank10 clear"></div>
<div class="zhengwen">
      <div  class="sideleft">
	      <uc5:left3 ID="left1" runat="server" />
	  </div>

        <div class="sideright">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft">推荐产品</div><div class="sright"><a href="product____1.html">更多 >></a></div></div>
           <div class="rig-pro-cen">
           <asp:Repeater ID="ProductListR" runat="server">
      <ItemTemplate>  
		       <div class="box2019">
		         <a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProductName") %>"></a>
		         <p><a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><%#cutstr(Eval("ProductName").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
        </div>
        </div>
        </div>
</div>

    

 <div class="clear blank20"></div>
<div class="comback">
 <div class="tjym2019"><br /><a href="about_1.html">公司简介</a><br /><p>About Us</p></div>
<div class="aboutus-box">
	
    <%=AboutUsContent%>

    <div class="cb"></div>

    <div class="about-marquee">
        	<div class="about-left" id="about-left"><a href="javascript:void(0)"><img src="/skin/images/left02.png" alt="向左" /></a></div>
            <div class="about-c" id="about">
            	<ul class="about-list">
                <asp:Repeater ID="CertPicList" runat="server">
      <ItemTemplate> 
<li><a href="certpic_detail-<%#Eval("FacPicID") %>.html" rel="sexylightbox[group2]"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("FacPicTitle") %>" width="280"></a><span><%#Eval("FacPicTitle") %></span></li>
      </ItemTemplate>
    </asp:Repeater>    
               </ul>
            </div>
            <div class="about-right" id="about-right"><a href="javascript:void(0)"><img src="/skin/images/right02.png" alt="向右" /></a></div>
        </div>
        <script type="text/javascript" src="/skin/js/gundong04.js"></script>

</div>
</div>


<div class="clear blank20"></div>
<div class="tjym2019"><a href="news__1.html">资讯中心</a><br /><p>News Center</p></div>
<div class="plist2019">
    <div class="new-left">
               
		 <div class="fsz_gray20110">
 <ul>
  <li>
<div class="szntread"><a href="<%#n1Link%>"><asp:Image ID="NewsPic1" runat="server" height="240" width="360" /></a>
<p><span class="szftitle"><a href="<%#n1Link%>"><%#n1Title%></a></span><br />
<a href="<%#n1Link%>"><%#cutstr(n1Desc,42)%>...</a></p></div></li>
 </ul>
</div>
    <div class="clear"></div>     
    <div class="new-right-cen">
		        <ul>
			<asp:Repeater ID="rp_NewsList1" runat="server">
            <ItemTemplate>
                     <li><span><%#Eval("AddTime","{0:MM-dd}") %></span><a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><%#cutstr(Eval("NewsTitle").ToString(), 18)%></a></li>
            </ItemTemplate>
       </asp:Repeater>	
			   </ul>
		 </div>

	  </div>
	  
	  <div class="new-left">
         
		 <div class="fsz_gray20110">
 <ul>
  <li>
<div class="szntread"><a href="<%#n2Link%>"><asp:Image ID="NewsPic2" runat="server" height="240" width="360" /></a><br />
<p><span class="szftitle"><a href="<%#n2Link%>"><%#n2Title%></a></span><br />
<a href="<%#n2Link%>"><%#cutstr(n2Desc,42)%>...</a></p></div></li>
 </ul>
</div>

<div class="clear"></div>     
    <div class="new-right-cen">
		        <ul>
			<asp:Repeater ID="rp_NewsList2" runat="server">
            <ItemTemplate>
                     <li><span><%#Eval("AddTime","{0:MM-dd}") %></span><a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><%#cutstr(Eval("NewsTitle").ToString(), 18)%></a></li>
            </ItemTemplate>
       </asp:Repeater>	
			   </ul>
		 </div>
         
	  </div>

      <div class="new-left">
         
		 <div class="fsz_gray20110">
 <ul>
  <li>
<div class="szntread"><a href="<%#n3Link%>"><asp:Image ID="NewsPic3" runat="server" height="240" width="360" /></a><br />
<p><span class="szftitle"><a href="<%#n3Link%>"><%#n3Title%></a></span><br />
<a href="<%#n3Link%>"><%#cutstr(n3Desc,42)%>...</a></p></div></li>
 </ul>
</div>

<div class="clear"></div>     
    <div class="new-right-cen">
		        <ul>
			<asp:Repeater ID="rp_NewsList3" runat="server">
            <ItemTemplate>
                     <li><span><%#Eval("AddTime","{0:MM-dd}") %></span><a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><%#cutstr(Eval("NewsTitle").ToString(), 18)%></a></li>
            </ItemTemplate>
       </asp:Repeater>	
			   </ul>
		 </div>
         
	  </div>
 

 </div>
    		   

   <div class="blank1"></div>

   <div class="link_bottom">
<div class="w1250">
<li><span>友情链接：</span>
      <asp:Repeater ID="FriendLinkList" runat="server">
      <ItemTemplate>    
<a href="<%#Eval("LinkUrl") %>" target="_blank" title="<%#Eval("LinkKeyword") %>"><%#Eval("LinkKeyword")%></a>  
      </ItemTemplate>
    </asp:Repeater>
</li>
</div></div>

<div class="clear"></div>

    <uc4:bottom ID="bottom1" runat="server" />

    </form>
</body>
</html>
