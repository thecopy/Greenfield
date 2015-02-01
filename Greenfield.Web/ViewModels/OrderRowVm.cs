using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenfield.Web.Api.ViewModels
{
    public class OrderRowVm
    {
        public String ArticleId { get; set; }
        public String ArticleDescription { get; set; }
        public String Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
