using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DVCP.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User1
    {
        public string ConfirmPassword { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User1()
        {
            Tbl_POST = new HashSet<Post>();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Post> Tbl_POST { get; set; }

        public class UserMetadata
        {
            [Key]
            [DisplayName("ID")]
            public int UserID { get; set; }

            [DisplayName("Tên người dùng")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên người dùng")]
            public string FullName { get; set; }

            [Display(Name = "Email")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tài khoản email")]
            [DataType(DataType.EmailAddress)]
            public string EmailID { get; set; }

            [Display(Name = "Ngày sinh")]
            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime DateOfBirth { get; set; }

            [Display(Name = "Mật khẩu")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mật khẩu")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "Mật khẩu cần tối thiểu 6 ký tự")]
            public string Password { get; set; }

            [Display(Name = "Nhập lại mật khẩu")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Mật khẩu không khớp")]
            public string ConfirmPassword { get; set; }

            [DisplayName("Điện thoại")]
            public string UserPhone { get; set; }

            [DisplayName("Giới tính")]
            public bool UserGender { get; set; }

            //[DisplayName("Nhóm người dùng")]
            //public int GroupId { get; set; }
            //[ForeignKey("GroupId")]
            //public virtual systemgroup systemgroup { get; set; }

            [DisplayName("Ngày xác nhận")]
            public DateTime? Confirmdate { get; set; }

            [DisplayName("Ảnh đại diện")]
            public string ImagePath { get; set; }

            [DisplayName("Ảnh đại diện")]
            public byte[] Avatar { get; set; }

            [DisplayName("Miêu tả")]
            public string Description { get; set; }

            [DisplayName("Trang thái")]
            public bool status { get; set; }
        }
    }
}