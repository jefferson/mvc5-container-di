using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Container
{
    public class ControllerFactory: DefaultControllerFactory
    {
        private readonly IContainer container;

        public ControllerFactory(IContainer _container)
        {
            this.container = _container;
        }

        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            return this.container.Resolve(controllerType) as Controller;
        }
        
    }
}
