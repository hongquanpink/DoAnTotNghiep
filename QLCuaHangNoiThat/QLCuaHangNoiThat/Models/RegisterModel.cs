using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLCuaHangNoiThat.Models
{
    public class RegisterModel
    {
        
        public long ID { get; set; }

        [Display(Name = "Tên ")]
        [Required(ErrorMessage ="Yeu Cau Nhap Tai Khoan")]
        public string UserName { set; get; }

        [Display(Name = "Mật Khẩu")]
        [StringLength(20,MinimumLength =6,ErrorMessage ="Do dai it nhat 6 ki tu")]
        public string Password { set; get; }

        [Display(Name = "Xác Nhận ")]
        [Compare("Password",ErrorMessage ="Xac Nhan Mat Khau Dung Khong")]
        public string Confirmpassword { set; get; }

        [Display(Name = "Họ tên ")]
        [Required(ErrorMessage = "Yeu Cau Nhap Ho Ten")]
        public string Name { set; get; }

        [Display(Name = "Địa Chỉ")]
        public string Address { set; get; }

        [Display(Name = "Email")]
        public string Email { set; get; }

        [Display(Name = "Điện Thoại")]
        public string Phone { set; get; }


    }
}