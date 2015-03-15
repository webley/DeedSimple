using System.Web.Mvc;
using DeedSimple.BLL.Implementation;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
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

            container.RegisterType<IPropertyProcessor, PropertyProcessor>();
            container.RegisterType<IUserProcessor, UserProcessor>();
            container.RegisterType<IImageProcessor, ImageProcessor>();

            container.RegisterType<IPropertyRepository, PropertyRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IImageRepository, ImageRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}