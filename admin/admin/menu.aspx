<%@ Page Language="C#" AutoEventWireup="true" CodeFile="menu.aspx.cs" Inherits="enet0769_admin_menu" %>
<%@ Register TagPrefix="WebSession" TagName="CheckSession" Src="UserControls/session.ascx"  %>
<WebSession:CheckSession id="CheckSession" runat="server"></WebSession:CheckSession>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>Menu</title>
<link type="text/css" href="css/admin_menu.css" rel="stylesheet" />
<script type="text/javascript" src="js/hlym.js"></script>
</head>
<body>
  <form id="Form1" method="post" runat="server">
			<div class="blk-main clearafter"> 

   <div class="clear"></div> 
   <div class="blk-xs fl"> 
    <div class="fdh-01 blk"> 
 <div class="fdh-01-tit"> 
 当前管理员：<asp:Label runat="server" ID="AdminAccount" /><br/>
 </div> 
 <div class="fdh-01-nav" navvicefocus1=""> 
   
   <div class="fdh-01-nav-one"> 
    <h3> <img src="css/administrator.png" alt="管理员密码" /> 管理员密码 </h3> 
    <dl style="display:none;">    
      <dt> 
       <a href="modify_password.aspx" title="修改密码" target="right"> 修改密码 </a> 
      </dt>   
    </dl> 
   </div> 
   
   <div class="fdh-01-nav-one"> 
    <h3> <img src="css/news.png" alt="站点信息管理" /> 站点信息管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="manage_site_info_class.aspx" title="站点信息分类" target="right"> 站点信息分类 </a> 
      </dt>
      <dt> 
       <a href="add_site_info.aspx" title="增加站点信息" target="right"> 增加站点信息 </a> 
      </dt>
      <dt> 
       <a href="manage_site_info.aspx" title="管理站点信息" target="right"> 管理站点信息 </a> 
      </dt>   
    </dl> 
   </div> 
   
   <div class="fdh-01-nav-one"> 
    <h3> <img src="css/news.png" alt="新闻资讯管理" /> 新闻资讯管理 </h3> 
    <dl style="display:none;">       
      <dt> 
       <a href="manage_news_class.aspx" title="管理新闻分类" target="right"> 管理新闻分类 </a> 
      </dt> 
      <dt> 
       <a href="add_news.aspx" title="增加公司新闻" target="right"> 增加公司新闻 </a> 
      </dt> 
      <dt> 
       <a href="manage_news.aspx" title="管理公司新闻" target="right"> 管理公司新闻 </a> 
      </dt>        
    </dl> 
   </div> 
   
   <div class="fdh-01-nav-one"> 
    <h3> <img src="css/bag.png" alt="公司产品管理" /> 公司产品管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="manage_majorclass.aspx" title="管理产品分类" target="right"> 管理产品分类 </a> 
      </dt> 
      <dt> 
       <a href="add_product2.aspx" title="发布公司产品" target="right"> 发布公司产品 </a> 
      </dt> 
       <dt> 
       <a href="manage_product2.aspx" title="管理公司产品" target="right"> 管理公司产品 </a> 
      </dt>             
    </dl> 
   </div> 
   
    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/bag.png" alt="应用案例管理" /> 应用案例管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="manage_pic_class.aspx" title="管理案例分类" target="right"> 管理案例分类 </a> 
      </dt> 
      <dt> 
       <a href="add_facpic.aspx" title="增加案例图片" target="right"> 增加案例图片 </a> 
      </dt> 
      <dt> 
       <a href="manage_facpic.aspx" title="管理案例图片" target="right"> 管理案例图片 </a> 
      </dt>           
    </dl> 
   </div> 

    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/friendlink.png" alt="友情链接管理" /> 友情链接管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="add_friendlink.aspx" title="增加友情链接" target="right"> 增加友情链接 </a> 
      </dt> 
      <dt> 
       <a href="manage_friendlink.aspx" title="管理友情链接" target="right"> 管理友情链接 </a> 
      </dt>         
    </dl> 
   </div>   
  
    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/guestbook.png" alt="客户留言管理" /> 客户留言管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="manage_guestbook.aspx" title="管理留言" target="right"> 管理留言 </a> 
      </dt>         
    </dl> 
   </div> 
    
    <div class="fdh-01-nav-one">
    <h3> <img src="css/seo.png" alt="网站优化管理" /> 网站优化管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="web_seo.aspx" title="SEO设置" target="right"> SEO设置 </a> 
      </dt>
      <dt> 
       <a href="add_kwds.aspx" title="增加关键词" target="right"> 增加关键词 </a> 
      </dt>  
      <dt> 
       <a href="manage_kwds.aspx" title="管理关键词" target="right"> 管理关键词 </a> 
      </dt>
      <dt> 
       <a href="manage_sitemap_class.aspx" title="管理站点地图分类" target="right"> 管理站点地图分类 </a> 
      </dt>
      <dt> 
       <a href="add_sitemap.aspx" title="增加站点地图链接" target="right"> 增加站点地图链接 </a> 
      </dt> 
      <dt> 
       <a href="manage_sitemap.aspx" title="管理站点地图链接" target="right"> 管理站点地图链接 </a> 
      </dt>               
    </dl> 
   </div> 
  
    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/gg.png" alt="网站广告管理" /> 网站广告管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="add_adv.aspx" title="增加广告" target="right"> 增加广告 </a> 
      </dt> 
      <dt> 
       <a href="manage_adv.aspx" title="管理广告" target="right"> 管理广告 </a> 
      </dt>         
    </dl> 
   </div>  
       
    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/pz.png" alt="网站配置管理" /> 网站配置管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="site_config.aspx" title="网站配置" target="right"> 网站配置 </a> 
      </dt>         
    </dl> 
   </div> 

    <div class="fdh-01-nav-one"> 
    <h3> <img src="css/loginout.png" alt="网站退出管理" /> 网站退出管理 </h3> 
    <dl style="display:none;">      
      <dt> 
       <a href="login_out.aspx" title="退出网站" target="_parent"> 退出网站 </a> 
      </dt>         
    </dl> 
   </div> 

 </div> 
 <div class="clear"></div> 
  
  
</div> 
     
   </div> 

  </div>

  <script src="js/admin_menu.js" type="text/javascript"></script>
		</form>
</body>
</html>
