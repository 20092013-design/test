using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MemberController : ApiController
    {
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }

        [Route("Member/AddMember"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddMember(string Payroll, string FullName, string SearchName, string IdNo, bool? IsPerson,
            string NHIFNo, string KRAPin, string NSSFNo, string HudumaNo, string Email, DateTime? DOB, int? TitleId, string Gender, int? MaritalStatusId,
             string Telephone1, string Telephone2, string Telephone3, string PhoneNo, string FaxNumber, string PhysicalLocation, string PostalAddress,
             int? MemberStatusId, bool? Blocked, int? LevelofEducationId, bool? IsRegister, bool? IsDormancy, string Remark, int? SecurityQuestion,
              string RegistrationCode, int NationalityId, DateTime? CompanyRegistrationDate, DateTime? RegistrationDate, string CompanyCertificateNo,
              int? BankId, int? BankBranchId, string BankAccountNo, int? CurrencyId, string SecurityAnswer, int? HierarchyId, decimal? GrossPay, decimal? NetPay, decimal? TotalShares, decimal? FreeShare, bool? Delete
             )
        {
            Member oNewMember = new Member();
            oNewMember.isSuccess = false;
            oNewMember.errorDescription = "";
            string MemberNo = null;
            if (Payroll == null) { Payroll = ""; }

            if (FullName == null) { FullName = ""; }
            if (SearchName == null) { SearchName = ""; }
            if (IdNo == null) { IdNo = ""; }
            if (NHIFNo == null) { NHIFNo = ""; }
            if (KRAPin == null) { KRAPin = ""; }
            if (NSSFNo == null) { NSSFNo = ""; }
            if (HudumaNo == null) { HudumaNo = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        oNewMember.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(oNewMember);
                    }
                }
            }
            if (TitleId == null) { TitleId = 0; }
            if (Gender == null) { Gender = ""; }
            if (MaritalStatusId == null) { MaritalStatusId = 0; }
            if (Telephone1 == null) { Telephone1 = ""; }
            if (Telephone2 == null) { Telephone2 = ""; }
            if (Telephone3 == null) { Telephone3 = ""; }
            if (PhoneNo == null) { PhoneNo = ""; }
            if (FaxNumber == null) { FaxNumber = ""; }
            if (PhysicalLocation == null) { PhysicalLocation = ""; }
            if (PostalAddress == null) { PostalAddress = ""; }
            if (MemberStatusId == null) { MemberStatusId = 0; }
            if (LevelofEducationId == null) { LevelofEducationId = 0; }
            if (Remark == null) { Remark = ""; }
            if (SecurityQuestion == null) { SecurityQuestion = 0; }
            if (RegistrationCode == null) { RegistrationCode = ""; }
            if (NationalityId == null) { NationalityId = 0; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (BankId == null) { BankId = 0; }

            if (BankBranchId == null) { BankBranchId = 0; }
            if (BankAccountNo == null) { BankAccountNo = ""; }
            if (CurrencyId == null) { CurrencyId = 0; }
            if (SecurityAnswer == null) { SecurityAnswer = ""; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (GrossPay == null) { GrossPay = 0; }
            if (NetPay == null) { NetPay = 0; }
            if (TotalShares == null) { TotalShares = 0; }
            if (FreeShare == null) { FreeShare = 0; }
            if (RegistrationDate == null) { RegistrationDate = DateTime.Parse("1900-01-01"); }
            if (DOB == null) { DOB = DateTime.Parse("1900-01-01"); }
            if (CompanyRegistrationDate == null) { CompanyRegistrationDate = DateTime.Parse("1900-01-01"); }
            if (IsPerson == true)
            {
                if (IdNo == "")
                {
                    oNewMember.errorDescription = "Id Number is required ****";
                    return Ok(oNewMember);
                }
                if (Gender == "")
                {
                    oNewMember.errorDescription = "Gender is required ****";
                    return Ok(oNewMember);
                }
            }
            if (PhoneNo.Length < 10)
            {
                oNewMember.errorDescription = "Phone number should a minimum of 10 characters";
                return Ok(oNewMember);

            }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblMembers.Any(p => p.IdNo == IdNo))
                    {
                        oNewMember.errorDescription = ("Id Number already exist in database. Please try again!");
                        return Ok(oNewMember);
                    }

                    MemberNo = db.proc_GenerateMemberNumber().FirstOrDefault();
                    var dbResult = db.proc_AddEditmember(0, Payroll, MemberNo, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                        TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                        LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                        BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, HierarchyId,GrossPay,NetPay,TotalShares,FreeShare, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewMember.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewMember.MemberId = dbResult.MemberId;
                    oNewMember.Payroll = dbResult.Payroll;
                    oNewMember.MemberNo = dbResult.MemberNo;
                    oNewMember.FullName = dbResult.FullName;
                    oNewMember.SearchName = dbResult.SearchName;
                    oNewMember.IdNo = dbResult.IdNo;
                    oNewMember.IsPerson = dbResult.IsPerson;
                    oNewMember.NHIFNo = dbResult.NHIFNo;
                    oNewMember.KRAPin = dbResult.KRAPin;
                    oNewMember.NSSFNo = dbResult.NSSFNo;
                    oNewMember.HudumaNo = dbResult.HudumaNo;
                    oNewMember.Email = dbResult.Email;
                    oNewMember.DOB = dbResult.DOB;
                    oNewMember.TitleId = dbResult.TitleId;
                    oNewMember.Gender = dbResult.Gender;
                    oNewMember.MaritalStatusId = dbResult.MaritalStatusId;
                    oNewMember.Telephone1 = dbResult.Telephone1;
                    oNewMember.Telephone2 = dbResult.Telephone2;
                    oNewMember.Telephone3 = dbResult.Telephone3;
                    oNewMember.PhoneNo = dbResult.PhoneNo;
                    oNewMember.FaxNumber = dbResult.FaxNumber;
                    oNewMember.PhysicalLocation = dbResult.PhysicalLocation;
                    oNewMember.PostalAddress = dbResult.PostalAddress;
                    oNewMember.PostalAddress = dbResult.PostalAddress;
                    oNewMember.MemberStatusId = dbResult.MemberStatusId;
                    oNewMember.Blocked = dbResult.Blocked;
                    oNewMember.LevelofEducationId = dbResult.LevelofEducationId;
                    oNewMember.IsRegister = dbResult.IsRegister;
                    oNewMember.IsDormancy = dbResult.IsDormancy;
                    oNewMember.Remark = dbResult.Remark;
                    oNewMember.SecurityQuestion = dbResult.SecurityQuestion;
                    oNewMember.RegistrationCode = dbResult.RegistrationCode;
                    oNewMember.NationalityId = dbResult.NationalityId;
                    oNewMember.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                    oNewMember.RegistrationDate = dbResult.RegistrationDate;
                    oNewMember.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                    oNewMember.BankId = dbResult.BankId;
                    oNewMember.BankBranchId = dbResult.BankBranchId;
                    oNewMember.BankAccountNo = dbResult.BankAccountNo;
                    oNewMember.CurrencyId = dbResult.CurrencyId;
                    oNewMember.SecurityAnswer = dbResult.SecurityAnswer;
                    oNewMember.HierarchyId = dbResult.HierarchyId;
                    oNewMember.isSuccess = true;
                    return Ok(oNewMember);
                }

            }
            catch (Exception ex)
            {
                oNewMember.errorDescription = ex.Message;
                return Ok(oNewMember);


            }

        }
        [Route("Member/UpdateMember"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateMember(int? MemberId, string Payroll, string MemberNo, string FullName, string SearchName, string IdNo, bool? IsPerson,
       string NHIFNo, string KRAPin, string NSSFNo, string HudumaNo, string Email, DateTime? DOB, int? TitleId, string Gender, int? MaritalStatusId,
        string Telephone1, string Telephone2, string Telephone3, string PhoneNo, string FaxNumber, string PhysicalLocation, string PostalAddress,
        int? MemberStatusId, bool? Blocked, int? LevelofEducationId, bool? IsRegister, bool? IsDormancy, string Remark, int? SecurityQuestion,
         string RegistrationCode, int NationalityId, DateTime? CompanyRegistrationDate, DateTime? RegistrationDate, string CompanyCertificateNo,
         int? BankId, int? BankBranchId, string BankAccountNo, int? CurrencyId, string SecurityAnswer, int? HierarchyId, decimal? GrossPay, decimal? NetPay, decimal? TotalShares, decimal? FreeShare, bool? Delete
        )
        {
            Member oNewMember = new Member();
            oNewMember.isSuccess = false;
            oNewMember.errorDescription = "";
            if (Payroll == null) { Payroll = ""; }
            if (MemberNo == null) { MemberNo = ""; }
            if (FullName == null) { FullName = ""; }
            if (SearchName == null) { SearchName = ""; }
            if (IdNo == null) { IdNo = ""; }
            if (NHIFNo == null) { NHIFNo = ""; }
            if (KRAPin == null) { KRAPin = ""; }
            if (NSSFNo == null) { NSSFNo = ""; }
            if (HudumaNo == null) { HudumaNo = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        oNewMember.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(oNewMember);
                    }
                }
            }
            if (TitleId == null) { TitleId = 0; }
            if (Gender == null) { Gender = ""; }
            if (MaritalStatusId == null) { MaritalStatusId = 0; }
            if (Telephone1 == null) { Telephone1 = ""; }
            if (Telephone2 == null) { Telephone2 = ""; }
            if (Telephone3 == null) { Telephone3 = ""; }
            if (PhoneNo == null) { PhoneNo = ""; }
            if (FaxNumber == null) { FaxNumber = ""; }
            if (PhysicalLocation == null) { PhysicalLocation = ""; }
            if (PostalAddress == null) { PostalAddress = ""; }
            if (MemberStatusId == null) { MemberStatusId = 0; }
            if (LevelofEducationId == null) { LevelofEducationId = 0; }
            if (Remark == null) { Remark = ""; }
            if (SecurityQuestion == null) { SecurityQuestion = 0; }
            if (RegistrationCode == null) { RegistrationCode = ""; }
            if (NationalityId == null) { NationalityId = 0; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (BankId == null) { BankId = 0; }
            if (BankBranchId == null) { BankBranchId = 0; }
            if (BankAccountNo == null) { BankAccountNo = ""; }
            if (CurrencyId == null) { CurrencyId = 0; }
            if (SecurityAnswer == null) { SecurityAnswer = ""; }
            if (GrossPay == null) { GrossPay = 0; }
            if (NetPay == null) { NetPay = 0; }
            if (TotalShares == null) { TotalShares = 0; }
            if (FreeShare == null) { FreeShare = 0; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (RegistrationDate == null) { RegistrationDate = DateTime.Parse("1900-01-01"); }
            if (DOB == null) { DOB = DateTime.Parse("1900-01-01"); }
            if (CompanyRegistrationDate == null) { CompanyRegistrationDate = DateTime.Parse("1900-01-01"); }
            if (IsPerson == true)
            {
                if (IdNo == "")
                {
                    oNewMember.errorDescription = "Id Number is required ****";
                    return Ok(oNewMember);
                }
                if (Gender == "")
                {
                    oNewMember.errorDescription = "Gender is required ****";
                    return Ok(oNewMember);
                }
            }
            if(PhoneNo.Length <10)
            {
                oNewMember.errorDescription = "Phone number should a minimum of 10 characters";
                return Ok(oNewMember);

            }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblMembers.Any(p => p.IdNo == IdNo))
                    {



                       var member = (from a in db.tblMembers
                                      where a.IdNo == IdNo
                                      select new
                                      { a.MemberId }).FirstOrDefault();
                        if (member.MemberId == MemberId)
                        {
                            var dbResult = db.proc_AddEditmembers(MemberId, Payroll, MemberNo, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                   TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                   LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                   BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, HierarchyId, GrossPay, NetPay, TotalShares, FreeShare, Delete = false).FirstOrDefault();
                            if (dbResult == null)
                            {
                                oNewMember.errorDescription = "Process failed. Please confirm user detail and try again";
                                return Ok(dbResult);
                            }
                            oNewMember.MemberId = dbResult.MemberId;
                            oNewMember.Payroll = dbResult.Payroll;
                            oNewMember.MemberNo = dbResult.MemberNo;
                            oNewMember.FullName = dbResult.FullName;
                            oNewMember.SearchName = dbResult.SearchName;
                            oNewMember.IdNo = dbResult.IdNo;
                            oNewMember.IsPerson = dbResult.IsPerson;
                            oNewMember.NHIFNo = dbResult.NHIFNo;
                            oNewMember.KRAPin = dbResult.KRAPin;
                            oNewMember.NSSFNo = dbResult.NSSFNo;
                            oNewMember.HudumaNo = dbResult.HudumaNo;
                            oNewMember.Email = dbResult.Email;
                            oNewMember.DOB = dbResult.DOB;
                            oNewMember.TitleId = dbResult.TitleId;
                            oNewMember.Gender = dbResult.Gender;
                            oNewMember.MaritalStatusId = dbResult.MaritalStatusId;
                            oNewMember.Telephone1 = dbResult.Telephone1;
                            oNewMember.Telephone2 = dbResult.Telephone2;
                            oNewMember.Telephone3 = dbResult.Telephone3;
                            oNewMember.PhoneNo = dbResult.PhoneNo;
                            oNewMember.FaxNumber = dbResult.FaxNumber;
                            oNewMember.PhysicalLocation = dbResult.PhysicalLocation;
                            oNewMember.PostalAddress = dbResult.PostalAddress;
                            oNewMember.PostalAddress = dbResult.PostalAddress;
                            oNewMember.MemberStatusId = dbResult.MemberStatusId;
                            oNewMember.Blocked = dbResult.Blocked;
                            oNewMember.LevelofEducationId = dbResult.LevelofEducationId;
                            oNewMember.IsRegister = dbResult.IsRegister;
                            oNewMember.IsDormancy = dbResult.IsDormancy;
                            oNewMember.Remark = dbResult.Remark;
                            oNewMember.SecurityQuestion = dbResult.SecurityQuestion;
                            oNewMember.RegistrationCode = dbResult.RegistrationCode;
                            oNewMember.NationalityId = dbResult.NationalityId;
                            oNewMember.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                            oNewMember.RegistrationDate = dbResult.RegistrationDate;
                            oNewMember.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                            oNewMember.BankId = dbResult.BankId;
                            oNewMember.BankBranchId = dbResult.BankBranchId;
                            oNewMember.BankAccountNo = dbResult.BankAccountNo;
                            oNewMember.CurrencyId = dbResult.CurrencyId;
                            oNewMember.SecurityAnswer = dbResult.SecurityAnswer;
                            oNewMember.HierarchyId = dbResult.HierarchyId;
                            oNewMember.GrossPay = dbResult.Gross;
                            oNewMember.NetPay = dbResult.Nett;
                            oNewMember.TotalShares = dbResult.TotalShares;
                            oNewMember.FreeShare = dbResult.FreeShare;
                            oNewMember.isSuccess = true;
                            return Ok(oNewMember);

                        }
                        else
                        {
                            oNewMember.errorDescription = ("Id Number already exist in database. Please try again!");
                            return Ok(oNewMember);

                        }
                    }
                    else
                    {
                        var dbResult = db.proc_AddEditmembers(MemberId, Payroll, MemberNo, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                      TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                      LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                      BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, HierarchyId, GrossPay, NetPay, TotalShares, FreeShare, Delete = false).FirstOrDefault();
                        if (dbResult == null)
                        {
                            oNewMember.errorDescription = "Process failed. Please confirm user detail and try again";
                            return Ok(dbResult);
                        }
                        oNewMember.MemberId = dbResult.MemberId;
                        oNewMember.Payroll = dbResult.Payroll;
                        oNewMember.MemberNo = dbResult.MemberNo;
                        oNewMember.FullName = dbResult.FullName;
                        oNewMember.SearchName = dbResult.SearchName;
                        oNewMember.IdNo = dbResult.IdNo;
                        oNewMember.IsPerson = dbResult.IsPerson;
                        oNewMember.NHIFNo = dbResult.NHIFNo;
                        oNewMember.KRAPin = dbResult.KRAPin;
                        oNewMember.NSSFNo = dbResult.NSSFNo;
                        oNewMember.HudumaNo = dbResult.HudumaNo;
                        oNewMember.Email = dbResult.Email;
                        oNewMember.DOB = dbResult.DOB;
                        oNewMember.TitleId = dbResult.TitleId;
                        oNewMember.Gender = dbResult.Gender;
                        oNewMember.MaritalStatusId = dbResult.MaritalStatusId;
                        oNewMember.Telephone1 = dbResult.Telephone1;
                        oNewMember.Telephone2 = dbResult.Telephone2;
                        oNewMember.Telephone3 = dbResult.Telephone3;
                        oNewMember.PhoneNo = dbResult.PhoneNo;
                        oNewMember.FaxNumber = dbResult.FaxNumber;
                        oNewMember.PhysicalLocation = dbResult.PhysicalLocation;
                        oNewMember.PostalAddress = dbResult.PostalAddress;
                        oNewMember.PostalAddress = dbResult.PostalAddress;
                        oNewMember.MemberStatusId = dbResult.MemberStatusId;
                        oNewMember.Blocked = dbResult.Blocked;
                        oNewMember.LevelofEducationId = dbResult.LevelofEducationId;
                        oNewMember.IsRegister = dbResult.IsRegister;
                        oNewMember.IsDormancy = dbResult.IsDormancy;
                        oNewMember.Remark = dbResult.Remark;
                        oNewMember.SecurityQuestion = dbResult.SecurityQuestion;
                        oNewMember.RegistrationCode = dbResult.RegistrationCode;
                        oNewMember.NationalityId = dbResult.NationalityId;
                        oNewMember.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                        oNewMember.RegistrationDate = dbResult.RegistrationDate;
                        oNewMember.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                        oNewMember.BankId = dbResult.BankId;
                        oNewMember.BankBranchId = dbResult.BankBranchId;
                        oNewMember.BankAccountNo = dbResult.BankAccountNo;
                        oNewMember.CurrencyId = dbResult.CurrencyId;
                        oNewMember.SecurityAnswer = dbResult.SecurityAnswer;
                        oNewMember.HierarchyId = dbResult.HierarchyId;
                        oNewMember.GrossPay = dbResult.Gross;
                        oNewMember.NetPay = dbResult.Nett;
                        oNewMember.TotalShares = dbResult.TotalShares;
                        oNewMember.FreeShare = dbResult.FreeShare;
                        oNewMember.isSuccess = true;
                        return Ok(oNewMember);

                    }

                }

            }
            catch (Exception ex)
            {
                oNewMember.errorDescription = ex.Message;
                return Ok(oNewMember);


            }

        }

        [Route("Member/getAllMembers")]
        public async Task<IHttpActionResult> getAllMembers()
        {
            Member oMember = new Member();
            oMember.isSuccess = false;
            oMember.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetALlMembers().ToList();
                    List<Member> listofmembers = new List<Member>();
                    foreach (var items in DbResult)
                    {
                        Member oNewMember = new Member();
                        oNewMember.MemberId = items.MemberId;
                        oNewMember.Payroll = items.Payroll;
                        oNewMember.MemberNo = items.MemberNo;
                        oNewMember.FullName = items.FullName;
                        oNewMember.SearchName = items.SearchName;
                        oNewMember.RegistrationDate = items.RegistrationDate;
                        oNewMember.IdNo = items.IdNo;
                        oNewMember.IsPerson = items.IsPerson;
                        oNewMember.NHIFNo = items.NHIFNo;
                        oNewMember.KRAPin = items.KRAPin;
                        oNewMember.HudumaNo = items.HudumaNo;
                        oNewMember.Email = items.Email;
                        oNewMember.DOB = items.DOB;
                        oNewMember.TitleId = items.TitleId;
                        oNewMember.Gender = items.Gender;
                        oNewMember.MaritalStatusId = items.MaritalStatusId;
                        oNewMember.Telephone1 = items.Telephone1;
                        oNewMember.Telephone2 = items.Telephone2;
                        oNewMember.Telephone3 = items.Telephone3;
                        oNewMember.PhoneNo = items.PhoneNo;
                        oNewMember.FaxNumber = items.FaxNumber;
                        oNewMember.PhysicalLocation = items.PhysicalLocation;
                        oNewMember.PostalAddress = items.PostalAddress;
                        oNewMember.MemberStatusId = items.MemberStatusId;
                        oNewMember.Blocked = items.Blocked;
                        oNewMember.LevelofEducationId = items.LevelofEducationId;
                        oNewMember.IsRegister = items.IsRegister;
                        oNewMember.IsDormancy = items.IsDormancy;
                        oNewMember.Remark = items.Remark;
                        oNewMember.SecurityQuestion = items.SecurityQuestion;
                        oNewMember.RegistrationCode = items.RegistrationCode;
                        oNewMember.NationalityId = items.NationalityId;
                        oNewMember.CompanyRegistrationDate = items.CompanyRegistrationDate;
                        oNewMember.CompanyCertificateNo = items.CompanyCertificateNo;
                        oNewMember.BankId = items.BankId;
                        oNewMember.BankBranchId = items.BankBranchId;
                        oNewMember.BankAccountNo = items.BankAccountNo;
                        oNewMember.CurrencyId = items.CurrencyId;
                        oNewMember.SecurityAnswer = items.SecurityAnswer;
                        oNewMember.HierarchyId = items.HierarchyId;
                        oNewMember.GrossPay = items.Gross;
                        oNewMember.NetPay = items.Nett;
                        oNewMember.TotalShares = items.TotalShares;
                        oNewMember.FreeShare = items.FreeShare;
                        oNewMember.errorDescription = "";
                        oNewMember.isSuccess = true;
                        listofmembers.Add(oNewMember);
                    }
                    IEnumerable<Member> myMember = listofmembers;
                    return Ok(myMember);

                }

            }
            catch (Exception ex)
            {
                oMember.errorDescription = ex.Message;
                return Ok(oMember);

            }

        }
        [Route("Member/getMember")]
        public async Task<IHttpActionResult> getMember(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var member = (from a in db.tblMembers
                              where a.MemberId == id
                              select new
                              {
                                  a.MemberId,
                                  a.Payroll,
                                  a.MemberNo,
                                  a.FullName,
                                  a.SearchName,
                                  a.IdNo,
                                  a.IsPerson,
                                  a.NHIFNo,
                                  a.KRAPin,
                                  a.NSSFNo,
                                  a.HudumaNo,
                                  a.Email,
                                  a.DOB,
                                  a.TitleId,
                                  a.Gender,
                                  a.MaritalStatusId,
                                  a.Telephone1,
                                  a.Telephone2,
                                  a.Telephone3,
                                  a.PhoneNo,
                                  a.FaxNumber,
                                  a.PhysicalLocation,
                                  a.PostalAddress,
                                  a.MemberStatusId,
                                  a.Blocked,
                                  a.LevelofEducationId,
                                  a.IsRegister,
                                  a.IsDormancy,
                                  a.Remark,
                                  a.SecurityQuestion,
                                  a.RegistrationCode,
                                  a.NationalityId,
                                  a.CompanyRegistrationDate,
                                  a.RegistrationDate,
                                  a.CompanyCertificateNo,
                                  a.BankId,
                                  a.BankBranchId,
                                  a.BankAccountNo,
                                  a.CurrencyId,
                                  a.SecurityAnswer,
                                  a.HierarchyId,
                                  a.FreeShare,
                                  a.TotalShares,
                                  a.Gross,
                                  a.Nett,

                              }).FirstOrDefault();
                return Ok(new { member });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Member/DeleteMember")]
        public IHttpActionResult DeleteMember(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblMember member = db.tblMembers.SingleOrDefault(x => x.MemberId == id);
                db.tblMembers.Remove(member);
                db.SaveChanges();
                return Ok(member);
            }


        }


        [Route("Api/AddContact"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddContact(string Payroll, int MemberId, string FullName, string SearchName, string IdNo, bool? IsPerson,
        string NHIFNo, string KRAPin, string NSSFNo, string HudumaNo, string Email, DateTime? DOB, int? TitleId, string Gender, int? MaritalStatusId,
        string Telephone1, string Telephone2, string Telephone3, string PhoneNo, string FaxNumber, string PhysicalLocation, string PostalAddress,
        int? MemberStatusId, bool? Blocked, int? LevelofEducationId, bool? IsRegister, bool? IsDormancy, string Remark, int? SecurityQuestion,
        string RegistrationCode, int NationalityId, DateTime? CompanyRegistrationDate, DateTime? RegistrationDate, string CompanyCertificateNo,
        int? BankId, int? BankBranchId, string BankAccountNo, int? CurrencyId, string SecurityAnswer, bool? Delete
    )

        {
            Contacts oNewContact = new Contacts();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";

            if (Payroll == null) { Payroll = ""; }
            if (MemberId == null) { MemberId = 0; }
            if (FullName == null) { FullName = ""; }
            if (SearchName == null) { SearchName = ""; }
            if (IdNo == null) { IdNo = ""; }
            if (NHIFNo == null) { NHIFNo = ""; }
            if (KRAPin == null) { KRAPin = ""; }
            if (NSSFNo == null) { NSSFNo = ""; }
            if (HudumaNo == null) { HudumaNo = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        oNewContact.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(oNewContact);
                    }
                }
            }
            if (TitleId == null) { TitleId = 0; }
            if (Gender == null) { Gender = ""; }
            if (MaritalStatusId == null) { MaritalStatusId = 0; }
            if (Telephone1 == null) { Telephone1 = ""; }
            if (Telephone2 == null) { Telephone2 = ""; }
            if (Telephone3 == null) { Telephone3 = ""; }
            if (PhoneNo == null) { PhoneNo = ""; }
            if (FaxNumber == null) { FaxNumber = ""; }
            if (PhysicalLocation == null) { PhysicalLocation = ""; }
            if (PostalAddress == null) { PostalAddress = ""; }
            if (MemberStatusId == null) { MemberStatusId = 0; }
            if (LevelofEducationId == null) { LevelofEducationId = 0; }
            if (Remark == null) { Remark = ""; }
            if (SecurityQuestion == null) { SecurityQuestion = 0; }
            if (RegistrationCode == null) { RegistrationCode = ""; }
            if (NationalityId == null) { NationalityId = 0; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (BankId == null) { BankId = 0; }
            if (BankBranchId == null) { BankBranchId = 0; }
            if (BankAccountNo == null) { BankAccountNo = ""; }
            if (CurrencyId == null) { CurrencyId = 0; }
            if (SecurityAnswer == null) { SecurityAnswer = ""; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (RegistrationDate == null) { RegistrationDate = DateTime.Parse("1900-01-01"); }
            if (DOB == null) { DOB = DateTime.Parse("1900-01-01"); }
            if (CompanyRegistrationDate == null) { CompanyRegistrationDate = DateTime.Parse("1900-01-01"); }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblContacts.Any(p => p.IdNo == IdNo))
                    {
                        oNewContact.errorDescription = ("Id Number already exist in database. Please try again!");
                        return Ok(oNewContact);
                    }

                    var dbResult = db.proc_AddEditContacts(0, Payroll, MemberId, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                    TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                    LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                    BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewContact.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }

                    oNewContact.Payroll = dbResult.Payroll;
                    oNewContact.MemberId = dbResult.MemberId;
                    oNewContact.FullName = dbResult.FullName;
                    oNewContact.SearchName = dbResult.SearchName;
                    oNewContact.IdNo = dbResult.IdNo;
                    oNewContact.IsPerson = dbResult.IsPerson;
                    oNewContact.NHIFNo = dbResult.NHIFNo;
                    oNewContact.KRAPin = dbResult.KRAPin;
                    oNewContact.NSSFNo = dbResult.NSSFNo;
                    oNewContact.HudumaNo = dbResult.HudumaNo;
                    oNewContact.Email = dbResult.Email;
                    oNewContact.DOB = dbResult.DOB;
                    oNewContact.TitleId = dbResult.TitleId;
                    oNewContact.Gender = dbResult.Gender;
                    oNewContact.MaritalStatusId = dbResult.MaritalStatusId;
                    oNewContact.Telephone1 = dbResult.Telephone1;
                    oNewContact.Telephone2 = dbResult.Telephone2;
                    oNewContact.Telephone3 = dbResult.Telephone3;
                    oNewContact.PhoneNo = dbResult.PhoneNo;
                    oNewContact.FaxNumber = dbResult.FaxNumber;
                    oNewContact.PhysicalLocation = dbResult.PhysicalLocation;
                    oNewContact.PostalAddress = dbResult.PostalAddress;
                    oNewContact.MemberStatusId = dbResult.MemberStatusId;
                    oNewContact.Blocked = dbResult.Blocked;
                    oNewContact.LevelofEducationId = dbResult.LevelofEducationId;
                    oNewContact.IsRegister = dbResult.IsRegister;
                    oNewContact.IsDormancy = dbResult.IsDormancy;
                    oNewContact.Remark = dbResult.Remark;
                    oNewContact.SecurityQuestion = dbResult.SecurityQuestion;
                    oNewContact.RegistrationCode = dbResult.RegistrationCode;
                    oNewContact.NationalityId = dbResult.NationalityId;
                    oNewContact.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                    oNewContact.RegistrationDate = dbResult.RegistrationDate;
                    oNewContact.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                    oNewContact.BankId = dbResult.BankId;
                    oNewContact.BankBranchId = dbResult.BankBranchId;
                    oNewContact.BankAccountNo = dbResult.BankAccountNo;
                    oNewContact.CurrencyId = dbResult.CurrencyId;
                    oNewContact.SecurityAnswer = dbResult.SecurityAnswer;
                    oNewContact.isSuccess = true;
                    return Ok(oNewContact);
                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }
        }



        //Update
        [Route("Api/UpdateContact"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateContact(int ContactId, string Payroll, int MemberId, string FullName, string SearchName, string IdNo, bool? IsPerson,
        string NHIFNo, string KRAPin, string NSSFNo, string HudumaNo, string Email, DateTime? DOB, int? TitleId, string Gender, int? MaritalStatusId,
        string Telephone1, string Telephone2, string Telephone3, string PhoneNo, string FaxNumber, string PhysicalLocation, string PostalAddress,
        int? MemberStatusId, bool? Blocked, int? LevelofEducationId, bool? IsRegister, bool? IsDormancy, string Remark, int? SecurityQuestion,
        string RegistrationCode, int NationalityId, DateTime? CompanyRegistrationDate, DateTime? RegistrationDate, string CompanyCertificateNo,
        int? BankId, int? BankBranchId, string BankAccountNo, int? CurrencyId, string SecurityAnswer, bool? Delete
           )

        {
            Contacts oNewContact = new Contacts();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";

            if (Payroll == null) { Payroll = ""; }
            if (MemberId == null) { MemberId = 0; }
            if (FullName == null) { FullName = ""; }
            if (SearchName == null) { SearchName = ""; }
            if (IdNo == null) { IdNo = ""; }
            if (NHIFNo == null) { NHIFNo = ""; }
            if (KRAPin == null) { KRAPin = ""; }
            if (NSSFNo == null) { NSSFNo = ""; }
            if (HudumaNo == null) { HudumaNo = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        oNewContact.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(oNewContact);
                    }
                }
            }

            if (TitleId == null) { TitleId = 0; }
            if (Gender == null) { Gender = ""; }
            if (MaritalStatusId == null) { MaritalStatusId = 0; }
            if (Telephone1 == null) { Telephone1 = ""; }
            if (Telephone2 == null) { Telephone2 = ""; }
            if (Telephone3 == null) { Telephone3 = ""; }
            if (PhoneNo == null) { PhoneNo = ""; }
            if (FaxNumber == null) { FaxNumber = ""; }
            if (PhysicalLocation == null) { PhysicalLocation = ""; }
            if (PostalAddress == null) { PostalAddress = ""; }
            if (MemberStatusId == null) { MemberStatusId = 0; }
            if (LevelofEducationId == null) { LevelofEducationId = 0; }
            if (Remark == null) { Remark = ""; }
            if (SecurityQuestion == null) { SecurityQuestion = 0; }
            if (RegistrationCode == null) { RegistrationCode = ""; }
            if (NationalityId == null) { NationalityId = 0; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (BankId == null) { BankId = 0; }
            if (BankBranchId == null) { BankBranchId = 0; }
            if (BankAccountNo == null) { BankAccountNo = ""; }
            if (CurrencyId == null) { CurrencyId = 0; }
            if (SecurityAnswer == null) { SecurityAnswer = ""; }
            if (CompanyCertificateNo == null) { CompanyCertificateNo = ""; }
            if (RegistrationDate == null) { RegistrationDate = DateTime.Parse("1900-01-01"); }
            if (DOB == null) { DOB = DateTime.Parse("1900-01-01"); }
            if (CompanyRegistrationDate == null) { CompanyRegistrationDate = DateTime.Parse("1900-01-01"); }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblContacts.Any(p => p.IdNo == IdNo))

                    {
                        var contact = (from a in db.tblContacts
                                       where a.IdNo == IdNo
                                       select new
                                       { a.ContactId }).FirstOrDefault();
                        if (contact.ContactId == ContactId)
                        {
                            var dbResult = db.proc_AddEditContacts(ContactId, Payroll, MemberId, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, Delete = false).FirstOrDefault();
                            if (dbResult == null)
                            {
                                oNewContact.errorDescription = "Process failed. Please confirm user detail and try again";
                                return Ok(dbResult);
                            }
                            oNewContact.ContactId = dbResult.ContactId;
                            oNewContact.Payroll = dbResult.Payroll;
                            oNewContact.MemberId = dbResult.MemberId;
                            oNewContact.FullName = dbResult.FullName;
                            oNewContact.SearchName = dbResult.SearchName;
                            oNewContact.IdNo = dbResult.IdNo;
                            oNewContact.IsPerson = dbResult.IsPerson;
                            oNewContact.NHIFNo = dbResult.NHIFNo;
                            oNewContact.KRAPin = dbResult.NHIFNo;
                            oNewContact.NSSFNo = dbResult.NSSFNo;
                            oNewContact.HudumaNo = dbResult.HudumaNo;
                            oNewContact.Email = dbResult.Email;
                            oNewContact.DOB = dbResult.DOB;
                            oNewContact.TitleId = dbResult.TitleId;
                            oNewContact.Gender = dbResult.Gender;
                            oNewContact.MaritalStatusId = dbResult.MaritalStatusId;
                            oNewContact.Telephone1 = dbResult.Telephone1;
                            oNewContact.Telephone2 = dbResult.Telephone2;
                            oNewContact.Telephone3 = dbResult.Telephone3;
                            oNewContact.PhoneNo = dbResult.PhoneNo;
                            oNewContact.FaxNumber = dbResult.FaxNumber;
                            oNewContact.PhysicalLocation = dbResult.PhysicalLocation;
                            oNewContact.PostalAddress = dbResult.PostalAddress;
                            oNewContact.MemberStatusId = dbResult.MemberStatusId;
                            oNewContact.Blocked = dbResult.Blocked;
                            oNewContact.LevelofEducationId = dbResult.LevelofEducationId;
                            oNewContact.IsRegister = dbResult.IsRegister;
                            oNewContact.IsDormancy = dbResult.IsDormancy;
                            oNewContact.Remark = dbResult.Remark;
                            oNewContact.SecurityQuestion = dbResult.SecurityQuestion;
                            oNewContact.RegistrationCode = dbResult.RegistrationCode;
                            oNewContact.NationalityId = dbResult.NationalityId;
                            oNewContact.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                            oNewContact.RegistrationDate = dbResult.RegistrationDate;
                            oNewContact.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                            oNewContact.BankId = dbResult.BankId;
                            oNewContact.BankBranchId = dbResult.BankBranchId;
                            oNewContact.BankAccountNo = dbResult.BankAccountNo;
                            oNewContact.CurrencyId = dbResult.CurrencyId;
                            oNewContact.SecurityAnswer = dbResult.SecurityAnswer;
                            oNewContact.isSuccess = true;
                            return Ok(oNewContact);
                        }
                        else
                        {
                            oNewContact.errorDescription = ("Id Number already exist in database. Please try again!");
                            return Ok(oNewContact);

                        }
                    }
                    else
                    {
                        var dbResult = db.proc_AddEditContacts(ContactId, Payroll, MemberId, FullName, SearchName, IdNo, IsPerson, NHIFNo, KRAPin, NSSFNo, HudumaNo, Email, DOB,
                 TitleId, Gender, MaritalStatusId, Telephone1, Telephone2, Telephone3, PhoneNo, FaxNumber, PhysicalLocation, PostalAddress, MemberStatusId, Blocked,
                 LevelofEducationId, IsRegister, IsDormancy, Remark, SecurityQuestion, RegistrationCode, NationalityId, CompanyRegistrationDate, RegistrationDate, CompanyCertificateNo,
                 BankId, BankBranchId, BankAccountNo, CurrencyId, SecurityAnswer, Delete = false).FirstOrDefault();
                        if (dbResult == null)
                        {
                            oNewContact.errorDescription = "Process failed. Please confirm user detail and try again";
                            return Ok(dbResult);
                        }
                        oNewContact.ContactId = dbResult.ContactId;
                        oNewContact.Payroll = dbResult.Payroll;
                        oNewContact.MemberId = dbResult.MemberId;
                        oNewContact.FullName = dbResult.FullName;
                        oNewContact.SearchName = dbResult.SearchName;
                        oNewContact.IdNo = dbResult.IdNo;
                        oNewContact.IsPerson = dbResult.IsPerson;
                        oNewContact.NHIFNo = dbResult.NHIFNo;
                        oNewContact.KRAPin = dbResult.NHIFNo;
                        oNewContact.NSSFNo = dbResult.NSSFNo;
                        oNewContact.HudumaNo = dbResult.HudumaNo;
                        oNewContact.Email = dbResult.Email;
                        oNewContact.DOB = dbResult.DOB;
                        oNewContact.TitleId = dbResult.TitleId;
                        oNewContact.Gender = dbResult.Gender;
                        oNewContact.MaritalStatusId = dbResult.MaritalStatusId;
                        oNewContact.Telephone1 = dbResult.Telephone1;
                        oNewContact.Telephone2 = dbResult.Telephone2;
                        oNewContact.Telephone3 = dbResult.Telephone3;
                        oNewContact.PhoneNo = dbResult.PhoneNo;
                        oNewContact.FaxNumber = dbResult.FaxNumber;
                        oNewContact.PhysicalLocation = dbResult.PhysicalLocation;
                        oNewContact.PostalAddress = dbResult.PostalAddress;
                        oNewContact.MemberStatusId = dbResult.MemberStatusId;
                        oNewContact.Blocked = dbResult.Blocked;
                        oNewContact.LevelofEducationId = dbResult.LevelofEducationId;
                        oNewContact.IsRegister = dbResult.IsRegister;
                        oNewContact.IsDormancy = dbResult.IsDormancy;
                        oNewContact.Remark = dbResult.Remark;
                        oNewContact.SecurityQuestion = dbResult.SecurityQuestion;
                        oNewContact.RegistrationCode = dbResult.RegistrationCode;
                        oNewContact.NationalityId = dbResult.NationalityId;
                        oNewContact.CompanyRegistrationDate = dbResult.CompanyRegistrationDate;
                        oNewContact.RegistrationDate = dbResult.RegistrationDate;
                        oNewContact.CompanyCertificateNo = dbResult.CompanyCertificateNo;
                        oNewContact.BankId = dbResult.BankId;
                        oNewContact.BankBranchId = dbResult.BankBranchId;
                        oNewContact.BankAccountNo = dbResult.BankAccountNo;
                        oNewContact.CurrencyId = dbResult.CurrencyId;
                        oNewContact.SecurityAnswer = dbResult.SecurityAnswer;
                        oNewContact.isSuccess = true;
                        return Ok(oNewContact);

                    }


                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }
        }


        [Route("Api/GetAllContacts")]
        public IHttpActionResult getAllContacts()
        {

            Contacts contact = new Contacts();
            contact.isSuccess = false;
            contact.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllContacts().ToList();
                    List<Contacts> listofcontacts = new List<Contacts>();
                    foreach (var items in dbResult)
                    {
                        Contacts oContact = new Contacts();

                        oContact.ContactId = items.ContactId;
                        oContact.Payroll = items.Payroll;
                        oContact.MemberId = items.MemberId;
                        oContact.FullName = items.FullName;
                        oContact.SearchName = items.SearchName;
                        oContact.IdNo = items.IdNo;
                        oContact.IsPerson = items.IsPerson;
                        oContact.NHIFNo = items.NHIFNo;
                        oContact.KRAPin = items.KRAPin;
                        oContact.NSSFNo = items.NSSFNo;
                        oContact.HudumaNo = items.HudumaNo;
                        oContact.Email = items.Email;
                        oContact.DOB = items.DOB;
                        oContact.TitleId = items.TitleId;
                        oContact.Gender = items.Gender;
                        oContact.MaritalStatusId = items.MaritalStatusId;
                        oContact.Telephone1 = items.Telephone1;
                        oContact.Telephone2 = items.Telephone2;
                        oContact.Telephone3 = items.Telephone3;
                        oContact.PhoneNo = items.PhoneNo;
                        oContact.FaxNumber = items.FaxNumber;
                        oContact.PhysicalLocation = items.PhysicalLocation;
                        oContact.PostalAddress = items.PostalAddress;
                        oContact.PostalAddress = items.PostalAddress;
                        oContact.MemberStatusId = items.MemberStatusId;
                        oContact.Blocked = items.Blocked;
                        oContact.LevelofEducationId = items.LevelofEducationId;
                        oContact.IsRegister = items.IsRegister;
                        oContact.IsDormancy = items.IsDormancy;
                        oContact.Remark = items.Remark;
                        oContact.SecurityQuestion = items.SecurityQuestion;
                        oContact.RegistrationCode = items.RegistrationCode;
                        oContact.NationalityId = items.NationalityId;
                        oContact.CompanyRegistrationDate = items.CompanyRegistrationDate;
                        oContact.RegistrationDate = items.RegistrationDate;
                        oContact.CompanyCertificateNo = items.CompanyCertificateNo;
                        oContact.BankId = items.BankId;
                        oContact.BankBranchId = items.BankBranchId;
                        oContact.BankAccountNo = items.BankAccountNo;
                        oContact.CurrencyId = items.CurrencyId;
                        oContact.SecurityAnswer = items.SecurityAnswer;
                        oContact.isSuccess = true;
                        oContact.errorDescription = "";

                        listofcontacts.Add(oContact);
                    }
                    IEnumerable<Contacts> myContacts = listofcontacts;
                    return Ok(myContacts);

                }
            }
            catch (Exception ex)
            {
                contact.errorDescription = ex.Message;
                return Ok(contact);

            }

        }


        [Route("Api/GetContact")]
        public async Task<IHttpActionResult> getContact(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var contact = (from a in db.tblContacts
                               where a.ContactId == id
                               select new
                               {
                                   a.ContactId,
                                   a.Payroll,
                                   a.MemberId,
                                   a.FullName,
                                   a.SearchName,
                                   a.IdNo,
                                   a.IsPerson,
                                   a.NHIFNo,
                                   a.KRAPin,
                                   a.NSSFNo,
                                   a.HudumaNo,
                                   a.Email,
                                   a.DOB,
                                   a.TitleId,
                                   a.Gender,
                                   a.MaritalStatusId,
                                   a.Telephone1,
                                   a.Telephone2,
                                   a.Telephone3,
                                   a.PhoneNo,
                                   a.FaxNumber,
                                   a.PhysicalLocation,
                                   a.PostalAddress,
                                   a.MemberStatusId,
                                   a.Blocked,
                                   a.LevelofEducationId,
                                   a.IsRegister,
                                   a.IsDormancy,
                                   a.Remark,
                                   a.SecurityQuestion,
                                   a.RegistrationCode,
                                   a.NationalityId,
                                   a.CompanyRegistrationDate,
                                   a.RegistrationDate,
                                   a.CompanyCertificateNo,
                                   a.BankId,
                                   a.BankBranchId,
                                   a.BankAccountNo,
                                   a.CurrencyId,
                                   a.SecurityAnswer,
                               }).FirstOrDefault();
                return Ok(new { contact });


            }

        }


        [Route("Api/DeleteContact"), HttpGet]
        public IHttpActionResult DeleteContact(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblContact contact = db.tblContacts.SingleOrDefault(x => x.ContactId == id);
                db.tblContacts.Remove(contact);
                db.SaveChanges();
                return Ok(contact);
            }
        }
        [Route("Api/getMemberContact")]
        public async Task<IHttpActionResult> getMemberContact(int MemberId)
        {
            Contacts contact = new Contacts();
            contact.isSuccess = false;
            contact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.GetMemberContacts(MemberId).ToList();
                    List<Contacts> listofContact = new List<Contacts>();

                    foreach (var items in dbResult)
                    {
                        Contacts oContact = new Contacts();

                        oContact.ContactId = items.ContactId;
                        oContact.Payroll = items.Payroll;
                        oContact.MemberId = items.MemberId;
                        oContact.FullName = items.FullName;
                        oContact.SearchName = items.SearchName;
                        oContact.IdNo = items.IdNo;
                        oContact.IsPerson = items.IsPerson;
                        oContact.NHIFNo = items.NHIFNo;
                        oContact.KRAPin = items.KRAPin;
                        oContact.NSSFNo = items.NSSFNo;
                        oContact.HudumaNo = items.HudumaNo;
                        oContact.Email = items.Email;
                        oContact.DOB = items.DOB;
                        oContact.TitleId = items.TitleId;
                        oContact.Gender = items.Gender;
                        oContact.MaritalStatusId = items.MaritalStatusId;
                        oContact.Telephone1 = items.Telephone1;
                        oContact.Telephone2 = items.Telephone2;
                        oContact.Telephone3 = items.Telephone3;
                        oContact.PhoneNo = items.PhoneNo;
                        oContact.FaxNumber = items.FaxNumber;
                        oContact.PhysicalLocation = items.PhysicalLocation;
                        oContact.PostalAddress = items.PostalAddress;
                        oContact.PostalAddress = items.PostalAddress;
                        oContact.MemberStatusId = items.MemberStatusId;
                        oContact.Blocked = items.Blocked;
                        oContact.LevelofEducationId = items.LevelofEducationId;
                        oContact.IsRegister = items.IsRegister;
                        oContact.IsDormancy = items.IsDormancy;
                        oContact.Remark = items.Remark;
                        oContact.SecurityQuestion = items.SecurityQuestion;
                        oContact.RegistrationCode = items.RegistrationCode;
                        oContact.NationalityId = items.NationalityId;
                        oContact.CompanyRegistrationDate = items.CompanyRegistrationDate;
                        oContact.RegistrationDate = items.RegistrationDate;
                        oContact.CompanyCertificateNo = items.CompanyCertificateNo;
                        oContact.BankId = items.BankId;
                        oContact.BankBranchId = items.BankBranchId;
                        oContact.BankAccountNo = items.BankAccountNo;
                        oContact.CurrencyId = items.CurrencyId;
                        oContact.SecurityAnswer = items.SecurityAnswer;
                        oContact.isSuccess = true;
                        oContact.errorDescription = "";

                        listofContact.Add(oContact);

                    }
                    IEnumerable<Contacts> myContact = listofContact;
                    return Ok(myContact);
                }
            }
            catch (Exception ex)
            {
                contact.errorDescription = ex.Message;
                return Ok(contact);
            }
        }
    }
}
