<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product_detail.aspx.cs" Inherits="product_detail" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv1.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left3" tagprefix="uc3" %>
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
<link href="/skin/css/product.css" rel="stylesheet" />
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
    <div class="blank10"></div>
<!--content-->
   <div class="zhengwen">
      <div  class="sideleft">
      <uc3:left3 ID="left1" runat="server" />
	  </div>

      <div class="sideright">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft">产品展示</div><div class="sright">当前位置：<a href="/">首页</a> &gt; <a href="product____1.html">产品中心</a></div></div>
		   <div class="rig-com-cen">
		       
		 
          <div style="margin-top:10px;text-align:center"> 
		   <h1 class="contitle"> 
           <%#ProductName%>
			</h1>
            </div><br />
			
          <div class="contenttext contentp2020">
          <div style="text-align:center"><img src="upimage/<%#PicPathBig%>" alt="<%#ProductName%>" /></div><br />
          <%#ProductContent%>
          <div class="clear"></div>
          </div>
          
         
          <br />
          <div class="pre_next">
            上一条：<asp:Label ID="pre_p" runat="server"></asp:Label>
              <br />
            下一条：<asp:Label ID="next_p" runat="server"></asp:Label>
              <br />
		  </div>

          <div><span class="fbold">&nbsp;产品推荐</span><br /></div>
        <div class="tj4p">
    <asp:Repeater ID="ProductListNew" runat="server">
      <ItemTemplate>  
		       <div class="boxtj">
		         <a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProductName") %>"></a>
		         <p><a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><%#cutstr(Eval("ProductName").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
    </div>

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
