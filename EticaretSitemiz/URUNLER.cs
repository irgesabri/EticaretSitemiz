//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EticaretSitemiz
{
    using System;
    using System.Collections.Generic;
    
    public partial class URUNLER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public URUNLER()
        {
            this.KATEGORI_URUNLER = new HashSet<KATEGORI_URUNLER>();
            this.URUNLER_RESIM = new HashSet<URUNLER_RESIM>();
        }
    
        public int urunID { get; set; }
        public string urunAdi { get; set; }
        public Nullable<decimal> urunFiyat { get; set; }
        public Nullable<int> urunStok { get; set; }
        public string urunAciklama { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KATEGORI_URUNLER> KATEGORI_URUNLER { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<URUNLER_RESIM> URUNLER_RESIM { get; set; }
    }
}
