namespace Greenfield.Web.App
{
    using Owin;

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(c => c.Bootstrapper = new NancyFxBootstrapper());
        }
    }
}