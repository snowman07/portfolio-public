<%@ Page Title="Sales Return" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesReturn.aspx.cs" Inherits="WebApp.SystemPages.Sales.SalesReturn" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">

        <div class="row">
            <div class="col-md-12 text-center">
                <div class="jumbotron">
                    <h1>Sales Returns</h1>
                </div>
            </div>
        </div>

        <%-- ---------------------------------------------- --%>
        <%---------------- THIS IS FOR SECURITY --------------%>
        <div class="row">
            <div class="offset-10">
                <asp:Label ID="Label2" runat="server" Text="Employee:"></asp:Label>
                <asp:Label ID="LoggedUser" runat="server" ></asp:Label>
            </div>
        </div>
        <%----------- END OF THIS IS FOR SECURITY ------------%>
        <%-- ---------------------------------------------- --%>

        <div class="row">
            <div class="col-md-12" style="border-top: solid black 5px;">
            </div><br/>
        </div><br/>


        <%-- ---------------------------------------------- --%>
        <%--------- START OF MessageUserControl Area ---------%>
        <div class="row">
            <div class="col-md-12">
                <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
            </div>
        </div>

        <%---------- END OF MessageUserControl Area ----------%>
        <%-- ---------------------------------------------- --%>

        <div class="row">
            <div class="col-md-12">
                <asp:TextBox ID="TextBox1" runat="server">

                </asp:TextBox>

                <asp:LinkButton ID="lookupSaleLB" runat="server"
                    class="btn btn-success">
                    Lookup Sale
                </asp:LinkButton>
                <asp:LinkButton ID="LinkButton1" runat="server"
                    class="btn btn-danger">
                    Clear
                </asp:LinkButton>
            </div>
        </div>


    </div>
    <%--ENDOF container--%>

</asp:Content>
