using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace Greenfield.Web.UI
{
    public class HomeModule : GreenfieldUiModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Home.cshtml"];
        }
    }
}
