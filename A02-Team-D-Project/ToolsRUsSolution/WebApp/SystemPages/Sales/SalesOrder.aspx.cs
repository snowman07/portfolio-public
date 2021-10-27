using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ToolsRUsSystem.BLL.Sales;
using ToolsRUsSystem.ViewModels;
using System.Configuration;
using WebApp.Security;
using ToolsRUsSystem.BLL.SharedControllers;
using System.Globalization;
#endregion

namespace WebApp.SystemPages.Sales
{
    public partial class SalesOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //security code for forms security
            //check to see if the user is logged on
            if (Request.IsAuthenticated)
            {
                //logged in BUT do you have authority to be on this page
                if (User.IsInRole(ConfigurationManager.AppSettings["associateRole"]) || User.IsInRole(ConfigurationManager.AppSettings["storeManagerRole"]))
                {
                    SecurityController ssysmgr = new SecurityController();

                    int? employeeid = ssysmgr.GetCurrentUserEmployeeID(User.Identity.Name);

                    int empid = employeeid ?? default(int);

                    CommonEmployeeController sysmgr = new CommonEmployeeController();
                    string employeeName = sysmgr.GetEmployeeName(empid);
                    LoggedUser.Text = employeeName;

                    //LoadCategoryList();
                }
                else
                {
                    Response.Redirect("~/SystemPages/DeniedAccess.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Account/Login.aspx");
            }
        }


        #region Shopping tab control

        // FOR CATEGORY DDL
        protected void CategoryDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                StockItemController sysmgr = new StockItemController();
                int? categoryid;

                if (CategoryDDL.SelectedValue != "")
                {
                    categoryid = int.Parse(CategoryDDL.SelectedValue);
                }
                else
                {
                    categoryid = null;
                }

