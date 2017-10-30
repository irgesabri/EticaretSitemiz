using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{

    public class SharedController : Controller
    {


        // GET: Shared
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UstMenu()
        {
            AyarGetir ayar = new AyarGetir();
            ViewBag.Siteadi = ayar.Ayar("siteadi");
            return View();
        }

        public ActionResult SolMenu()
        {

            //cash bellek nedir ? bazı dataları sürekli  databaseden çekmek iyi bir teknik değildir
            //cashe in anlamı: sayfaya başkaları girdiği zaman artık dataları hazneden göndermek yani database e gitmemek
            if (System.Web.HttpContext.Current.Application["solmenu"] == null)
            {
                KategoriListele c = new KategoriListele();
                System.Web.HttpContext.Current.Application["solmenu"] = c.Kategoriler();//hazneyi doldurduk.cache içine kategorileri aldık
                return View((List<KATEGORILER>)System.Web.HttpContext.Current.Application["solmenu"]);
                //cache doldurduktan sonra geriye list tipinde dondur.

            }
            else//eeger cache dolu geliyor ise cache i list tipinde Kategoriler olarak gönder.
            {
                return View((List<KATEGORILER>)System.Web.HttpContext.Current.Application["solmenu"]);

                //olay şu, databaseden bir kere cache i doldurduktan sonra sürekli hep cache den çağıracak butun datayı.
            }

            // application cashe gibidir. ama sunucu tarafında tutulur. yani sunucunun belleğinde tututlur. herkes erişebilir cashe de herkes erişrbilir. ama cash belli bir zaman sonra sıfırlanabilir. application, sunucu açık olduğu sürece dururu. kendi kedine boşalma ihtimali yoktur.
            //sitedeki online kişi sayısını ölçmek istiyorsa application seceriz.

            #region Cache li hali
            //if (System.Web.HttpContext.Current.Cache["solmenu"] == null)
            //{
            //    KategoriListele c = new KategoriListele();
            //    System.Web.HttpContext.Current.Cache["solmenu"] = c.Kategoriler();//hazneyi doldurduk.cache içine kategorileri aldık
            //    return View((List<KATEGORILER>)System.Web.HttpContext.Current.Cache["solmenu"]);
            //    //cache doldurduktan sonra geriye list tipinde dondur.

            //}
            //else//eeger cache dolu geliyor ise cache i list tipinde Kategoriler olarak gönder.
            //{
            //    return View((List<KATEGORILER>)System.Web.HttpContext.Current.Cache["solmenu"]);

            //    //olay şu, databaseden bir kere cache i doldurduktan sonra sürekli hep cache den çağıracak butun datayı.
            //} 
            #endregion


            #region Cachesiz
            //KategoriListele k = new KategoriListele();

            //return View(k.Kategoriler());
            #endregion

        }
        public ActionResult SolReklam()
        {
            ReklamGetir r = new ReklamGetir();

            return View(r.reklamlar(ReklamGetir.YERLER.SOL));
            //ezberleneck şeyler enum ile yazılır.
            //yerler.sol ile reklam sola yerleşmeyecek biz onun sol reklam olduğunu sola koyacağımızı anlıyoruz.

        }

    }
}