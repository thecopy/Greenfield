using System;

namespace Greenfield
{
    public interface IInvoice
    {
        String Id { get; set; }
        IOrder Order { get; set; }
        DateTime Sent { get; set; }
        DateTime Expires { get; set; }
        Decimal Interest { get; set; }
        Boolean IsPayed { get; set; }
        DateTime? PayedDate { get; set; }
    }
}