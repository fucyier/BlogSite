using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.Business.DependencyResolvers.Ninject;
namespace Blog.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private readonly IKernel _kernel;
        public NinjectControllerFactory()
        {
            _kernel = new StandardKernel(new ResolveModule());
        }
        public IKernel Kernel
        {
            get { return _kernel; }
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)_kernel.Get(controllerType);
        }
    }
}