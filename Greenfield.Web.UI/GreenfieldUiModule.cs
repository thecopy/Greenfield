using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace Greenfield.Web.UI
{
    public class GreenfieldUiModule : NancyModule
    {
        public GreenfieldUiModule(string baseUrl = "") : base("/ui/" + baseUrl)
        {
            
        }
    }
}
