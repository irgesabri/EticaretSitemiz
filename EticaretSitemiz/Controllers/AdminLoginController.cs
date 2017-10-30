using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EticaretSitemiz.Controllers
{
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username,string password)
        {
            // string test = username + " " + password;//bu sadece görmek için 
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                var result = c.KULLANICI.Where(x => x.kullaniciAdi == username && x.password == password).FirstOrDefault();
                if (result==null)
                {

                }
                else
                {
                    Session["login"] = result.kullaniciAdi;
                    //amacımız sadece sesionu doldurmak.sesionun içine şifre atmıyoruz.Bu bizim için önemli.Biz sadece sesionun boş olup olmadığını kontrol edecez.
                    //kullanıcı adını Session[login] diye bir değişkenen aldım. aslında login burada bir değişken.bu değişkenin başka sayfalardan da erişebiliyoruz.
                return  RedirectToAction("Index", "Yonetim");

                    // Session : Sunucu tarafından tutulan bir hazne düşünün. Her sayfadan, bu hazneye erişebiliyoruz. Biz bu yönetimden sessiona erişiyoruz. Ama biz sessionı login de doldurmuştuk. Demek ki her sayfadan erişebiliyoruz. Ama bu kullanıcı bazlıdır. Kullanıcı giriş yaptığında kendi sessionını görür. Başka bir kullanıcı da kendi sessionını görür.


                    // Sessionı yok etmenin yollarından bir tanesi session = null yazmak veya browserı kapatmak veya browser açıkken 15-20 dk hareket olmazsa kendi kendine düşer. Ya da sunucunun komple kapatılıp, açılması sessionların uçmasına neden olur çünkü session sunucunun ram inde tutulur
                }
            }

            return View();
        }
    }
}