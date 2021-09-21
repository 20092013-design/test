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
    
    public partial class proc_AddEditProduct_Result
    {
        public int ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public Nullable<decimal> MinDeposit { get; set; }
        public Nullable<bool> MaxAmount { get; set; }
        public Nullable<decimal> UpperLimit { get; set; }
        public Nullable<bool> EarnDividends { get; set; }
        public Nullable<decimal> DividendRate { get; set; }
        public Nullable<bool> Withdrawn { get; set; }
        public Nullable<bool> FixedDeposit { get; set; }
        public Nullable<bool> Transferred { get; set; }
        public Nullable<bool> GuaranteeLoan { get; set; }
        public string Frequency { get; set; }
        public Nullable<bool> EarnInterest { get; set; }
        public Nullable<bool> ChargeDefaulters { get; set; }
        public Nullable<bool> MultAccounts { get; set; }
        public Nullable<bool> CallDeposit { get; set; }
        public Nullable<decimal> MinBalance { get; set; }
        public Nullable<bool> CanBeOverdrawn { get; set; }
        public Nullable<bool> AccrueInterestDaily { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public System.Guid Guid { get; set; }
        public byte[] Timestamp { get; set; }
    }
}