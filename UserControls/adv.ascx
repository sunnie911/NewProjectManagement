<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adv.ascx.cs" Inherits="UserControls_adv" %>
<!-- adv -->
<% 
{
  int i = 0;
}
%>
<div class="example">
<ul>
     <asp:Repeater ID="AdvList" runat="server">
      <ItemTemplate>
<li><a href="<%#Eval("LinkUrl") %>" target="_blank"><img src="upimage/<%#Eval("AdvPicUrl") %>" alt="<%#Eval("AdvName") %>"/></a></li>
<%
{
   i = i + 1;
}
%>
      </ItemTemplate>
    </asp:Repeater> 
</ul>
<ol>
<%
for (int ii = 0; ii < i; ii++)
{
%> 
<li <% if(ii==0){ %>class="seleted"<% } %> ></li>
<% } %>
</ol>
</div>
<!-- adv -->
