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
    
    public partial class tblBeneficiary
    {
        public int BeneficiaryId { get; set; }
        public int MemberId { get; set; }
        public int RelationshipId { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }
        public decimal Value { get; set; }
        public System.DateTime DOB { get; set; }
        public string IdNo { get; set; }
        public string Remarks { get; set; }
        public byte[] Timestamp { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public System.Guid GUID { get; set; }
    }
}
