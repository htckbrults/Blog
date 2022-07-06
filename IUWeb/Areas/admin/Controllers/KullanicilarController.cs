using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class KullanicilarController : Controller
    {
        private readonly IUserService service;
        public KullanicilarController(IUserService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList());
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public IActionResult Insert(Users users, IFormFile file)
        {
            if (file != null)
            {
                string AlinanUzanti = Path.GetExtension(file.FileName);
                string[] uzanti = { ".jpg", ".jpeg", ".png" };
                if (uzanti.Contains(AlinanUzanti))
                {
                    string RasgeleAd = Guid.NewGuid() + AlinanUzanti;
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RasgeleAd}");

                    using (var Stream = new FileStream(KayitYolu,FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    users.AvatarImages = RasgeleAd;
                    ViewBag.Message = service.Insert(users);
                }
                else
                {
                    ViewBag.error = "Lütfen jpg,jpeg veya png uzantı dosya yükleyiniz.";
                }
            }
            else
            {
                ViewBag.error = "Lütfen Dosya Seçiniz";
            }
            return View();
        }
        [HttpGet]
        [Route("/admin/Kullanicilar/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x=> x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Kullanicilar/Update/{Id}")]
        public IActionResult Update(int Id,Users users,IFormFile file)
        {
            users.Id = Id;

            if (file != null)
            {
                string AlinanUzanti = Path.GetExtension(file.FileName);
                string[] uzanti = { ".jpg", ".jpeg", ".png" };
                if (uzanti.Contains(AlinanUzanti))
                {
                    string RasgeleAd = Guid.NewGuid() + AlinanUzanti;
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{RasgeleAd}");

                    using (var Stream = new FileStream(KayitYolu, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    users.AvatarImages = RasgeleAd;
                    ViewBag.Message = service.Update(users);
                }
                else
                {
                    ViewBag.error = "Lütfen jpg,jpeg veya png uzantı dosya yükleyiniz.";
                }
            }
            else
            {
                ViewBag.Message = service.Update(users);
            }
      
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/kullanicilar/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/admin/kullanicilar");
        }
    }
}
