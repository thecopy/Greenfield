namespace Greenfield.Web
{
    public class HomeModule : GreenfieldUiModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Home.cshtml"];
        }
    }
}
