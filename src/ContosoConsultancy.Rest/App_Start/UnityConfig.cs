using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace ContosoConsultancy.Rest
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<DataAccess.ContosoConsultancyDataContext>((new HierarchicalLifetimeManager()));
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}