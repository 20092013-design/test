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
    
    public partial class proc_GetMembersSharesALL_Result
    {
        public int MemberShareId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> ProductId { get; set; }
        public Nullable<int> OurBranchId { get; set; }
        public Nullable<int> TheirBranchId { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<decimal> ContributionRate { get; set; }
        public Nullable<decimal> MinBalance { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public Nullable<bool> HideBalance { get; set; }
        public Nullable<bool> ExemptMobileCharges { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
