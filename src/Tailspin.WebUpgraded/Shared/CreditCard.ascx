<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>

      <fieldset>
        <table class="shopping-cart">
            <thead>
                <tr>
                    <th class="first">Credit Card Type</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>
                        <select name="CardType">
                            <option value="Visa" selected="selected">Visa</option>
                            <option value="MasterCard">MasterCard</option>
                            <option value="Amex">Amex</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td>
                         <label>Credit Card Number</label>
                         <%=Html.TextBox("AccountNumber", "4586 9748 7358 4049", new { size = 40, maxlength = 40 })%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Security Code</label>
                        <%=Html.TextBox("VerificationCode", "000", new { size = 3, maxlength = 3 })%>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Expiration</label>
                        <select name="ExpirationMonth">
                            <%for (int i = 1; i <= 12; i++) { %>
                            <option value="<%=i%>"><%=i%></option>
                            <%} %>
                        </select>
                        <select name="ExpirationYear">
                            <%for (int i = 0; i <= 6; i++) { %>
                            <option value="<%=DateTime.Now.Year+i%>"><%=DateTime.Now.Year + i%></option>
                            <%} %>
                        </select>
                    </td>
                </tr>
            </tbody>
          </table>
        </fieldset>
