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
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Sales = new HashSet<Sale>();
            this.Slots = new HashSet<Slot>();
        }
    
        public int Employee_ID { get; set; }
        public Nullable<int> Employee_Title_ID { get; set; }
        public Nullable<int> Employee_Type_ID { get; set; }
        public Nullable<int> Security_Question_ID { get; set; }
        public string Employee_Security_Answer { get; set; }
        public string Employee_Name { get; set; }
        public string Employee_Surname { get; set; }
        public string Employee_Cellphone_Number { get; set; }
        public string Employee_Email { get; set; }
        public string Employee_Address { get; set; }
        public byte[] Employee_Login_Password { get; set; }
        public byte[] Employee_Picture { get; set; }
        public string Bank_Name { get; set; }
        public string Branch_Code { get; set; }
        public string Account_Number { get; set; }
    
        public virtual Employee_Title Employee_Title { get; set; }
        public virtual Employee_Type Employee_Type { get; set; }
        public virtual Security_Question Security_Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sale> Sales { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Slot> Slots { get; set; }
    }
}
