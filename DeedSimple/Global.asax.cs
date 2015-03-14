using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DeedSimple.DataAccess;
using DeedSimple.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeedSimple
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DeedSimpleContext>());
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());

            Database.SetInitializer(new DeedSimpleDatabaseInitializer());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());

            //Database.SetInitializer(new DropCreateDatabaseAlways<DeedSimpleContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<ApplicationDbContext>());
            
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("Buyer"))
            {
                var role = new IdentityRole { Name = "Buyer" };
                roleManager.Create(role);
            }

            if (!roleManager.RoleExists("Seller"))
            {
                var role = new IdentityRole { Name = "Seller" };
                roleManager.Create(role);
            }
            
            AreaRegistration.RegisterAllAreas();
            UnityConfig.RegisterComponents();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
