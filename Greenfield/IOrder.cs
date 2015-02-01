using System;
using System.Collections.Generic;

namespace Greenfield
{
    public interface IOrder
    {
        String Id { get; set; }
        IList<OrderRow> Rows { get; set; }
        decimal TotalPrice { get; }
        decimal TotalRows { get; }
    }
}