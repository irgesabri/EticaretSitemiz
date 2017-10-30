using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class KategoriListele
    {
        public List<KATEGORILER> Kategoriler()
        {
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                return c.KATEGORILER.OrderBy(x => x.kategoriSira).ToList();
            }
        }
    }
}