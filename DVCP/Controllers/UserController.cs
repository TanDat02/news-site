using DVCP.Models;
using DVCP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Security.Cryptography;
using System.Text;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc.Models;

using PagedList;
using System.Web.Helpers;
using System.Net.Mail;
using System.Net;

namespace DVCP.Controllers
{
    public class UserController : Controller
    {
        UnitOfWork UnitOfWork = new UnitOfWork(new DVCPContext());
        DVCPContext db = new DVCPContext();

        private static int LoginId, UserId;
        private static DateTime LoginTime;
        // GET: User
        [HttpGet]
        public ActionResult Login()
        {
            ViewBag.ReturnUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin login, systemlogin systemlogin, string ReturnUrl = "")
        {
            string message = "";

            if (ModelState.IsValid)
            {
                using (DVCPContext dc = new DVCPContext())
                {
                    var v = dc.Users.Where(a => a.EmailID == login.EmailID).FirstOrDefault();
                    if (v != null)
                    {
                        if (!v.IsEmailVerified)
                        {
                            ViewBag.Message = "Vui lòng xác minh email của bạn trước!";
                            return View();
                        }

                        if (!this.IsCaptchaValid(""))
                        {
                            ViewBag.error = "Captcha không hợp lệ!";
                            return View();
                        }

                        if (string.Compare(Crypto.Hash(login.Password), v.Password) == 0)
                        {
                            //string ip = Request.UserHostAddress;
                            //systemlogin.ClientIp = ip;
                            string clientIp = GetIPAddress();
                            systemlogin.ClientIp = clientIp;
                            
                            UserId = v.UserID;
                            LoginTime = DateTime.Now;

                            setCookie(v.EmailID, login.RememberMe, v.userrole);
                            dc.systemlogins.Add(systemlogin);
                            dc.SaveChanges();
                            LoginId = systemlogin.LoginId;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            message = "Mật khẩu không đúng!";
                        }
                    }
                    else
                    {
                        message = "Tài khoản không tồn tại!";
                    }
                }
            }
            ViewBag.Message = message;
            return View();
        }

