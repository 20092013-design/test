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
    
    public partial class proc_GetAllKins_Result
    {
        public int KinId { get; set; }
        public Nullable<int> MemberId { get; set; }
        public Nullable<int> RelationId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string IdNo { get; set; }
        public string Remarks { get; set; }
        public byte[] Timestamp { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.Guid> GUID { get; set; }
    }
}