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
    
    public partial class proc_getStructureTree_Result
    {
        public int Id { get; set; }
        public Nullable<int> CurrentId { get; set; }
        public string StructureCaption { get; set; }
        public string CurrentName { get; set; }
        public Nullable<int> ParId { get; set; }
        public Nullable<int> StructId { get; set; }
        public string ParentName { get; set; }
    }
}