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
    
    public partial class proc_GetAllAppraisedLoans_Result
    {
        public int LoanId { get; set; }
        public Nullable<int> LoanTypeId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public string Code { get; set; }
        public string ManualRef { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<decimal> InterestRate { get; set; }
        public Nullable<System.DateTime> ApplicationDate { get; set; }
        public string PeriodFrequency { get; set; }
        public Nullable<int> RepayPeriod { get; set; }
        public Nullable<bool> IsMarkUpBased { get; set; }
        public Nullable<decimal> MarkupAmount { get; set; }
        public Nullable<int> InterestType { get; set; }
        public Nullable<int> Status { get; set; }
        public Nullable<System.DateTime> StatusDate { get; set; }
        public Nullable<int> PurposeId { get; set; }
        public Nullable<decimal> GrossPay { get; set; }
        public Nullable<decimal> NetPay { get; set; }
        public string LoanSeries { get; set; }
        public Nullable<decimal> TotalShares { get; set; }
        public Nullable<decimal> FreeShares { get; set; }
        public Nullable<bool> IsMigrated { get; set; }
        public Nullable<int> CreditOfficerId { get; set; }
        public Nullable<int> DonorId { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid GUID { get; set; }
        public int LoanStatusId { get; set; }
        public string LoanStatusName { get; set; }
        public Nullable<System.DateTime> CreatedOn1 { get; set; }
        public string CreatedBy1 { get; set; }
        public Nullable<System.DateTime> ModifiedOn1 { get; set; }
        public string ModifiedBy1 { get; set; }
        public byte[] TimeStamp1 { get; set; }
        public System.Guid GUID1 { get; set; }
    }
}
