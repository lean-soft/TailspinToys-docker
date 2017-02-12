<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys: Shopping Cart</title>
</asp:Content>
            
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    	<h1 class="section-header">Your Shopping Cart</h1>
    	<div class="product-wrapper">
            <div class="product-detail-top"></div><!--end product-detail-top-->
            <div class="product-detail">
            	<table class="shopping-cart">
                	<thead>
                    	<tr>
                        	<th class="first" colspan="2">Item</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Remove</th>
                            <th>Total</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (ShoppingCartItem item in this.CurrentCart().Items) { %>
                        	<tr>
                            	<td><a href="<%=Url.Action("Show","Home",new{sku=item.Product.SKU}) %>"><img src="<%=Html.ProductImage(item.Product.DefaultImage.FullSizePhoto) %>" width="65" height="57" alt="F-15 Strike Eagle" /></a></td>
                                <td><a href="<%=Url.Action("Show","Home",new{sku=item.Product.SKU}) %>"><strong><%=item.Product.Name%></strong></a> <br/>Added on <%=item.DateAdded.ToString()%></td>
                                <td><%= item.Product.Price.ToString("C") %></td>
                                <td><%using (Html.BeginForm("UpdateItem", "Cart")) {%><input type="hidden" name="id" value="<%=item.Product.SKU %>" /><input class="quantity" name="Quantity" type="text" value="<%=item.Quantity.ToString() %>" onchange="this.form.submit();" /><%} %></td>
                                <td><%using (Html.BeginForm("RemoveItem", "Cart")) {%><input type="hidden" name="id" value="<%=item.Product.SKU %>" /><input class="remove" type="button" value="Remove" title="Remove this item from your shopping cart" onclick="this.form.submit();" /><%} %></td>
                                <td><%= item.LineTotal.ToString("C") %></td>
                            </tr>
                        <%} %>
                    </tbody>
                    <tfoot>
                    	<td colspan="6">
                        	<span class="coupon-code">
                            	<p>Enter discount coupon:</p><input class="coupon-code" type="text" /><input class="enter" type="button" value="Go" title="Apply coupon code" /></span>
                            </span>
                        	<%using (Html.BeginForm("Checkout", "Order")) {%><input class="checkout" type="button" value="Checkout" title="Proceed to checkout" onclick="this.form.submit();" /><%} %>
                        </td>
                    </tfoot>
                </table>
                <div class="clear"></div><!--end clear-->
            </div><!--end product-detail-->
            <div class="product-detail-btm"></div><!--end product-detail-btm-->
            <div class="clear"></div><!--end clear-->
        </div><!--end product-wrapper-->
        <div class="product-wrapper-btm"></div><!--end product-wrapper-btm-->
        <div class="clear"></div><!--end clear-->
    </div><!--end content-->
</asp:Content>