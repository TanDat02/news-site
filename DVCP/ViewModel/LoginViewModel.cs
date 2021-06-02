using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVCP.ViewModel
{
    public class LoginViewModel
    {

        [MaxLength(20)]
        [Required(ErrorMessage = "Vui lòng nhập tài khoản")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [MaxLength(20)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}