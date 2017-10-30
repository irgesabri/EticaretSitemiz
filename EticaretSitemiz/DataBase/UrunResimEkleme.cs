using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class UrunResimEkleme
    {
        public void Ekle(string resimad, int urunID)
        {
            using (Eticaret_DBEntities c = new Eticaret_DBEntities())
            {
                URUNLER_RESIM r = new URUNLER_RESIM();
                r.Durum = true;
                r.Resim = resimad;
                r.Sira = 1;
                r.urunID = urunID;

                c.URUNLER_RESIM.Add(r);
                c.SaveChanges();
            }
        }
    }
}