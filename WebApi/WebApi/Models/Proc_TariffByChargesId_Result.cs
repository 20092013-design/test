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
    
    public partial class Proc_TariffByChargesId_Result
    {
        public int TariffId { get; set; }
        public Nullable<int> ChargesId { get; set; }
        public Nullable<decimal> Start { get; set; }
        public Nullable<decimal> Stop { get; set; }
        public Nullable<decimal> ChargeAmount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
