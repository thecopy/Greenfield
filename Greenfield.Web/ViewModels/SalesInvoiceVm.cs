using System;

namespace Greenfield.Web.Api.ViewModels
{
    public class SalesInvoiceVm
    {
        public string Id { get; set; }
        public OrderVm Order { get; set; }
        public DateTime Sent { get; set; }
        public DateTime Expires { get; set; }
        public decimal Interest { get; set; }
        public bool IsPayed { get; set; }
        public DateTime? PayedDate { get; set; }
    }
}
