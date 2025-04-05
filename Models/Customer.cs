using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Books.Models
{
    public enum GenderEnum
    {
        Male = 1,
        Female = 2,
    }
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "الاسم الأول مطلوب")]
        [StringLength(50, ErrorMessage = "الحد الأقصى للاسم الأول هو 50 حرف")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "الاسم الأخير مطلوب")]
        [StringLength(50, ErrorMessage = "الحد الأقصى للاسم الأخير هو 50 حرف")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "الجنس مطلوب")]
        public GenderEnum Gender { get; set; }

        [StringLength(200, ErrorMessage = "الحد الأقصى للعناوين هو 200 حرف")]
        public string Address { get; set; }

        [Required(ErrorMessage = "البريد الإلكتروني مطلوب")]
        [EmailAddress(ErrorMessage = "البريد الإلكتروني غير صالح")]
        [StringLength(100, ErrorMessage = "الحد الأقصى للبريد الإلكتروني هو 100 حرف")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "رقم الهاتف غير صالح")]
        [StringLength(11, ErrorMessage = "الحد الأقصى لرقم الهاتف هو 11 حرف")]
        public string Phone { get; set; }
    }
}
