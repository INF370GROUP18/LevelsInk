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
    
    public partial class Supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Supplier()
        {
            this.Supplier_Order = new HashSet<Supplier_Order>();
        }
    
        public int Supplier_ID { get; set; }
        public string Supplier_Name { get; set; }
        public string Supplier_Surname { get; set; }
        public string Supplier_Cellphone_Number { get; set; }
        public string Supplier_Telephone { get; set; }
        public string Supplier_Email { get; set; }
        public string Supplier_Location { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Code { get; set; }
        public string Account_Number { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier_Order> Supplier_Order { get; set; }
    }
}