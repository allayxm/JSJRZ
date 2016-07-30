using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
//using System.Web.Optimization;
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
            //BundleConfig.RegisterBundles(BundleTable.Bundles);

            BasicDBClass.DataSource = "localhost";
            BasicDBClass.DBName = "td_oa";
            BasicDBClass.Port = 3305;
            BasicDBClass.UserID = "root";
            BasicDBClass.Password = "myoa888";
        }
    }
}
