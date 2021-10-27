using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ToolsRUsSystem.ViewModels;
using System.Configuration;
using WebApp.Security;
using ToolsRUsSystem.BLL.SharedControllers;
using ToolsRUsSystem.BLL.Receiving;
#endregion

namespace WebApp.SystemPages.Receiving
{
    public partial class Receiving : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //security code for forms security
            //check to see if the user is logged on
            if (Request.IsAuthenticated)
            {
                //logged in BUT do you have authority to be on this page
                if (User.IsInRole(ConfigurationManager.AppSettings["associateRole"]) || User.IsInRole(ConfigurationManager.AppSettings["departmentHeadRole"]))
                {

                    SecurityController ssysmgr = new SecurityController();

                    int? employeeid = ssysmgr.GetCurrentUserEmployeeID(User.Identity.Name);

                    int empid = employeeid ?? default(int);

                    CommonEmployeeController sysmgr = new CommonEmployeeController();
                    string employeeName = sysmgr.GetEmployeeName(empid);
                    LoggedUser.Text = employeeName;
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

        protected void SelectOrderCommand(object sender, CommandEventArgs e)
        {
            RecieveListView.Visible = true;
            ReceiveButton.Visible = true;
            CloseButton.Visible = true;
            ReasonLabel.Visible = true;
            ReasonTextBox.Visible = true;

            MessageUserControl.TryRun(() =>
            {
                ReceivingController recmgr = new ReceivingController();
                List<ReceivingList> ReceivingList1 = new List<ReceivingList>();
                int x = int.Parse((e.CommandArgument).ToString());
                ReceivingList1 = recmgr.PODetail(x);
                RecieveListView.DataSource = ReceivingList1;
                RecieveListView.DataBind();

                HiddenField1.Value = (x).ToString();
                UnOrderedItemsListView.Visible = true;
            }, "Successful", "P.O. selected.");
        }

        protected void ReceiveButtonClick(object sender, EventArgs e)
        {
            MessageUserControl.TryRun(() =>
            {
                List<ReceivingList> ReceivingList1 = new List<ReceivingList>();
                int PurchaseOrderID = int.Parse(HiddenField1.Value);

                int qtyLeft = 0;
                int receiveConfirm = 0;

                foreach (var item in RecieveListView.Items)
                {
                    HiddenField PurchaseOrderDetailHiddenLabel = item.FindControl("PurchaseOrderDetailLabel") as HiddenField;
                    Label sid = item.FindControl("SIDLabel") as Label;
                    Label outstand = item.FindControl("OutstandingLabel") as Label;
                    TextBox ReceiveText = item.FindControl("ReceiveTextBox") as TextBox;
                    TextBox ReturnText = item.FindControl("ReturnTextBox") as TextBox;
                    TextBox ReasonText = item.FindControl("ReasonTextBox") as TextBox;
                    
                    int intOutstand = int.Parse(outstand.Text);
                    ReceivingList ReceivingList2 = new ReceivingList
                    {
                        PurchaseOrderDetail = int.Parse(PurchaseOrderDetailHiddenLabel.Value),
                        SID = int.Parse(sid.Text),
                        Outstanding = int.Parse(outstand.Text),
                        Receive = int.Parse(ReceiveText.Text),
                        Return = int.Parse(ReturnText.Text),
                        Reason = ReasonText.Text
                    };

                    qtyLeft += (ReceivingList2.Outstanding - ReceivingList2.Receive).GetValueOrDefault();
                    receiveConfirm += (ReceivingList2.Receive + ReceivingList2.Return).GetValueOrDefault();

                    if (ReceivingList2.Receive > intOutstand)
                    {
                        throw new Exception("Outstanding quantity cannot be greater than received quantity.");
                    }
                    else if (ReceivingList2.Return != 0)
                    {
                        if (ReceivingList2.Reason == "")
                        {
                            throw new Exception("Reason cannot be empty");
                        }
                        else
                        {
                            ReceivingList1.Add(ReceivingList2);
                        }
                    }
                }
                if (receiveConfirm == 0)
                {
                    throw new Exception("Nothing received.");
                }
                bool checkOutstanding = false;
                if (qtyLeft == 0)
                {
                    checkOutstanding = true;
                }
                ReceivingController recmgr = new ReceivingController();
                recmgr.ReceiveReturnReasonTransaction(checkOutstanding, PurchaseOrderID, ReceivingList1);
                MessageUserControl.ShowInfo("Successful", "Order Received");
                OutstandingOrdersListView.DataBind();
                HidePanels();
            });
        }

        protected void CloseButtonClick(object sender, EventArgs e)
        {
            string reason = ReasonTextBox.Text;
            if (reason == "")
            {
                MessageUserControl.ShowInfo("Error", "Reason cannot be empty. Please provide a reason.");
            }
            else
            {
                MessageUserControl.TryRun(() =>
                {
                    int PurchaseOrderID = int.Parse(HiddenField1.Value);
                    ReceivingController sysmgr = new ReceivingController();
                    sysmgr.ForceCloseOrder(PurchaseOrderID, reason);
                    OutstandingOrdersListView.DataBind();
                    HidePanels();

                }, "Successful", "Purchase Order closed.");
            }
        }

        private void HidePanels()
        {
            RecieveListView.Visible = false;
            ReceiveButton.Visible = false;
            UnOrderedItemsListView.Visible = false;
            CloseButton.Visible = false;
            ReasonLabel.Visible = false;
            ReasonTextBox.Visible = false;
        }

        protected void CheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }
    }
}