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
    
    public partial class Inventory_Item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Inventory_Item()
        {
            this.Inventory_Price = new HashSet<Inventory_Price>();
            this.Inventory_Write_off_Line = new HashSet<Inventory_Write_off_Line>();
            this.Prepare_Inventory_Line = new HashSet<Prepare_Inventory_Line>();
            this.Sales_Line = new HashSet<Sales_Line>();
            this.Stock_Take_Line = new HashSet<Stock_Take_Line>();
            this.Supplier_Order_List = new HashSet<Supplier_Order_List>();
        }
    
        public int Inventory_Item_ID { get; set; }
        public Nullable<int> Inventory_Item_Type_ID { get; set; }
        public Nullable<int> Unit_Of_Measure_ID { get; set; }
        public string Inventory_Item_Name { get; set; }
        public Nullable<int> Inventory_Item_Barcode { get; set; }
        public Nullable<int> Inventory_Item_Quantity { get; set; }
    
        public virtual Inventory_Item_Type Inventory_Item_Type { get; set; }
        public virtual Unit_Of_Measure Unit_Of_Measure { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Price> Inventory_Price { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inventory_Write_off_Line> Inventory_Write_off_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prepare_Inventory_Line> Prepare_Inventory_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sales_Line> Sales_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stock_Take_Line> Stock_Take_Line { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supplier_Order_List> Supplier_Order_List { get; set; }
    }
}
