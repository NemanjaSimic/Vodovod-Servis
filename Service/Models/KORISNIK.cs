//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Service.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KORISNIK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KORISNIK()
        {
            this.PRIJAVLJUJEs = new HashSet<PRIJAVLJUJE>();
        }
    
        public string IME_KOR { get; set; }
        public string PREZ_KOR { get; set; }
        public string JMBG_KOR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRIJAVLJUJE> PRIJAVLJUJEs { get; set; }
    }
}
