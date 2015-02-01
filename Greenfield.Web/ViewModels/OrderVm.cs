using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Connection;

namespace Greenfield.Web.Api.ViewModels
{
    public class OrderVm
    {
        public String Id { get; set; }
        public IList<OrderRowVm> Rows { get; set; }
        public bool IsNew { get; set; }

        public decimal TotalPrice
        {
            get { return Rows.Sum(r => r.Price*r.Quantity); }
        }
        public decimal TotalRows
        {
            get { return Rows.Count; }
        }
    }
}
