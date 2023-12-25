using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QLCuaHangNoiThat.Areas.Admin.Model
{
    public class LoginModel
    {
        [Required(ErrorMessage="Moi ban nhap Username")]
        public string UserName { set; get; }

        [Required(ErrorMessage ="Moi ban nhap Password")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}