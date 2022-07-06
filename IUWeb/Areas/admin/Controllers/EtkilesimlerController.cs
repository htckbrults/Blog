using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Areas.admin.Controllers
{
    [Area("admin")]
    public class EtkilesimlerController : Controller
    {
        private readonly IInteractionsService service;
        public EtkilesimlerController(IInteractionsService _service)
        {
            service = _service;
        }
        [Route("/admin/Etkilesimler/{blogId}")]
        public IActionResult Index(int blogId)
        {
            return View(service.GetAllList(x=> x.Blogs).Where(x=> x.BlogsId == blogId));
        }
        [HttpGet]
        [Route("/admin/Etkilesimler/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            service.Delete(x=> x.Id == Id);
            return Redirect("/admin/Bloglar");
        }
    }
}
