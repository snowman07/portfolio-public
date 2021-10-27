<%@ Page Title="Rentals" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApp.SystemPages.Rentals.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Rentals</h1>

    <%-- ---------------------------------------------- --%>
    <%---------------- THIS IS FOR SECURITY --------------%>
    <div class="row">
        <div class="offset-10">
            <asp:Label ID="Label2" runat="server" Text="Employee"></asp:Label>
            <asp:Label ID="LoggedUser" runat="server" ></asp:Label>
        </div>
    </div>
    <%----------- END OF THIS IS FOR SECURITY ------------%>
    <%-- ---------------------------------------------- --%>

</asp:Content>
