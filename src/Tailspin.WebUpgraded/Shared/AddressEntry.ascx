<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script src='<%=ResolveUrl("/Scripts/StateDropDown.js") %>' type="text/javascript"></script>
    <%
        Address thisAddress = this.CurrentCustomer().DefaultAddress;
        
    %>
<fieldset class="address-form">
  <%=Html.Hidden("UserName",this.CurrentCustomer().UserName) %>
  <table class="shopping-cart">
    <thead>
        <tr>
            <th class="first" colspan="2" />
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>
                <label>First</label>
            </td>
            <td>
                <%=Html.TextBox("FirstName", thisAddress.FirstName ?? "")%><%=Html.ValidationMessage("FirstName", "* Required") %>
            </td>
        </tr>                       
        <tr>
            <td>
                <label>Last</label>
            </td>
            <td>
                <%=Html.TextBox("LastName", thisAddress.LastName ?? "")%> <%=Html.ValidationMessage("LastName", "* Required") %>
            </td>
        </tr>                       
        <tr>
            <td>
                <label>Email</label>
            </td>
            <td>
                 <%=Html.TextBox("Email", thisAddress.Email ?? "")%><%=Html.ValidationMessage("Email", "* Required") %>
            </td>
        </tr>                       
        <tr>
            <td>
                  <label>Address</label>
            </td>
            <td>
                  <%=Html.TextBox("Street1", thisAddress.Street1 ?? "")%><%=Html.ValidationMessage("Street1", "* Required") %>
            </td>
        </tr>                       
        <tr>
            <td>
                  <label>Address 2</label>
            </td>
            <td>
                <%=Html.TextBox("Street2", thisAddress.Street2 ?? "")%>
            </td>
        </tr>                       
        <tr>
            <td>
                  <label>City</label>
            </td>
            <td>
                    <%=Html.TextBox("City", thisAddress.City ?? "")%><%=Html.ValidationMessage("City", "* Required") %>
            </td>
        </tr>                       
        <tr>
            <td>
                  <label>Country and State</label>
            </td>
            <td>
                <script type="text/javascript">
                      var postState = '<%=thisAddress.StateOrProvince%>';
                      var postCountry = '<%=thisAddress.Country%>';
                  </script>
                  <select id='countrySelect' name='country' onchange='populateState()'></select><%=Html.ValidationMessage("Country", "* Required")%>
                  <select id='stateSelect' name='stateorprovince'></select><%=Html.ValidationMessage("State", "* Required")%>
                  <script type="text/javascript">initCountry('US'); </script>
            </td>
        </tr>                       
        <tr>
            <td>
                  <label>Postal Code</label>
            </td>
            <td>
                   <%=Html.TextBox("Zip", thisAddress.Zip ?? "")%><%= Html.ValidationMessage("Zip", "* Required") %>
            </td>
        </tr>    
    </tbody>                   
</table>
</fieldset>
