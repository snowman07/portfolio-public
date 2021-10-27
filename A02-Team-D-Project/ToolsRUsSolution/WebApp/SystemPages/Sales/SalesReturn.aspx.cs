using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additonal Namespaces
using ToolsRUsSystem.BLL;
using ToolsRUsSystem.ViewModels;
using System.Configuration;
using WebApp.Security;
using ToolsRUsSystem.BLL.SharedControllers;
#endregion

namespace WebApp.SystemPages.Sales
{
    public partial class SalesReturn : System.Web.UI.Page
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
    }
}