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
    
    public partial class proc_AddEditChargeFinal_Result
    {
        public int ChargesId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<bool> IsPercent { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<bool> Tariff { get; set; }
        public Nullable<decimal> TariffAmount { get; set; }
        public Nullable<bool> IgnoreLowLimit { get; set; }
        public Nullable<decimal> LowerLimit { get; set; }
        public Nullable<decimal> UpperLimit { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
