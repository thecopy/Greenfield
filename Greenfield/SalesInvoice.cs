using System;

namespace Greenfield
{
    public class SalesInvoice : IInvoice
    {
        public string Id { get; set; }
        public IOrder Order { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Expires { get; set; }
        public decimal Interest { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedDate { get; set; }
    }
}
