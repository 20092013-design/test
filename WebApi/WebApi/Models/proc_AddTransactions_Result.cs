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
    
    public partial class proc_AddTransactions_Result
    {
        public int TransactionChargesId { get; set; }
        public Nullable<int> AccountTransactionId { get; set; }
        public Nullable<int> ChargesId { get; set; }
        public Nullable<int> TariffId { get; set; }
        public Nullable<bool> IsPercent { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
