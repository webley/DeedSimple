using System.Web.Mvc;
using DeedSimple.DataAccess;
using DeedSimple.Processor;
using Microsoft.Practices.Unity;
using Unity.Mvc5;

namespace DeedSimple
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            //container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<IPropertyProcessor, PropertyProcessor>();
            container.RegisterType<IUserProcessor, UserProcessor>();

            container.RegisterType<IPropertyRepository, PropertyRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}