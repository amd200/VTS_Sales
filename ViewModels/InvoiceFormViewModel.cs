using Books.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Books.ViewModels
{
    public class InvoiceFormViewModel
{
    public int InvoiceId { get; set; }

    [Display(Name = "تاريخ الفاتورة")]
    [Required(ErrorMessage = "من فضلك اختر تاريخ الفاتورة")]
    public DateTime InvoiceDate { get; set; }

    [Display(Name = "العميل")]
    [Required(ErrorMessage = "من فضلك اختر العميل")]
    public int CustomerId { get; set; }

    public IEnumerable<SelectListItem> Customers { get; set; }

    [Display(Name = "الخصم")]
    [Range(0, 100, ErrorMessage = "الخصم يجب أن يكون بين 0 و 100")]
    public decimal InvoiceDiscount { get; set; }

        public List<InvoiceDetailFormViewModel> InvoiceDetails { get; set; } = new List<InvoiceDetailFormViewModel>();
        public IEnumerable<Product> Products { get; set; }
        public decimal TotalAmount
    {
        get
        {
            return InvoiceDetails?.Sum(d => d.Total * (1 - InvoiceDiscount / 100)) ?? 0;
        }
    }
}

}