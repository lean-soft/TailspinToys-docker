<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys: Billing</title>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

<div id="bdy">
<h1 class="section-header">Address</h1>
	<div class="product-wrapper">
        <div class="product-detail-top"></div><!--end product-detail-top-->
        <div class="product-detail">
        	<div class="product-overview">
    
                <%using (Html.BeginForm("Address", "Order")) { %>           
                    <%this.RenderAddressEntry();%>
                    <input type="submit" class="textbutton" value="Review Order" />
                <%} %>
            </div>
        </div>
    </div>
    <div class="product-wrapper-btm"></div><!--end product-wrapper-btm-->
 </div>
</asp:Content>
