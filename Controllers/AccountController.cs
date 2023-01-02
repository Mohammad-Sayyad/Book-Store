using BookStore.Areas.Identity.Data;
using BookStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {

        UserManager<ApplicationUser> userManager;
        SignInManager<ApplicationUser> signInManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

      public async Task<IActionResult> CheckNameUser(string username)
        {
            ApplicationUser user = await userManager.FindByNameAsync(username);
            if(user == null)
            return Json(true);
            else return Json(false);
        }
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData["msg"] = "You Log out from site";
            return RedirectToAction("index", "book");
        }

        public async Task<IActionResult> PasswordRecoveryLevelOne(string username)
        {

            ApplicationUser user = await userManager.FindByNameAsync(username);
            string token = await userManager.GeneratePasswordResetTokenAsync(user);
            string hrefAddress = Url.Action("PasswordRecoveryLevelTwo", "Account" , new {user.Id , token} , "https");
            string body = $"Hi {user.firstname}" +
                $"Click this <ahref='{hrefAddress}'>Link </a> to reset your password ";

            MailMessage mailMessage = new MailMessage("sayyadamir71111@gmail.com" , user.Email);
            mailMessage.Subject = ("Reset Password");
            mailMessage.Body = body;
            mailMessage.IsBodyHtml = true;
            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com" , 587);
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("sayyadamir71111@gmail.com" , "amir20222024");
            try
            {
                smtpClient.Send(mailMessage);
                TempData["msg"] = "Email password change has been sent";
            }
            catch
            {
                TempData["msg"] = "Error sending email";
            }
            return RedirectToAction("index" , "book");
        }

        public async Task<IActionResult> PasswordRecoveryLevelTwo (string Id ,string token)
        {
            return View();
        }

        public async Task<IActionResult> SignInConfirm(SigninViewModel signinViewModel)
        {
            ApplicationUser user = await userManager.FindByNameAsync(signinViewModel.username);
            if (user == null)
            {

                TempData["msg"] = "خطا در ورود به سایت";
                return RedirectToAction("signin");
            }
            else
            {

                ;
                var result = await signInManager.PasswordSignInAsync(user, signinViewModel.password
                  , signinViewModel.rememberme, true);

                if (result.Succeeded)
                {
                    TempData["msg"] = "ورود به سایت با موفقیت انجام شد";
                    return RedirectToAction("index", "book");

                }
                else if (result.IsLockedOut == true)
                { // یعنی سه بار پشت سرهم پسورد را اشتباه وارد کرده اید

                    TempData["msg"] = "نام کاربری شما به مدت یک دقیقه غیر فعال گردید";
                    // await userManager.SetLockoutEndDateAsync(user, DateTimeOffset.UtcNow.AddMinutes(10)); // برای زمانی که اگر پنج بار اشتباه زد که پنج دقیقه جریمه می شود بار دوم ده دقیقه جریمه میشود
                    return RedirectToAction("signin");
                }
                else
                {
                    TempData["msg"] = "نام کاربری یا رمز شما اشتباه می باشد";
                    return RedirectToAction("signin");
                }


            }

        }
        public async Task<IActionResult> RegisterConfirm(RegisterViewModel registerViewModel)
        {
            ApplicationUser user = await userManager.FindByNameAsync(registerViewModel.username);
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = registerViewModel.username,
                    Email = registerViewModel.username,
                    firstname = registerViewModel.firstname,
                    lastname = registerViewModel.lastname,
                    gender = registerViewModel.gender,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user, registerViewModel.password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Customers");
                    // created successfully
                    TempData["msg"] = "Register Confirmed! ";
                }
                else
                {
                    //error
                    TempData["msg"] = "Wrong in Regist , try again";
                }
            }
            return RedirectToAction("index", "book");

            
        }


    }
}