                List<StockItemList> info = sysmgr.List_StockItemFromCategorySelection(categoryid);
                //categoryCount
                categoryCount.Value = info.Count.ToString();

            }, "Found", "Available products below");

        }

        protected void StockItemGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            //Reminder: MessageUserControl will do the error handling
            MessageUserControl.TryRun(() =>
            {
                //ListView source = e.CommandSource as ListView;
                GridView source = e.CommandSource as GridView;

                List<StockItemList> inputList = new List<StockItemList>();   //for Shopping tab
                List<ViewCartItem> outputList = new List<ViewCartItem>();   // for View Cart tab

                int selectedIndex;

                if (int.TryParse(e.CommandArgument.ToString(), out selectedIndex))
                {
                    //foreach (ListViewDataItem item in source.Items)
                    foreach (GridViewRow row in source.Rows)
                    {
                        var stockItemID = row.FindControl("StockItemIDSV") as Label;
                        var description = row.FindControl("DescriptionSV") as Label;
                        var quantityOnHand = row.FindControl("QuantityOnHandSV") as Label;
                        var quantity = row.FindControl("QuantitySV") as TextBox;

                        var shoppingCartInfo = new StockItemList();

                        var sid = shoppingCartInfo.StockItemID = int.Parse(stockItemID.Text.ToString());
                        shoppingCartInfo.Description = description.Text;
                        var qoh = int.Parse(quantityOnHand.Text.ToString());
                        var quantityS = shoppingCartInfo.Count = int.Parse(quantity.Text.ToString());
                        shoppingCartInfo.QuantityOnHand = qoh - quantityS;
                        shoppingCartInfo.SellingPrice = decimal.Parse((row.FindControl("PriceSV") as Label).Text);

                        if (quantityS > qoh)
                        {
                            throw new Exception("Quantity can't be greater than the Quantity On Hand");
                        }
                        else if (quantityS < 0)
                        {
                            throw new Exception("Quantity can't be less than zero");
                        }
                        else
                        {
                            inputList.Add(shoppingCartInfo);
                        }

                    }

                    foreach (GridViewRow row in cartGrid.Rows)
                    {
                        var stockItemID = row.FindControl("StockItemIDCV") as Label;
                        var description = row.FindControl("DescriptionCV") as Label;
                        var quantityOnHand = row.FindControl("QuantityOnHandCV") as Label;
                        var quantity = row.FindControl("QuantityCV") as TextBox;

                        var cartInfo = new ViewCartItem();

                        cartInfo.StockItemID = int.Parse((row.FindControl("StockItemIDCV") as Label).Text);
                        cartInfo.Description = description.Text;
                        cartInfo.QuantityOnHand = int.Parse(quantityOnHand.Text.ToString());
                        var quantityC = cartInfo.Quantity = int.Parse(quantity.Text.ToString());
                        var priceC = cartInfo.Price = decimal.Parse((row.FindControl("PriceCV") as Label).Text);
                        decimal totalC = cartInfo.Total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);
                        outputList.Add(cartInfo);
                    }
                    var addto = inputList[selectedIndex];
                    var cartInfo2 = new ViewCartItem();

                    var sid2 = cartInfo2.StockItemID = addto.StockItemID;
                    cartInfo2.Description = addto.Description;
                    cartInfo2.QuantityOnHand = addto.QuantityOnHand;
                    cartInfo2.Quantity = addto.Count;
                    cartInfo2.Price = addto.SellingPrice;
                    decimal totalAmount = cartInfo2.Total = cartInfo2.Price * cartInfo2.Quantity;
                    totalLabel.Text = cartGrid.Rows.Count.ToString();
                    if (outputList.Any(x => x.StockItemID == sid2))
                    {
                        throw new Exception("Item already exists. Add another item or click the view cart button to view the cart.");
                    }
                    else
                    {
                        outputList.Add(cartInfo2);
                        cartGrid.DataSource = outputList;
                        cartGrid.DataBind();
                    }
                }

            }, "Success", "Item has been added. You can see it in View Cart tab.");

            decimal subtotal = 0;
            foreach (GridViewRow row in cartGrid.Rows)
            {
                decimal total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);
                subtotal += total;
                totalLabel.Text = subtotal.ToString();
            }
        }
        #endregion


        #region View Cart tab

        protected void cartGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                GridView sourceGridview = e.CommandSource as GridView;
                List<ViewCartItem> inputlist = new List<ViewCartItem>();
                //List<CheckoutModel> outputlist = new List<CheckoutModel>();
                int selectedindex;

                if (int.TryParse(e.CommandArgument.ToString(), out selectedindex))
                {
                    foreach (GridViewRow row in sourceGridview.Rows)
                    {
                        var stockItemID = row.FindControl("StockItemIDCV") as Label;
                        var description = row.FindControl("DescriptionCV") as Label;
                        var quantityOnHand = int.Parse((row.FindControl("QuantityOnHandCV") as Label).Text);
                        var quantity = int.Parse((row.FindControl("QuantityCV") as TextBox).Text);
                        var price = decimal.Parse((row.FindControl("PriceCV") as Label).Text);
                        var total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);

                        var cartgridinfo = new ViewCartItem();
                        var sid = cartgridinfo.StockItemID = int.Parse(stockItemID.Text.ToString());
                        cartgridinfo.Description = description.Text.ToString();
                        cartgridinfo.QuantityOnHand = quantityOnHand;
                        cartgridinfo.Quantity = quantity;
                        cartgridinfo.Price = price;
                        var totalAmount = cartgridinfo.Total = price * quantity;

                        inputlist.Add(cartgridinfo);
                    }

                    inputlist.RemoveAt(selectedindex);
                    sourceGridview.DataSource = inputlist;
                    sourceGridview.DataBind();

                    decimal subtotal = 0;
                    foreach (GridViewRow row in cartGrid.Rows)
                    {
                        decimal total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);
                        subtotal += total;
                        totalLabel.Text = subtotal.ToString();
                    }

                    if (cartGrid.Rows.Count == 0)
                    {
                        int zero = 0;
                        totalLabel.Text = zero.ToString();
                    }
                }
            }, "Success", "Product has been deleted.");
        }

        protected void refreshBtn_Click(object sender, ImageClickEventArgs e)
        {
            GridView sourceGridView = cartGrid as GridView;
            List<ViewCartItem> inputlist = new List<ViewCartItem>();
            MessageUserControl.TryRun(() =>
            {
                foreach (GridViewRow row in sourceGridView.Rows)
                {
                    var stockItemID = row.FindControl("StockItemIDCV") as Label;
                    var description = row.FindControl("DescriptionCV") as Label;
                    var quantityOnHand = int.Parse((row.FindControl("QuantityOnHandCV") as Label).Text);
                    var quantity = int.Parse((row.FindControl("QuantityCV") as TextBox).Text);
                    var price = decimal.Parse((row.FindControl("PriceCV") as Label).Text);
                    var total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);

                    var cartgridinfo = new ViewCartItem();
                    var sid = cartgridinfo.StockItemID = int.Parse(stockItemID.Text.ToString());
                    cartgridinfo.Description = description.Text.ToString();
                    cartgridinfo.QuantityOnHand = quantityOnHand;
                    cartgridinfo.Quantity = quantity;
                    cartgridinfo.Price = price;
                    var totalAmount = cartgridinfo.Total = price * quantity;

                    if (quantity > quantityOnHand)
                    {
                        throw new Exception("Quantity can't be greater than the quantity on hand");
                    }

                    else
                    {
                        inputlist.Add(cartgridinfo);
                        sourceGridView.DataSource = inputlist;
                        sourceGridView.DataBind();
                    }
                }

                decimal subtotal = 0;
                foreach (GridViewRow row in cartGrid.Rows)
                {
                    decimal total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);
                    subtotal += total;
                    totalLabel.Text = subtotal.ToString();
                }
                //totalLabel.Text = string.Format("${0:C}", subtotal.ToString());
            }, "Success", "You have updated the cart");
        }

        protected void CheckoutLB_Command(object sender, CommandEventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                GridView sourceGridview = cartGrid as GridView;
                List<ViewCartItem> inputlist = new List<ViewCartItem>();
                List<CheckoutModel> outputlist = new List<CheckoutModel>();

                foreach (GridViewRow row in sourceGridview.Rows)
                {
                    var stockItemID = row.FindControl("StockItemIDCV") as Label;
                    var description = row.FindControl("DescriptionCV") as Label;
                    var quantityOnHand = int.Parse((row.FindControl("QuantityOnHandCV") as Label).Text);
                    var quantity = int.Parse((row.FindControl("QuantityCV") as TextBox).Text);
                    var price = decimal.Parse((row.FindControl("PriceCV") as Label).Text);
                    var total = decimal.Parse((row.FindControl("TotalCV") as Label).Text);

                    var cartgridinfo = new CheckoutModel();
                    var sid = cartgridinfo.StockItemID = int.Parse(stockItemID.Text.ToString());
                    cartgridinfo.Description = description.Text.ToString();
                    cartgridinfo.QuantityOnHand = quantityOnHand;
                    cartgridinfo.Quantity = quantity;
                    cartgridinfo.Price = price;
                    var totalAmount = cartgridinfo.Total = price * quantity;

                    outputlist.Add(cartgridinfo);
                }

                checkoutGrid.DataSource = outputlist;
                checkoutGrid.DataBind();

                decimal subtotal = 0;
                decimal tax;
                decimal totalC;
                foreach (GridViewRow row in checkoutGrid.Rows)
                {
                    decimal totalCK = decimal.Parse((row.FindControl("TotalCK") as Label).Text);
                    decimal sub = subtotal += totalCK;
                    subtotalLabel.Text = sub.ToString();

                    tax = sub * 5 / 100;
                    taxLabel.Text = Math.Round(tax, 2).ToString();

                    totalC = tax + sub;
                    totalLabelCK.Text = Math.Round(totalC, 2).ToString();
                }
            }, "Success", "Item/s added to checkout");
        }
        #endregion

        #region Checkout tab

        protected void placeOrderLB_Click(object sender, EventArgs e)
        {
            SecurityController ssysmgr = new SecurityController();
            int? employeeid = ssysmgr.GetCurrentUserEmployeeID(User.Identity.Name);
            int empid = employeeid ?? default(int);

            GridView sourceGridview = checkoutGrid as GridView;
            List<CheckoutModel> outputlist = new List<CheckoutModel>();

            foreach (GridViewRow row in sourceGridview.Rows)
            {
                var stockItemID = row.FindControl("StockItemIDCK") as Label;
                var description = row.FindControl("DescriptionCK") as Label;
                var quantityOnHand = int.Parse((row.FindControl("QuantityOnHandCK") as Label).Text);
                var quantity = int.Parse((row.FindControl("QuantityCK") as Label).Text);
                var price = decimal.Parse((row.FindControl("PriceCK") as Label).Text);
                var total = decimal.Parse((row.FindControl("TotalCK") as Label).Text);

                var cartgridinfo = new CheckoutModel();
                var sid = cartgridinfo.StockItemID = int.Parse(stockItemID.Text.ToString());
                cartgridinfo.Description = description.Text.ToString();
                cartgridinfo.QuantityOnHand = quantityOnHand;
                cartgridinfo.Quantity = quantity;
                cartgridinfo.Price = price;
                var totalAmount = cartgridinfo.Total = price * quantity;

                outputlist.Add(cartgridinfo);
            }

            List<AddCartModel> addCart = new List<AddCartModel>();
            foreach (CheckoutModel checkoutModel in outputlist)
            {
                AddCartModel addDB = new AddCartModel()
                {
                    StockItemID = checkoutModel.StockItemID,
                    Quantity = checkoutModel.Quantity,
                    SellingPrice = checkoutModel.Price
                };

                addCart.Add(addDB);
            }

            string paymentType = paymentTypeCK.SelectedValue;
            decimal subtotal = decimal.Parse(subtotalLabel.Text);
            decimal tax = decimal.Parse(taxLabel.Text);
            int couponid = int.Parse(couponDDL.SelectedValue);

            CheckoutController sysmgr = new CheckoutController();
            MessageUserControl.TryRun(() =>
            {
                if (paymentType == null)
                {
                    throw new Exception("You must select a payment type");
                }
                else
                {
                    int id = sysmgr.Return_SalesID(paymentType, empid, tax, subtotal, couponid, addCart);
                }
            }, "Success", "You successfully purchase an item");
        }

        protected void couponDDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion


        #region For General Control / Nav Buttons Control

        protected void Cancel_Click(object sender, EventArgs e)
        {
            // SHOPPING VIEW
            CategoryDDL.SelectedIndex = 0;
            //StockItemLV.Visible = false;
            categoryCount.Value = "";
            StockItemGV.DataSource = null;
            StockItemGV.DataBind();

            // VIEW CART TAB
            cartGrid.DataSource = null;
            cartGrid.DataBind();
            totalLabel.Text = "";

            // CHECKOUT TAB
            checkoutGrid.DataSource = null;
            checkoutGrid.DataBind();
            subtotalLabel.Text = "";
            totalLabelCK.Text = "";
            taxLabel.Text = "";
            couponDDL.SelectedIndex = 0;
            paymentTypeCK.ClearSelection();

        }

        public void refresh_shoppingCart()
        {

        }
        protected void Cart_Click(object sender, EventArgs e)
        {
            refresh_shoppingCart();
        }

        #endregion
    }
}