using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HR_module.Models;


namespace HR_module.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository<Candidate>>().To<CandidateRepository>();
            
        }
    }
}