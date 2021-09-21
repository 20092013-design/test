using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{

    public class Title
    {
        public int? TitleId { get; set; }
        public string TitleName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Nationality
    {
        public int? NationalityId { get; set; }
        public string NationalityName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Gender
    {
        public int? GenderId { get; set; }
        public string GenderName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Marital
    {
        public int? MaritalStatusId { get; set; }
        public string MaritalStatusName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Education
    {
        public int? LevelofEducationId { get; set; }
        public string LevelofEducationName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Member_Status
    {
        public int? MemberStatusId { get; set; }
        public string MemberStatusName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Bank
    {
        public int? BankId { get; set; }
        public string BankName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Bank_Branches
    {
        public int? BranchId { get; set; }
        public int? BankId { get; set; }
        public string BranchName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class Currency
    {
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencySymbol { get; set; }
        public bool? IsMainCurrency { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class CurrencyRate
    {
        public int? ExchangeRateId { get; set; }
        public decimal? BuyRate { get; set; }
        public decimal? SellRate { get; set; }
        public int? CurrencyId { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
        public int? BaseCurrencyId { get; set; }

    }
}