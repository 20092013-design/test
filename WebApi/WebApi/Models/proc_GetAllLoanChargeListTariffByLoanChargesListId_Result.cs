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
    
    public partial class proc_GetAllLoanChargeListTariffByLoanChargesListId_Result
    {
        public int LoanChargesListTariffId { get; set; }
        public Nullable<int> LoanChargesListId { get; set; }
        public Nullable<decimal> FromInterval { get; set; }
        public Nullable<decimal> ToInterval { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
    }
}
