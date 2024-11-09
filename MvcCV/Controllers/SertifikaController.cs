using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    public class SertifikaController : Controller
    {
        SertifikaRepository repo=new SertifikaRepository();
        // GET: Sertifika
        public ActionResult Index()
        {
            var sertifikalar = repo.List();
            return View(sertifikalar);
        }
        [HttpGet]
        public ActionResult SertifikaGetir( int id)
        {
            var sertifika = repo.Find(x=>x.ID==id);
            return View(sertifika);
        }
        [HttpPost]
        public ActionResult SertifikaGetir(TblSertifikalarim p)
        {
            var sertifika = repo.Find(x => x.ID == p.ID);
            sertifika.Aciklama = p.Aciklama;
            sertifika.Tarih=p.Tarih;
            repo.TUpdate(sertifika);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult YeniSertifika() { return View(); }
        [HttpPost]
        public ActionResult YeniSertifika(TblSertifikalarim p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult SertifikaSil(int id)
        {
            var sertifika=repo.Get(id);
            repo.TDelete(sertifika);
            return RedirectToAction("Index");
        }
    }
}