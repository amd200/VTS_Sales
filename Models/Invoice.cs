using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }

        public decimal InvoiceDiscount { get; set; }

        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }

        public decimal TotalAmount()
        {
            return (InvoiceDetails?.Sum(d => d.Total * (1 - InvoiceDiscount / 100)) ?? 0);
        }
    }

}