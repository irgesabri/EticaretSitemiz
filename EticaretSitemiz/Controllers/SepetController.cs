using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{
    public class SepetController : Controller
    {
        // GET: Sepet
        public ActionResult Index()
        {
            List<SepetSinifi> sepet = new List<SepetSinifi>();
            var sepetUrunleri = (List<URUNLER>)Session["sepet"];
            //session: geçiçi bellek için kullanılır. 
            foreach (var item in sepetUrunleri)
            {
                if (sepet.Where(x=>x.urunID==item.urunID).FirstOrDefault()!=null)
                {
                    var urunkalembilgisi = sepet.Where(x => x.urunID == item.urunID).FirstOrDefault();
                    urunkalembilgisi.Adet = urunkalembilgisi.Adet + 1;
                    urunkalembilgisi.ToplamFiyat = urunkalembilgisi.ToplamFiyat + item.urunFiyat.Value;
                }
                else
                {
                    SepetSinifi eklenecekurun = new SepetSinifi();
                    eklenecekurun.Adet = 1;
                    eklenecekurun.Fiyat = item.urunFiyat.Value;
                    eklenecekurun.ToplamFiyat = item.urunFiyat.Value;
                    eklenecekurun.UrunAdi = item.urunAdi;
                    eklenecekurun.urunID = item.urunID;
                    sepet.Add(eklenecekurun);
                }
            }
            return View(sepet);
        }

    }
    //1.adım
    public class SepetSinifi
    {
        public int urunID { get; set; }
        public string UrunAdi { get; set; }
        public decimal Fiyat { get; set; }
        public int Adet { get; set; }
        public decimal ToplamFiyat { get; set; }
    }

}