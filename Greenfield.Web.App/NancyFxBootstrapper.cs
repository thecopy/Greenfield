using Greenfield.Web.Api;
using Nancy;
using Nancy.Bootstrappers.Ninject;
using Ninject;

namespace Greenfield.Web
{
    public class NancyFxBootstrapper : NinjectNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(IKernel existingContainer)
        {
            GreenfieldBootstrapper.SetupAutoMapping();
            GreenfieldBootstrapper.SetupNinjectGlobalScope(existingContainer);
        }
        
        protected override void ConfigureRequestContainer(IKernel container, NancyContext context)
        {
            GreenfieldBootstrapper.SetupNinjectRequestScope(container);
        }
    }
}
