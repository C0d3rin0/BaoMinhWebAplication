//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BaoMinhWebApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Nhom
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nhom()
        {
            this.NhomThuocChiNhanh = new HashSet<NhomThuocChiNhanh>();
            this.TaiKhoan = new HashSet<TaiKhoan>();
        }
    
        public int id { get; set; }
        public string Ten { get; set; }
        public bool TrangThai { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NhomThuocChiNhanh> NhomThuocChiNhanh { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaiKhoan> TaiKhoan { get; set; }
    }
}
