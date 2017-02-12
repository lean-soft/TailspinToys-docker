<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys: <%=this.Product().Name %></title>
</asp:Content>
            
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
	<h1 class="section-header">Our Hottest Paper Planes</h1>
	<div class="product-wrapper">
        <div class="product-detail-top"></div><!--end product-detail-top-->
        <div class="product-detail">
        	<div class="product-overview">
                <img src="<%=Html.ProductImage(this.Product().DefaultImage.ThumbnailPhoto)%>" width="210" height="219" alt="<%=this.Product().Name %>" />
                <h2><%=this.Product().Name %></h2>
                <p><%=this.Product().Blurb %></p>
                <%using (Html.BeginForm("AddItem", "Cart")) {%><input type="hidden" value="<%=this.Product().SKU %>" name="sku" /><input type="submit" class="add-cart" value="" /><%} %>
                <h3>Price: <strong><%=this.Product().Price.ToString("C")%></strong></h3>
             </div><!--end product-overview-->
             <div class="product-specifications">
                <%foreach (ProductDescriptor pd in this.Product().Descriptors) {%>
                   <h3><strong><%=pd.Title %></strong></h3>
                   <p><%=pd.Body %></p>
                <%}%>
            </div><!--end product-specifications-->
        </div><!--end product-detail-->
        <div class="product-detail-btm"></div><!--end product-detail-btm-->
        <div class="clear"></div><!--end clear-->
    </div><!--end product-wrapper-->
    <div class="product-wrapper-btm"></div><!--end product-wrapper-btm-->
    <div class="related-products">
    	<h2>You Might Also Like</h2>
        <ul>
        <%foreach (Product p in this.Product().RelatedProducts)
        {%>
            <li><a href="<%=Url.Action("show","home",new{sku=p.SKU})%>" title="<%= p.Name %>"><%=p.Name %></a></li>
        <%}%>
        </ul>
    </div><!--end related-products-->
    <div class="clear"></div><!--end clear-->
</asp:Content>