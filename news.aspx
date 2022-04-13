<%@ Page Language="C#" AutoEventWireup="true" CodeFile="news.aspx.cs" Inherits="news" EnableViewState="false" %>
<%@ Register src="UserControls/top.ascx" tagname="top" tagprefix="uc1" %>
<%@ Register src="UserControls/adv3.ascx" tagname="adv1" tagprefix="uc2" %>
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
    
<!--content-->
<div class="plistkp">
    <div class="c_local1">当前位置：<a href="/">首页</a> &gt;<a href="news__1.html">资讯中心</a><%#ShowNewsPath%></div>
    <div class="blank20 clear"></div>

    <div class="smc1">
<ul>
<asp:Repeater ID="Newsfl" runat="server">
    <ItemTemplate>
<li class="<%# IsNbsp(DataBinder.Eval(Container.DataItem, "ClassID").ToString()) %>"><a href="/news_<%#DataBinder.Eval(Container.DataItem, "ClassID")%>_1.html" title="<%#DataBinder.Eval(Container.DataItem, "ClassName")%>"><%#DataBinder.Eval(Container.DataItem, "ClassName")%></a></li>
    </ItemTemplate>
</asp:Repeater>
</ul>
</div>
<br />

<div class="new2-menu">
            <asp:Repeater ID="rp_NewsList" runat="server">
            <ItemTemplate> 
            <div class="newsrow">
                <div class="newsleft"><a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><img src="/upimage/<%#Eval("PicPathSmall") %>" alt="<%#Eval("NewsTitle") %>" class="thumbnail" width="370" height="242" /></a></div>
                <div class="newsright">
                <span class="newtit2018"><a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><%#Eval("NewsTitle") %></a></span><br />
                <span class="newdate2018">日期：<%#Eval("ReleaseTime", "{0:yyyy-MM-dd}")%></span><br />
                <a href="news_detail-<%#Eval("NewsID") %>.html" title="<%#Eval("NewsTitle") %>"><%#Eval("SeoDesc")%></a>
                </div>
            </div>
             	</ItemTemplate>
       </asp:Repeater>
 </div>

<div class="blank22"></div>
 <webdiyer:AspNetPager ID="AspNetPager1" runat="server" AlwaysShow="True" CustomInfoHTML="共有  <b><font color='red'>%RecordCount%</font></b>  条记录 当前页<b><font color='red'>%CurrentPageIndex%</font>/%PageCount%</b>   次序 %StartRecordIndex%-%EndRecordIndex%"
                                        FirstPageText="首页" HorizontalAlign="right" 
            InputBoxStyle="width:19px" LastPageText="尾页"
                                        meta:resourceKey="AspNetPager1" 
            NextPageText="下一页" NumericButtonCount="5" OnPageChanged="AspNetPager1_PageChanged"
                                        PageSize="8" PrevPageText="上一页" 
            ShowCustomInfoSection="Left" Style="font-size: 14px"
                                        Width="98%" CustomInfoTextAlign="Left" 
            UrlPaging="True" EnableUrlRewriting="True" 
        UrlRewritePattern="news_%classid%_{0}.html">
                                    </webdiyer:AspNetPager>                      
<div class="clear"></div>



</div>


<div class="clear blank30"></div>
<!--content-->

    <uc4:bottom ID="bottom1" runat="server" />
    
    </form>
</body>
</html>
