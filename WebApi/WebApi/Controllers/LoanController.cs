using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoanController : ApiController
    {
        [Route("Loan/AddLoanPurpose"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanPurpose(string Name, bool? Delete)
        {
            LoanPurpose oNewLoanPurpose = new LoanPurpose();
            oNewLoanPurpose.errorDescription = "";
            oNewLoanPurpose.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanPurposes(0, Name, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanPurpose.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanPurpose.LoanPurposeId = DbResult.LoanPurposeId;
                    oNewLoanPurpose.Name = DbResult.Name;
                    oNewLoanPurpose.isSuccess = true;
                    return Ok(oNewLoanPurpose);

                }
            }
            catch (Exception ex)
            {
                oNewLoanPurpose.errorDescription = ex.Message;
                return Ok(oNewLoanPurpose);

            }
        }
        [Route("Loan/UpdateLoanPurpose"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanPurpose(int? LoanPurposeId, string Name, bool? Delete)
        {
            LoanPurpose oNewLoanPurpose = new LoanPurpose();
            oNewLoanPurpose.errorDescription = "";
            oNewLoanPurpose.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanPurposes(LoanPurposeId, Name, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanPurpose.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanPurpose.LoanPurposeId = DbResult.LoanPurposeId;
                    oNewLoanPurpose.Name = DbResult.Name;
                    oNewLoanPurpose.isSuccess = true;
                    return Ok(oNewLoanPurpose);

                }
            }
            catch (Exception ex)
            {
                oNewLoanPurpose.errorDescription = ex.Message;
                return Ok(oNewLoanPurpose);

            }
        }
        [Route("Loan/getAllLoanPurposes")]
        public async Task<IHttpActionResult> getAllLoanPurposes()
        {

            LoanPurpose oNewLoanPurpose = new LoanPurpose();
            oNewLoanPurpose.errorDescription = "";
            oNewLoanPurpose.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllLoanPurpose().ToList();
                    List<LoanPurpose> listofLoanPurpose = new List<LoanPurpose>();
                    foreach (var items in dbResult)
                    {
                        LoanPurpose oLoanPurpose = new LoanPurpose();
                        oLoanPurpose.LoanPurposeId = items.LoanPurposeId;
                        oLoanPurpose.Name = items.Name;
                        oLoanPurpose.isSuccess = true;
                        listofLoanPurpose.Add(oLoanPurpose);
                    }
                    IEnumerable<LoanPurpose> myLoanPurpose = listofLoanPurpose;
                    return Ok(myLoanPurpose);

                }
            }
            catch (Exception ex)
            {
                oNewLoanPurpose.errorDescription = ex.Message;
                return Ok(oNewLoanPurpose);

            }

        }
        [Route("Loan/getLoanPurpose")]
        public async Task<IHttpActionResult> getLoanPurpose(int? id)
        {
            LoanPurpose oNewLoanPurpose = new LoanPurpose();
            oNewLoanPurpose.errorDescription = "";
            oNewLoanPurpose.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var loanpurpose = (from a in db.tblLoanPurposes
                                       where a.LoanPurposeId == id
                                       select new
                                       {
                                           a.LoanPurposeId,
                                           a.Name,

                                       }).FirstOrDefault();
                    oNewLoanPurpose.isSuccess = true;
                    return Ok(new { loanpurpose });


                }

            }
            catch (Exception ex)
            {
                oNewLoanPurpose.errorDescription = ex.Message;
                return Ok(oNewLoanPurpose);

            }


        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanPurpose")]
        public IHttpActionResult DeleteLoanPurpose(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblLoanPurpose LoanPurpose = db.tblLoanPurposes.SingleOrDefault(x => x.LoanPurposeId == id);
                db.tblLoanPurposes.Remove(LoanPurpose);
                db.SaveChanges();
                return Ok(LoanPurpose);
            }
        }
        [Route("Loan/AddLoanApplication"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanApplication(int? LoanTypeId, int? MemberId,
            string Code, string ManualRef, decimal? LoanAmount, decimal? InterestRate, DateTime? ApplicationDate,
            string PeriodFrequency, int? RepayPeriod, bool? IsMarkUpBased, decimal? MarkupAmount, int? Interest,
            int? Status, DateTime? StatusDate, int? PurposeId, decimal? GrossPay, decimal? NetPay,
            string LoanSeries, decimal? TotalShares, decimal? FreeShares, bool? IsMigrated,
            int? CreditOfficerId, int? DonorId, int? CurrencyId, int? BranchId, bool? Delete)
        {
            LoanApplication oNewLoan = new LoanApplication();
            oNewLoan.isSuccess = false;
            oNewLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    Code = db.proc_GenerateLoanCode().FirstOrDefault();
                    var dbResult = db.proc_AddEditLoans(0, LoanTypeId, MemberId, Code, ManualRef, LoanAmount,
                        InterestRate, ApplicationDate, PeriodFrequency, RepayPeriod, IsMarkUpBased, MarkupAmount, Interest, Status, StatusDate,
                        PurposeId, GrossPay, NetPay, LoanSeries, TotalShares, FreeShares, IsMigrated, CreditOfficerId, DonorId, CurrencyId, BranchId, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewLoan.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewLoan.LoanTypeId = dbResult.LoanTypeId;
                    oNewLoan.MemberId = dbResult.MemberId;
                    oNewLoan.Code = dbResult.Code;
                    oNewLoan.ManualRef = dbResult.ManualRef;
                    oNewLoan.LoanAmount = dbResult.LoanAmount;
                    oNewLoan.InterestRate = dbResult.InterestRate;
                    oNewLoan.ApplicationDate = dbResult.ApplicationDate;
                    oNewLoan.PeriodFrequency = dbResult.PeriodFrequency;
                    oNewLoan.RepayPeriod = dbResult.RepayPeriod;
                    oNewLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                    oNewLoan.MarkupAmount = dbResult.MarkupAmount;
                    oNewLoan.Interest = dbResult.InterestType;
                    oNewLoan.Status = dbResult.Status;
                    oNewLoan.StatusDate = dbResult.StatusDate;
                    oNewLoan.PurposeId = dbResult.PurposeId;
                    oNewLoan.GrossPay = dbResult.GrossPay;
                    oNewLoan.NetPay = dbResult.NetPay;
                    oNewLoan.LoanSeries = dbResult.LoanSeries;
                    oNewLoan.TotalShares = dbResult.TotalShares;
                    oNewLoan.FreeShares = dbResult.FreeShares;
                    oNewLoan.IsMigrated = dbResult.IsMigrated;
                    oNewLoan.CreditOfficerId = dbResult.CreditOfficerId;
                    oNewLoan.DonorId = dbResult.DonorId;
                    oNewLoan.CurrencyId = dbResult.CurrencyId;
                    oNewLoan.BranchId = dbResult.BranchId;
                    oNewLoan.isSuccess = true;
                    return Ok(oNewLoan);
                }

            }
            catch (Exception ex)
            {
                oNewLoan.errorDescription = ex.Message;
                return Ok(oNewLoan);

            }

        }
        [Route("Loan/UpdateLoanApplication"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanApplication(int? LoanId, int? LoanTypeId, int? MemberId,
         string Code, string ManualRef, decimal? LoanAmount, decimal? InterestRate, DateTime? ApplicationDate,
         string PeriodFrequency, int? RepayPeriod, bool? IsMarkUpBased, decimal? MarkupAmount, int? Interest,
         int? Status, DateTime? StatusDate, int? PurposeId, decimal? GrossPay, decimal? NetPay,
         string LoanSeries, decimal? TotalShares, decimal? FreeShares, bool? IsMigrated,
         int? CreditOfficerId, int? DonorId, int? CurrencyId, int? BranchId, bool? Delete)
        {
            LoanApplication oNewLoan = new LoanApplication();
            oNewLoan.isSuccess = false;
            oNewLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var dbResult = db.proc_AddEditLoans(LoanId, LoanTypeId, MemberId, Code, ManualRef, LoanAmount,
                        InterestRate, ApplicationDate, PeriodFrequency, RepayPeriod, IsMarkUpBased, MarkupAmount, Interest, Status, StatusDate,
                        PurposeId, GrossPay, NetPay, LoanSeries, TotalShares, FreeShares, IsMigrated, CreditOfficerId, DonorId, CurrencyId, BranchId, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewLoan.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewLoan.LoanTypeId = dbResult.LoanTypeId;
                    oNewLoan.MemberId = dbResult.MemberId;
                    oNewLoan.Code = dbResult.Code;
                    oNewLoan.ManualRef = dbResult.ManualRef;
                    oNewLoan.LoanAmount = dbResult.LoanAmount;
                    oNewLoan.InterestRate = dbResult.InterestRate;
                    oNewLoan.ApplicationDate = dbResult.ApplicationDate;
                    oNewLoan.PeriodFrequency = dbResult.PeriodFrequency;
                    oNewLoan.RepayPeriod = dbResult.RepayPeriod;
                    oNewLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                    oNewLoan.MarkupAmount = dbResult.MarkupAmount;
                    oNewLoan.Interest = dbResult.InterestType;
                    oNewLoan.Status = dbResult.Status;
                    oNewLoan.StatusDate = dbResult.StatusDate;
                    oNewLoan.PurposeId = dbResult.PurposeId;
                    oNewLoan.GrossPay = dbResult.GrossPay;
                    oNewLoan.NetPay = dbResult.NetPay;
                    oNewLoan.LoanSeries = dbResult.LoanSeries;
                    oNewLoan.TotalShares = dbResult.TotalShares;
                    oNewLoan.FreeShares = dbResult.FreeShares;
                    oNewLoan.IsMigrated = dbResult.IsMigrated;
                    oNewLoan.CreditOfficerId = dbResult.CreditOfficerId;
                    oNewLoan.DonorId = dbResult.DonorId;
                    oNewLoan.CurrencyId = dbResult.CurrencyId;
                    oNewLoan.BranchId = dbResult.BranchId;
                    oNewLoan.isSuccess = true;
                    return Ok(oNewLoan);
                }

            }
            catch (Exception ex)
            {
                oNewLoan.errorDescription = ex.Message;
                return Ok(oNewLoan);

            }

        }
        [Route("Loan/getAllLoanAPPlication")]
        public async Task<IHttpActionResult> getAllLoanAPPlication()
        {

            LoanApplication oLoan = new LoanApplication();
            oLoan.isSuccess = false;
            oLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetAllApplyLoans().ToList();
                    List<LoanApplication> listofLoans = new List<LoanApplication>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanApplication oNewLoan = new LoanApplication();
                        oNewLoan.LoanId = dbResult.LoanId;
                        oNewLoan.LoanTypeId = dbResult.LoanTypeId;
                        oNewLoan.MemberId = dbResult.MemberId;

                        oNewLoan.Code = dbResult.Code;
                        oNewLoan.ManualRef = dbResult.ManualRef;
                        oNewLoan.LoanAmount = dbResult.LoanAmount;
                        oNewLoan.InterestRate = dbResult.InterestRate;
                        oNewLoan.ApplicationDate = dbResult.ApplicationDate;
                        oNewLoan.PeriodFrequency = dbResult.PeriodFrequency;
                        oNewLoan.RepayPeriod = dbResult.RepayPeriod;
                        oNewLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                        oNewLoan.MarkupAmount = dbResult.MarkupAmount;
                        oNewLoan.Interest = dbResult.InterestType;
                        oNewLoan.Status = dbResult.Status;
                        oNewLoan.StatusDate = dbResult.StatusDate;
                        oNewLoan.PurposeId = dbResult.PurposeId;
                        oNewLoan.GrossPay = dbResult.GrossPay;
                        oNewLoan.NetPay = dbResult.NetPay;
                        oNewLoan.LoanSeries = dbResult.LoanSeries;
                        oNewLoan.TotalShares = dbResult.TotalShares;
                        oNewLoan.FreeShares = dbResult.FreeShares;
                        oNewLoan.IsMigrated = dbResult.IsMigrated;
                        oNewLoan.CreditOfficerId = dbResult.CreditOfficerId;
                        oNewLoan.DonorId = dbResult.DonorId;
                        oNewLoan.CurrencyId = dbResult.CurrencyId;
                        oNewLoan.BranchId = dbResult.BranchId;
                        oNewLoan.errorDescription = "";
                        oNewLoan.isSuccess = true;
                        listofLoans.Add(oNewLoan);
                    }
                    IEnumerable<LoanApplication> myLoan = listofLoans;
                    return Ok(myLoan);


                }

            }
            catch (Exception ex)
            {
                oLoan.errorDescription = ex.Message;
                return Ok(oLoan);

            }
        }
        [Route("Loan/getLoan")]
        public async Task<IHttpActionResult> getLoan(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loan = (from a in db.tblLoans                            where a.LoanId == id                            select new                            {                                a.LoanId,                                a.LoanTypeId,                                a.MemberId,                                a.Code,                                a.ManualRef,                                a.LoanAmount,                                a.InterestRate,                                a.ApplicationDate,                                a.PeriodFrequency,                                a.RepayPeriod,                                a.IsMarkUpBased,                                a.MarkupAmount,                                a.InterestType,                                a.Status,                                a.StatusDate,                                a.PurposeId,                                a.GrossPay,                                a.NetPay,                                a.LoanSeries,                                a.TotalShares,                                a.FreeShares,                                a.IsMigrated,                                a.CreditOfficerId,                                a.DonorId,                                a.CurrencyId,                                a.BranchId,                                a.ModifiedOn,                                a.ModifiedBy,                                a.CreatedBy,                                a.CreatedOn,                            }).FirstOrDefault();                var LoanCharge = (from a in db.LoanApplicationCharges
                                  join b in db.tblLoanTypeCharges on a.LoanTypeChargesId equals b.LoanTypeChargesId
                                  where a.LoanId == id
                                  select new
                                  {
                                      a.LoanApplicationChargesId,
                                      a.LoanId,
                                      a.LoanTypeChargesId,
                                      a.LoanChargesListId,
                                      a.IsPercentage,
                                      a.IsTariffBased,
                                      Name = b.Name,
                                      a.Value,
                                      a.Amount,
                                      a.CreatedOn,
                                      a.CreatedBy,
                                      a.ModifiedBy,
                                      a.ModifiedOn,
                                  }).ToList();                return Ok(new { loan, LoanCharge });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoan")]
        public IHttpActionResult DeleteLoan(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblLoan loan = db.tblLoans.SingleOrDefault(x => x.LoanId == id);
                db.tblLoans.Remove(loan);
                db.SaveChanges();
                return Ok(loan);
            }


        }
        [Route("Loan/AddLoanCollateral"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanCollateral(int? CollateralId, string OwnerName, int? LoanId, string RegistrationDetails, decimal? ActualValue, decimal? ForcedSaleValue,
            string Remarks, DateTime? ExpiryDate, bool? Delete)
        {
            LoanCollateral oLoanCollateral = new LoanCollateral();
            oLoanCollateral.isSuccess = false;
            oLoanCollateral.errorDescription = "";
            if (Remarks == null)
            {
                Remarks = "";
            }
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditLoanCollateral(0, LoanId, CollateralId, OwnerName, RegistrationDetails, ActualValue, ForcedSaleValue, Remarks, ExpiryDate, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oLoanCollateral.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oLoanCollateral.LoanCollateralId = dbResult.LoanCollateralId;
                    oLoanCollateral.LoanId = dbResult.LoanId;
                    oLoanCollateral.CollateralId = dbResult.CollateralId;
                    oLoanCollateral.OwnerName = dbResult.OwnerName;
                    oLoanCollateral.RegistrationDetails = dbResult.RegistrationDetails;
                    oLoanCollateral.ActualValue = dbResult.ActualValue;
                    oLoanCollateral.ForcedSaleValue = dbResult.ForcedSaleValue;
                    oLoanCollateral.Remarks = dbResult.Remarks;
                    oLoanCollateral.ExpiryDate = dbResult.ExpiryDate;
                    oLoanCollateral.isSuccess = true;
                    return Ok(oLoanCollateral);


                }

            }
            catch (Exception ex)
            {
                oLoanCollateral.errorDescription = ex.Message;
                return Ok(oLoanCollateral);

            }

        }
        [Route("Loan/UpdateLoanCollateral"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanCollateral(int? LoanCollateralId, int? CollateralId, string OwnerName, int? LoanId, string RegistrationDetails, decimal? ActualValue, decimal? ForcedSaleValue,
           string Remarks, DateTime? ExpiryDate, bool? Delete)
        {
            LoanCollateral oLoanCollateral = new LoanCollateral();
            oLoanCollateral.isSuccess = false;
            oLoanCollateral.errorDescription = "";
            if (Remarks == null)
            {
                Remarks = "";
            }
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditLoanCollateral(LoanCollateralId, LoanId, CollateralId, OwnerName, RegistrationDetails, ActualValue, ForcedSaleValue, Remarks, ExpiryDate, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oLoanCollateral.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oLoanCollateral.LoanCollateralId = dbResult.LoanCollateralId;
                    oLoanCollateral.LoanId = dbResult.LoanId;
                    oLoanCollateral.CollateralId = dbResult.CollateralId;
                    oLoanCollateral.OwnerName = dbResult.OwnerName;
                    oLoanCollateral.RegistrationDetails = dbResult.RegistrationDetails;
                    oLoanCollateral.ActualValue = dbResult.ActualValue;
                    oLoanCollateral.ForcedSaleValue = dbResult.ForcedSaleValue;
                    oLoanCollateral.Remarks = dbResult.Remarks;
                    oLoanCollateral.ExpiryDate = dbResult.ExpiryDate;
                    oLoanCollateral.isSuccess = true;
                    return Ok(oLoanCollateral);


                }

            }
            catch (Exception ex)
            {
                oLoanCollateral.errorDescription = ex.Message;
                return Ok(oLoanCollateral);

            }

        }
        [Route("Loan/getAllLoanCollateral")]
        public async Task<IHttpActionResult> getAllLoanCollateral(int? LoanId)
        {

            LoanCollateral oNewCollateral = new LoanCollateral();
            oNewCollateral.isSuccess = false;
            oNewCollateral.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetAllLoanCollateral(LoanId).ToList();
                    List<LoanCollateral> listofCollateral = new List<LoanCollateral>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanCollateral oCollateral = new LoanCollateral();
                        oCollateral.LoanCollateralId = dbResult.LoanCollateralId;
                        oCollateral.LoanId = dbResult.LoanId;
                        oCollateral.CollateralId = dbResult.CollateralId;
                        oCollateral.OwnerName = dbResult.OwnerName;
                        oCollateral.RegistrationDetails = dbResult.RegistrationDetails;
                        oCollateral.ActualValue = dbResult.ActualValue;
                        oCollateral.ForcedSaleValue = dbResult.ForcedSaleValue;
                        oCollateral.Remarks = dbResult.Remarks;
                        oCollateral.ExpiryDate = dbResult.ExpiryDate;

                        oCollateral.isSuccess = true;
                        listofCollateral.Add(oCollateral);
                    }
                    IEnumerable<LoanCollateral> myLoanCollateral = listofCollateral;
                    return Ok(myLoanCollateral);


                }


            }
            catch (Exception ex)
            {
                oNewCollateral.errorDescription = ex.Message;
                return Ok(oNewCollateral);

            }

        }
        [Route("Loan/getLoanCollateral")]
        public async Task<IHttpActionResult> getLoanCollateral(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loanCollateral = (from a in db.tblLoanCollaterals
                                      where a.LoanCollateralId == id
                                      select new
                                      {
                                          a.LoanCollateralId,
                                          a.LoanId,
                                          a.ForcedSaleValue,
                                          a.ExpiryDate,
                                          a.ActualValue,
                                          a.OwnerName,
                                          a.RegistrationDetails,
                                          a.Remarks,
                                          a.CollateralId,
                                      }).FirstOrDefault();
                return Ok(new { loanCollateral });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanCollateral")]
        public IHttpActionResult DeleteLoanCollateral(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblLoanCollateral loanCollateral = db.tblLoanCollaterals.SingleOrDefault(x => x.LoanCollateralId == id);
                db.tblLoanCollaterals.Remove(loanCollateral);
                db.SaveChanges();
                return Ok(loanCollateral);
            }


        }
        [Route("Loan/AddLoanGuarator"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanGuarator(int? LoanId, int? MemberId, string FullName, string IdNo, int? GuarantorTypeId,
            string LoanSerialRef, decimal? GuaranteedAmount, bool? Delete)
        {
            LoanGuarator oNewGuarator = new LoanGuarator();
            oNewGuarator.isSuccess = false;
            oNewGuarator.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditLoanGuarators(0, LoanId, MemberId, FullName, IdNo, GuarantorTypeId, LoanSerialRef, GuaranteedAmount, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewGuarator.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewGuarator.LoanGuarantorId = dbResult.LoanGuarantorId;
                    oNewGuarator.LoanId = dbResult.LoanId;
                    oNewGuarator.MemberId = dbResult.MemberId;
                    oNewGuarator.LoanSerialRef = dbResult.LoanSerialRef;
                    oNewGuarator.IdNo = dbResult.IdNo;
                    oNewGuarator.FullName = dbResult.FullName;
                    oNewGuarator.GuaranteedAmount = dbResult.GuaranteedAmount;
                    oNewGuarator.GuarantorTypeId = dbResult.GuarantorTypeId;
                    oNewGuarator.isSuccess = true;
                    return Ok(oNewGuarator);

                }

            }
            catch (Exception ex)
            {
                oNewGuarator.errorDescription = ex.Message;
                return Ok(oNewGuarator);


            }


        }
        [Route("Loan/UpdateLoanGuarator"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanGuarator(int? LoanGuarantorId, int? LoanId, int? MemberId, string FullName, string IdNo, int? GuarantorTypeId,
          string LoanSerialRef, decimal? GuaranteedAmount, bool? Delete)
        {
            LoanGuarator oNewGuarator = new LoanGuarator();
            oNewGuarator.isSuccess = false;
            oNewGuarator.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditLoanGuarators(LoanGuarantorId, LoanId, MemberId, FullName, IdNo, GuarantorTypeId, LoanSerialRef, GuaranteedAmount, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewGuarator.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewGuarator.LoanGuarantorId = dbResult.LoanGuarantorId;
                    oNewGuarator.LoanId = dbResult.LoanId;
                    oNewGuarator.MemberId = dbResult.MemberId;
                    oNewGuarator.LoanSerialRef = dbResult.LoanSerialRef;
                    oNewGuarator.IdNo = dbResult.IdNo;
                    oNewGuarator.FullName = dbResult.FullName;
                    oNewGuarator.GuaranteedAmount = dbResult.GuaranteedAmount;
                    oNewGuarator.GuarantorTypeId = dbResult.GuarantorTypeId;
                    oNewGuarator.isSuccess = true;
                    return Ok(oNewGuarator);

                }

            }
            catch (Exception ex)
            {
                oNewGuarator.errorDescription = ex.Message;
                return Ok(oNewGuarator);


            }


        }
        [Route("Loan/getAllLoanGuarator")]
        public async Task<IHttpActionResult> getAllLoanGuarator(int? LoanId)
        {

            LoanGuarator oNewGuarator = new LoanGuarator();
            oNewGuarator.isSuccess = false;
            oNewGuarator.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetAllLoanGuarators(LoanId).ToList();
                    List<LoanGuarator> listofGuarator = new List<LoanGuarator>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanGuarator oGuarator = new LoanGuarator();
                        oGuarator.LoanGuarantorId = dbResult.LoanGuarantorId;
                        oGuarator.LoanId = dbResult.LoanId;
                        oGuarator.MemberId = dbResult.MemberId;
                        oGuarator.LoanSerialRef = dbResult.LoanSerialRef;
                        oGuarator.IdNo = dbResult.IdNo;
                        oGuarator.FullName = dbResult.FullName;
                        oGuarator.GuaranteedAmount = dbResult.GuaranteedAmount;
                        oGuarator.GuarantorTypeId = dbResult.GuarantorTypeId;
                        oGuarator.isSuccess = true;
                        listofGuarator.Add(oGuarator);
                    }
                    IEnumerable<LoanGuarator> myLoanGuarator = listofGuarator;
                    return Ok(myLoanGuarator);

                }

            }
            catch (Exception ex)
            {
                oNewGuarator.errorDescription = ex.Message;
                return Ok(oNewGuarator);

            }

        }
        [Route("Loan/getLoanGuarator")]
        public async Task<IHttpActionResult> getLoanGuarator(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loanGuarator = (from a in db.tblLoanGuarators
                                    where a.LoanGuarantorId == id
                                    select new
                                    {
                                        a.LoanGuarantorId,
                                        a.LoanId,
                                        a.MemberId,
                                        a.IdNo,
                                        a.FullName,
                                        a.GuarantorTypeId,
                                        a.GuaranteedAmount,
                                        a.LoanSerialRef,
                                    }).FirstOrDefault();
                return Ok(new { loanGuarator });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanGuarator")]
        public IHttpActionResult DeleteLoanGuarator(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblLoanGuarator loanGuarator = db.tblLoanGuarators.SingleOrDefault(x => x.LoanGuarantorId == id);
                db.tblLoanGuarators.Remove(loanGuarator);
                db.SaveChanges();
                return Ok(loanGuarator);
            }


        }


        [Route("Loan/AddLoanStatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanStatus(string LoanStatusName, bool? Delete)
        {
            LoanStatus oNewLoanStatus = new LoanStatus();
            oNewLoanStatus.errorDescription = "";
            oNewLoanStatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanStatus(0, LoanStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanStatus.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanStatus.LoanStatusId = DbResult.LoanStatusId;
                    oNewLoanStatus.LoanStatusName = DbResult.LoanStatusName;
                    oNewLoanStatus.isSuccess = true;
                    return Ok(oNewLoanStatus);

                }
            }
            catch (Exception ex)
            {
                oNewLoanStatus.errorDescription = ex.Message;
                return Ok(oNewLoanStatus);

            }
        }
        [Route("Loan/UpdateLoanStatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanStatus(int? LoanStatusId, string LoanStatusName, bool? Delete)
        {
            LoanStatus oNewLoanStatus = new LoanStatus();
            oNewLoanStatus.errorDescription = "";
            oNewLoanStatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanStatus(LoanStatusId, LoanStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanStatus.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanStatus.LoanStatusId = DbResult.LoanStatusId;
                    oNewLoanStatus.LoanStatusName = DbResult.LoanStatusName;
                    oNewLoanStatus.isSuccess = true;
                    return Ok(oNewLoanStatus);

                }
            }
            catch (Exception ex)
            {
                oNewLoanStatus.errorDescription = ex.Message;
                return Ok(oNewLoanStatus);

            }
        }

        [Route("Loan/getAllLoanStatus")]
        public async Task<IHttpActionResult> getAllLoanStatus()
        {

            LoanStatus oNewLoanStatus = new LoanStatus();
            oNewLoanStatus.errorDescription = "";
            oNewLoanStatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllLoanStatus().ToList();
                    List<LoanStatus> listofLoanStatus = new List<LoanStatus>();
                    foreach (var items in dbResult)
                    {
                        LoanStatus oLoanStatus = new LoanStatus();
                        oLoanStatus.LoanStatusId = items.LoanStatusId;
                        oLoanStatus.LoanStatusName = items.LoanStatusName;
                        oLoanStatus.isSuccess = true;
                        listofLoanStatus.Add(oLoanStatus);
                    }
                    IEnumerable<LoanStatus> myLoanStatus = listofLoanStatus;
                    return Ok(myLoanStatus);

                }
            }
            catch (Exception ex)
            {
                oNewLoanStatus.errorDescription = ex.Message;
                return Ok(oNewLoanStatus);

            }

        }
        [Route("Loan/getLoanStatus")]
        public async Task<IHttpActionResult> getLoanStatus(int? id)
        {
            LoanStatus oNewLoanStatus = new LoanStatus();
            oNewLoanStatus.errorDescription = "";
            oNewLoanStatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var loanStatus = (from a in db.tblLoanStatus
                                      where a.LoanStatusId == id
                                      select new
                                      {
                                          a.LoanStatusId,
                                          a.LoanStatusName,

                                      }).FirstOrDefault();
                    oNewLoanStatus.isSuccess = true;
                    return Ok(new { loanStatus });


                }

            }
            catch (Exception ex)
            {
                oNewLoanStatus.errorDescription = ex.Message;
                return Ok(oNewLoanStatus);

            }


        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanStatus")]
        public IHttpActionResult DeleteLoanStatus(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblLoanStatu LoanStatus = db.tblLoanStatus.SingleOrDefault(x => x.LoanStatusId == id);
                db.tblLoanStatus.Remove(LoanStatus);
                db.SaveChanges();
                return Ok(LoanStatus);
            }
        }
        [Route("Loan/AddLoanDonor"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanDonor(string DonorName, bool? Delete)
        {
            LoanDonor oNewLoanDonor = new LoanDonor();
            oNewLoanDonor.errorDescription = "";
            oNewLoanDonor.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanDonors(0, DonorName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanDonor.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanDonor.DonorId = DbResult.DonorId;
                    oNewLoanDonor.DonorName = DbResult.DonorName;
                    oNewLoanDonor.isSuccess = true;
                    return Ok(oNewLoanDonor);

                }
            }
            catch (Exception ex)
            {
                oNewLoanDonor.errorDescription = ex.Message;
                return Ok(oNewLoanDonor);

            }
        }
        [Route("Loan/UpdateLoanDonor"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanDonor(int? DonorId, string DonorName, bool? Delete)
        {
            LoanDonor oNewLoanDonor = new LoanDonor();
            oNewLoanDonor.errorDescription = "";
            oNewLoanDonor.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanDonors(DonorId, DonorName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanDonor.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewLoanDonor.DonorId = DbResult.DonorId;
                    oNewLoanDonor.DonorName = DbResult.DonorName;
                    oNewLoanDonor.isSuccess = true;
                    return Ok(oNewLoanDonor);

                }
            }
            catch (Exception ex)
            {
                oNewLoanDonor.errorDescription = ex.Message;
                return Ok(oNewLoanDonor);

            }
        }
        [Route("Loan/getAllLoanDonor")]
        public async Task<IHttpActionResult> getAllLoanDonor()
        {

            LoanDonor oNewLoanDonor = new LoanDonor();
            oNewLoanDonor.errorDescription = "";
            oNewLoanDonor.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllLoanDonors().ToList();
                    List<LoanDonor> listofLoanDonor = new List<LoanDonor>();
                    foreach (var items in dbResult)
                    {
                        LoanDonor oLoanDonor = new LoanDonor();
                        oLoanDonor.DonorId = items.DonorId;
                        oLoanDonor.DonorName = items.DonorName;
                        oLoanDonor.isSuccess = true;
                        listofLoanDonor.Add(oLoanDonor);
                    }
                    IEnumerable<LoanDonor> myLoanDonor = listofLoanDonor;
                    return Ok(myLoanDonor);

                }
            }
            catch (Exception ex)
            {
                oNewLoanDonor.errorDescription = ex.Message;
                return Ok(oNewLoanDonor);

            }

        }
        [Route("Loan/getLoanDonor")]
        public async Task<IHttpActionResult> getLoanDonor(int? id)
        {
            LoanDonor oNewLoanDonor = new LoanDonor();
            oNewLoanDonor.errorDescription = "";
            oNewLoanDonor.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var loanDonor = (from a in db.tblLoanDonors
                                     where a.DonorId == id
                                     select new
                                     {
                                         a.DonorId,
                                         a.DonorName,

                                     }).FirstOrDefault();
                    oNewLoanDonor.isSuccess = true;
                    return Ok(new { loanDonor });


                }

            }
            catch (Exception ex)
            {
                oNewLoanDonor.errorDescription = ex.Message;
                return Ok(oNewLoanDonor);

            }


        }
        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanDonor")]
        public IHttpActionResult DeleteLoanDonor(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblLoanDonor LoanDonor = db.tblLoanDonors.SingleOrDefault(x => x.DonorId == id);
                db.tblLoanDonors.Remove(LoanDonor);
                db.SaveChanges();
                return Ok(LoanDonor);
            }
        }
        [Route("Loan/AddCompanyBranch"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCompanyBranch(string Code, string Name, bool? Delete)
        {
            CompanyBranch oNewCompanyBranch = new CompanyBranch();
            oNewCompanyBranch.errorDescription = "";
            oNewCompanyBranch.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Code == null) { Code = ""; }
                    if (Name == null) { Name = ""; }

                    var DbResult = db.proc_AddEditCompanyBranches(0, Code, Name, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCompanyBranch.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCompanyBranch.Code = DbResult.Code;
                    oNewCompanyBranch.Name = DbResult.Name;

                    oNewCompanyBranch.isSuccess = true;
                    return Ok(oNewCompanyBranch);

                }
            }
            catch (Exception ex)
            {
                oNewCompanyBranch.errorDescription = ex.Message;
                return Ok(oNewCompanyBranch);

            }
        }
        [Route("Loan/UpdateCompanyBranch"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCompanyBranch(int? CompanyBranchesId, string Code, string Name, bool? Delete)
        {
            CompanyBranch oNewCompanyBranch = new CompanyBranch();
            oNewCompanyBranch.errorDescription = "";
            oNewCompanyBranch.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (Code == null) { Code = ""; }
                    if (Name == null) { Name = ""; }

                    var DbResult = db.proc_AddEditCompanyBranches(CompanyBranchesId, Code, Name, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCompanyBranch.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewCompanyBranch.CompanyBranchesId = DbResult.CompanyBranchesId;
                    oNewCompanyBranch.Code = DbResult.Code;
                    oNewCompanyBranch.Name = DbResult.Name;

                    oNewCompanyBranch.isSuccess = true;
                    return Ok(oNewCompanyBranch);


                }
            }
            catch (Exception ex)
            {
                oNewCompanyBranch.errorDescription = ex.Message;
                return Ok(oNewCompanyBranch);

            }
        }
        [Route("Loan/GetAllCompanyBranches")]
        public async Task<IHttpActionResult> GetAllCompanyBranches()
        {
            CompanyBranch oNewCompanyBranch = new CompanyBranch();
            oNewCompanyBranch.errorDescription = "";
            oNewCompanyBranch.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllCompanyBranches().ToList();
                    List<CompanyBranch> listofCompanyBranches = new List<CompanyBranch>();
                    foreach (var items in dbResult)
                    {
                        CompanyBranch oCompanyBranch = new CompanyBranch();
                        oCompanyBranch.CompanyBranchesId = items.CompanyBranchesId;
                        oCompanyBranch.Code = items.Code;
                        oCompanyBranch.Name = items.Name;
                        oCompanyBranch.isSuccess = true;

                        listofCompanyBranches.Add(oCompanyBranch);
                    }
                    IEnumerable<CompanyBranch> myCompanyBranch = listofCompanyBranches;
                    return Ok(myCompanyBranch);

                }
            }
            catch (Exception ex)
            {
                oNewCompanyBranch.errorDescription = ex.Message;
                return Ok(oNewCompanyBranch);

            }

        }
        [Route("Loan/GetCompanyBranch")]
        public async Task<IHttpActionResult> GetCompanyBranch(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var CompanyBranch = (from a in db.tblCompanyBranches
                                     where a.CompanyBranchesId == id
                                     select new
                                     {
                                         a.CompanyBranchesId,
                                         a.Code,
                                         a.Name,
                                     }).FirstOrDefault();
                return Ok(new { CompanyBranch });


            }
        }

        [HttpGet, HttpDelete]
        [Route("Loan/DeleteCompanyBranch")]
        public IHttpActionResult DeleteCompanyBranch(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblCompanyBranch CompanyBranch = db.tblCompanyBranches.SingleOrDefault(x => x.CompanyBranchesId == id);
                db.tblCompanyBranches.Remove(CompanyBranch);
                db.SaveChanges();
                return Ok(CompanyBranch);
            }
        }
        [Route("Loan/GetAllLoanApplicationCharges")]
        public async Task<IHttpActionResult> GetAllLoanApplicationCharges(int? LoanId)
        {


            LoanApplicationsCharges oNewLoanCharges = new LoanApplicationsCharges();
            oNewLoanCharges.IsSuccess = false;
            oNewLoanCharges.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetAllLoanChargesbyLoanId(LoanId).ToList();
                    List<LoanApplicationsCharges> listofLoanCharges = new List<LoanApplicationsCharges>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanApplicationsCharges oLoanCharges = new LoanApplicationsCharges();
                        oLoanCharges.LoanApplicationChargesId = dbResult.LoanApplicationChargesId;
                        oLoanCharges.LoanId = dbResult.LoanId;
                        oLoanCharges.LoanChargesListId = dbResult.LoanChargesListId;
                        oLoanCharges.IsTariff = dbResult.IsTariffBased;
                        oLoanCharges.IsPercent = dbResult.IsPercentage;
                        oLoanCharges.Value = dbResult.Value;
                        oLoanCharges.Amount = dbResult.Amount;
                        oLoanCharges.IsSuccess = true;
                        listofLoanCharges.Add(oLoanCharges);
                    }
                    IEnumerable<LoanApplicationsCharges> myLoanCharges = listofLoanCharges;
                    return Ok(myLoanCharges);

                }

            }
            catch (Exception ex)
            {
                oNewLoanCharges.ErrorDescription = ex.Message;
                return Ok(oNewLoanCharges);

            }

        }

        [HttpGet, HttpDelete]
        [Route("Loan/DeleteLoanApplicationCharges")]
        public IHttpActionResult DeleteLoanApplicationCharges(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                LoanApplicationCharge LoanCharge = db.LoanApplicationCharges.SingleOrDefault(x => x.LoanApplicationChargesId == id);
                db.LoanApplicationCharges.Remove(LoanCharge);
                db.SaveChanges();
                return Ok(LoanCharge);
            }
        }

        [Route("Loan/CountLoanRows"), HttpGet, HttpPost]        public async Task<IHttpActionResult> CountLoanRows(int? MemberId)        {            LoanApplication oNewLoanApplication = new LoanApplication();            oNewLoanApplication.isSuccess = false;            oNewLoanApplication.errorDescription = "";            try            {                using (DBContextEntities db = new DBContextEntities())                {                    var dbResult = db.proc_CountLoanRows(MemberId).FirstOrDefault();                    oNewLoanApplication.CountRows = dbResult.Value;                    oNewLoanApplication.isSuccess = true;                    oNewLoanApplication.errorDescription = "";                    return Ok(oNewLoanApplication);                }            }            catch (Exception ex)            {                oNewLoanApplication.errorDescription = ex.Message;                return Ok(oNewLoanApplication);            }        }

        [Route("Loan/GetTotalShares")]
        public async Task<IHttpActionResult> GetTotalShares(int? MemberId)
        {
            AccountTransaction oNewAccountTransaction = new AccountTransaction();
            oNewAccountTransaction.isSuccess = false;
            oNewAccountTransaction.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetTotalShare(MemberId).FirstOrDefault();
                    oNewAccountTransaction.BalanceAmount = dbResult.Value;

                    oNewAccountTransaction.isSuccess = true;
                    oNewAccountTransaction.errorDescription = "";

                    return Ok(oNewAccountTransaction);
                }
            }
            catch (Exception ex)
            {
                oNewAccountTransaction.errorDescription = ex.Message;
                return Ok(oNewAccountTransaction);
            }
        }
        [Route("Loan/GetAllLoanDefaultStatus")]
        public async Task<IHttpActionResult> GetAllLoanDefaultStatus()
        {

            LoanStatus oNewLoanStatus = new LoanStatus();
            oNewLoanStatus.errorDescription = "";
            oNewLoanStatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getDefaultStatus().ToList();
                    List<LoanStatus> listofLoanStatus = new List<LoanStatus>();
                    foreach (var items in dbResult)
                    {
                        LoanStatus oLoanStatus = new LoanStatus();
                        oLoanStatus.LoanStatusId = items.LoanStatusId;
                        oLoanStatus.LoanStatusName = items.LoanStatusName;
                        oLoanStatus.isSuccess = true;
                        listofLoanStatus.Add(oLoanStatus);
                    }
                    IEnumerable<LoanStatus> myLoanStatus = listofLoanStatus;
                    return Ok(myLoanStatus);

                }
            }
            catch (Exception ex)
            {
                oNewLoanStatus.errorDescription = ex.Message;
                return Ok(oNewLoanStatus);

            }
        }
        [Route("Loan/getAllLoanActiveAPPlication")]
        public async Task<IHttpActionResult> getAllLoanActiveAPPlication()
        {

            LoanApplication oLoan = new LoanApplication();
            oLoan.isSuccess = false;
            oLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetActiveLoans().ToList();
                    List<LoanApplication> listofLoans = new List<LoanApplication>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanApplication oNewLoan = new LoanApplication();
                        oNewLoan.LoanId = dbResult.LoanId;
                        oNewLoan.LoanTypeId = dbResult.LoanTypeId;
                        oNewLoan.MemberId = dbResult.MemberId;

                        oNewLoan.Code = dbResult.Code;
                        oNewLoan.ManualRef = dbResult.ManualRef;
                        oNewLoan.LoanAmount = dbResult.LoanAmount;
                        oNewLoan.InterestRate = dbResult.InterestRate;
                        oNewLoan.ApplicationDate = dbResult.ApplicationDate;
                        oNewLoan.PeriodFrequency = dbResult.PeriodFrequency;
                        oNewLoan.RepayPeriod = dbResult.RepayPeriod;
                        oNewLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                        oNewLoan.MarkupAmount = dbResult.MarkupAmount;
                        oNewLoan.Interest = dbResult.InterestType;
                        oNewLoan.Status = dbResult.Status;
                        oNewLoan.StatusDate = dbResult.StatusDate;
                        oNewLoan.PurposeId = dbResult.PurposeId;
                        oNewLoan.GrossPay = dbResult.GrossPay;
                        oNewLoan.NetPay = dbResult.NetPay;
                        oNewLoan.LoanSeries = dbResult.LoanSeries;
                        oNewLoan.TotalShares = dbResult.TotalShares;
                        oNewLoan.FreeShares = dbResult.FreeShares;
                        oNewLoan.IsMigrated = dbResult.IsMigrated;
                        oNewLoan.CreditOfficerId = dbResult.CreditOfficerId;
                        oNewLoan.DonorId = dbResult.DonorId;
                        oNewLoan.CurrencyId = dbResult.CurrencyId;
                        oNewLoan.BranchId = dbResult.BranchId;
                        oNewLoan.errorDescription = "";
                        oNewLoan.isSuccess = true;
                        listofLoans.Add(oNewLoan);
                    }
                    IEnumerable<LoanApplication> myLoan = listofLoans;
                    return Ok(myLoan);


                }

            }
            catch (Exception ex)
            {
                oLoan.errorDescription = ex.Message;
                return Ok(oLoan);

            }
        }
        [Route("Loan/getAllLoanAppraisedAPPlication")]
        public async Task<IHttpActionResult> getAllLoanAppraisedAPPlication()
        {

            LoanApplication oLoan = new LoanApplication();
            oLoan.isSuccess = false;
            oLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetAllAppraisedLoan().ToList();
                    List<LoanApplication> listofLoans = new List<LoanApplication>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanApplication oNewLoan = new LoanApplication();
                        oNewLoan.LoanId = dbResult.LoanId;
                        oNewLoan.LoanTypeId = dbResult.LoanTypeId;
                        oNewLoan.MemberId = dbResult.MemberId;

                        oNewLoan.Code = dbResult.Code;
                        oNewLoan.ManualRef = dbResult.ManualRef;
                        oNewLoan.LoanAmount = dbResult.LoanAmount;
                        oNewLoan.InterestRate = dbResult.InterestRate;
                        oNewLoan.ApplicationDate = dbResult.ApplicationDate;
                        oNewLoan.PeriodFrequency = dbResult.PeriodFrequency;
                        oNewLoan.RepayPeriod = dbResult.RepayPeriod;
                        oNewLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                        oNewLoan.MarkupAmount = dbResult.MarkupAmount;
                        oNewLoan.Interest = dbResult.InterestType;
                        oNewLoan.Status = dbResult.Status;
                        oNewLoan.StatusDate = dbResult.StatusDate;
                        oNewLoan.PurposeId = dbResult.PurposeId;
                        oNewLoan.GrossPay = dbResult.GrossPay;
                        oNewLoan.NetPay = dbResult.NetPay;
                        oNewLoan.LoanSeries = dbResult.LoanSeries;
                        oNewLoan.TotalShares = dbResult.TotalShares;
                        oNewLoan.FreeShares = dbResult.FreeShares;
                        oNewLoan.IsMigrated = dbResult.IsMigrated;
                        oNewLoan.CreditOfficerId = dbResult.CreditOfficerId;
                        oNewLoan.DonorId = dbResult.DonorId;
                        oNewLoan.CurrencyId = dbResult.CurrencyId;
                        oNewLoan.BranchId = dbResult.BranchId;
                        oNewLoan.errorDescription = "";
                        oNewLoan.isSuccess = true;
                        listofLoans.Add(oNewLoan);
                    }
                    IEnumerable<LoanApplication> myLoan = listofLoans;
                    return Ok(myLoan);


                }

            }
            catch (Exception ex)
            {
                oLoan.errorDescription = ex.Message;
                return Ok(oLoan);

            }
        }
        [Route("Loan/VerifyLoanApplication"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> VerifyLoanApplication(int? id)
        {
            ErrorModels oError = new ErrorModels();
            oError.IsSuccess = true;
            oError.ErrorDescription = "";

            try
            {
                List<LoanChargesList> listofLoanChargesList = new List<LoanChargesList>();
                using (DBContextEntities db = new DBContextEntities())
                {
                    var loan = (from a in db.tblLoans
                                where a.LoanId == id
                                select new
                                {
                                    a.LoanId,
                                    a.LoanTypeId,
                                    a.MemberId,
                                    a.Code,
                                    a.ManualRef,
                                    a.LoanAmount,
                                    a.InterestRate,
                                    a.ApplicationDate,
                                    a.PeriodFrequency,
                                    a.RepayPeriod,
                                    a.IsMarkUpBased,
                                    a.MarkupAmount,
                                    a.InterestType,
                                    a.Status,
                                    a.StatusDate,
                                    a.PurposeId,
                                    a.GrossPay,
                                    a.NetPay,
                                    a.LoanSeries,
                                    a.TotalShares,
                                    a.FreeShares,
                                    a.IsMigrated,
                                    a.CreditOfficerId,
                                    a.DonorId,
                                    a.CurrencyId,
                                    a.BranchId,
                                }).FirstOrDefault();

                    var member = (from a in db.tblMembers
                                  where a.MemberId == id
                                  select new
                                  { a.MemberId, a.Payroll, a.MemberNo, a.FullName, a.RegistrationDate, }).FirstOrDefault();


                    ////////////////////////////////////////

                    var loantypes = (from a in db.tblLoansTypes
                                     where a.LoanTypeId == loan.LoanTypeId
                                     select new
                                     {
                                         a.LoanTypeId,
                                         a.RefCode,
                                         a.Description,
                                         a.MaxPeriod,
                                         a.InterestRate,
                                         a.InterestRateFrequency,
                                         a.MinAmount,
                                         a.MaxAmount,
                                         a.IncomeFactor,
                                         a.ChargeInterestDuringGracePeriod,
                                         a.SharesFactor,
                                         a.MinGuarantors,
                                         a.MaxGuarantors,
                                         a.InterestPayMethod,
                                         a.DefaultPenalty,
                                         a.DefaultPenaltyFrequency,
                                         a.Moratorium,
                                         a.MinShares,
                                         a.InterestCalFormula,
                                         a.MinPeriod,
                                         a.LoansFactor,
                                         a.RepaymentFrequency,
                                         a.GracePeriod,
                                         a.ApplyPenaltyAfterMaturity,
                                         a.IsSecure,
                                         a.Consider23rdRule,
                                         a.PreConsiderInterest,
                                         a.ForgoneInterest,
                                         a.AllowPartialDisbursements,
                                         a.AllowTopups,
                                         a.AdjustInterestRate,
                                         a.ConsiderLoanSeries,
                                         a.IsMarkupBased,
                                         a.MarginBaseAmount,
                                         a.IncrementValue,
                                         a.IsMobileLoan,
                                         a.IsIncrementFactor,
                                         a.NearestPrincipleRounding,
                                         a.PrincipalRoundingType,
                                         a.NearestInterestRounding,
                                         a.InterestRoundingType,
                                         a.Category,
                                         a.Remarks,
                                     }).FirstOrDefault();

                    //Loan Type verification
                    double days = 0;
                    if (loan != null && member != null) { days = (Convert.ToDateTime(loan.ApplicationDate) - Convert.ToDateTime(member.RegistrationDate)).TotalDays; }
                    if (loan != null && loan.TotalShares != null && loantypes.SharesFactor != 0 && loan.LoanAmount > (loan.TotalShares * loantypes.SharesFactor)) { oError.LoanShareFactorError = "Applied loan Amount is greater than the product of your total shares and sharesfactor"; oError.IsSuccess = false; }
                    if (loantypes != null && loantypes.MinPeriod != 0 && days < loantypes.MinPeriod) { oError.LoanMinPeriodError = "You have not satisfied the Minimum Membership Period Rule"; oError.IsSuccess = false; }
                    if (loantypes != null && loantypes.MinShares != 0 && loan.TotalShares < loantypes.MinShares) { oError.LoanSharesError = "Your Shares is Less than the required minimum shares"; oError.IsSuccess = false; }
                    if (loan != null && loantypes != null && loantypes.MaxAmount != 0 && loan.LoanAmount > loantypes.MaxAmount) { oError.LoanMaxError = "Applied Loan Amount is has exceeded the applicable maximum amount"; oError.IsSuccess = false; }
                    if (loan != null && loantypes != null && loantypes.MaxAmount != 0 && loan.LoanAmount < loantypes.MinAmount) { oError.LoanMinError = "Applied loan is less than the required minimum loan amount"; oError.IsSuccess = false; }

                    /////////////////////////////////////////////////////////////////////
                    if (loantypes != null && loantypes.IsSecure == true && loan.LoanId != null && loan.LoanId != 0)
                    {

                        /////////Loan Guarantors
                        ///
                        var DbResult = db.proc_GetAllLoanGuarators(loan.LoanId).ToList();
                        List<LoanGuarantors> listofLoanGuarantors = new List<LoanGuarantors>();
                        if (DbResult != null)
                        {
                            foreach (var items in DbResult)
                            {
                                LoanGuarantors oLoanGuarantors = new LoanGuarantors();

                                oLoanGuarantors.LoanGuarantorId = items.LoanGuarantorId;
                                oLoanGuarantors.MemberId = items.MemberId;
                                listofLoanGuarantors.Add(oLoanGuarantors);

                                var MemberResult = db.proc_GetMemberById(oLoanGuarantors.MemberId).ToList();
                                if (MemberResult != null)
                                {
                                    foreach (var item in MemberResult)
                                    {
                                        Members oMember = new Members();

                                        oMember.MemberId = item.MemberId;
                                        oMember.Nett = item.Nett;
                                        oMember.FullName = item.FullName;

                                        //Check if this user can secure the loan
                                        if (oMember.Nett < loan.LoanAmount) { oError.GuarantorSecureError = oMember.FullName + " can not secure this Loan "; oError.IsSuccess = false; }
                                    }

                                }
                            }
                            IEnumerable<LoanGuarantors> myLoanGuarantors = listofLoanGuarantors;
                            int NoOfGurantors = listofLoanGuarantors.Count;
                            if (loantypes.MinGuarantors != 0 && loantypes.MinGuarantors > NoOfGurantors) { oError.MinGuarantorsError = "Loan Guarantors are less than the required minimum guarantors "; oError.IsSuccess = false; }

                            if (loantypes.MaxGuarantors != 0 && loantypes.MaxGuarantors < NoOfGurantors) { oError.MaxGuarantorsError = "Loan Guarantors are more than the required maximum guarantors "; oError.IsSuccess = false; }
                        }




                        ////////Loan Collaterals
                        ///
                        var CollateralResult = db.proc_GetAllLoanCollateral(loan.LoanId).ToList();
                        List<Collaterals> listofLoanCollaterals = new List<Collaterals>();
                        if (CollateralResult != null)
                        {
                            foreach (var item1 in CollateralResult)
                            {
                                Collaterals oCollaterals = new Collaterals();

                                oCollaterals.LoanCollateralId = item1.LoanCollateralId;
                                oCollaterals.CollateralId = item1.CollateralId;
                                oCollaterals.ActualValue = item1.LoanCollateralId;
                                oCollaterals.ForcedSaleValue = item1.CollateralId;

                                listofLoanCollaterals.Add(oCollaterals);

                                if (oCollaterals.ForcedSaleValue < loan.LoanAmount) { oError.CollateralError = "The selected Collateral can not secure the Loan "; oError.IsSuccess = false; }

                            }
                        }
                        IEnumerable<Collaterals> myLoanCollaterals = listofLoanCollaterals;
                        int NoOfCollateralss = listofLoanCollaterals.Count;


                    }




                    return Ok(oError);
                }
            }


            catch (Exception ex)
            {
                oError.ErrorDescription = ex.Message;
                return Ok(oError);

            }

        }
        [Route("Loan/GetSumLoanCharges")]
        public async Task<IHttpActionResult> GetSumLoanCharges(int? LoanId)
        {
            SumLoanCharge oNewLoanSumLoanCharge = new SumLoanCharge();
            oNewLoanSumLoanCharge.IsSuccess = false;
            oNewLoanSumLoanCharge.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetSumLoanApplicationCharges(LoanId).FirstOrDefault();
                    oNewLoanSumLoanCharge.TotalAmount = dbResult.Value;

                    oNewLoanSumLoanCharge.IsSuccess = true;
                    oNewLoanSumLoanCharge.ErrorDescription = "";

                    return Ok(oNewLoanSumLoanCharge);
                }
            }
            catch (Exception ex)
            {
                oNewLoanSumLoanCharge.ErrorDescription = ex.Message;
                return Ok(oNewLoanSumLoanCharge);
            }
        }
        [Route("Loan/DeleteAllLoanDetails"), HttpGet, HttpPost]        public async Task<IHttpActionResult> DeleteAllLoanDetails(int? LoanId)        {            LoanApplication oNewLoanApplication = new LoanApplication();            oNewLoanApplication.isSuccess = false;            oNewLoanApplication.errorDescription = "";            try            {                using (DBContextEntities db = new DBContextEntities())                {                    var dbResult = db.proc_deleteLoan(LoanId);                    if (dbResult == 0)
                    {
                        oNewLoanApplication.errorDescription = "This loan has been delete ***";
                        return Ok(oNewLoanApplication);

                    }                    oNewLoanApplication.isSuccess = true;                    oNewLoanApplication.errorDescription = "";                    return Ok(oNewLoanApplication);                }            }            catch (Exception ex)            {                oNewLoanApplication.errorDescription = ex.Message;                return Ok(oNewLoanApplication);            }        }
        [Route("Loan/GetUsedShares")]
        public async Task<IHttpActionResult> GetUsedShares(int? MemberId)
        {
            SumLoanCharge oNewLoanSumLoanCharge = new SumLoanCharge();
            oNewLoanSumLoanCharge.IsSuccess = false;
            oNewLoanSumLoanCharge.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetGuaranteedAmount(MemberId).FirstOrDefault();
                    oNewLoanSumLoanCharge.TotalAmount = dbResult.Value;

                    oNewLoanSumLoanCharge.IsSuccess = true;
                    oNewLoanSumLoanCharge.ErrorDescription = "";

                    return Ok(oNewLoanSumLoanCharge);
                }
            }
            catch (Exception ex)
            {
                oNewLoanSumLoanCharge.ErrorDescription = ex.Message;
                return Ok(oNewLoanSumLoanCharge);
            }
        }


    }
    }
