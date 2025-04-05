using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public class Category
    {
        public int Id { get; set; } 

        [Required(ErrorMessage = "اسم الفئة مطلوب")]
        [MaxLength(128, ErrorMessage = "الحد الأقصى للاسم 128 حرفًا")]
        public string Name { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}