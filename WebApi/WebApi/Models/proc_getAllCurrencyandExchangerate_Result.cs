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
    
    public partial class proc_getAllCurrencyandExchangerate_Result
    {
        public int CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public bool IsMainCurrency { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public int ExchangeRateId { get; set; }
        public decimal BuyRate { get; set; }
        public decimal SellRate { get; set; }
        public int CurrencyId1 { get; set; }
        public Nullable<System.DateTime> CreatedOn1 { get; set; }
        public string CreatedBy1 { get; set; }
        public Nullable<System.DateTime> ModifiedOn1 { get; set; }
        public string ModifiedBy1 { get; set; }
    }
}
