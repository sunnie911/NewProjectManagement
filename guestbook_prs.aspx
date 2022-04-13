<%@ Page Language="C#" AutoEventWireup="true" CodeFile="guestbook_prs.aspx.cs" Inherits="guestbook_prs" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv6.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta name="renderer" content="webkit|ie-comp|ie-stand" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
<title>客户留言成功 - GOODNET CMS网站模板</title>
<link href="/templets/bluesite/images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/jquery-1.8.0.min.js"></script>
<script type="text/javascript" src="js/menushow.js"></script>
</head>

<body>
    <form id="form1" runat="server">
    
    <uc1:top ID="top1" runat="server" />
    <uc2:adv1 ID="adv1" runat="server" />
<!--content-->
<div class="zhengwen">
      <div  class="left">
      <uc3:left ID="left2" runat="server" />
	  </div>
	  
	  <div class="right">
	     <div class="rig-com">
		   <div class="rig-com-tit"><div class="sleft">客户留言</div><div class="sright">当前位置：<a href="/">首页</a> &gt; 客户留言</div></div>
		   <div class="rig-com-cen">
		       
          <div style="margin-top:2px;text-align:center"></div><br />
		
          <div class="contenttext" style="margin-bottom:20px; line-height:24px; padding-top:10px; height:316px;">
            <div class="contenttext_overflow" id="fontzoom">
            	 <!-- 填写留言 -->
<div class="blank10"></div>
<div style="border:1px solid #cccccc; height:28px;">&nbsp;&nbsp;增加留言成功，感谢您对我司的支持!</div>
<!-- 填写留言 -->
            </div>
          </div>

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
