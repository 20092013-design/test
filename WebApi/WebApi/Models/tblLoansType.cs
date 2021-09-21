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
    using System.Collections.Generic;
    
    public partial class tblLoansType
    {
        public int LoanTypeId { get; set; }
        public string RefCode { get; set; }
        public string Description { get; set; }
        public Nullable<int> MaxPeriod { get; set; }
        public Nullable<int> InterestRate { get; set; }
        public string InterestRateFrequency { get; set; }
        public Nullable<decimal> MinAmount { get; set; }
        public Nullable<decimal> MaxAmount { get; set; }
        public Nullable<decimal> IncomeFactor { get; set; }
        public Nullable<bool> ChargeInterestDuringGracePeriod { get; set; }
        public Nullable<decimal> SharesFactor { get; set; }
        public Nullable<int> MinGuarantors { get; set; }
        public Nullable<int> MaxGuarantors { get; set; }
        public string InterestPayMethod { get; set; }
        public Nullable<int> DefaultPenalty { get; set; }
        public string DefaultPenaltyFrequency { get; set; }
        public Nullable<int> Moratorium { get; set; }
        public Nullable<int> MinShares { get; set; }
        public string InterestCalFormula { get; set; }
        public Nullable<int> MinPeriod { get; set; }
        public Nullable<decimal> LoansFactor { get; set; }
        public string RepaymentFrequency { get; set; }
        public Nullable<int> GracePeriod { get; set; }
        public Nullable<bool> ApplyPenaltyAfterMaturity { get; set; }
        public Nullable<bool> IsSecure { get; set; }
        public Nullable<bool> Consider23rdRule { get; set; }
        public Nullable<bool> PreConsiderInterest { get; set; }
        public Nullable<bool> ForgoneInterest { get; set; }
        public Nullable<bool> AllowPartialDisbursements { get; set; }
        public Nullable<bool> AllowTopups { get; set; }
        public Nullable<bool> AdjustInterestRate { get; set; }
        public Nullable<bool> ConsiderLoanSeries { get; set; }
        public Nullable<bool> IsMarkupBased { get; set; }
        public Nullable<decimal> ForcedSaleValue { get; set; }
        public Nullable<bool> UseOfZeroShares { get; set; }
        public Nullable<decimal> MarginBaseAmount { get; set; }
        public string IncrementValue { get; set; }
        public Nullable<bool> IsMobileLoan { get; set; }
        public Nullable<bool> IsIncrementFactor { get; set; }
        public string NearestPrincipleRounding { get; set; }
        public string PrincipalRoundingType { get; set; }
        public string NearestInterestRounding { get; set; }
        public string InterestRoundingType { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
    }
}
