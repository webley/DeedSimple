using System.Web.Mvc;
using DeedSimple.BLL.Implementation;
using DeedSimple.BLL.Interface;
using DeedSimple.DataAccess;
using DeedSimple.DataAccess.Implementation;
using DeedSimple.DataAccess.Interface;
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
            container.RegisterType<IOfferRepository, OfferRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}