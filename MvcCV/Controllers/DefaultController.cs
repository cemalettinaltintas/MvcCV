using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCV.Models.Entity;

namespace MvcCV.Controllers
{
    //Otorize işleminde maaf tuttuk
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        DbCvEntities db=new DbCvEntities();
        // GET: Default
        public ActionResult Index()
        {
            var degerler=db.TblHakkimda.ToList();
            return View(degerler);
        }
        public PartialViewResult Deneyim()
        {
            var deneyimler=db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }
        public PartialViewResult Egitimlerim()
        {
            var egitimlerim=db.TblEgitimlerim.ToList();
            return PartialView(egitimlerim);
        }
        public PartialViewResult Yeteneklerim()
        {
            var yeteneklerim=db.TblYeteneklerim.ToList();
            return PartialView(yeteneklerim);
        }
        public PartialViewResult Hobilerim()
        {
            var hobilerim=db.TblHobilerim.ToList(); 
            return PartialView(hobilerim);
        }
        public PartialViewResult Sertifikalar()
        {
            var sertifikalar=db.TblSertifikalarim.ToList();   
            return PartialView(sertifikalar);
        }
        [HttpGet]
        public PartialViewResult iletisim()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult iletisim(Tbliletisim t)
        {
            t.Tarih=Convert.ToDateTime( DateTime.Now.Date.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult SosyalMedya()
        {
            var sosyalMedya=db.TblSosyalMedya.Where(x=>x.Durum==true).ToList();
            return PartialView(sosyalMedya);
        }
    }
}