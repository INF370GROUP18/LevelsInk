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
    
    public partial class Menu_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Menu_Item()
        {
            this.Food_Order_Line = new HashSet<Food_Order_Line>();
            this.Menu_Item_Price = new HashSet<Menu_Item_Price>();
        }
    
        public int Menu_Item_ID { get; set; }
        public Nullable<int> Menu_Item_Category_ID { get; set; }
        public string Menu_Item_Name { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Food_Order_Line> Food_Order_Line { get; set; }
        public virtual Menu_Item_Category Menu_Item_Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Menu_Item_Price> Menu_Item_Price { get; set; }
    }
}
