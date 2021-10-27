<%@ Page Title="Receiving" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Receiving.aspx.cs" Inherits="WebApp.SystemPages.Receiving.Receiving" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Receiving</h1>

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

    <%--Message Control--%>
    <div class="row" style="margin-right:120px; margin-left:120px;">
        <div class="col-md-12">
            <asp:UpdatePanel ID="UpdatePaneReceiving1" runat="server">
                <ContentTemplate>
                    <uc1:messageusercontrol runat="server" id="MessageUserControl" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div><br/>
    <%--End Message Control--%>

    <asp:HiddenField ID="HiddenField1" runat="server" />

    <div class="row col-md-15" align="center">
        <h3>Purchase Orders</h3>
        <asp:ListView ID="OutstandingOrdersListView" runat="server" DataSourceID="PurchaseOrderListViewODS" DataKeyNames="PurchaseOrderID">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF; color: #284775;">
                    <td>
                        <asp:Label Text='<%# Eval("PurchaseOrderID") %>' runat="server" ID="PurchaseOrderIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VendorID") %>' runat="server" ID="VendorIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VendorName") %>' runat="server" ID="VendorNameLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="PhoneLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("EmployeeID") %>' runat="server" ID="EmployeeIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("OrderDate") %>' runat="server" ID="OrderDateLabel" /></td>
                    <td>
                        <asp:LinkButton ID="SelectOrder" runat="server" CommandArgument='<%# Eval("PurchaseOrderID") %>' OnCommand="SelectOrderCommand">Select Order</asp:LinkButton>
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
                <tr style="background-color: #E0FFFF; color: #333333;">
                    <td>
                        <asp:Label Text='<%# Eval("PurchaseOrderID") %>' runat="server" ID="PurchaseOrderIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VendorID") %>' runat="server" ID="VendorIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VendorName") %>' runat="server" ID="VendorNameLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Phone") %>' runat="server" ID="PhoneLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("EmployeeID") %>' runat="server" ID="EmployeeIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("OrderDate") %>' runat="server" ID="OrderDateLabel" /></td>
                    <td>
                        <asp:LinkButton ID="SelectOrder" runat="server" CommandArgument='<%# Eval("PurchaseOrderID") %>' OnCommand="SelectOrderCommand">Select Order</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                    <th runat="server">PurchaseOrderID</th>
                                    <th runat="server">VendorID</th>
                                    <th runat="server">VendorName</th>
                                    <th runat="server">Phone</th>
                                    <th runat="server">EmployeeID</th>
                                    <th runat="server">OrderDate</th>
                                    <th runat="server" style="width: 120px"></th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
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
        </asp:ListView>
    </div>

    <br /><br /><br /><br />

    <div class="row col-md-15" align="center">
        <div>
            <asp:LinkButton ID="ReceiveButton" runat="server" class="btn btn-info btn-sm" Visible="false" OnClick="ReceiveButtonClick">Receive</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="CloseButton" runat="server" class="btn btn-info btn-sm" Visible="false" OnClick="CloseButtonClick">Force Close</asp:LinkButton>
            
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Label ID="ReasonLabel" runat="server" Text="Label" Visible="false">Reason</asp:Label>
            <asp:TextBox ID="ReasonTextBox" runat="server" Width="300px" Visible="false"></asp:TextBox>
        </div>
    </div>

    <br /><br />

    <div class="row col-md-15" align="center">
        <asp:ListView ID="RecieveListView" runat="server" Visible="true">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF; color: #284775;">
                    <asp:HiddenField Value='<%# Eval("PurchaseOrderDetail") %>' runat="server" ID="PurchaseOrderDetailLabel" />
                    <td>
                        <asp:Label Text='<%# Eval("SID") %>' runat="server" ID="SIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Ordered") %>' runat="server" ID="OrderedLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Outstanding") %>' runat="server" ID="OutstandingLabel" /></td>
                    <td>
                        <asp:TextBox ID="ReceivingTextBox" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="ReturningTextBox" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonTextBox" runat="server"></asp:TextBox>
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
                <tr style="background-color: #E0FFFF; color: #333333;">
                    <asp:HiddenField Value='<%# Eval("PurchaseOrderDetail") %>' runat="server" ID="PurchaseOrderDetailLabel" />
                    <td>
                        <asp:Label Text='<%# Eval("SID") %>' runat="server" ID="SIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Ordered") %>' runat="server" ID="OrderedLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Outstanding") %>' runat="server" ID="OutstandingLabel" /></td>
                    <td>
                        <asp:TextBox ID="ReceiveTextBox" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="ReturnTextBox" runat="server" Text="0"></asp:TextBox>
                    </td>
                    <td>
                        <asp:TextBox ID="ReasonTextBox" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                    <th runat="server">SID</th>
                                    <th runat="server">Desription</th>
                                    <th runat="server">QtyO</th>
                                    <th runat="server">QOS</th>
                                    <th runat="server">Receive</th>
                                    <th runat="server">Return</th>
                                    <th runat="server">Reason</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
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
        </asp:ListView>
    </div>

    <br /><br /><br /><br />

    <div class="row col-md-15" align="center">
        <asp:ListView ID="UnOrderedItemsListView" runat="server" DataSourceID="UnOrderedItems" InsertItemPosition="LastItem" DataKeyNames="CID" Visible="false">
            <AlternatingItemTemplate>
                <tr style="background-color: #FFFFFF; color: #284775;">
                    <td>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("CID") %>' runat="server" ID="CIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VSN") %>' runat="server" ID="VSNLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Qty") %>' runat="server" ID="QtyLabel" /></td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button runat="server" CommandName="Insert" Text="Insert" ID="InsertButton" />
                        <asp:Button runat="server" CommandName="Cancel" Text="Clear" ID="CancelButton" />
                    </td>
                    <td>
                        <asp:TextBox Text='<%# Bind("CID") %>' runat="server" ID="CIDTextBox" ReadOnly="True" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("Description") %>' runat="server" ID="DescriptionTextBox" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("VSN") %>' runat="server" ID="VSNTextBox" /></td>
                    <td>
                        <asp:TextBox Text='<%# Bind("Qty") %>' runat="server" ID="QtyTextBox" /></td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #E0FFFF; color: #333333;">
                    <td>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("CID") %>' runat="server" ID="CIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VSN") %>' runat="server" ID="VSNLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Qty") %>' runat="server" ID="QtyLabel" /></td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table runat="server" id="itemPlaceholderContainer" style="background-color: #FFFFFF; border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px; font-family: Verdana, Arial, Helvetica, sans-serif;" border="1">
                                <tr runat="server" style="background-color: #E0FFFF; color: #333333;">
                                    <th runat="server"></th>
                                    <th runat="server">CID</th>
                                    <th runat="server">Description</th>
                                    <th runat="server">VSN</th>
                                    <th runat="server">Qty</th>
                                </tr>
                                <tr runat="server" id="itemPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center; background-color: #5D7B9D; font-family: Verdana, Arial, Helvetica, sans-serif; color: #FFFFFF">
                            <asp:DataPager runat="server" ID="DataPager2">
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
            <SelectedItemTemplate>
                <tr style="background-color: #E2DED6; font-weight: bold; color: #333333;">
                    <td>
                        <asp:Button runat="server" CommandName="Delete" Text="Delete" ID="DeleteButton" />
                    </td>
                    <td>
                        <asp:Label Text='<%# Eval("CID") %>' runat="server" ID="CIDLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Description") %>' runat="server" ID="DescriptionLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("VSN") %>' runat="server" ID="VSNLabel" /></td>
                    <td>
                        <asp:Label Text='<%# Eval("Qty") %>' runat="server" ID="QtyLabel" /></td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
    </div>

    <asp:ObjectDataSource ID="PurchaseOrderListViewODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="PORecieveOrders" TypeName="ToolsRUsSystem.BLL.Receiving.ReceivingController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="UnOrderedItems" runat="server" DataObjectTypeName="ToolsRUsSystem.ViewModels.UnOrderedList" DeleteMethod="UnOrderedItemsDelete" InsertMethod="UnOrderedItemsAdd" OldValuesParameterFormatString="original_{0}" SelectMethod="UnOrderedItemsSelect" TypeName="ToolsRUsSystem.BLL.Receiving.ReceivingController" OnDeleted="CheckForException" OnInserted="CheckForException" OnSelected="CheckForException" OnUpdated="CheckForException"></asp:ObjectDataSource>

</asp:Content>
