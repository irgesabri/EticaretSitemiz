using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class UrunEkleme
    {
        public void Ekle(URUNLER urun)//urunler ritinde data alacak. yani database e eklenecek satırın  tipinde data alacak.Bu da rahat bir şekilde urun eklemimizi sağlayacak.
        {
            using (Eticaret_DBEntities c= new Eticaret_DBEntities())
            {
                c.URUNLER.Add(urun);//paremtreden gelen urun u ekle
                c.SaveChanges();
            }
        }
    }
}