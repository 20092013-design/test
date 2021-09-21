using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class MemberShare
    {
        public int? MemberShareId { get; set; }
        public int? MemberId { get; set; }
        public int? ProductId { get; set; }
        public decimal? ContributionRate { get; set; }
        public decimal? MinBalance { get; set; }
        public DateTime? TransactionDate { get; set; }
        public bool? HideBalance { get; set; }
        public int? CurrencyId { get; set; }
        public bool? ExemptMobileCharges { get; set; }
        public string AccountNo { get; set; }
        public bool? isSuccess { get; set; }
        public string errorDescription { get; set; }


    }
}