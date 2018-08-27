using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Http.Dependencies;
using HR_module.Models;
using HR_module.Util;


namespace TaskWebApplication.Util
{
    public class NinjectDependencyResolver : NinjectScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
            : base(kernelParam)
        {
            kernel = kernelParam;     
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectScope(kernel.BeginBlock());
        }


        
    }
}