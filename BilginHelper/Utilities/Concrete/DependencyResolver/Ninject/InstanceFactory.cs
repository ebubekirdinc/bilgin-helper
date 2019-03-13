using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace BilginHelper.Utilities.Concrete.DependencyResolver.Ninject
{
    public class InstanceFactory
    {
        public static T GetInstance<T, Module>() where Module : NinjectModule, new()
        {
            var kernel = new StandardKernel(new Module());
            return kernel.Get<T>();
        }
    }
}
