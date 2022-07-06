using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IBlogService service;
        private readonly ICommentService commentService;
        public HomeController(IBlogService service, ICommentService commentService)
        {
            this.service = service;
            this.commentService = commentService;
        }
        public IActionResult Index()
        {
            return View(service.GetAllList(x => x.Comments, Q => Q.Interactions));
        }

        [Route("/Blog/Detail/{Id}")]
        public IActionResult Details(int Id)
        {
            return View(service.GetById(x => x.Id == Id, e => e.Interactions, r => r.Comments));
        }

        [HttpPost]
        [Route("/Blog/Detail/{Id}")]
        public IActionResult Details(int Id,Comments comments)
        {
            comments.Status = false;
            comments.CommentDate = DateTime.Now;
            comments.Id = 0;
            comments.BlogsId = Id;
            ViewBag.Message = commentService.Insert(comments);
            return View(service.GetById(x => x.Id == Id, e => e.Interactions, r => r.Comments));
        }
    }
}
