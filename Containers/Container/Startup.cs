using Container;
using Containers.Controllers;
using Containers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Containers.Container
{
    public static class Startup
    {
        public static void Configure(IContainer container)
        {

            #region register controllers
            //container.Register<HomeController, HomeController>(LifeCycle.Transient);
            #endregion

            container.Register<ITestTag, TestTag>();

        }
    }
}