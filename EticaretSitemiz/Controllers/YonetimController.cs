using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{
    public class YonetimController : Controller
    {
        // GET: Yonetim
        public ActionResult Index()
        {

            if (RouteData.Values["islem"]!=null)
            {
                using (Eticaret_DBEntities c=new Eticaret_DBEntities())
                {
                    int silinecekKategoriID = Convert.ToInt32(RouteData.Values["deger"]);
                    var kategori = c.KATEGORILER.Where(x=>x.kategoriID==silinecekKategoriID).FirstOrDefault();
                    c.KATEGORILER.Remove(kategori);
                    c.SaveChanges();

                    System.Web.HttpContext.Current.Cache.Remove("solmenu");
                    return RedirectToAction("Index", "Yonetim", new { id = "KategoriEkle", islem = string.Empty, deger = string.Empty });
                }
            }


            try
            {
                if (Session["login"]==null)
                {
                    return RedirectToAction("Index", "AdminLogin");
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "AdminLogin");
            }
            return View();
        }
    }
}