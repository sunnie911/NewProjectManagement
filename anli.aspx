<%@ Page Language="C#" AutoEventWireup="true" CodeFile="anli.aspx.cs" Inherits="anli" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv4.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>视频 - GOODNET CMS</title>
<link href="/templets/bluesite/images/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <uc1:top ID="top1" runat="server" />
    <uc2:adv1 ID="adv1" runat="server" />
<!--content-->
<div class="zhengwen">
      <div  class="left">
	      <uc3:left ID="left1" runat="server" />
	  </div>
	  
	  <div class="right">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft">产品视频</div><div class="sright">当前位置：<a href="/">首页</a> &gt; <a href="anli_1.html">产品视频</a></div></div>
		   <div class="rig-pro-cen">
  <asp:Repeater ID="ProductList" runat="server">
      <ItemTemplate> 
      <div class="box2016">
		         <a title="<%#Eval("ProjectName") %>" href="anli-view-<%#Eval("ProjectID") %>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProjectName") %>" width="175" height="131"></a>
		         <p><a title="<%#Eval("ProjectName") %>" href="anli-view-<%#Eval("ProjectID") %>.html"><%#cutstr(Eval("ProjectName").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
			   <div class="clear"></div>

<div class="blank22"></div>
<webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>   次序 %StartRecordIndex%-%EndRecordIndex%"
      FirstPageText="首页" HorizontalAlign="Right" InputBoxStyle="width:19px" LastPageText="尾页"
      meta:resourceKey="AspNetPager1" NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
      PageSize="12" PrevPageText="上一页" ShowCustomInfoSection="Left" Style="font-size: 12px"
      Width="98%" CustomInfoTextAlign="Left" UrlPaging="True" EnableUrlRewriting="True" 
                   UrlRewritePattern="anli_{0}.html">
</webdiyer:AspNetPager>                         
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
