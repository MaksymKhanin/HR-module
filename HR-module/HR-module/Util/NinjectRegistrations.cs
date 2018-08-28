using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_module.Models;
using HR_module.Infrastructure.Repository.DI.Abstract;
using HR_module.Infrastructure.Repository.DI.Implementation;
using HR_module.Models.Contexts;


namespace HR_module.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<ICandidatesRepository<Candidate>>().To<CandidateRepository>();
            
        }
    }
}