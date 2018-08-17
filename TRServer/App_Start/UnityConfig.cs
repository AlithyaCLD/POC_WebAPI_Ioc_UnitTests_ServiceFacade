using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TRDataLayer.Interfaces.Repositories;
using Unity;
using Unity.Lifetime;
using TRDataLayer.Implementations.Repositories;

namespace TRServer
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IDropdownRepository, DropdownRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);
        }
    }
}