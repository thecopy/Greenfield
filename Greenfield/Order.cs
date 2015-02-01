using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenfield
{
    public class Order : IOrder
    {
        public String Id { get; set; }
        public IList<OrderRow> Rows { get; set; }

        public decimal TotalPrice
        {
            get { return Rows.Sum(r => r.Price*r.Quantity); }
        }
        public decimal TotalRows
        {
            get { return Rows.Count; }
        }

        public Order()
        {
            Rows = new List<OrderRow>();
        }
    }
}
