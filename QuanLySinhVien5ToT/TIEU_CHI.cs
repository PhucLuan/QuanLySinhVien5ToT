//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLySinhVien5ToT
{
    using System;
    using System.Collections.Generic;
    
    public partial class TIEU_CHI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TIEU_CHI()
        {
            this.TIEU_CHUAN = new HashSet<TIEU_CHUAN>();
            this.KQ_THEO_TIEUCHI = new HashSet<KQ_THEO_TIEUCHI>();
        }
    
        public string MaTieuChi { get; set; }
        public string TenTieuChi { get; set; }
        public Nullable<int> TienDoTong { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TIEU_CHUAN> TIEU_CHUAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KQ_THEO_TIEUCHI> KQ_THEO_TIEUCHI { get; set; }
    }
}
