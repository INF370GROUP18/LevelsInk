//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nati_Supermarket_and_Takeaway_WinForms
{
    using System;
    using System.Collections.Generic;
    
    public partial class Sale_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale_Type()
        {
            this.Sales = new HashSet<Sale>();
        }
    
        public int Sale_Type_ID { get; set; }
        public string Sale_Type_Description { get; set; }
    
        public virtual Sale_Type Sale_Type1 { get; set; }
        public virtual Sale_Type Sale_Type2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
