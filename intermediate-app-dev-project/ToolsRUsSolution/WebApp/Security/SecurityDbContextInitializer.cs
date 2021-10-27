using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

#region Additional Namespaces
using System.Data.Entity;
using WebApp.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Configuration;
#endregion

namespace WebApp.Security
{
    public class SecurityDbContextInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            #region Seed the roles
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var startupRoles = ConfigurationManager.AppSettings["startupRoles"].Split(';');
            foreach (var role in startupRoles)
                roleManager.Create(new IdentityRole { Name = role });
            #endregion



            #region Seed the users

            //--------START OF webmaster
            string adminUser = ConfigurationManager.AppSettings["adminUserName"];
            string adminRole = ConfigurationManager.AppSettings["adminRole"];
            string adminEmail = ConfigurationManager.AppSettings["adminEmail"];
            string adminPassword = ConfigurationManager.AppSettings["adminPassword"];
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            var result = userManager.Create(new ApplicationUser
            {
                UserName = adminUser,
                Email = adminEmail
            }, adminPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(adminUser).Id, adminRole);
            //--------END OF webmaster



            // Add Employees
            string employeeUser = "DBookem";
            string employeeRole = ConfigurationManager.AppSettings["associateRole"];
            string employeeEmail = "bookem@test.ca";
            string userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            result = userManager.Create(new ApplicationUser
            {
                UserName = employeeUser,
                Email = employeeEmail,
                EmployeeId = 1
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(employeeUser).Id, employeeRole);


            employeeUser = "JKan";
            employeeRole = ConfigurationManager.AppSettings["associateRole"];
            employeeEmail = "kan@test.ca";
            userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            result = userManager.Create(new ApplicationUser
            {
                UserName = employeeUser,
                Email = employeeEmail,
                EmployeeId = 5
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(employeeUser).Id, employeeRole);

            employeeUser = "NItall";
            employeeRole = ConfigurationManager.AppSettings["associateRole"];
            employeeEmail = "test@email.ca";
            userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            result = userManager.Create(new ApplicationUser
            {
                UserName = employeeUser,
                Email = employeeEmail,
                EmployeeId = 4
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(employeeUser).Id, employeeRole);

            employeeUser = "NPointe";
            employeeRole = ConfigurationManager.AppSettings["storeManagerRole"];
            employeeEmail = "Npointe@yahoo.ca";
            userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            result = userManager.Create(new ApplicationUser
            {
                UserName = employeeUser,
                Email = employeeEmail,
                EmployeeId = 15
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(employeeUser).Id, employeeRole);

            employeeUser = "HAgonor";
            employeeRole = ConfigurationManager.AppSettings["departmentHeadRole"];
            employeeEmail = "HAgonor@yahoo.ca";
            userPassword = ConfigurationManager.AppSettings["newUserPassword"];
            result = userManager.Create(new ApplicationUser
            {
                UserName = employeeUser,
                Email = employeeEmail,
                EmployeeId = 3
            }, userPassword);
            if (result.Succeeded)
                userManager.AddToRole(userManager.FindByName(employeeUser).Id, employeeRole);



            ////------START salesreturnsRole
            //string salesreturnsUser = "SalesUser";
            //string salesreturnsRole = ConfigurationManager.AppSettings["salesreturnsRole"];
            //string salesreturnsEmail = "donna.salesreturns@yahoo.no";
            //string salesreturnsPassword = ConfigurationManager.AppSettings["newUserPassword"];
            ////var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //result = userManager.Create(new ApplicationUser
            //{
            //    UserName = salesreturnsUser,
            //    Email = salesreturnsEmail,
            //    SalesReturnsID = 1,
            //    PurchasingID = null
            //}, salesreturnsPassword);
            //if (result.Succeeded)
            //    userManager.AddToRole(userManager.FindByName(salesreturnsUser).Id, salesreturnsRole);
            ////-------END salesreturnsRole

            ////------START purchasingRole
            //string purchasingUser = "PurchasingUser";
            //string purchasingRole = ConfigurationManager.AppSettings["purchasingRole"];
            //string purchasingEmail = "hess.purchasing@yahoo.no";
            //string purchasingPassword = ConfigurationManager.AppSettings["newUserPassword"];
            ////var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            //result = userManager.Create(new ApplicationUser
            //{
            //    UserName = purchasingUser,
            //    Email = purchasingEmail,
            //    PurchasingID = 1,
            //    SalesReturnsID = null
            //}, purchasingPassword);
            //if (result.Succeeded)
            //    userManager.AddToRole(userManager.FindByName(purchasingUser).Id, purchasingRole);
            ////-------END purchasingRole




            #endregion


            base.Seed(context);
        }
    }
}