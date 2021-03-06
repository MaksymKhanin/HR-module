﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(TaskWebApplication.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(TaskWebApplication.App_Start.NinjectWebCommon), "Stop")]

namespace TaskWebApplication.App_Start
{
    using System;
    using System.Web;
    using Ninject.Web.Common.WebHost;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Mvc;
    using HR_module.Util;
    using HR_module.Models;
    using System.Web.Http;
    using Ninject.Web.Mvc;
    using Ninject.Web.WebApi;
    using HR_module.Infrastructure.Repository.DI.Abstract;
    using HR_module.Infrastructure.Repository.DI.Implementation;
    using HR_module.Models.Contexts;


    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();


        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                //kernel.Bind<OrganisationsContext>().ToSelf().InRequestScope();
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                //System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver  = new Ninject.Web.WebApi.

                RegisterServices(kernel);
                //GlobalConfiguration.Configuration.DependencyResolver = new Ninject.Web.WebApi.NinjectDependencyResolver(kernel);
                return kernel;

            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new Util.NinjectDependencyResolver(kernel));

            kernel.Bind<ICandidatesRepository<Candidate>>().To<CandidateRepository>();
            //kernel.Bind<IRepository<Organisation>>().To<OrganisationRepository>();
            //kernel.Bind<IRepository<Bill>>().To<BillRepository>();
            //kernel.Bind<IRepository<Operation>>().To<OperationRepository>();
        }
    }
}