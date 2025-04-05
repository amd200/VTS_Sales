using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Books.ViewModels
{
    public class SignUpViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "اسم المستخدم مطلوب")]
        [StringLength(255)]
        [Index(IsUnique = true)]
        public string UserName { get; set; } 

        [Required(ErrorMessage = "كلمة المرور مطلوبة")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "كلمة المرور يجب أن تكون بين 6 و 100 حرف")]
        public string Password { get; set; } 

        [Required(ErrorMessage = "تأكيد كلمة المرور مطلوب")]
        [Compare("Password", ErrorMessage = "كلمة المرور والتأكيد لا يتطابقان")]
        public string ConfirmPassword { get; set; }

        public string SesstionId { get; set; }

    }
}