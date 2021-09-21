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
    
    public partial class proc_GetRepaymentByLoanId_Result
    {
        public int RepaymentId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> LoanId { get; set; }
        public Nullable<int> BankId { get; set; }
        public string RepaymentNo { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<decimal> Principal { get; set; }
        public Nullable<decimal> Interest { get; set; }
        public string PaymentMode { get; set; }
        public string VoucherNo { get; set; }
        public Nullable<decimal> LoanAmount { get; set; }
        public Nullable<decimal> OtherCharges { get; set; }
        public Nullable<decimal> LoanBalance { get; set; }
        public Nullable<System.DateTime> RefDate { get; set; }
        public string ChequeNo { get; set; }
        public Nullable<bool> CalculateGrossAmount { get; set; }
        public Nullable<bool> AffectsMonthlySchedule { get; set; }
        public Nullable<bool> ClearLoans { get; set; }
        public Nullable<bool> RepaidByGuarantors { get; set; }
        public string PaidBy { get; set; }
        public string Remarks { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
    }
}
