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
    
    public partial class proc_GetAllLoanRecoverOrders_Result
    {
        public int LoanRecoveryOrderId { get; set; }
        public string OrderName { get; set; }
        public int RecoveryOrder { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
        public System.Guid GUID { get; set; }
    }
}
