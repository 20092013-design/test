using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal? MinDeposit { get; set; }
        public bool? MaxAmount { get; set; }
        public decimal? UpperLimit { get; set; }
        public bool? EarnDividends { get; set; }
        public decimal? DividendRate { get; set; }
        public bool? Withdrawn { get; set; }
        public bool? FixedDeposit { get; set; }
        public bool? Transferred { get; set; }
        public bool? GuaranteeLoan { get; set; }
        public string Frequency { get; set; }
        public bool? EarnInterest { get; set; }
        public bool? ChargeDefaulters { get; set; }
        public bool? MultAccounts { get; set; }
        public bool? CallDeposit { get; set; }
        public decimal? MinBalance { get; set; }
        public bool? AccrueInterestDaily { get; set; }
        public bool? isSuccess { get; set; }
        public string errorDescription { get; set; }
        public bool? CanBeOverdrawn { get; set; }
    }
    public class Charge
    {
        public int? ChargesId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public bool? Tariff { get; set; }
        public decimal? TariffAmount { get; set; }
        public bool? IsPercent { get; set; }
        public decimal? Value { get; set; }
        public bool? IgnoreLowLimit { get; set; }
        public decimal? LowerLimit { get; set; }
        public decimal? UpperLimit { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }

    public class Productcharge
    {
        public int? ProductChargeId { get; set; }
        public int? ProductId { get; set; }
        public int? ChargeId { get; set; }
        public int? ChargeType { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
}