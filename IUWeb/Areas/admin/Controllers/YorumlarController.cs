using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class YorumlarController : Controller
    {
        private readonly ICommentService service;
        public YorumlarController(ICommentService _service)
        {
            service = _service;
        }
        [Route("/admin/Yorumlar/{BlogId}")]
        public IActionResult Index(int BlogId) //2
        {
            return View(service.GetAllList(x=> x.Blogs).Where(x=> x.BlogsId == BlogId));
        }
        [HttpGet]
        [Route("/admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id)
        {
            return View(service.GetById(x=> x.Id == Id));
        }
        [HttpPost]
        [Route("/admin/Yorumlar/Update/{Id}")]
        public IActionResult Update(int Id,Comments comments)
        {
            comments.Id = Id;
            ViewBag.Message = service.Update(comments);
            return View(service.GetById(x => x.Id == Id));
        }
        [HttpGet]
        [Route("/admin/Yorumlar/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x => x.Id == Id);
            return Redirect("/admin/bloglar");
        }
    }
}
