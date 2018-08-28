using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Data.Entity;
using HR_module.Models;
using HR_module.Models.Contexts;
using Ninject.Modules;
using HR_module.Util;
using Ninject;
using Ninject.Web.Mvc;
using Ninject.Web.Common;


namespace HR_module
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Context db = new Context();
            db.Database.Initialize(true);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            NinjectModule registrations = new NinjectRegistrations();
            var kernel = new StandardKernel(registrations);
            var ninjectResolver = new NinjectDependencyResolver(kernel);
            //GlobalConfiguration.Configuration.DependencyResolver = 
            //    (System.Web.Http.Dependencies.IDependencyResolver)new NinjectDependencyResolver(kernel);

            DependencyResolver.SetResolver(ninjectResolver);
            
        }
    }
}
