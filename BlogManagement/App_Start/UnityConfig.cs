using BlogManagement.PostServices;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace BlogManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();            
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            container.RegisterType<IPostService, PostService>();
        }
    }
}