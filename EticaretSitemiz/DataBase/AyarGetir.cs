using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class AyarGetir
    {
        public string Ayar(string ayarIsim)
        {
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                var deger = c.SITEAYARLARI.Where(x => x.ayarisim == ayarIsim).FirstOrDefault();
                if (deger==null)
                {
                    return null;
                }
                else
                {
                    return deger.ayardeger;
                }
            }
        }
     
    }
}