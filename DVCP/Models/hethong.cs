using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace DVCP.Models
{
    [Table("binhdinh_csdltnmt_systemgroup")]
    public class systemgroup
    {
        [Key]
        [DisplayName("ID")]
        public int GroupId { get; set; }

        [DisplayName("Tên nhóm")]
        public string GroupName { get; set; }

        [DisplayName("Miêu tả")]
        public string GroupDesc { get; set; }
    }
    [Table("binhdinh_csdltnmt_systemuser")]
    public class systemuser
    {
        [Key]
        [DisplayName("ID")]
        public int UserId { get; set; }

        [Required]
        [DisplayName("Tên đăng nhập")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Tài khoản email")]
        [EmailAddress]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu đăng nhập")]
        public string PassWord { get; set; }

        [DisplayName("Tên người dùng")]
        public string FullName { get; set; }

        [DisplayName("Điện thoại")]
        public string UserPhone { get; set; }

        [DisplayName("Địa chỉ")]
        public string UserAdd { get; set; }

        [DisplayName("Giới tính")]
        public int UserGender { get; set; }

        [DisplayName("Nhóm")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual systemgroup systemgroup { get; set; }

        [DisplayName("Ngày tạo")]
        public DateTime? RegDate { get; set; }

        [Display(Name = "Kích hoạt")]
        public bool IsActive { get; set; }

        [DisplayName("Mã xác nhận")]
        public string Confirmcode { get; set; }

        [DisplayName("Ngày xác nhận")]
        public DateTime? Confirmdate { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string ImagePath { get; set; }

        [DisplayName("Ảnh đại diện")]
        public byte[] Avatar { get; set; }

        [DisplayName("Miêu tả")]
        public string Description { get; set; }
    }
    [Table("binhdinh_csdltnmt_systemlogin")]
    public class systemlogin
    {
        [Key]
        [DisplayName("ID")]
        public int LoginId { get; set; }

        [DisplayName("Người đăng nhập")]
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual systemuser systemuser { get; set; }

        [DisplayName("Thời điểm")]
        public DateTime? LoginTime { get; set; }

        [DisplayName("Kết thúc")]
        public DateTime? LogoutTime { get; set; }

        [DisplayName("Thời gian(s)")]
        public int SecondTime { get; set; }

        [DisplayName("Client IP")]
        public string ClientIp { get; set; }

        [DisplayName("Miêu tả")]
        public string Description { get; set; }
    }
    [Table("binhdinh_csdltnmt_mapapikey")]
    public class mapapikey
    {
        [Key]
        [DisplayName("ID")]
        public int KeyId { get; set; }

        [DisplayName("Miêu tả")]
        public string KeyCode { get; set; }

        [Display(Name = "Lựa chọn")]
        public bool Active { get; set; }

        [DisplayName("Ghi chú")]
        public string Ghichu { get; set; }
    }
    [Table("binhdinh_csdltnmt_systemmiss")]
    public class systemmiss
    {
        [Key]
        [DisplayName("ID")]
        public int MissId { get; set; }

        [DisplayName("User Id")]
        public int UserId { get; set; }

        [DisplayName("Map Code")]
        public int MapCode { get; set; }

        [DisplayName("Map Edit")]
        public int MapEdit { get; set; }
    }
    [Table("binhdinh_csdltnmt_systemmap")]
    public class systemmap
    {
        [Key]
        [DisplayName("ID")]
        public int MapId { get; set; }

        [Required]
        [DisplayName("Nhóm")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual systemgroup systemgroup { get; set; }

        [Required]
        [DisplayName("Key Code")]
        public int MapCode { get; set; }

        [DisplayName("Link Url")]
        public string LinkUrl { get; set; }

        [DisplayName("Tên chức năng")]
        public string MapName { get; set; }

        [DisplayName("Mức cấp quyền")]
        public int MapEdit { get; set; }

        [DisplayName("Tùy chọn")]
        public bool MapOpt { get; set; }

        [DisplayName("Mã cha")]
        public int ParentCode { get; set; }

        [DisplayName("Mức con")]
        public int LevelGroup { get; set; }

        [DisplayName("Ghi chú")]
        public string Description { get; set; }
    }
    [Table("binhdinh_csdltnmt_systemview")]
    public class systemview
    {
        [Key]
        [DisplayName("ID")]
        public int ViewId { get; set; }

        [DisplayName("Hôm nay")]
        public int HomNay { get; set; }

        [DisplayName("Hôm qua")]
        public int HomQua { get; set; }

        [DisplayName("Tuần này")]
        public int TuanNay { get; set; }

        [DisplayName("Tuần trước")]
        public int TuanTruoc { get; set; }

        [DisplayName("Tháng này")]
        public int ThangNay { get; set; }

        [DisplayName("Tháng trước")]
        public int ThangTruoc { get; set; }

        [DisplayName("Tất cả")]
        public int TatCa { get; set; }
    }

    /*======================================================*/
    /*======================================================*/
    /*======================================================*/
    public class HethongDangnhap
    {
        [Key]
        [DisplayName("ID")]
        public int UserId { get; set; }

        [Display(Name = "Tên đăng nhập")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên đăng nhập cần phải có.")]
        //[StringLength(300, MinimumLength = 4, ErrorMessage = "Mật khẩu phải hơn 3 ký tự.")]
        public string UserName { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu đăng nhập")]
        //[StringLength(100, ErrorMessage = "Mật khẩu đăng nhập phải lớn hơn 5 ký tự.", MinimumLength = 6)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mật khẩu đăng nhập cần phải có.")]
        public string PassWord { get; set; }

        public string Captcha { get; set; }

        [Display(Name = "Ghi nhớ đăng nhập?")]
        public bool RememberMe { get; set; }
    }
    public class HethongDangky
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

        [Display(Name = "Vui lòng nhập lại mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Mật khẩu xác nhận và mật khẩu không khớp")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Điện thoại")]
        public string UserPhone { get; set; }

        [DisplayName("Giới tính")]
        public int UserGender { get; set; }

        [DisplayName("Nhóm người dùng")]
        public int GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual systemgroup systemgroup { get; set; }

        [DisplayName("Ngày xác nhận")]
        public DateTime? Confirmdate { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string ImagePath { get; set; }

        [DisplayName("Ảnh đại diện")]
        public byte[] Avatar { get; set; }

        [DisplayName("Miêu tả")]
        public string Description { get; set; }
    }
    public class HethongDoimatkhau
    {
        [Key]
        [DisplayName("ID")]
        public int UserId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Mật khẩu hiện tại")]
        public string PasswordOld { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Nhập mật khẩu mới")]
        public string PasswordNew1 { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        public string PasswordNew2 { get; set; }

    }
    public class HethongQuenmatkhau
    {
        [Key]
        [Display(Name = "Tài khoản email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tài khoản email cần phải có.")]
        [DataType(DataType.EmailAddress)]
        public string UserEmail { get; set; }
    }
    public class HethongTaomatkhau
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Tài khoản email")]
        public string UserEmail { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Nhập mật khẩu mới")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string PasswordNew1 { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Xác nhận mật khẩu mới")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        public string PasswordNew2 { get; set; }

        public string Code { get; set; }
    }
    [Serializable]
    public class HethongSession
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public int GroupId { get; set; }
    }
    public class Mahoa
    {
        public static string SHA1Encode(string value)
        {
            var hash = System.Security.Cryptography.SHA1.Create();
            var encoder = new System.Text.ASCIIEncoding();
            var combined = encoder.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(combined)).ToLower().Replace("-", "");
        }
        public static string CreateMD5(string input)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            { sb.Append(hashBytes[i].ToString("X2")); }
            return sb.ToString().ToLower();
        }
        public static int SetGroupMiss(int groupid)
        {
            int count = 0;
            using (DVCPContext db = new DVCPContext())
            {
                count = db.systemmaps.Where(p => p.GroupId == groupid).Count();
                if (count == 0)
                {
                    var list = (from p in db.systemmaps
                                where (p.GroupId == 0) && (p.MapId > 0)
                                orderby p.GroupId ascending
                                select new
                                {
                                    GroupId = groupid,
                                    MapCode = p.MapCode,
                                    MapName = p.MapName,
                                    LinkUrl = p.LinkUrl,
                                    MapEdit = p.MapEdit,
                                    MapOpt = p.MapOpt,
                                    ParentCode = p.ParentCode,
                                    LevelGroup = p.LevelGroup,
                                    Description = p.Description
                                }).ToList();
                    foreach (var p in list)
                    {
                        systemmap item = new systemmap();
                        item.GroupId = p.GroupId;
                        item.MapCode = p.MapCode;
                        item.MapName = p.MapName;
                        item.LinkUrl = p.LinkUrl;
                        item.MapEdit = p.MapEdit;
                        item.MapOpt = p.MapOpt;
                        item.ParentCode = p.ParentCode;
                        item.LevelGroup = p.LevelGroup;
                        item.Description = p.Description;
                        db.systemmaps.Add(item);
                    }
                    db.SaveChanges();
                }
            }
            return count;
        }

    }

    /**===*/
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string EmailID { get; set; }

        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Chưa nhập mật khẩu mới", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu cần tối thiểu 6 ký tự")]
        public string NewPassword { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }

        //public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
    public class ResetPasswordModel
    {
        [Display(Name = "Mật khẩu mới")]
        [Required(ErrorMessage = "Chưa nhập mật khẩu mới", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu cần tối thiểu 6 ký tự")]
        public string NewPassword { get; set; }

        [Display(Name = "Xác nhận mật khẩu")]
        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Mật khẩu mới và mật khẩu xác nhận không khớp")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string ResetCode { get; set; }
    }

    [Table("User")]
    public partial class User1
    {
        public int UserID { get; set; }
        public string FullName { get; set; }
        public string EmailID { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string Password { get; set; }
        public bool IsEmailVerified { get; set; }
        public System.Guid ActivationCode { get; set; }
        public string ResetPasswordCode { get; set; }
        public string UserPhone { get; set; }
        public DateTime? Confirmdate { get; set; }
        public string ImagePath { get; set; }
        public byte[] Avatar { get; set; }
        public string Description { get; set; }
        public bool UserGender { get; set; }
        public int? GroupId { get; set; }
        public string userrole { get; set; }
        public bool status { get; set; }
    }

    public class UserLogin
    {
        [Display(Name = "Email")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email không được để trống")]
        public string EmailID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password không được để trống")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lưu tài khoản")]
        public bool RememberMe { get; set; }
    }

    public class UserDetail
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
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Điện thoại")]
        public string UserPhone { get; set; }

        [DisplayName("Giới tính")]
        public bool UserGender { get; set; }

        [DisplayName("Ảnh đại diện")]
        public string ImagePath { get; set; }

        [DisplayName("Ảnh đại diện")]
        public byte[] Avatar { get; set; }

        [DisplayName("Nhóm người dùng")]
        public int? GroupId { get; set; }
        [ForeignKey("GroupId")]
        public virtual systemgroup systemgroup { get; set; }

        [DisplayName("Miêu tả")]
        public string Description { get; set; }

        [DisplayName("Trang thái")]
        public bool status { get; set; }
    }
}