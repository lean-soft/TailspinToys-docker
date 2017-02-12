<%@ Page Title="" Language="C#" MasterPageFile="Template.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <title>Product Listing - Tailspin Toys</title>
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content">
        <% 
            Dictionary<string, object> parms = new Dictionary<string, object>();
            parms.Add("Products", this.ProductList());
            Html.RenderAction("ListProducts", "Products", new RouteValueDictionary(parms));
        %>
    </div><!--end home-->
</asp:Content>