using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class YetenekController : Controller
    {
        YetenekRepository repo=new YetenekRepository();
        // GET: Yetenek
        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }
        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniYetenek(TblYeteneklerim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult YetenekSil(int id)
        {
            TblYeteneklerim yetenek = repo.Get(id);
            repo.TDelete(yetenek);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            TblYeteneklerim yetenek = repo.Get(id);
            return View(yetenek);
        }
        [HttpPost]
        public ActionResult YetenekDuzenle(TblYeteneklerim p)
        {
            TblYeteneklerim yetenek=repo.Get(p.ID);
            yetenek.Yetenek=p.Yetenek;
            yetenek.Oran = p.Oran;
            repo.TUpdate(yetenek);  
            return RedirectToAction("Index");
        }
    }
}