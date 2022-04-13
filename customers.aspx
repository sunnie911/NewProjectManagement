<%@ Page Language="C#" AutoEventWireup="true" CodeFile="customers.aspx.cs" Inherits="customers" EnableViewState="false" %>
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
<title>企业风采 - <%#CompanyName%></title>
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
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt; <a href="customers_1.html">企业风采</a></div>
    <div class="blank10 clear"></div>
    <div class="smc1">
<ul>
<li><a href="/about_1.html" title="公司简介">公司简介</a></li>    
<li><a href="/partner_1.html" title="合作伙伴">合作伙伴</a></li>    
<li><a href="/cert_1.html" title="资质证书">资质证书</a></li> 
<li class="showmj"><a href="/customers_1.html" title="企业风采">企业风采</a></li>
<li><a href="/job.html" title="人才招聘">人才招聘</a></li>
<li><a href="/contact.html" title="联系我们">联系我们</a></li> 
</ul>
</div>
<br />
     <asp:Repeater ID="FactoryPicList" runat="server">
      <ItemTemplate> 
      <div class="box2019">
		         <a title="<%#Eval("FacPicTitle") %>" href="kehu_detail-<%#Eval("FacPicID") %>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("FacPicTitle") %>" width="210" height="140"></a>
		         <p><a title="<%#Eval("FacPicTitle") %>" href="kehu_detail-<%#Eval("FacPicID") %>.html"><%#cutstr(Eval("FacPicTitle").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
			   <div class="clear"></div>

<div class="blank22"></div>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>   次序 %StartRecordIndex%-%EndRecordIndex%"
      FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px" LastPageText="尾页"
      meta:resourceKey="AspNetPager1" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
      PageSize="12" PrevPageText="上一页" ShowCustomInfoSection="Left" Style="font-size: 14px"
      Width="98%" CustomInfoTextAlign="Left" UrlPaging="True" EnableUrlRewriting="True" 
                   UrlRewritePattern="customers_{0}.html">
</webdiyer:AspNetPager>                         
<div class="clear"></div>
<div class="blank8"></div>

</div>



<div class="clear"></div>
<div class="blank10"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
