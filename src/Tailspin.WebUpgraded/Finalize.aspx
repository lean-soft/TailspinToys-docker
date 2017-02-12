<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys: Finalize Order</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div id="bdy">
    <h1 class="section-header">Billing and Order Summary</h1>
	<div class="product-wrapper">
        <div class="product-detail-top"></div><!--end product-detail-top-->
        <div class="product-detail">
        	<div class="product-overview"> 
                <%using (Html.BeginForm("Payment","Order")) { %>
                    <%this.RenderCreditCard(); %>
                    <input type="submit" class="textbutton" value="Place Order" />
                <%} %>
        
                <fieldset>
                <%using (Html.BeginForm("Finalize","Order")) { %>
                <table class="shopping-cart">
                    <thead>
                        <tr>
                            <th class="first" align="left">Select Shipping</th>
                        </tr>
                    </thead>
                    <tbody>
                        <%foreach (ShippingMethod m in this.ShippingMethods().OrderBy(x=>x.Cost)) { %>
                            <tr>
                                <td>
                                    <input onclick="this.form.submit();" type="radio" value="<%=m.ID %>" name="id" <%=Html.IsChecked(m.ID, this.CurrentCart().ShippingMethodID)%>/> <%=m.Display %>
                                </td>
                            </tr>
                        <%} %>
                    </tbody>
                </table>
                <%} %>
                </fieldset>
                
                <fieldset>
                <table class="shopping-cart">
                    <thead>
                        <tr>
                            <th class="first" align="left">Shipping To</th>
                            <th>Billing To</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td style="width: 50%;">
                               <%this.RenderAddressDisplay(this.CurrentCart().ShippingAddress); %>
                            </td>
                            <td style="width: 50%;">
                                <%this.RenderAddressDisplay(this.CurrentCart().BillingAddress); %>
                            </td>
                        </tr>
                    </tbody>
                </table>
                        
                <table class="shopping-cart">
                    <thead>
                        <tr>
                            <th class="First" align="left"><b>Quantity</b></th>
                            <th><b>Item</b></th>
                            <th><b>Regular</b></th>
                            <th><b>Total</b></th>
                        </tr>
                      </thead>
                      <tbody>
                        <%foreach(ShoppingCartItem item in this.CurrentCart().Items){%>
                        <tr>
                            <td ><%=item.Quantity %></td>
                            <td ><%=item.Product.Name%></td>
                            <td  align="right"><%=item.Product.Price.ToString("C")%></td>
                            <td  align="right"><%=item.LineTotal.ToString("C") %></td>
                        </tr>

                        <%} %>
                         <tr>
                            <td colspan="4"><hr /></td>
                         </tr>
                         <tr>
                            <td colspan="3" align="right">Subtotal</td>
                            <td align="right"><%= this.CurrentCart().SubTotal.ToString("C")%></td>
                         </tr>
                          <tr>
                            <td colspan="3" align="right">Tax</td>
                            <td align="right"><%= this.CurrentCart().TaxAmount.ToString("C")%></td>
                         </tr>
                         <tr>
                            <td colspan="3" align="right">Shipping (<%= this.CurrentCart().ShippingService%>)</td>
                            <td align="right"><%= this.CurrentCart().ShippingAmount.ToString("C")%></td>
                         </tr>
                         <tr>
                            <td colspan="3" align="right">Discount:</td>
                            <td align="right">-<%= this.CurrentCart().DiscountAmount.ToString("C")%></td>
                         </tr>
                          <tr>
                            <td colspan="3" align="right">Grand Total</td>
                            <td align="right"><b><%= this.CurrentCart().Total.ToString("C")%></b></td>
                         </tr>
                         </tbody>
                    </table>    
                    </fieldset>         
                </div>
            </div>
        </div>
        <div class="product-wrapper-btm"></div><!--end product-wrapper-btm-->
    </div>
</asp:Content>
