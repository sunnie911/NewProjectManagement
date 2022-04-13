<%@ Control Language="C#" AutoEventWireup="true" CodeFile="left3.ascx.cs" Inherits="UserControls_left3" %>
<div class="pro-left2016">
		    <div class="pro-left-tit2016"><a href="/product____1.html">产品中心<br />Products Center</a></div>
			<div class="pro-left-cen2016">
			   <ul>
                    <!-- product class -->
<asp:Repeater ID="ShowMajorClass" runat="server" OnItemDataBound="ShowMajorClass_ItemDataBind">
      <ItemTemplate>  
      <div class="proclass_list2016">
            <div class="proclass_tit2016"><a href="/product_mc_<%#DataBinder.Eval(Container.DataItem, "MajorID")%>__1.html"><%#DataBinder.Eval(Container.DataItem, "MajorName")%></a><asp:HiddenField ID="hidMajorID" runat="server" Value='<%# Eval("MajorID")%>'/></div>
              <ul>
              <asp:Repeater ID="ShowSubClass" runat="server">
                <ItemTemplate><li><a href="/product_sc_<%#DataBinder.Eval(Container.DataItem, "MajorID")%>_<%#DataBinder.Eval(Container.DataItem, "SubID")%>_1.html"><%#DataBinder.Eval(Container.DataItem, "SubName")%></a></li></ItemTemplate>
            </asp:Repeater>
            </ul>
      </div>                                 
      </ItemTemplate>
</asp:Repeater>
                    <!-- product class -->
			   </ul>
			   			   
			</div>
		  </div>

          <div class="cont-left">
		    <div class="cont-left-tit">联系我们</div>
			<div class="cont-left-cen">   
			   <div class="cont-left-cen-bg">
               <div class="contactbg"></div>
<!--<b><%#CompanyName%></b><br />
地址：<%#Address%><br /> -->
电话：<%#Tel%><br />
传真：<%#Fax%><br />
网址：<%#WebSite%><br />
</div>
			</div>
		  </div>
		  
		  
