//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    
    public partial class proc_AddEditPaymentModes_Result
    {
        public int PaymentModeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> AllowBackDated { get; set; }
        public Nullable<int> MaxDaysofBackDated { get; set; }
        public Nullable<bool> CanDisburseLoan { get; set; }
        public Nullable<bool> IsDefault { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
