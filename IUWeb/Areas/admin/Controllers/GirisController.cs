using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    [AllowAnonymous]
    public class GirisController : Controller
    {
        private readonly IUserService service;
        public GirisController(IUserService _service)
        {
            service = _service;
        }
       
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string Email,string Sifre)
        {
            // Claims : Giriş Yapan Kullanıcının Bilgilerini Tutmak ve yönetmek için kullanılan Bir Class'tır.
            // ClaminsIdentity : Proje içerisinde Oluşturulan Claims'lere sanal isim verip Yönetmemizi sağlarlar.
            // ClaimsPrincipal : Claims içerisindeki dataları Şifrelememizi sağlar.
            var userInfo = service.GetById(x=> x.Email == Email && x.Password == Sifre);
            if (userInfo != null)
            {
                //using System.Security.Claims;
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userInfo.NameSurname),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("Id",userInfo.Id.ToString())
                };
                var UserIdenttiy = new ClaimsIdentity(claims,"UserLogin");
                ClaimsPrincipal principal = new ClaimsPrincipal(UserIdenttiy);

                // Tarayıcı açılıp kapandığında belirlenen süre kadar cookie saklanıyor.
                var CookieSuresi = new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(25),
                    IsPersistent = true,
                    AllowRefresh = true 
                };
                //using Microsoft.AspNetCore.Authentication;
                HttpContext.SignInAsync(principal, CookieSuresi);
               // return RedirectToAction("Index","Bloglar");
                return Redirect("/admin/Bloglar");
            }
            else
            {
                ViewBag.Error = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }
        }
    }
}
