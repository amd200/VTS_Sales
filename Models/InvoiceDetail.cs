using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class InvoiceDetail
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }  
        public virtual Invoice Invoice { get; set; }

        public int ProductId { get; set; }
        public Product Prdoduct { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public decimal Total => Quantity * Price ;
    }

}