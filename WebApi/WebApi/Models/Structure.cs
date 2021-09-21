using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Structure
    {
        public int? StructureId { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        public string Remarks { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
    public class StructureValue
    {
        public int? StructureValueId { get; set; }
        public int? StructureId { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsGroup { get; set; }
        public string Remarks { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
    public class StructureGroupDetails
    {
        public int? StructureGroupId { get; set; }
        public int? StructureValueId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Retirement { get; set; }
        public string PostalAddress { get; set; }
        public int? NoofWeek { get; set; }
        public string EveryDayofWeek { get; set; }
        public int? DateOfMonth { get; set; }
        public bool? UseRefDate { get; set; }
        public int? MaximumMembership { get; set; }
        public decimal? ServiceCharge { get; set; }
        public int? CreditOfficerID { get; set; }
        public bool? LimitSavings { get; set; }
        public decimal? GroupLoanLimit { get; set; }
        public decimal? IndividualLoanLimit { get; set; }
        public string GroupPrefix { get; set; }
        public int? PrevNo { get; set; }
        public int? PreviousEmployerId { get; set; }
        public string SourceBranch { get; set; }
        public bool? Blocked { get; set; }
        public DateTime? DateBlocked { get; set; }
        public string Remarks { get; set; }
        public string Location { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
    public class CreditOfficer
    {
        public int? CreditOfficerId { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public DateTime? DateJoined { get; set; }
        public string IdNo { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Remarks { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
    public class stractureValueTree
    {
        public int? Id { get; set; }
        public string StructureCaption { get; set; }
        public string CurrentName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
    
}