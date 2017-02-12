<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Tailspin Toys: Receipt</title>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<div id="bdy">
    <h1 class="section-header">Receipt: <%=this.CurrentOrder().ID.ToString().Substring(0,12) %></h1>
	<div class="product-wrapper">
        <div class="product-detail-top"></div><!--end product-detail-top-->
        <div class="product-detail">
        	<div class="product-overview">                
                <fieldset>
                    <legend>Order Details</legend>
                                
                    <table class="shopping-cart">
                        <thead>
                            <tr>
                                <th class="first" align="left"><b>Quantity</b></th>
                                <th><b>Item</b></th>
                                <th><b>Regular</b></th>
                                <th><b>Total</b></th>
                            </tr>
                        </thead>
                        <tbody>
                            <%foreach(OrderLine item in this.CurrentOrder().Items){%>
                                <tr>
                                    <td ><%=item.Quantity %></td>
                                    <td ><%=item.Item.Name%></td>
                                    <td  align="right"><%=item.Item.Price.ToString("C")%></td>
                                    <td  align="right"><%=item.LineTotal.ToString("C") %></td>
                                </tr>
                            <%} %>
                             <tr>
                                <td colspan="4"><hr /></td>
                             </tr>
                             <tr>
                                <td colspan="3" align="right">Subtotal</td>
                                <td align="right"><%= this.CurrentOrder().SubTotal.ToString("C")%></td>
                             </tr>
                              <tr>
                                <td colspan="3" align="right">Tax</td>
                                <td align="right"><%= this.CurrentOrder().TaxAmount.ToString("C")%></td>
                             </tr>
                             <tr>
                                <td colspan="3" align="right">Shipping (<%= this.CurrentOrder().ShippingService%>)</td>
                                <td align="right"><%= this.CurrentOrder().ShippingAmount.ToString("C")%></td>
                             </tr>
                             <tr>
                                <td colspan="3" align="right">Discount:</td>
                                <td align="right">-<%= this.CurrentOrder().DiscountAmount.ToString("C")%></td>
                             </tr>
                              <tr>
                                <td colspan="3" align="right">Grand Total</td>
                                <td align="right"><b><%= this.CurrentOrder().Total.ToString("C")%></b></td>
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
