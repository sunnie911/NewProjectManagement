<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adv.ascx.cs" Inherits="m_usercontrols_adv" %>
 <div class="ban swiper-container-horizontal"> 
  <div class="swiper-wrapper" style="transform: translate3d(-1242px, 0px, 0px); transition-duration: 300ms;">

    <asp:Repeater ID="AdvList" runat="server">
      <ItemTemplate>   
      <div class="swiper-slide" style="width: 414px;"> 
     <a href="<%#Eval("LinkUrl") %>" title="<%#Eval("AdvName") %>"><img alt="<%#Eval("AdvName") %>" src="/upimage/<%#Eval("AdvPicUrl") %>" class="loaded" /></a> 
    </div> 
         </ItemTemplate>
    </asp:Repeater>  

  </div> 
 </div> 