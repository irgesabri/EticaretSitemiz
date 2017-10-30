using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EticaretSitemiz
{
    public class ReklamGetir
    {
        public List<REKLAM> reklamlar(YERLER YER)
        {
            using (Eticaret_DBEntities c=new Eticaret_DBEntities())
            {
                return c.REKLAM.Where(x => x.yer == YER.ToString() && x.durum == true).ToList();
                //yani reklamın durumu açık ise
            }

        }

        public enum YERLER
        {
            SOL,SAG,UST,ALT
        }


    }
}