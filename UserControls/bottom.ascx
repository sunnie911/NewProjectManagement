<%@ Control Language="C#" AutoEventWireup="true" CodeFile="bottom.ascx.cs" Inherits="UserControls_bottom" %>
<div class="footbottom"><div class="w1250">
<div class="foot16l">
<ul>
<li><dl><dt>关于我们</dt><dd><a href="/about_1.html">公司简介</a></dd><dd><a href="/partner_1.html">合作伙伴</a></dd><dd><a href="/cert_1.html">资质证书</a></dd><dd><a href="/customers_1.html">企业风采</a></dd><dd><a href="/contact.html">联系方式</a></dd></dl></li>
<li><dl><dt>产品中心</dt>
<asp:Repeater ID="ShowMajorClass" runat="server">
    <ItemTemplate>
<dd><a href="/product_mc_<%#DataBinder.Eval(Container.DataItem, "MajorID")%>__1.html" title="<%#DataBinder.Eval(Container.DataItem, "MajorName")%>"><%#DataBinder.Eval(Container.DataItem, "MajorName")%></a></dd>
    </ItemTemplate>
</asp:Repeater>
</dl></li>
<li><dl><dt>成功案例</dt>
<asp:Repeater ID="ShowCase" runat="server">
    <ItemTemplate>
<dd><a href="/facpic_detail-<%#Eval("FacPicID") %>.html" title="<%#Eval("FacPicTitle") %>"><%#Eval("FacPicTitle").ToString().Length > 9 ? Eval("FacPicTitle").ToString().Substring(0, 9) : Eval("FacPicTitle")%></a></dd>
    </ItemTemplate>
</asp:Repeater>
</dl></li>
<li><dl><dt>新闻资讯</dt><dd><a href="/news_1_1.html" title="公司新闻">公司新闻</a></dd><dd><a href="/news_2_1.html" title="行业资讯">行业资讯</a></dd><dd><a href="/news_3_1.html" title="常见问题">常见问题</a></dd></dl></li>
</ul>
</div>
<div class="foot16r"><ul><li><img src="/upimage/<%#ErweimaPicUrl%>" class="bimg"/><span><%#ErweimaAlt%></span></li><li><img src="/upimage/<%#MobilePicUrl%>" class="bimg"/><span class="wap2017"><%#MobileAlt%></span></li></ul></div>
<div class="foot-b">
<ul>
<li>本站图片等部分资料来源于网上，部分未能与原作者取得联系，若涉及版权问题，请联系我们删除！</li>
<li>Copyright <%#WebSite%> © 2020 All Rights Reserved <%#CompanyName%> 版权所有</li>
<li>地址：<%#Address%> 全国统一客服热线：<%#Tel400%> <%#Contacts%></li>
<li>电话：<%#Tel%> 传真：<%#Fax%> 邮箱：<%#Email%></li>
<li><a href="http://beian.miit.gov.cn" target="_blank" rel="nofollow"><%#RecordNumber%></a> <a href="sitemap.html">网站地图</a> <%#Statistics%></li>
<li></li>
</ul></div>
</div></div>