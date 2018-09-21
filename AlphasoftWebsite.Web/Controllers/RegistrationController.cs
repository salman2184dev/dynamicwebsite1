using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using AlphasoftWebsite.Core.Model;
using AlphasoftWebsite.Core.Model.Extended;

namespace AlphasoftWebsite.Web.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration([Bind(Exclude = "IsEmailVerified,ActivationCode")] User user)
        {
            bool Status = false;
            string message = "";
            //
            // Model Validation 
            if (ModelState.IsValid)
            {

                #region //Email is already Exist 
                var isExist = IsEmailExist(user.Email);
                if (isExist)
                {
                    ModelState.AddModelError("EmailExist", "Email already exist");
                    return View(user);
                }
                #endregion

                #region Generate Activation Code 
                user.ActivationCode = Guid.NewGuid().ToString();
                #endregion

                #region  Password Hashing 
                user.Password = Crypto.Hash(user.Password);
                #endregion
                user.IsEmailVerified = false;

                user.RegistrationDate = DateTime.Now;

                #region Save to Database
                using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
                {
                    dc.Users.Add(user);
                    dc.SaveChanges();

                    //Send Email to User
                    SendVerificationLinkEmail(user.Email, user.ActivationCode.ToString());
                    message = "Registration successfully done. Account activation link " +
                              " has been sent to your email id:" + user.Email;
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
            using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
            {
                var v = dc.Users.FirstOrDefault(a => a.Email == emailID);
                return v != null;
            }
        }

        [NonAction]
        public void SendVerificationLinkEmail(string emailID, string activationCode, string emailFor = "VerifyAccount")
        {
            var verifyUrl = "/Registration/" + emailFor + "/" + activationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);

            var fromEmail = new MailAddress("salman.zahir.mbstu@gmail.com", "Salman Zahir");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "insert2184"; 

            string subject = "";
            string body = "";
            if (emailFor == "VerifyAccount")
            {
                subject = "Your account is successfully created!";
                body = "<br/><br/>We are excited to tell you that your Alphasoft account is" +
                       " successfully created. Please click on the below link to verify your account" +
                       " <br/><br/><a href='" + link + "'>" + link + "</a> ";
            }
            else if (emailFor == "ResetPassword")
            {
                subject = "Reset Password";
                body = "Hi,<br/><br/>We got request for reset your account password. Please click on the below link to reset your password" +
                       "<br/><br/><a href=" + link + ">Reset Password link</a>";
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

        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool Status = false;
            using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
            {                
                var v = dc.Users.FirstOrDefault(a => a.ActivationCode == new Guid(id).ToString());
                if (v != null)
                {
                    v.IsEmailVerified = true;
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

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserLogin login, string ReturnUrl = "")
        {
            string message = "";
            using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
            {
                var v = dc.Users.FirstOrDefault(a => a.Email == login.Email);
                if (v != null)
                {
                    if (!v.IsEmailVerified)
                    {
                        ViewBag.Message = "Please verify your email first";
                        return View();
                    }
                    if (String.CompareOrdinal(Crypto.Hash(login.Password), v.Password) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 min = 1 year
                        var ticket = new FormsAuthenticationTicket(login.Email, login.RememberMe, timeout);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeout);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        Session["User"] = login.Email;
                        Session["UserName"] = v.UserName;

                        #region AddLogin info
                        var logininfo = new LoginInfo();
                        logininfo.UserId = v.UserId;
                        logininfo.LogInTime = DateTime.Now;
                        logininfo.LoginIp = Request.UserHostAddress;
                        dc.LoginInfoes.Add(logininfo);
                        dc.SaveChanges();
                        #endregion

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Registration");
                        }
                    }
                    else
                    {
                        message = "Invalid credential provided";
                    }
                }
                else
                {
                    message = "Invalid credential provided";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            string message = "";
            bool status = false;

            using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
            {
                var account = dc.Users.FirstOrDefault(a => a.Email == email);
                if (account != null)
                {
                    string resetCode = Guid.NewGuid().ToString();
                    SendVerificationLinkEmail(account.Email, resetCode, "ResetPassword");
                    account.ResetPasswordCode = resetCode;
                    dc.Configuration.ValidateOnSaveEnabled = false;
                    dc.SaveChanges();
                    message = "Reset password link has been sent to your email id.";
                }
                else
                {
                    message = "Account not found";
                }
            }
            ViewBag.Message = message;
            return View();
        }

        public ActionResult ResetPassword(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return HttpNotFound();
            }

            using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
            {
                var user = dc.Users.FirstOrDefault(a => a.ResetPasswordCode == id);
                if (user != null)
                {
                    ResetPassword model = new ResetPassword();
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
        public ActionResult ResetPassword(ResetPassword model)
        {
            var message = "";
            if (ModelState.IsValid)
            {
                using (AlphasoftWebsiteContext dc = new AlphasoftWebsiteContext())
                {
                    var user = dc.Users.FirstOrDefault(a => a.ResetPasswordCode == model.ResetCode);
                    if (user != null)
                    {
                        user.Password = Crypto.Hash(model.NewPassword);
                        user.ResetPasswordCode = "";

                        #region Add ResetPassword info
                        var resetpassword = new ResetPassword();
                        resetpassword.UserId = user.UserId;
                        resetpassword.ResetCode = model.ResetCode;
                        resetpassword.NewPassword = user.Password;
                        resetpassword.ResetTime = DateTime.Now;
                        dc.ResetPasswords.Add(resetpassword);
                        #endregion

                        dc.Configuration.ValidateOnSaveEnabled = false;
                        dc.SaveChanges();
                        message = "New password updated successfully";
                    }
                }
            }
            else
            {
                message = "Something invalid";
            }
            ViewBag.Message = message;
            return View(model);
        }
    }
}