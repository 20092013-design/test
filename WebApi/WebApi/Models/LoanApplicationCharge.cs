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
    
    public partial class LoanApplicationCharge
    {
        public int LoanApplicationChargesId { get; set; }
        public Nullable<int> LoanId { get; set; }
        public Nullable<int> LoanTypeChargesId { get; set; }
        public Nullable<int> LoanChargesListId { get; set; }
        public Nullable<bool> IsPercentage { get; set; }
        public Nullable<bool> IsTariffBased { get; set; }
        public Nullable<decimal> Value { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] TimeStamp { get; set; }
        public System.Guid GUID { get; set; }
    
        public virtual tblLoan tblLoan { get; set; }
    }
}
