using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{
    public class UrunDetayController : Controller
    {
        // GET: UrunDetay
        public ActionResult Index()
        {
            var data = RouteData.Values["id"];
            UrunDetayGetir urundetay = new UrunDetayGetir();
            var urun = urundetay.urungetir(Convert.ToInt32(data));
            
            return View(urun);
        }
    }
}