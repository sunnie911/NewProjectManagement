<%@ Page Language="C#" AutoEventWireup="true" CodeFile="factorypic.aspx.cs" Inherits="factorypic" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv4.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html>
<html lang="zh-CN">
<head>
<meta charset="utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge" />
<meta name="viewport" content="width=device-width, initial-scale=1" />
<title>成功案例 - <%#CompanyName%></title>
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
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt; <a href="factorypic_1.html">厂房设备</a></div>
    <div class="blank20 clear"></div>
    <h1 class="contitle">厂房设备</h1><br />
    <asp:Repeater ID="FactoryPicList" runat="server">
      <ItemTemplate> 
      <div class="box2019">
		         <a title="<%#Eval("FacPicTitle") %>" href="facpic_detail-<%#Eval("FacPicID") %>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("FacPicTitle") %>" width="210" height="140"></a>
		         <p><a title="<%#Eval("FacPicTitle") %>" href="facpic_detail-<%#Eval("FacPicID") %>.html"><%#cutstr(Eval("FacPicTitle").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
			   <div class="clear blank22"></div>


<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>   次序 %StartRecordIndex%-%EndRecordIndex%"
      FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px" LastPageText="尾页"
      meta:resourceKey="AspNetPager1" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
      PageSize="12" PrevPageText="上一页" ShowCustomInfoSection="Left" Style="font-size: 14px"
      Width="98%" CustomInfoTextAlign="Left" UrlPaging="True" EnableUrlRewriting="True" 
                   UrlRewritePattern="factorypic_{0}.html">
</webdiyer:AspNetPager>                         
</div>

<div class="clear blank8"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    </form>
</body>
</html>
