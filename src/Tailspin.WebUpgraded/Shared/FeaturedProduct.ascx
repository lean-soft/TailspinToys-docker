<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Tailspin.Model.Product>" %>

<%
    if(Model != null){
        var Product = Model; %>
        <a href="<%=Url.Action("Show","Home",new{sku=Product.SKU}) %>">
             <img src='<%=ResolveUrl("~/Content/Images/LiftingBodies.jpg") %>' alt="featured product"/>
        </a>
    <%}else{ %>
     
     <img src='<%=ResolveUrl("~/Content/Images/LiftingBodies.jpg") %>' alt="featured product"/>
    <%} %>
