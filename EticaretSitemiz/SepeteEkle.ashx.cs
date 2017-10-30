using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    /// <summary>
    /// Summary description for SepeteEkle
    /// </summary>
    public class SepeteEkle : IHttpHandler,System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
           

            if (context.Session["sepet"]==null)
            {
                List<URUNLER> sepettekiurunler = new List<URUNLER>();
                UrunDetayGetir detay = new UrunDetayGetir();
                var urun = detay.urungetir(Convert.ToInt32(context.Request.Form["urunid"]));
                sepettekiurunler.Add(urun);
                context.Session["sepet"] = sepettekiurunler;
            }
            else
            {
                UrunDetayGetir detay = new UrunDetayGetir();
                List<URUNLER> sepettekiurunler = new List<URUNLER>();
                sepettekiurunler =(List<URUNLER>) context.Session["sepet"];
                var urun = detay.urungetir(Convert.ToInt32(context.Request.Form["urunid"]));
                sepettekiurunler.Add(urun);
                context.Session["sepet"] = sepettekiurunler;
            }


            var sepettekiurunlerim =(List<URUNLER>)context.Session["sepet"];
            decimal toplamFiyat = (decimal)sepettekiurunlerim.Sum(x => x.urunFiyat);

            int sepetUrunlerAdet = sepettekiurunlerim.Count;
            string cevap = string.Format("Sepetinizde {0} değerinde {1} Adet ürün var", toplamFiyat.ToString("C"), sepetUrunlerAdet);
            context.Response.ContentType = "text/plain";
            context.Response.Write(cevap);


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}