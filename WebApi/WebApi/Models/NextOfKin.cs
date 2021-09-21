using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Kin
    {
        public int? KinId { get; set; }
        public int? MemberId { get; set; }
        public int? RelationId { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Town { get; set; }
        public DateTime? DOB { get; set; }
        public string IdNo { get; set; }
        public string Remarks { get; set; }
        public bool isSuccess { get; set; }
        public string errorDescription { get; set; }
    }


    public class Relation
    {
        public int? RelationId { get; set; }
        public string RelationName { get; set; }
        public bool isSuccess { get; set; }
        public string errorDescription { get; set; }
    }
}