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
    
    public partial class proc_GetAllLoanTypeChargesByLoanType_Result
    {
        public int LoanTypeChargesId { get; set; }
        public Nullable<int> LoanChargesListId { get; set; }
        public Nullable<int> LoanTypeId { get; set; }
        public string Name { get; set; }
        public Nullable<bool> IsPercentage { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<int> PeriodToCharge { get; set; }
        public Nullable<bool> HasLimit { get; set; }
        public Nullable<decimal> LowerLimit { get; set; }
        public Nullable<decimal> UpperLimit { get; set; }
        public Nullable<bool> UseFormula { get; set; }
        public string TheFormula { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
    }
}
