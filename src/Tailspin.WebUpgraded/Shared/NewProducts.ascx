<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProductList>" %>

<div class="bottomWidget fltleft">
        <h5>New Planes</h5>
        <div class="bottomContent">
            <ul>
                <%foreach (Product p in Model.Products) { %>
                <li><a href="<%=Url.Action("show","home",new{sku=p.SKU})%>" title="Go to <%= p.Name %> Details Page"><%=p.Name %></a></li>
                <%} %>
            </ul>
        </div>
      </div>
