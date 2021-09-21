using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Member
    {
        public int? MemberId { get; set; }
        public string Payroll { get; set; }
        public string MemberNo { get; set; }
        public string FullName { get; set; }
        public string SearchName { get; set; }
        public string IdNo { get; set; }
        public bool? IsPerson { get; set; }

        public string NHIFNo { get; set; }
        public string KRAPin { get; set; }
        public string NSSFNo { get; set; }
        public string HudumaNo { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int? TitleId { get; set; }
        public string Gender { get; set; }
        public int? MaritalStatusId { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNumber { get; set; }
        public string PhysicalLocation { get; set; }
        public string PostalAddress { get; set; }

        public int? MemberStatusId { get; set; }
        public bool? Blocked { get; set; }
        public int? LevelofEducationId { get; set; }
        public bool? IsRegister { get; set; }
        public bool? IsDormancy { get; set; }
        public string Remark { get; set; }
        public int? SecurityQuestion { get; set; }

        public string RegistrationCode { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? CompanyRegistrationDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CompanyCertificateNo { get; set; }
        public int? BankId { get; set; }
        public int? BankBranchId { get; set; }
        public string BankAccountNo { get; set; }
        public int? CurrencyId { get; set; }
        public string SecurityAnswer { get; set; }
        public int? HierarchyId { get; set; }
        public bool? Delete { get; set; }
        public decimal? GrossPay { get; set; }
        public decimal? NetPay { get; set; }
        public decimal? TotalShares { get; set; }
        public decimal? FreeShare { get; set; }
        
    }
    public partial class Contacts
    {
        public int? ContactId { get; set; }
        public string Payroll { get; set; }
        public int? MemberId { get; set; }
        public string FullName { get; set; }
        public string SearchName { get; set; }
        public string IdNo { get; set; }
        public bool? IsPerson { get; set; }
        public string NHIFNo { get; set; }
        public string KRAPin { get; set; }
        public string NSSFNo { get; set; }
        public string HudumaNo { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int? TitleId { get; set; }
        public string Gender { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Telephone1 { get; set; }
        public string Telephone2 { get; set; }
        public string Telephone3 { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNumber { get; set; }
        public string PhysicalLocation { get; set; }
        public string PostalAddress { get; set; }
        public int? MemberStatusId { get; set; }
        public bool? Blocked { get; set; }
        public int? LevelofEducationId { get; set; }
        public bool? IsRegister { get; set; }
        public bool? IsDormancy { get; set; }
        public string Remark { get; set; }
        public int? SecurityQuestion { get; set; }
        public string RegistrationCode { get; set; }
        public int? NationalityId { get; set; }
        public DateTime? CompanyRegistrationDate { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public string CompanyCertificateNo { get; set; }
        public int? BankId { get; set; }
        public int? BankBranchId { get; set; }
        public string BankAccountNo { get; set; }
        public int? CurrencyId { get; set; }
        public string SecurityAnswer { get; set; }
        public bool? Delete { get; set; }
        public bool? isSuccess { get; set; }
        public string errorDescription { get; set; }
    }
    public class Image
    {
        public int? FileId { get; set; }
        public string FileName { get; set; }
        public int? DocumentTypeId { get; set; }
        public bool? Delete { get; set; }
        public bool? isSuccess { get; set; }
        public string errorDescription { get; set; }

    }
}