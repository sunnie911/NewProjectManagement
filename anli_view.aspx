<%@ Page Language="C#" AutoEventWireup="true" CodeFile="anli_view.aspx.cs" Inherits="anli_view" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv4.ascx" tagname="adv1" tagprefix="uc2" %>
<%@ Register src="UserControls/left.ascx" tagname="left" tagprefix="uc3" %>
<%@ Register src="UserControls/bottom.ascx" tagname="bottom" tagprefix="uc4" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title><%#ProjectName%> - GOODNET CMS</title>
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
		   <div class="rig-com-tit"><div class="sleft">产品视频</div><div class="sright">当前位置：<a href="/">首页</a> &gt; <a href="anli_1.html">产品视频</a> &gt; <%#ProjectName%></div></div>
		   <div class="rig-com-cen">
		       
          <div style="margin-top:10px;text-align:center"> 
		   <h1 class="contitle"> 
           <%#ProjectName%>
			</h1>
            </div><br />
		
          <div class="contenttext" style=" margin-bottom:20px; line-height:24px; padding-top:10px;">
            <div class="contenttext_overflow" id="fontzoom">
            <%#ProjectContent%>
            </div>
          </div>

                    
                            <div><span class="fbold">&nbsp;&nbsp;视频推荐</span><br /></div>
        <div class="tj4p">
    <asp:Repeater ID="ProductListNew" runat="server">
      <ItemTemplate>  
		       <div class="box2016">
		         <a title="<%#Eval("ProjectName") %>" href="anli-view-<%#Eval("ProjectID") %>.html"><img src="/upimage/<%#Eval("PicPathSmall")%>" alt="<%#Eval("ProjectName") %>" width="175" height="131"></a>
		         <p><a title="<%#Eval("ProjectName") %>" href="anli-view-<%#Eval("ProjectID") %>.html"><%#cutstr(Eval("ProjectName").ToString(), 15)%></a></p>
		       </div>
      </ItemTemplate>
    </asp:Repeater>
    </div>
		    
<div style="margin-top:5px;"></div>


		   </div>
		 </div>
		 
	 </div>
	  <div class="clear"></div>
   </div>
<!--content-->
<div class="blank8"></div>
    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
