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
    public class InvoiceDetailFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "المنتج مطلوب")]
        [Display(Name = "المنتج")]
        public int ProductId { get; set; }

        public IEnumerable<SelectListItem> Products { get; set; }

        [Required]
        [Display(Name = "السعر")]
        public decimal Price { get; set; }

        [Required]
        [Display(Name = "الكمية")]
        public int Quantity { get; set; }

        [Display(Name = "الإجمالي")]
        public decimal Total
        {
            get
            {
                return Price * Quantity;
            }
        }
    }
}