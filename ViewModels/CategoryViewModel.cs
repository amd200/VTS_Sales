using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Books.ViewModels
{
	public class CategoryViewModel
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم الفئة مطلوب")]
        [MaxLength(128, ErrorMessage = "الحد الأقصى للاسم 128 حرفًا")]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}