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
    
    public partial class Inventory_Item_Type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Item_Type()
        {
            this.Inventory_Item = new HashSet<Inventory_Item>();
        }
    
        public int Inventory_Item_Type_ID { get; set; }
        public string Inv_Item_Type_Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Item> Inventory_Item { get; set; }
    }
}