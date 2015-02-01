using Nancy;

namespace Greenfield.Web.Api
{
    public class GreenfieldWebModule : NancyModule
    {
        public GreenfieldWebModule(string baseUrl = "") : base("/api/" + baseUrl)
        {
            // =)
        }
    }
}
