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
    
    public partial class proc_AddEditAutoGenPrefixe_Result
    {
        public int AutoPrefixId { get; set; }
        public string PrefixName { get; set; }
        public string PrefixText { get; set; }
        public bool IsSystemAssisted { get; set; }
        public bool IsDateRelated { get; set; }
        public bool Today { get; set; }
        public bool Month { get; set; }
        public bool Year { get; set; }
        public bool BranchPrefix { get; set; }
        public string UseBranchPrefix { get; set; }
        public string UseGroupPrefix { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreateBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public byte[] Timestamp { get; set; }
    }
}
