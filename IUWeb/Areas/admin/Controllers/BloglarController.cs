using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class BloglarController : Controller
    {
        private readonly IBlogService service;
        public BloglarController(IBlogService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList());
        }

        // Aynı Sınıf içersinde aynı isim metotlar tanımlanmak isteniyorsa, Alacağı parametre sayısı yada parametre tipleri farklı olmak zorundadır. Bu olaya Metot Overloading denir.

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Insert(Blogs blogs, IFormFile file)
        {

            var daaa = ModelState.ToList();
            blogs.UsersId = 2;
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName); //.jpg .jpeg
                string[] uzantilar = { ".jpg", ".jpeg", ".png" };
                if (uzantilar.Contains(DosyaUzanti))
                {
                    string Rastgale = Guid.NewGuid() + DosyaUzanti; // wq213qwe2321dsdf.jpg
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{Rastgale}");
                    using (var Stream = new FileStream(KayitYolu,FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    blogs.Images = Rastgale;
                    ViewBag.Message = service.Insert(blogs);
                }
                else
                {
                    ViewBag.Error = "Lütfen Jpeg,Jpg veya Png uzantılı Dosya Seçiniz";
                }
            }
            else
            {
                ViewBag.Error = "Lütfen Dosya Seçiniz";
            }
            return View();
        }
        [HttpGet]
        [Route("/admin/Bloglar/Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(service.GetById(x => x.Id == id));
        }
        [HttpPost]
        [Route("/admin/Bloglar/Update/{id}")]
        public IActionResult Update(int id, Blogs blogs,IFormFile file)
        {
            blogs.Id = id;
            if (file != null)
            {
                string DosyaUzanti = Path.GetExtension(file.FileName); //.jpg .jpeg
                string[] uzantilar = { ".jpg", ".jpeg", ".png" };
                if (uzantilar.Contains(DosyaUzanti))
                {
                    string Rastgale = Guid.NewGuid() + DosyaUzanti; // wq213qwe2321dsdf.jpg
                    string KayitYolu = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/images/{Rastgale}");
                    using (var Stream = new FileStream(KayitYolu, FileMode.Create))
                    {
                        file.CopyTo(Stream);
                    }
                    blogs.Images = Rastgale;
                    ViewBag.Message = service.Update(blogs);
                }
                else
                {
                    ViewBag.Error = "Lütfen Jpeg,Jpg veya Png uzantılı Dosya Seçiniz";
                }
            }
            else
            {
                ViewBag.Message = service.Update(blogs);
            }
            return View(service.GetById(x => x.Id == id));
        }
        [HttpGet]
        [Route("/admin/Bloglar/Delete/{id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/admin/Bloglar");
        }
    }
}
