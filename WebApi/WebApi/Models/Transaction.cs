using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class AccountTransaction
    {
        public int? AccountTransactionId { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public string MemberNo { get; set; }
        public string DocumentNo { get; set; }
        public int? ProductId { get; set; }
        public string ModeOfPayment { get; set; }
        public string TransType { get; set; }
        public int? BaseCurrencyId { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencySymbol { get; set; }
        public decimal? ExchangeRate { get; set; }
        public bool? Commission { get; set; }
        public string PaidBy { get; set; }
        public decimal? LocalCurrencyAmount { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
        public bool? IsPercent { get; set; }
        public decimal? AmountCharge { get; set; }
        public decimal? AmountBalances { get; set; }
        public int? ChargeId { get; set; }
        public bool? IsBlock { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public decimal? BalanceAmount { get; set; }



    }
    public class PaymentModes
    {
        public int? PaymentModeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? AllowBackDated { get; set; }
        public int? MaxDaysofBackDated { get; set; }
        public bool? CanDisburseLoan { get; set; }
        public bool? IsDefault { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
    public class Currency_ExchangeRate
    {
        public int? CurrencyId { get; set; }
        public decimal? BuyRate { get; set; }
        public int? ExchangeRateId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }



    }
    public class TransactionErrors
    {
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
    public class TransactionCharge
    {
        public int? TransactionChargesId { get; set; }
        public int? AccountTransactionId { get; set; }
        public int? ChargesId { get; set; }
        public bool? IsPercent { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Total { get; set; }

        public int? TariffId { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }


    }
    public class Tariff
    {
        public int? TariffId { get; set; }
        public int? ChargesId { get; set; }
        public decimal? Start { get; set; }
        public decimal? Stop { get; set; }
        public decimal? ChargeAmount { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
}