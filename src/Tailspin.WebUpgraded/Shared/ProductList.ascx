<%@ Control Language="C#"  Inherits="System.Web.Mvc.ViewUserControl<ProductList>" %>

     <h1 class="section-header">Our Hottest Paper Planes</h1>
    	<div class="product-wrapper">
            <p class="pagination">Viewing page 1 of 1.</p><!--end pagination-->
            <ul class="product-listing">
            <%foreach (Product p in Model.Products) { %>
                <li>
                    <img src="<%=Html.ProductImage(p.DefaultImage.ThumbnailPhoto) %>" width="140" height="154" alt="<%=p.Name %>" />
                    <h3><a href="<%=Url.Action("show","home",new{sku=p.SKU})%>" title="<%=p.Name %>"><%=p.Name %></a></h3>
                    <p><%=p.Blurb %></p>
                    <p><a class="view" href="<%=Url.Action("show","home",new{sku=p.SKU})%>">View Plane</a></p>
                    <span class="clear"></span>
                </li>
            <%} %>
            </ul><!--end product-listing-->
            <div class="clear"></div><!--end clear-->
        </div><!--end product-wrapper-->
        <div class="product-wrapper-btm"></div><!--end product-btm-->
      
     
                        
                    