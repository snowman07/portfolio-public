<%@ Page Title="Sales Order" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesOrder.aspx.cs" Inherits="WebApp.SystemPages.Sales.SalesOrder" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%--<div class="container">--%>

        <div class="row">
            <div class="col-md-12 text-center">
                <div class="jumbotron">
                    <h1>Sales Order</h1>
                </div>
            </div>
        </div>

        <%-- ---------------------------------------------- --%>
        <%------------------ START OF SECURITY ---------------%>
        <div class="row">
            <div class="offset-10">
                <asp:Label ID="Label2" runat="server" Text="Employee:"></asp:Label>
                <asp:Label ID="LoggedUser" runat="server" ></asp:Label>
            </div>
        </div>
        <%----------------- END OF SECURITY ------------------%>
        <%-- ---------------------------------------------- --%>

        <div class="row">
            <div class="col-md-12" style="border-top: solid black 5px;">
            </div><br/>
        </div>


        <%-- ---------------------------------------------- --%>
        <%--------- START OF MessageUserControl Area ---------%>
        <div class="row" style="margin-right:120px; margin-left:120px;">
            <div class="col-md-12">
                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                    <ContentTemplate>
                        <uc1:messageusercontrol runat="server" id="MessageUserControl" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div><br/>
        <%---------- END OF MessageUserControl Area ----------%>
        <%-- ---------------------------------------------- --%>


        <%-- ---------------------------------------------- --%>
        <%---------------- START OF PANELVIEW ----------------%>
        <div class="row">
            <div class="col-md-12">
                <%--<asp:MultiView ID="MultiView1" runat="server" 
                    ActiveViewIndex="0">--%>

                <ul class="nav nav-pills nav-fill">
                    <li class="nav-item">
                        <a class="nav-link active" 
                            href="#shopping" 
                            data-toggle="tab" 
                            id="shoppingOpen" 
                            style="font-size: 30px; font-style:normal;">
                            <i class="fa fa-shopping-bag"></i>&nbsp;&nbsp;&nbsp;Shopping
                        </a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" 
                            href="#viewcart" 
                            data-toggle="tab" 
                            id="cartOpen"
                            style="font-size: 30px; font-style:normal;">
                            <i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;&nbsp;View Cart 
                        </a>                  
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" 
                            href="#checkout" 
                            data-toggle="tab" 
                            id="checkoutOpen"
                            style="font-size: 30px; font-style:normal;">
                            <i class="fa fa-thumbs-up"></i>&nbsp;&nbsp;&nbsp;Checkout
                        </a>
                    </li>
                </ul> <br />

                <%--<asp:View ID="View1" runat="server"><br>--%>
                <div class="tab-content">
                    
                    <%-- ----------------------------------------------- --%>
                    <%--------------- START OF SHOPPING VIEW --------------%>
                    <div class="tab-pane active" id="shopping">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-between;">
                                        <h2 style="font-style:italic;"><i class="fa fa-shopping-bag"></i>&nbsp;&nbsp;Shopping</h2>
                                        <asp:Button ID="Cancel" runat="server" Text="Cancel" 
                                            class="btn btn-danger btn-lg" 
                                            OnClick="Cancel_Click"
                                             OnClientClick="return confirm('Are you sure?')"/>
                                    </div>
                                </div><br/>

                                <div class="row">
                                    <%-- START OF DDL for Category ------------------ --%>
                                    <div class="col-md-3">
                                        <asp:Label ID="Label1" runat="server" Text="Select a category:"></asp:Label>
                                        <asp:DropDownList ID="CategoryDDL" runat="server"
                                            DataSourceID="CategoryDDLODS"
                                            DataTextField="DisplayField"
                                            DataValueField="ValueField"
                                                AppendDataBoundItems="true"
                                                AutoPostBack="true"
                                            OnSelectedIndexChanged="CategoryDDL_SelectedIndexChanged"
                                                CssClass="btn btn-success dropdown-toggle">
                                            <asp:ListItem Value="0" Selected="True" Text="select..."></asp:ListItem>
                                            <asp:ListItem Value="" Text="All"></asp:ListItem>
                                        </asp:DropDownList>     
                                    </div>
                                    <%-- ------------------  ENDOF DDL for Category --%>


                                    <%-- START OF Category Count ------------------ --%>
                                    <div class="col-md-1">
                                        <asp:Label ID="Label3" runat="server" Text="Count:"></asp:Label>
                                        <input class="form-control" runat="server"
                                            id="categoryCount" 
                                            type="text" 
                                            value="0" 
                                            disabled 
                                            Text='<%# Eval("categoryCount") %>'> 
                                    </div>
                                    <%-- ------------------  ENDOF Category Count --%>   


                                    <%-- START OF GridView ------------------------ --%>
                                    <div class="col-md-8">
                                       
                                        <p>Here is the is result of category:</p>
                                        <asp:GridView ID="StockItemGV" runat="server" 
                                             AutoGenerateColumns="false"
                                            DataSourceID="StockItemLVODS"
                                             OnRowCommand="StockItemGV_RowCommand"
                                             CssClass="table table-sm table-hover table-dark">

                                            <Columns>
                                                <asp:ButtonField Text="Add" 
                                                     CommandName="Add"
                                                     ControlStyle-CssClass="btn btn-outline-primary"/>

                                                <asp:TemplateField HeaderText="StockItemID" SortExpression="StockItemID"  Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("StockItemID") %>' ID="StockItemIDSV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("Description") %>' ID="DescriptionSV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Math.Round((decimal)(Eval("SellingPrice")), 2) %>' ID="PriceSV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity Available" SortExpression="QuantityOnHand">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("QuantityOnHand") %>' ID="QuantityOnHandSV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="QuantitySV" runat="server" TextMode="Number" Text='<%# Eval("Count") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>

                                        </asp:GridView>
                                    </div>
                                    <%-- --------------------------- ENDOF GridView --%>  
                
                                </div><br/><br/><br/>
                                <%-- ENDOF row --%>


                                <%-- START OF View Cart LinkButton -------------------- --%>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:flex-end;">
                                        <asp:LinkButton ID="Cart" runat="server" 
                                            class="btn btn-warning btn-lg" 
                                            OnClick="Cart_Click"
                                             OnClientClick="openCart()">
                                            View Cart&nbsp;&nbsp;
                                            <span><i class="fa fa-caret-right"></i></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <%-- ---------------------------END OF View Cart LinkButton --%>


                                <%-- ----------------------------- --%>
                                <%-- --------- ODS AREA ---------- --%>
                                <%-- ----------------------------- --%>
                                <asp:ObjectDataSource ID="CategoryDDLODS" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="Categories_DDL" 
                                    TypeName="ToolsRUsSystem.BLL.Sales.CategoryController">
                                </asp:ObjectDataSource>

                                <asp:ObjectDataSource ID="StockItemLVODS" runat="server" 
                                    OldValuesParameterFormatString="original_{0}" 
                                    SelectMethod="List_StockItemFromCategorySelection" 
                                    TypeName="ToolsRUsSystem.BLL.Sales.StockItemController">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="CategoryDDL" 
                                            PropertyName="SelectedValue" 
                                            Name="categoryid"
                                            Type="Int32">
                                        </asp:ControlParameter>
                                    </SelectParameters>
                                </asp:ObjectDataSource>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%-- ENDOF tab-pane --%>
                    <%--------------- END OF SHOPPING VIEW ----------------%>
                    <%-- ----------------------------------------------- --%>


                    <%-- ---------------------------------------- --%>
                    <%------------ START OF VIEWCART VIEW ----------%>
                    <div class="tab-pane" id="viewcart">
                        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-between;">
                                        <h2 style="font-style:italic"><i class="fa fa-shopping-cart"></i>&nbsp;&nbsp;View Cart</h2>
                                        <asp:Button ID="Button1" runat="server" Text="Cancel" 
                                                    class="btn btn-danger btn-lg" 
                                                    OnClick="Cancel_Click"
                                                     OnClientClick="return confirm('Are you sure?')"/>
                                    </div>
                                </div>
                                <br/>
                                <br/>

                                <%-- START OF ListView ------------------------ --%>
                                <%--<asp:ListView ID="ViewCartLV" runat="server">
                                    <AlternatingItemTemplate>
                                        <tr style="background-color: #FFF8DC;">
                                            <td>
                                                <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" />
                                            </td>
                                            <td>
                                                <asp:TextBox Text='<%# Eval("Quantity") %>' ID="QuantityTBViewCart" runat="server"
                                                        TextMode="Number"
                                                        min="1"
                                                        max="999"
                                                        step="1"
                                                        CssClass="form-control form-control-sm text-center">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SellingPrice", "{0:c}") %>' runat="server" ID="SellingPriceLabel" />
                                            </td>
                                            <td>
                                                <asp:Label Text='<%# Eval("Total", "{0:c}") %>' runat="server" ID="TotalLabel" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="RefreshCart" runat="server"
                                                        CssClass="btn btn-info btn-xs" CommandArgument='<%# Eval("ItemID") %>' CommandName="refresh">
                                                    <span class="glyphicon glyphicon-refresh"></span>
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="RemoveFromCart" runat="server"
                                                        CssClass="btn btn-danger btn-xs" CommandArgument='<%# Eval("ItemID") %>' CommandName="remove">
                                                    <span class="glyphicon glyphicon-trash"></span>
                                                </asp:LinkButton>
                                            </td>
                                            <td style="display:none">
                                                <asp:HiddenField ID="ItemIDLabel" runat="server" Value='<%# Eval("ShoppingItemID") %>' />
                                            </td>
                                        </tr>
                                    </AlternatingItemTemplate>
                                    <EmptyDataTemplate>
                                        <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                                            <tr>
                                                <td>No data was returned.</td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate>
                                    <ItemTemplate>
                                        <tr style="background-color: #DCDCDC; color: #000000;">
                                            <td>
                                                <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" />
                                            </td>
                                            <td>
                                                <asp:TextBox Text='<%# Eval("Quantity") %>' ID="QuantityTBViewCart" runat="server"
                                                        TextMode="Number"
                                                        min="1"
                                                        max="999"
                                                        step="1"
                                                        CssClass="form-control form-control-sm text-center">
                                                </asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:Label Text='<%# Eval("SellingPrice", "{0:c}") %>' runat="server" ID="SellingPriceLabel" />
                                            </td>
                                            <td>
                                                <asp:Label Text='<%# Eval("Total", "{0:c}") %>' runat="server" ID="TotalLabel" />
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="RefreshCart" runat="server"
                                                        CssClass="btn btn-info btn-xs" CommandArgument='<%# Eval("ItemID") %>' CommandName="refresh">
                                                    <span class="glyphicon glyphicon-refresh"></span>
                                                </asp:LinkButton>
                                            </td>
                                            <td>
                                                <asp:LinkButton ID="RemoveFromCart" runat="server"
                                                        CssClass="btn btn-danger btn-xs" CommandArgument='<%# Eval("ItemID") %>' CommandName="remove">
                                                    <span class="glyphicon glyphicon-trash"></span>
                                                </asp:LinkButton>
                                            </td>
                                            <td style="display:none">
                                                <asp:HiddenField ID="ItemIDLabel" runat="server" Value='<%# Eval("ShoppingItemID") %>' />
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <LayoutTemplate>
                                        <table runat="server">
                                            <tr runat="server">
                                                <td runat="server">
                                                    <table runat="server" id="itemPlaceholderContainer" width="800px" style="background-color: #FFFFFF; text-align:center; font-family: Verdana, Arial, Helvetica, sans-serif;">
                                                        <tr runat="server" style="background-color: #fff; color: #000;">
                                                            <th runat="server">Description</th>
                                                            <th runat="server" width="140px">Quantity</th>
                                                            <th runat="server">Price</th>
                                                            <th runat="server">Total</th>
                                                            <th runat="server"></th>
                                                            <th runat="server"></th>
                                                            <th runat="server"></th>
                                                        </tr>
                                                        <tr runat="server" id="itemPlaceholder"></tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr runat="server">
                                                <td runat="server" style="text-align: center; background-color: #f0f0f0; font-family: Verdana, Arial, Helvetica, sans-serif; color: #000;">
                                                    <asp:DataPager runat="server" ID="DataPager1">
                                                        <Fields>
                                                            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                                            <asp:NumericPagerField></asp:NumericPagerField>
                                                            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
                                                        </Fields>
                                                    </asp:DataPager>
                                                </td>
                                            </tr>
                                        </table>
                                    </LayoutTemplate>
                                </asp:ListView>--%>



                                <%-- ------------------------ END OF ListView - --%>


                                <%-- START OF GridView ------------------------ --%>
                                <div class="row">
                                    <div class="col-md-12">
                                        <asp:GridView ID="cartGrid" runat="server"
                                             AutoGenerateColumns="false"
                                             ItemType="ToolsRUsSystem.ViewModels.ViewCartItem"
                                             DataKeyNames="StockItemID"
                                             OnRowCommand="cartGrid_RowCommand"
                                             CssClass="table table-sm table-hover table-dark">
                                    
                                            <Columns>
                                                <asp:TemplateField HeaderText="StockItemID" SortExpression="StockItemID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("StockItemID") %>' ID="StockItemIDCV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        
                                                <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("Description") %>' ID="DescriptionCV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity Available" SortExpression="QuantityOnHand" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("QuantityOnHand") %>' ID="QuantityOnHandCV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="QuantityCV" runat="server" TextMode="Number" Text='<%# Eval("Quantity") %>'></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        
                                                <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("Price") %>' ID="PriceCV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        
                                                <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                                    <ItemTemplate>
                                                        <asp:Label runat="server" Text='<%# Eval("Total") %>' ID="TotalCV"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                        
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton runat="server" ID="refreshBtn" 
                                                             CommandName="Refresh" 
                                                             ImageUrl="~/img/Refresh.png" 
                                                             AlternateText="Refresh" 
                                                             ImageAlign="AbsMiddle"
                                                             OnClick="refreshBtn_Click">
                                                        </asp:ImageButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                
                                                <asp:ButtonField Text="remove" CommandName="Remove" 
                                                     ControlStyle-CssClass="btn btn-outline-danger" />

                                            </Columns>
                                        </asp:GridView>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-around">
                                        <div></div>
                                        <div>
                                            <asp:Label ID="Label4" runat="server" CssClass="font-weight-bold" Text="Total: "></asp:Label>
                                            &nbsp;
                                            <asp:Label ID="totalLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>
                                <br/>
                                <br/>

                                <%-- ------------------------ END OF GridView - --%>



                                <%-- START OF Shopping and Checkout LinkButton -------------------- --%>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-between;">
                                        <asp:LinkButton ID="ShoppingLB" runat="server" 
                                            class="btn btn-warning btn-lg" 
                                             OnClientClick="openShopping()">
                                            <span><i class="fa fa-caret-left"></i></span>&nbsp;&nbsp;Shopping
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="CheckoutLB" runat="server" 
                                            class="btn btn-warning btn-lg" 
                                             OnClientClick="openCheckout()"
                                             OnCommand="CheckoutLB_Command">
                                            Checkout&nbsp;&nbsp;
                                            <span><i class="fa fa-caret-right"></i></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                 <%-- -----------------END OF Shopping and Checkout Cart LinkButton --%>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%------------ END OF VIEWCART VIEW ------------%>
                    <%-- ---------------------------------------- --%>

                    
                    <%-- ---------------------------------------- --%>
                    <%------------ START OF CHECKOUT VIEW ----------%>
                    <div class="tab-pane" id="checkout">
                        <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-between;">
                                        <h2 style="font-style:italic"><i class="fa fa-thumbs-up"></i>&nbsp;&nbsp;Checkout</h2>
                                        <asp:Button ID="Button2" runat="server" Text="Cancel" 
                                                    class="btn btn-danger btn-lg" 
                                                    OnClick="Cancel_Click"
                                                     OnClientClick="return confirm('Are you sure?')"/>
                                    </div>
                                </div>
                                <br/>
                                <br/>

                                <%-- START OF GridView ------------------------ --%>
                                <asp:GridView ID="checkoutGrid" runat="server"
                                     ItemType="ToolsRUsSystem.ViewModels.CheckoutModel"
                                     AutoGenerateColumns="false"
                                     CssClass="table table-sm table-hover table-dark">
                                    <Columns>
                                        <asp:TemplateField HeaderText="StockItemID" SortExpression="StockItemID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("StockItemID") %>' ID="StockItemIDCK"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Description" SortExpression="Description">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Description") %>' ID="DescriptionCK"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity Available" SortExpression="QuantityOnHand" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("QuantityOnHand") %>' ID="QuantityOnHandCK"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Quantity" SortExpression="Quantity">
                                            <ItemTemplate>
                                                <asp:Label ID="QuantityCK" runat="server" Text='<%# Eval("Quantity") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Price" SortExpression="Price">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Price") %>' ID="PriceCK"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Total" SortExpression="Total">
                                            <ItemTemplate>
                                                <asp:Label runat="server" Text='<%# Eval("Total") %>' ID="TotalCK"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <br/>
                                <%-- ------------------------ END OF GridView - --%>
                                <div class="row">
                                    <div class="col-md-4" style="padding-left:20px;">
                                        <asp:Label ID="Label8" runat="server" 
                                            Text="Select discount coupon:"
                                             CssClass="font-weight-bold">
                                        </asp:Label>
                                        <asp:DropDownList ID="couponDDL" runat="server"
                                            CssClass="btn btn-success dropdown-toggle" 
                                            DataSourceID="couponODS" 
                                            DataTextField="DisplayField" 
                                            DataValueField="ValueField"
                                             AppendDataBoundItems="true"
                                             OnSelectedIndexChanged="couponDDL_SelectedIndexChanged">
                                            <asp:ListItem Value="0" Selected="true">
                                                Select A Coupon
                                            </asp:ListItem>
                                        </asp:DropDownList>
                                        <%-- -------------------- --%>
                                        <%-- ----- ODS AREA ----- --%>
                                        <%-- -------------------- --%>
                                        <asp:ObjectDataSource ID="couponODS" runat="server" 
                                            OldValuesParameterFormatString="original_{0}" 
                                            SelectMethod="Category_DDL" 
                                            TypeName="ToolsRUsSystem.BLL.Sales.CouponController">
                                        </asp:ObjectDataSource>
                                    </div>
                                    <div class="col-md-4" style="padding-left:40px;">
                                        <asp:Label ID="Label9" runat="server" 
                                            Text="Select payment type:"
                                             CssClass="font-weight-bold">
                                        </asp:Label><br/>
                                        <asp:RadioButtonList ID="paymentTypeCK" runat="server" 
                                            RepeatDirection="Horizontal">
                                            <asp:ListItem Value="C" Text="Credit"></asp:ListItem>
                                            <asp:ListItem Value="D" Text="Debit"></asp:ListItem>
                                            <asp:ListItem Value="M" Text="Cash"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-md-4" style="padding-left:200px;">
                                        <div>
                                            <asp:Label ID="Label5" runat="server" 
                                                CssClass="font-weight-bold" 
                                                Text="Subtotal: ">
                                            </asp:Label>
                                            &nbsp;
                                            <asp:Label ID="subtotalLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label6" runat="server" 
                                                CssClass="font-weight-bold" 
                                                Text="Tax: ">
                                            </asp:Label>
                                            &nbsp;
                                            <asp:Label ID="taxLabel" runat="server" Text=""></asp:Label>
                                        </div>
                                        <div>
                                            <asp:Label ID="Label7" runat="server" 
                                                CssClass="font-weight-bold" 
                                                Text="Total: ">
                                            </asp:Label>
                                            &nbsp;
                                            <asp:Label ID="totalLabelCK" runat="server" Text=""></asp:Label>
                                        </div>
                                    </div>
                                </div>

                                <br/>
                                <br/>


                                <%-- START OF ViewCart and Place Order LinkButton -------------------- --%>
                                <div class="row">
                                    <div class="col-md-12" style="display:flex; justify-content:space-between;">
                                        <asp:LinkButton ID="ViewCart" runat="server" 
                                            class="btn btn-warning btn-lg" 
                                             OnClientClick="openCart()">
                                            <span><i class="fa fa-caret-left"></i></span>&nbsp;&nbsp;View Cart
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="placeOrderLB" runat="server" 
                                            class="btn btn-warning btn-lg" 
                                             OnClientClick="openCheckout()"
                                             OnClick="placeOrderLB_Click">
                                            Place Order&nbsp;&nbsp;
                                            <span><i class="fa fa-check-circle"></i></span>
                                        </asp:LinkButton>
                                    </div>
                                </div>
                                <%-- -----------------END OF ViewCart and Place Order LinkButton --%>


                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <%------------ END OF CHECKOUT VIEW ------------%>
                    <%-- ---------------------------------------- --%>


                </div>
                <%-- ENDOF tab-content --%>

            </div>
            <%-- ENDOF col-md-11 --%>

        </div>
        <%-- ENDOF row --%>
        <%----------------- END OF PANELVIEW -----------------%>
        <%-- ---------------------------------------------- --%>

        <br/><br/>
    <%--</div>--%>
    <%--ENDOF container--%>


    <script>
        function openCart() {
            $('#cartOpen').trigger('click')
            return false;
        }
        function openShopping() {
            $('#shoppingOpen').trigger('click')
        }
        function openCheckout() {
            $('#checkoutOpen').trigger('click')
        }
    </script>

</asp:Content>
