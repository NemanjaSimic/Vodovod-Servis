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
    
    public partial class DEO_OPREME
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DEO_OPREME()
        {
            this.NALAZI_SE_NA = new HashSet<NALAZI_SE_NA>();
            this.NALAZI_U = new HashSet<NALAZI_U>();
        }
    
        public string TIP_OPREME { get; set; }
        public string VODOVODNA_MREZA_ID_MREZ { get; set; }
        public byte ID_TIP { get; set; }
        public Nullable<byte> DUBINA { get; set; }
    
        public virtual VODOVODNA_MREZA VODOVODNA_MREZA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NALAZI_SE_NA> NALAZI_SE_NA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NALAZI_U> NALAZI_U { get; set; }
    }
}
