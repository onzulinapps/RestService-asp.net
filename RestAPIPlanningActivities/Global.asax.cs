using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Common;
using RestAPIPlanningActivities.Models;
using System.Data.Entity;

namespace RestAPIPlanningActivities
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            MyDbContext DbContext = new MyDbContext();
            //DbConnection conexion = DbContext.Database.Connection;
            //Database.SetInitializer<MyDbContext>(new CreateDatabaseIfNotExists<MyDbContext>());
            //quiero que el modelo cambie en caso de que exista
            /*
            if (!DbContext.Database.Exists())
            { 
                new MyDbInitializer().InitializeDatabase(DbContext);
            }
            */ 
            /*
            else
            {
                new DbInitializer().InitializeDatabase(DbContext);
            }
            */
            //conexion.Open();
        }
    }
}
