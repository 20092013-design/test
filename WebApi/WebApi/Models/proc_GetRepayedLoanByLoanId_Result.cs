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
    
    public partial class proc_GetRepayedLoanByLoanId_Result
    {
        public int RepaymentId { get; set; }
        public Nullable<int> LoanId { get; set; }
        public Nullable<int> BankId { get; set; }
        public Nullable<int> CurrencyId { get; set; }
        public Nullable<int> SerialId { get; set; }
        public Nullable<int> BaseCurrencyId { get; set; }
        public Nullable<decimal> ExchangeRate { get; set; }
        public string RepaymentNo { get; set; }
        public System.DateTime TransactionDate { get; set; }
        public Nullable<System.DateTime> ValueDate { get; set; }
        public Nullable<int> TransType { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string PaymentMode { get; set; }
        public string VoucherNo { get; set; }
        public string ChequeNo { get; set; }
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
