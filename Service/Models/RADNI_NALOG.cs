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
    
    public partial class RADNI_NALOG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RADNI_NALOG()
        {
            this.EKIPAs = new HashSet<EKIPA>();
        }
    
        public string ID_RADNAL { get; set; }
        public string PRIMA_JMBG_ZAP { get; set; }
        public string PRIMA_JMBG_KOR { get; set; }
        public string PRIMA_ID_KVAR { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EKIPA> EKIPAs { get; set; }
        public virtual PRIMA PRIMA { get; set; }
    }
}
