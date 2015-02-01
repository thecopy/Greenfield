using System;
using Microsoft.Owin.Hosting;
using Owin;

namespace Greenfield.Web
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Greenfield Server");

            const string url = "http://+:27015";

            using (WebApp.Start<Startup>(url))
            {
                Console.WriteLine("Running on {0}", url);
                Console.WriteLine("Loaded Modules:");
                Console.WriteLine("Press enter to exit");
                Console.ReadLine();
            }
        }
    }

    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy(conf => conf.Bootstrapper = new NancyFxBootstrapper());
        }
    }

}
