using BusinessLayer.Abstract;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace UIWeb.Controllers
{
    [AllowAnonymous]
    public class JSONController : Controller
    {
        private readonly IInteractionsService service;
        public JSONController(IInteractionsService service)
        {
            this.service = service;
        }

        public JsonResult Index(int BlogId,bool Status)
        {
            // Bir Kullanıcı bir Etkileşim yapabilsin ama Etkileşiminide değiştirebilsin.
            string ipAdresi = Dns.GetHostAddresses(Dns.GetHostName())[1].ToString();
            var Dogrula = service.GetById(x=> x.IPAddress == ipAdresi && x.BlogsId == BlogId);
            if (Dogrula == null)
            {
                Interactions i = new Interactions();
                i.IPAddress = ipAdresi;
                i.BlogsId = BlogId;
                i.InteractionDate = DateTime.Now;
                i.InteractionType = Status;
                service.Insert(i);
            }
            else
            {
                if (Dogrula.InteractionType == true && Status== false)
                {
                    Dogrula.InteractionType = false;
                }
                else if (Dogrula.InteractionType == false && Status == true)
                {
                    Dogrula.InteractionType = true;
                }
                service.Update(Dogrula);
            }

            return Json("");
        }


        [Route("/JSON/PartialGetir/{Id}")]
        public IActionResult PartialGetir(int Id)
        {
            return PartialView("/Views/Shared/PartialEtkilesim.cshtml",service.GetAllList().Where(x => x.BlogsId == Id).ToList());
        }
    }
}
