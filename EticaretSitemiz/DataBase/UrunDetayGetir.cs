using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class UrunDetayGetir
    {
        public URUNLER urungetir(int urun_id)
        {
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                return c.URUNLER.Include("URUNLER_RESIM").Where(x => x.urunID == urun_id).FirstOrDefault();
            }
        }
    }
}