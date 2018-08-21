using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using HR_module.Models;
using HR_module.Util;


namespace TaskWebApplication.Util
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        //public IDependencyScope BeginScope()
        //{
        //    return new NinjectScope(kernel.BeginBlock());
        //}


        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {

            //kernel.Bind(typeof(IRepository<>)).To(typeof(repository))
            kernel.Bind<IRepository<Candidate>>().To<CandidateRepository>();
           
        }
    }
}