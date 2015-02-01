using Nancy;

namespace Greenfield.Web
{
    public class GreenfieldUiModule : NancyModule
    {
        public GreenfieldUiModule(string baseUrl = "") : base("/ui/" + baseUrl)
        {
            
        }
    }
}
