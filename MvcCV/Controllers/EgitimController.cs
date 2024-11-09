using MvcCV.Models.Entity;
using MvcCV.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCV.Controllers
{
    //Control seviyesinde otorize --> Sadece bu kontrol için otorize işlemi yapar
    //[Authorize]
    public class EgitimController : Controller
    {
        EgitimRepository repo=new EgitimRepository();
        // GET: Egitim
        public ActionResult Index()
        {
            var egitimler = repo.List();
            return View(egitimler);
        }
        [HttpGet]
        public ActionResult EgitimEkle() { return View(); }
        [HttpPost]
        public ActionResult EgitimEkle(TblEgitimlerim p)
        {
            if (!ModelState.IsValid)
            {
                return View("EgitimEkle");
            }
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult EgitimSil(int id)
        {
            TblEgitimlerim egitim = repo.Get(id);
            repo.TDelete(egitim);   
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EgitimGetir(int id)
        {
            TblEgitimlerim egitim = repo.Get(id);
            return View(egitim);
        }
        [HttpPost]
        public ActionResult EgitimGetir(TblEgitimlerim p)
        {
            
            if (!ModelState.IsValid)
            {
                return View("EgitimGetir");
            }
            TblEgitimlerim egitim = repo.Get(p.ID);
            egitim.Baslik=p.Baslik;
            egitim.AltBaslik1 = p.AltBaslik1;
            egitim.AltBaslik2 = p.AltBaslik2;
            egitim.Tarih=p.Tarih;
            egitim.GNO=p.GNO;
            repo.TUpdate(egitim);
            return RedirectToAction("Index");
        }
    }
}