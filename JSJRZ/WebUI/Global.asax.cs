using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using MXKJ.DBMiddleWareLib;
using MXKJ.JSJRZ.WebUI.App_Start;

namespace WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            BasicDBClass.DataSource = System.Web.Configuration.WebConfigurationManager.AppSettings["DataSource"];
            BasicDBClass.DBName = System.Web.Configuration.WebConfigurationManager.AppSettings["DBName"];
            BasicDBClass.Port = int.Parse( System.Web.Configuration.WebConfigurationManager.AppSettings["Port"] );
            BasicDBClass.UserID = System.Web.Configuration.WebConfigurationManager.AppSettings["UserID"];
            BasicDBClass.Password = System.Web.Configuration.WebConfigurationManager.AppSettings["Password"];
        }
    }
}
