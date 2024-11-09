using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class HobiController : Controller
    {
        HobiRepository repo=new HobiRepository();
        // GET: Hobi
        [HttpGet]
        public ActionResult Index()
        {
            var hobilerim = repo.List();
            return View(hobilerim);
        }
        [HttpPost]
        public ActionResult Index(TblHobilerim p)
        {
            var hobi=repo.Get(1);
            hobi.Aciklama1 = p.Aciklama1;
            hobi.Aciklama2 = p.Aciklama2;
            repo.TUpdate(hobi);
            return RedirectToAction("Index");
        }
    }
}