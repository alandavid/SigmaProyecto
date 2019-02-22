using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ninja.Models.Invoice
{
    public class InvoiceDto
    {
        public long Id { get; set; }
        public string Type { get; set; }
        public List<InvoiceDetailDto> Detail { get; set; }
    }
}