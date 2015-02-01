using Raven.Client;

namespace Greenfield.Web.Api
{
    public class RootModule : GreenfieldWebModule
    {
        public RootModule(IDocumentSession session)
        {
            Get["/"] = _ => "Greenfield";
        }
    }
}