        [HttpGet]
        public ActionResult Registration()
        {
            ViewBag.GroupId = new SelectList(db.systemgroups, "GroupId", "GroupName");
            return View();
        }
        //Registration POST action 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User1 user)
        {
            bool Status = false;
            string message = "";

            if (ModelState.IsValid)
            {
                #region //Email is already Exist 
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email đã tồn tại");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                user.IsEmailVerified = false;

                user.GroupId = 3;
                user.userrole = "user";

                #region Save to Database
                using (DVCPContext dc = new DVCPContext())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
                    message = "Đăng ký thành công. Liên kết kích hoạt tài khoản " +
                        " đã được gửi đến email của bạn: " + user.EmailID;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (DVCPContext dc = new DVCPContext())
            {
                var v = dc.Users.Where(a => a.EmailID == emailID).FirstOrDefault();
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount", string pass = "")
        {
            var verifyUrl = "/User/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("tandata02@gmail.com", "Dotnet Awesome");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "trantandat26021999@1"; // Thay thế bằng mật khẩu thực

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount" && pass =="")
            {
                subject = "Tài khoản của bạn đã được tạo thành công!";
                body = "<br/><br/>Chúng tôi rất vui được thông báo với bạn rằng tài khoản Dotnet Awesome của bạn đã" +
                    " thành công trong việc tạo ra. Vui lòng nhấp vào liên kết dưới đây để xác minh tài khoản của bạn" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "VerifyAccount")
            {
                subject = "Tài khoản của bạn đã được Admin tạo thành công!";
                body = "<br/><br/>Mật khẩu đăng nhập của bạn là:" + "<a>" + pass + "</a>" +
                    " Vui lòng nhấp vào liên kết dưới đây để xác minh tài khoản của bạn" +
                    " <br/><br/><a href='" + link + "'>" + link + "</a> ";

            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Đặt lại mật khẩu";
                body = "Hi,<br/><br/>Chúng tôi đã nhận được yêu cầu đặt lại mật khẩu tài khoản của bạn. Vui lòng nhấp vào liên kết dưới đây để đặt lại mật khẩu của bạn" +
                    "<br/><br/><a href=" + link + ">Liên kết đặt lại mật khẩu</a>";
            }


            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

        //Verify Account  
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (DVCPContext dc = new DVCPContext())
            {
                dc.Configuration.ValidateOnSaveEnabled = false; // This line I have added here to avoid 
                                                                // Confirm password does not match issue on save changes
                var v = dc.Users.Where(a => a.ActivationCode == new Guid(id)).FirstOrDefault();
                if (v != null)
                {
                    v.IsEmailVerified = true;
                    v.Confirmdate = DateTime.Now;
                    dc.SaveChanges();
                    Status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }
            ViewBag.Status = Status;
            return View();
        }

        //Part 3 - Forgot Password

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string EmailID)
        {
            // Xác minh ID Email 
            // Tạo liên kết Đặt lại mật khẩu 
            // Gửi Email
            string message = "";
            bool status = false;

            using (DVCPContext dc = new DVCPContext())
            {
                var account = dc.Users.Where(a => a.EmailID == EmailID).FirstOrDefault();
                if (account != null)
                {
                    //Send email for reset password
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.EmailID, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property 
                    //in our model class in part 1
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Liên kết đặt lại mật khẩu đã được gửi đến email của bạn.";
                }
                else
                {
                    message = "Tài khoản không được tìm thấy";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            // Xác minh liên kết đặt lại mật khẩu 
            // Tìm tài khoản được liên kết với liên kết này 
            // chuyển hướng đến trang đặt lại mật khẩu
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (DVCPContext dc = new DVCPContext())
            {
                var user = dc.Users.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
                if (user != null)
                {
                    ResetPasswordModel model = new ResetPasswordModel();
                    model.ResetCode = id;
                    return View(model);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (DVCPContext dc = new DVCPContext())
                {
                    var user = dc.Users.Where(a => a.ResetPasswordCode == model.ResetCode).FirstOrDefault();
                    if (user != null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.ResetPasswordCode = "";
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "Đã cập nhật mật khẩu mới thành công";
                    }
                }
            }
            else
            {
                message = "Một cái gì đó không hợp lệ";
            }
            ViewBag.Message = message;
            return View(model);
        }

        public ActionResult Logout()
        {
            systemlogin systemlogin = new systemlogin();
            systemlogin.LoginId = LoginId;
            systemlogin.UserId = UserId;
            systemlogin.LoginTime = LoginTime;
            systemlogin.LogoutTime = DateTime.Now;
            systemlogin.ClientIp = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(0).ToString();
            db.Entry(systemlogin).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }
        [Authorize(Roles = "admin")]
        public ActionResult UserManager()
        {
            List<User1> lstUser = UnitOfWork.userRepository.AllUsers().ToList();
            return View(lstUser);
        }
        public void setCookie(string username, bool rememberme = false, string role = "normal")
        {
            var authTicket = new FormsAuthenticationTicket(
                               1,
                               username,
                               DateTime.Now,
                               DateTime.Now.AddMinutes(120),
                               rememberme,
                               role
                               );

            string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            Response.Cookies.Add(authCookie);
        }

        [Authorize(Roles = "admin")]
        public ActionResult createUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult createUser([Bind(Exclude = "IsEmailVerified,ActivationCode")] User1 user)
        {
            bool Status = false;
            string message = "";
            
            if (ModelState.IsValid)
            {
                #region //Email is already Exist 
                var isExist = IsEmailExist(user.EmailID);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email đã tồn tại");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid();
                #endregion

                string pass = user.Password;

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                user.ConfirmPassword = Crypto.Hash(user.ConfirmPassword); //
                #endregion
                user.IsEmailVerified = false;

                user.GroupId = user.GroupId;
                user.status = true;
                user.userrole = "editor";

                #region Save to Database
                using (DVCPContext dc = new DVCPContext())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString(), "VerifyAccount", pass);
                    message = "Tạo tài khoản thành công. Liên kết kích hoạt tài khoản " +
                        " đã được gửi đến email: " + user.EmailID;
                    Status = true;
                }
                #endregion
            }
            else
            {
                message = "Invalid Request";
            }

            ViewBag.Message = message;
            ViewBag.Status = Status;
            return View(user);
        }

        [Authorize]
        public ActionResult ChangePass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePass(changepassViewModel model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                using (DVCPContext dc = new DVCPContext())
                {
                    var oldpassword = Crypto.Hash(model.oldpassword);
                    var password = Crypto.Hash(model.password);

                    var user = dc.Users.Where(a => a.UserID.Equals(UserId) && a.Password.Equals(oldpassword)).FirstOrDefault();
                    if (user != null)
                    {
                        var user1 = dc.Users.Where(a => a.UserID.Equals(UserId) && a.Password.Equals(password)).FirstOrDefault();
                        if (user1 != null)
                        {
                            message = "Mật khẩu mới không được trùng mật khẩu cũ!";
                        }
                        else
                        {
                            user.Password = password;
                            user.ResetPasswordCode = "";
                            dc.Configuration.ValidateOnSaveEnabled = false;
                            dc.SaveChanges();
                            message = "Đã cập nhật mật khẩu mới thành công";
                        }
                    }
                    else
                    {
                        message = "Mật khẩu cũ không đúng!";
                    }
                }
            }
            else
            {
                message = "Một cái gì đó không hợp lệ:";
            }
            ViewBag.Message = message;
            return View();
        }

        [Authorize(Roles = "admin")]
        public JsonResult changeStatus(int userid, bool state = true)
        {
            string prefix = state ? "Đã bỏ cấm" : "Đã cấm";
            User1 u = UnitOfWork.userRepository.FindByID(userid);
            if (u.EmailID != "admin")
            {
                u.status = state;
                UnitOfWork.Commit();
                return Json(new { Message = prefix + " \"" + u.EmailID + "\"" }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Message = "Không được cấm admin" }, JsonRequestBehavior.AllowGet);
        }

        //[Authorize(Roles = "admin")]
        //public ActionResult Details()
        //{
        //    List<User1> lstUser = UnitOfWork.userRepository.AllUsers().ToList();
        //    return View(lstUser);
        //}

        // GET: Admin/systemusers/Details/5
        public ActionResult Details()
        {
            var databyid = db.Users.Single(x => x.UserID == UserId);
            return View(databyid);
        }

        [Authorize(Roles = "admin")]
        public ActionResult Home(string sortorder, string currentfilter, string searchstring, int? page, int? pagesize, int? userid)
        {
            if (searchstring != null)
            {
                page = 1;
            }
            else
            {
                searchstring = currentfilter;
            }
            ViewBag.CurrentFilter = searchstring;

            List<User1> lstUser = UnitOfWork.userRepository.AllUsers().ToList();
            return View(lstUser);

            if (!String.IsNullOrEmpty(searchstring))
            {
                lstUser = (List<User1>)lstUser.Where(s => s.UserID.ToString().Contains(searchstring));
            }

            if (userid != null && userid > 0)
            {
                lstUser = (List<User1>)lstUser.Where(s => s.UserID == userid);
            }


            lstUser = (List<User1>)lstUser.OrderBy(s => s.UserID);
            ViewBag.RowsCount = lstUser.Count();

            int? pageSize = 10;
            int pageNumber = (page ?? 1);
            if (pagesize != null) { pageSize = pagesize; }
            ViewBag.PageSize = pageSize;
            return View(lstUser.ToPagedList(pageNumber, (int)pageSize));

        }

        public ActionResult Create()
        {
            List<User1> lstUser = UnitOfWork.userRepository.AllUsers().ToList();
            return View();
        }

        // POST: SoMucKe/Create
        [HttpPost]
        public ActionResult Create(userListViewModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    User user = UnitOfWork.userRepository.FindByUsername(model.username);
            //    if (user == null)
            //    {
            //        User nuser = new User
            //        {
            //            username = model.username,
            //            fullname = model.fullname,
            //            status = true,
            //            userrole = "editor",
            //            password = CommonData.CommonFunction.CalculateMD5Hash(model.password)
            //        };
            //        UnitOfWork.userRepository.Add(nuser);
            //        UnitOfWork.Commit();
            //        return RedirectToAction("UserManager");
            //    }
            //    else
            //    {
            //        ViewBag.anno = "Thêm người dùng thất bại";
            //        return View();
            //    }
            //}
            return View();

        }

        // GET: Admin/systemgroup
        public ActionResult nhomnguoidung()
        {
            var list = from p in db.systemgroups
                       where p.GroupId > 0
                       select p;
            return View(list);
        }

        // GET: Admin/systemgroup/Details/5
        public ActionResult nhomchitiet(int id)
        {
            var databyid = db.systemgroups.Single(x => x.GroupId == id);
            return View(databyid);
        }

        // GET: Admin/systemgroup/Create
        public ActionResult nhomtaomoi()
        {
            return View();
        }

        // POST: Admin/systemgroup/Create
        [HttpPost]
        public ActionResult nhomtaomoi(systemgroup collection)
        {
            try
            {
                db.systemgroups.Add(collection);
                db.SaveChanges();
                return RedirectToAction("nhomnguoidung");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/systemgroup/Edit/5
        public ActionResult nhomcapnhat(int id)
        {
            var databyid = db.systemgroups.Single(x => x.GroupId == id);
            return View(databyid);
        }

        // POST: Admin/systemgroup/Edit/5
        [HttpPost]
        public ActionResult nhomcapnhat(int id, systemgroup collection)
        {
            try
            {
                db.Entry(collection).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("nhomnguoidung");
            }
            catch
            {
                return View(collection);
            }
        }

        // GET: Admin/systemgroup/Delete/5
        public ActionResult nhomxoa(int id)
        {
            var databyid = db.systemgroups.Single(x => x.GroupId == id);
            return View(databyid);
        }

        // POST: Admin/systemgroup/Delete/5
        [HttpPost]
        public ActionResult nhomxoa(int id, systemgroup collection)
        {
            try
            {
                var data = db.systemgroups.Single(x => x.GroupId == id);
                db.systemgroups.Remove(data);
                db.SaveChanges();
                return RedirectToAction("nhomnguoidung");
            }
            catch
            {
                return View(collection);
            }
        }

        [HttpGet]
        public ActionResult quanLyTaiKhoan()
        {
            var list = from p in db.Users
                       where p.UserID > 0
                       select p;
            return View(list);
        }

        // GET: Admin/systemusers/Details/5
        public ActionResult chiTietTaiKhoan(int id)
        {
            var databyid = db.Users.Single(x => x.UserID == id);
            ViewBag.GroupID = new SelectList(db.systemgroups, "GroupId", "GroupName", databyid.GroupId);
            return View(databyid);
        }

        // GET: Admin/Users/Edit/5
        public ActionResult taiKhoanCapNhat(int id)
        {
            UserDetail model = new UserDetail();
            var user = db.Users.Where(a => a.UserID == id).FirstOrDefault();
            model.UserID = id;
            model.FullName = user.FullName;
            model.EmailID = user.EmailID;
            model.DateOfBirth = user.DateOfBirth;
            model.UserPhone = user.UserPhone;
            model.UserGender = user.UserGender;
            model.GroupId = user.GroupId;
            model.Description = user.Description;

            return View(model);
        }

        [HttpPost]
        public ActionResult taiKhoanCapNhat(UserDetail collection)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (DVCPContext dc = new DVCPContext())
                {
                    var user = dc.Users.Where(a => a.UserID == collection.UserID).FirstOrDefault();
                    if (user != null)
                    {
                        user.FullName = collection.FullName;
                        user.EmailID = collection.EmailID;
                        user.DateOfBirth = collection.DateOfBirth;
                        user.UserPhone = collection.UserPhone;
                        user.UserGender = collection.UserGender;
                        user.GroupId = collection.GroupId;
                        user.Description = collection.Description;
                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "Đã cập thông tin tài khoản thành công";
                    }
                }
            }
            else
            {
                message = "Một cái gì đó không hợp lệ";
            }
            ViewBag.Message = message;
            return View(collection);
        }

        public ActionResult taiKhoanXoa(int id)
        {
            var databyid = db.Users.Single(x => x.UserID == id);
            return View(databyid);
        }

        // POST: Admin/User1/Delete/5
        [HttpPost]
        public ActionResult taiKhoanXoa(int id, User1 collection)
        {
            try
            {
                var data = db.Users.Single(x => x.UserID == id);
                db.Users.Remove(data);
                db.SaveChanges();
                return RedirectToAction("quanLyTaiKhoan");
            }
            catch
            {
                return View(collection);
            }
        }

        public static string GetIPAddress()
        {
            return GetIPAddress(new HttpRequestWrapper(System.Web.HttpContext.Current.Request));
        }

        internal static string GetIPAddress(HttpRequestBase request)
        {
            // handle standardized 'Forwarded' header
            string forwarded = request.Headers["Forwarded"];
            if (!String.IsNullOrEmpty(forwarded))
            {
                foreach (string segment in forwarded.Split(',')[0].Split(';'))
                {
                    string[] pair = segment.Trim().Split('=');
                    if (pair.Length == 2 && pair[0].Equals("for", StringComparison.OrdinalIgnoreCase))
                    {
                        string ip = pair[1].Trim('"');

                        // IPv6 addresses are always enclosed in square brackets
                        int left = ip.IndexOf('['), right = ip.IndexOf(']');
                        if (left == 0 && right > 0)
                        {
                            return ip.Substring(1, right - 1);
                        }

                        // strip port of IPv4 addresses
                        int colon = ip.IndexOf(':');
                        if (colon != -1)
                        {
                            return ip.Substring(0, colon);
                        }

                        // this will return IPv4, "unknown", and obfuscated addresses
                        return ip;
                    }
                }
            }

            // handle non-standardized 'X-Forwarded-For' header
            string xForwardedFor = request.Headers["X-Forwarded-For"];
            if (!String.IsNullOrEmpty(xForwardedFor))
            {
                return xForwardedFor.Split(',')[0];
            }

            return request.UserHostAddress;
        }
    }
}