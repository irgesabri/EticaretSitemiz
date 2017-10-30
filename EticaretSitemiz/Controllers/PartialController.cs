//using EticaretSitemiz.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Urunler()
        {

            if (RouteData.Values["id"]==null)
            {
                //id dedğimiz /Kategori/Index/1 deki 1 
                //appstart altında routeconfig.cs içindeki url:"{controller}/{action}/{id}" bu url yapısından da anlaşılacğaı uzere 3. paremetre id oluyor.Bu yuzden yukardan id aldık.

                using (Eticaret_DBEntities c=new Eticaret_DBEntities())
                {
                    List<URUNLER> urunler = c.URUNLER.Include("URUNLER_RESIM").ToList();
                    return View(urunler);
                }
            }

            else//id paremetresi dolu ise notmal butun urunleri getirmeyecekti de kategoriler baglı urunleri getirecektik.
            {
                Eticaret_DBEntities c = new Eticaret_DBEntities();
                int kategori_ID = Convert.ToInt32(RouteData.Values["id"]);
                var urunkategorileri = c.KATEGORI_URUNLER.Where(x => x.kategoriID == kategori_ID).ToList();
                ViewBag.KategoriUrunleri = urunkategorileri;
                return View();
            }

            #region İlk hali
            //using (Eticaret_DBEntities c = new Eticaret_DBEntities())
            //{
            //    List<URUNLER> urunler = c.URUNLER.Include("URUNLER_RESIM").ToList();
            //    return View(urunler);
            //    // using içinden çıkan komutlarda bağlı tablolar gelmez
            //} 
            #endregion

            // return View();
        }
        //get 
        public ActionResult UrunEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(string urunadi, string urunfiyat, string urunstok, string urunaciklama, HttpPostedFileBase urunresim) // geriye HttpPostedfileBase tipinde değer döndürür
        {
            string uyari = null;
            string resimad = null;
            if (urunresim != null)
            {
                string pic = System.IO.Path.GetFileName(urunresim.FileName); // dosyanın ismini getiriyor
                resimad = Guid.NewGuid().ToString() + "-" + pic;
                string path = System.IO.Path.Combine(Server.MapPath("~/images/urunler"), resimad); // dosyanın kaydedileceği yer
                // dosya yüklendi
                urunresim.SaveAs(path); // kayıt işlemi
            }
            else
            {
                uyari += "Resim Ekleyiniz.<br>";
            }
            if (urunadi.Length == 0)
            {
                uyari += "Ürün Adı Boş Bırakılamaz.<br>";
            }
            if (urunfiyat.Length == 0)
            {
                uyari += "Ürün Fiyatı Giriniz.<br>";
            }
            if (urunaciklama.Length == 0)
            {
                uyari += "Ürün Açıklama Alanı Boş Bırakılamaz.<br>";
            }
            try
            {
                Convert.ToDecimal(urunfiyat);
            }
            catch (Exception)
            {
                uyari += "Hatalı Ürün Fiyatı.<br>";
            }
            try
            {
                Convert.ToInt32(urunstok);
            }
            catch (Exception)
            {
                uyari += "Hatalı Ürün Adeti Girdiniz.<br>";
            }
            string a = urunadi;
            if (uyari == null)
            {
                UrunEkleme ekle = new UrunEkleme();
                URUNLER urun = new URUNLER();
                urun.urunAdi = urunadi;
                urun.urunAciklama = urunaciklama;
                urun.urunFiyat = Convert.ToDecimal(urunfiyat);
                urun.urunStok = Convert.ToInt32(urunstok);
                ekle.Ekle(urun); // urunu ekle methoduna gönderiyoruz. urun eklendi

                UrunResimEkleme resimEkle = new UrunResimEkleme();
                resimEkle.Ekle(resimad, urun.urunID); // urun.Urunler_ID urun nesnesi içinde komple URUNLER tablosunun sütunları zaten vardı oraan geliyor

                ViewBag.Uyari = "Ürün Eklendi";
                return RedirectToAction("Index", "Yonetim"); // burada anasayfaya yönlendirdik
            }
            else // uyarı boş değil ise. yukarıdan herhangi bir uyarı geldiyse, viewbagle karşıya gönderiyorum ki kullanıcıya uyarı çıksın
            {
                ViewBag.Uyari = uyari;
                return RedirectToAction("Index", "Yonetim");
            }

            //return View(); siliyoruz kendisine gitmesin istiyoruz. Yonetime gitsin istiyoruz
        }
        #region ilk hali
        //[HttpPost]//post
        //public ActionResult UrunEkle(string urunadi, string urunfiyat, string urunstok, string urunaciklama, HttpPostedFileBase urunresim)//HttpPostedFileBase tipinde deger dondurur
        //{
        //    string uyari = null;
        //    string resimad = null;
        //    //resim ekleme
        //    if (urunresim != null)
        //    {
        //        string pic = System.IO.Path.GetFileName(urunresim.FileName);//dosyanın ismini getirdik.
        //        resimad = Guid.NewGuid().ToString() + "-" + pic;
        //        string path = System.IO.Path.Combine(Server.MapPath("~/images/urunler"), resimad);//dosyanın kaydedileceği yeri belirledik.
        //        urunresim.SaveAs(path);//kayıt işlemi
        //    }
        //    else
        //    {
        //        uyari += "Resim Ekleyiniz.<br>";
        //    }

        //    if (urunadi.Length == 0)
        //    {
        //        uyari += "Ürün adi boş bırakılamaz<br>";
        //    }
        //    if (urunaciklama.Length == 0)
        //    {
        //        uyari += "Ürün açıklama alanı boş bırakılamaz <br>";
        //    }
        //    try
        //    {
        //        Convert.ToDecimal(urunfiyat);
        //    }
        //    catch (Exception)
        //    {
        //        uyari += "Hatalı ürün fiyatı <br>";
        //    }

        //    try
        //    {
        //        Convert.ToInt32(urunstok);
        //    }
        //    catch (Exception)
        //    {
        //        uyari += "Hatalı ürün adeti girdiniz.<br>";
        //    }

        //    string a = urunadi;
        //    if (uyari == null)
        //    {
        //        UrunEkleme ekle = new UrunEkleme();
        //        URUNLER urun = new URUNLER();
        //        urun.urunAdi = urunadi;
        //        urun.urunAciklama = urunaciklama;
        //        urun.urunFiyat = Convert.ToDecimal(urunfiyat);
        //        urun.urunStok = Convert.ToInt32(urunstok);

        //        ekle.Ekle(urun);

        //        UrunResimEkleme resimekleme = new UrunResimEkleme();
        //        resimekleme.Ekle(resimad, urun.urunID);//urun.urunID urun nesnesi içinde komple urunler tablosunun sutunları zaten vardı oraya geliyor.


        //        ViewBag.Uyari = "Ürün Eklendi";
        //        return RedirectToAction("Index", "Yonetim");
        //    }
        //    else
        //    {
        //        ViewBag.Uyari = uyari;
        //        return RedirectToAction("Index", "Yonetim");
        //    }

        //} 
        #endregion
        public ActionResult AdminMenu()
        {
            return View();
        }

        public ActionResult Sayfa()
        {


            var cagrilacaksayfa = RouteData.Values["id"];
            //ID ile buradaki viewwe cekeceği sayfayı soylesek o da cekse
            //mesela urunekle
            //http:localhost/Yonetim/Index/UrunEkle
            // RouteData.Values["id"]; id ile ne isism yollarsam gidipi o viewi çagıracak.

            if (RouteData.Values["id"]==null)
            {
                return View("UrunEkle");
            }
            else
            {
                return View(RouteData.Values["id"].ToString());// boş değil ise bizim yolladığımız datayı gitsin çeksin
            }


            #region İlk hali
            //ilk hali
            ////bu partial diğer viewlweri Load etmek için kullancacam. başka viewlwri çağıracak.
            //return View("UrunEkle");//paremetee ile viewName alıp geriye dondurecek.
            ////yani bir view , başka bir viewi çağırabilir..buna dinamic view çağırma denir.dinamic bir sayfa yapısı oluşturmamızı sağlayacak 
            #endregion.
        }
        //get
        public ActionResult KategoriEkle()
        {
            return View();
        }

        //post
        [HttpPost]
        public ActionResult KategoriEkle(string kategoriadi,string kategorisira)
        {
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                KATEGORILER k = new KATEGORILER();
                k.kategoriAdi = kategoriadi;
                k.kategoriSira = Convert.ToInt32(kategorisira);
                c.KATEGORILER.Add(k);
                c.SaveChanges();//kategori eklendikten sonra cashe i boşltmamız lazım. çünkü artık yeni bir kategori eklendi.
                System.Web.HttpContext.Current.Cache.Remove("solmenu");//cashe temziledik

                return RedirectToAction("Index", "Yonetim", new { id = "KategoriEkle" });

            }

        }

    }
}