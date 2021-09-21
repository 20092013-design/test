using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Beneficiary
    {
        public int? BeneficiaryId { get; set; }
        public int? MemberId { get; set; }
        public int? RelationshipId { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }
        public decimal? Value { get; set; }
        public DateTime? DOB { get; set; }
        public string IdNo { get; set; }
        public string Remarks { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
}