using System;

namespace Greenfield
{
    public class OrderRow
    {
        public Article Article { get; set; }
        public String Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}