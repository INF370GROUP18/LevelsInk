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
    
    public partial class Sale
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sale()
        {
            this.Food_Order_Line = new HashSet<Food_Order_Line>();
            this.Sales_Line = new HashSet<Sales_Line>();
        }
    
        public int Sales_ID { get; set; }
        public Nullable<System.DateTime> Sales_Date { get; set; }
        public Nullable<int> Sale_Type_ID { get; set; }
        public Nullable<int> Sale_Status_ID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<System.TimeSpan> Sales_Time { get; set; }
    
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food_Order_Line> Food_Order_Line { get; set; }
        public virtual Sale_Status Sale_Status { get; set; }
        public virtual Sale_Type Sale_Type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_Line> Sales_Line { get; set; }
    }
}
