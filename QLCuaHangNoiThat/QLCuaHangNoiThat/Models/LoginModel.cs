using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLCuaHangNoiThat.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name="Ten dang nhap")]
        [Required(ErrorMessage ="Ban phai nhap tai khoan")]
        public string UserName { get; set; }

        [Display(Name ="Mat Khau")]
        [Required(ErrorMessage ="Ban phai nhap mat khau")]
        public string PassWord { get; set; }
    }
}