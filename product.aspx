<%@ Page Language="C#" AutoEventWireup="true" CodeFile="product.aspx.cs" Inherits="product" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv1.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left3" tagprefix="uc3" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
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
    <div class="blank10"></div>
<!--content-->
<div class="zhengwen">
      <div  class="sideleft">
	      <uc3:left3 ID="left1" runat="server" />
	  </div>
	  
	  <div class="sideright">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft"><%#ShowMajorClass%></div><div class="sright">当前位置：<a href="/">首页</a> &gt; <a href="product____1.html">产品中心</a><%#ShowMajorPath%></div></div>
		   <div class="rig-pro-cen">
    <asp:Repeater ID="ProductList" runat="server">
      <ItemTemplate>  
		       <div class="box2020">
		         <a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProductName") %><%#Eval("ProductModel") %>" width="175" height="131"></a>
		         <p><a title="<%#Eval("ProductName") %>" href="product_detail-<%#Eval("ProductID")%>.html"><%#cutstr(Eval("ProductName").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
			   <div class="clear"></div>

<div class="blank22"></div>
               <div class="pagination-wrap">
          <div id="pages">
            <div class="page">
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>   次序 %StartRecordIndex%-%EndRecordIndex%"
      FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px" LastPageText="尾页"
      meta:resourceKey="AspNetPager1" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
      PageSize="12" PrevPageText="上一页" ShowCustomInfoSection="Left" Style="font-size: 14px"
      Width="98%" CustomInfoTextAlign="Left" UrlPaging="True" EnableUrlRewriting="True" 
                   UrlRewritePattern="product_%action%_%MajorID%_%SubID%_{0}.html" 
                    CurrentPageButtonStyle="style=&quot;color:#ffffff;&quot;">
</webdiyer:AspNetPager>
                </div>
          </div>
        </div>
<div class="clear"></div>
<div class="blank8"></div>

		   </div>
		   
		 </div>
		 
	 </div>
	  <div class="clear"></div>
   </div>

<div class="clear"></div>
<div class="blank10"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
