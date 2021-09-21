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
    public class LoanTypeController : ApiController
    {
        [Route("LoanType/AddLoanType"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanType(string RefCode, string Description, int? MaxPeriod, int? InterestRate, string InterestRateFrequency, decimal? MinAmount, decimal? MaxAmount, decimal? IncomeFactor, bool? ChargeInterestDuringGracePeriod, decimal? SharesFactor, int? MinGuarantors, int? MaxGuarantors,
        string InterestPayMethod, int? DefaultPenalty, string DefaultPenaltyFrequency, int? Moratorium, int? MinShares, string InterestCalFormula, int? MinPeriod, decimal? LoansFactor, string RepaymentFrequency, int? GracePeriod, bool? ApplyPenaltyAfterMaturity,
        bool? IsSecure, bool? Consider23rdRule, bool? PreConsiderInterest, bool? ForgoneInterest, bool? AllowPartialDisbursements, bool? AllowTopups, bool? AdjustInterestRate, bool? ConsiderLoanSeries, bool? IsMarkupBased,
        decimal? ForcedSaleValue, bool? UseOfZeroShares, decimal? MarginBaseAmount, string IncrementValue, bool? IsMobileLoan, bool? IsIncrementFactor, string NearestPrincipleRounding, string PrincipalRoundingType, string NearestInterestRounding, string InterestRoundingType,
        string Category, string Remarks, bool Delete)

        {
            LoanType oNewLoanType = new LoanType();
            oNewLoanType.IsSuccess = false;
            oNewLoanType.ErrorDescription = "";

            if (MinAmount > MaxAmount)
            {
                oNewLoanType.ErrorDescription = "Maximum Amount Can not be less than Minimum Amount";
                return Ok(oNewLoanType);
            }

            if (MinGuarantors > MaxGuarantors)
            {
                oNewLoanType.ErrorDescription = "Maximum Guarantors Can not be less than Minimum Guarantors";
                return Ok(oNewLoanType);
            }

            if (ApplyPenaltyAfterMaturity == null) { ApplyPenaltyAfterMaturity = false; }
            if (IsSecure == null) { IsSecure = false; }
            if (Consider23rdRule == null) { Consider23rdRule = false; }
            if (AllowTopups == null) { AllowTopups = false; }
            if (ForcedSaleValue == null) { ForcedSaleValue = 0; }
            if (UseOfZeroShares == null) { UseOfZeroShares = false; }
            if (IncrementValue == null) { IncrementValue = ""; }


            if (RefCode == null) { RefCode = ""; }
            if (Description == null)
            {
                oNewLoanType.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanType);
            }
            if (MaxPeriod == null) { MaxPeriod = 0; }
            if (InterestRate == null) { InterestRate = 0; }
            if (InterestRateFrequency == null) { InterestRateFrequency = ""; }
            if (DefaultPenalty == null) { DefaultPenalty = 0; }
            if (DefaultPenaltyFrequency == null) { DefaultPenaltyFrequency = ""; }
            if (InterestPayMethod == null) { InterestPayMethod = ""; }
            if (InterestCalFormula == null) { InterestCalFormula = ""; }
            if (IncomeFactor == null) { IncomeFactor = 0; }
            if (RepaymentFrequency == null) { RepaymentFrequency = ""; }
            if (SharesFactor == null) { SharesFactor = 0; }
            if (LoansFactor == null) { LoansFactor = 0; }
            if (MinGuarantors == null) { MinGuarantors = 0; }
            if (MaxGuarantors == null) { MaxGuarantors = 0; }
            if (MinShares == null) { MinShares = 0; }
            if (MinAmount == null) { MinAmount = 0; }
            if (MaxAmount == null) { MaxAmount = 0; }
            if (MinPeriod == null) { MinPeriod = 0; }
            if (AdjustInterestRate == null) { AdjustInterestRate = false; }
            if (ConsiderLoanSeries == null) { ConsiderLoanSeries = false; }
            if (ForgoneInterest == null) { ForgoneInterest = false; }
            if (GracePeriod == null) { GracePeriod = 0; }
            if (ChargeInterestDuringGracePeriod == null) { ChargeInterestDuringGracePeriod = false; }
            if (AllowPartialDisbursements == null) { AllowPartialDisbursements = false; }
            if (Category == null) { Category = " "; }
            if (Remarks == null) { Remarks = " "; }
            if (PreConsiderInterest == null) { PreConsiderInterest = false; }
            if (Moratorium == null) { Moratorium = 0; }
            if (NearestPrincipleRounding == null) { NearestPrincipleRounding = " "; }
            if (PrincipalRoundingType == null) { PrincipalRoundingType = " "; }
            if (NearestInterestRounding == null) { NearestInterestRounding = " "; }
            if (InterestRoundingType == null) { InterestRoundingType = " "; }
            if (IsMobileLoan == null) { IsMobileLoan = false; }
            if (MarginBaseAmount == null) { MarginBaseAmount = 0; }
            if (IsIncrementFactor == null) { IsIncrementFactor = false; }
            if (IsMarkupBased == null) { IsMarkupBased = false; }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoansType(0, RefCode, Description, MaxPeriod, InterestRate, InterestRateFrequency, MinAmount, MaxAmount, IncomeFactor, ChargeInterestDuringGracePeriod, SharesFactor, MinGuarantors, MaxGuarantors,
                    InterestPayMethod, DefaultPenalty, DefaultPenaltyFrequency, Moratorium, MinShares, InterestCalFormula, MinPeriod, LoansFactor, RepaymentFrequency, GracePeriod, ApplyPenaltyAfterMaturity,
                    IsSecure, Consider23rdRule, PreConsiderInterest, ForgoneInterest, AllowPartialDisbursements, AllowTopups, AdjustInterestRate, ConsiderLoanSeries, IsMarkupBased,
                    ForcedSaleValue, UseOfZeroShares, MarginBaseAmount, IncrementValue, IsMobileLoan, IsIncrementFactor, NearestPrincipleRounding, PrincipalRoundingType, NearestInterestRounding, InterestRoundingType,
                    Category, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanType.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewLoanType.LoanTypeId = DbResult.LoanTypeId;
                    oNewLoanType.RefCode = DbResult.RefCode;
                    oNewLoanType.Description = DbResult.Description;
                    oNewLoanType.MaxPeriod = DbResult.MaxPeriod;
                    oNewLoanType.InterestRate = DbResult.InterestRate;
                    oNewLoanType.InterestRateFrequency = DbResult.InterestRateFrequency;
                    oNewLoanType.MinAmount = DbResult.MinAmount;
                    oNewLoanType.MaxAmount = DbResult.MaxAmount;
                    oNewLoanType.IncomeFactor = DbResult.IncomeFactor;
                    oNewLoanType.ChargeInterestDuringGracePeriod = DbResult.ChargeInterestDuringGracePeriod;
                    oNewLoanType.SharesFactor = DbResult.SharesFactor;
                    oNewLoanType.MinGuarantors = DbResult.MinGuarantors;
                    oNewLoanType.MaxGuarantors = DbResult.MaxGuarantors;
                    oNewLoanType.InterestPayMethod = DbResult.InterestPayMethod;
                    oNewLoanType.DefaultPenalty = DbResult.DefaultPenalty;
                    oNewLoanType.DefaultPenaltyFrequency = DbResult.DefaultPenaltyFrequency;
                    oNewLoanType.Moratorium = DbResult.Moratorium;
                    oNewLoanType.MinShares = DbResult.MinShares;
                    oNewLoanType.InterestCalFormula = DbResult.InterestCalFormula;
                    oNewLoanType.MinPeriod = DbResult.MinPeriod;
                    oNewLoanType.LoansFactor = DbResult.LoansFactor;
                    oNewLoanType.RepaymentFrequency = DbResult.RepaymentFrequency;
                    oNewLoanType.GracePeriod = DbResult.GracePeriod;
                    oNewLoanType.ApplyPenaltyAfterMaturity = DbResult.ApplyPenaltyAfterMaturity;
                    oNewLoanType.IsSecure = DbResult.IsSecure;
                    oNewLoanType.ChargeInterestDuringGracePeriod = DbResult.ChargeInterestDuringGracePeriod;
                    oNewLoanType.PreConsiderInterest = DbResult.PreConsiderInterest;
                    oNewLoanType.ForgoneInterest = DbResult.ForgoneInterest;
                    oNewLoanType.AllowPartialDisbursements = DbResult.AllowPartialDisbursements;
                    oNewLoanType.AllowTopups = DbResult.AllowTopups;
                    oNewLoanType.AdjustInterestRate = DbResult.AdjustInterestRate;
                    oNewLoanType.ConsiderLoanSeries = DbResult.ConsiderLoanSeries;
                    oNewLoanType.IsMarkupBased = DbResult.IsMarkupBased;
                    oNewLoanType.ForcedSaleValue = DbResult.ForcedSaleValue;
                    oNewLoanType.UseOfZeroShares = DbResult.UseOfZeroShares;
                    oNewLoanType.MarginBaseAmount = DbResult.MarginBaseAmount;
                    oNewLoanType.IncrementValue = DbResult.IncrementValue;
                    oNewLoanType.IsMobileLoan = DbResult.IsMobileLoan;
                    oNewLoanType.IsIncrementFactor = DbResult.IsIncrementFactor;
                    oNewLoanType.NearestPrincipleRounding = DbResult.NearestPrincipleRounding;
                    oNewLoanType.PrincipalRoundingType = DbResult.PrincipalRoundingType;
                    oNewLoanType.NearestInterestRounding = DbResult.NearestInterestRounding;
                    oNewLoanType.InterestRoundingType = DbResult.InterestRoundingType;
                    oNewLoanType.Category = DbResult.Category;
                    oNewLoanType.Remarks = DbResult.Remarks;

                    oNewLoanType.ErrorDescription = "";
                    oNewLoanType.IsSuccess = true;
                    return Ok(oNewLoanType);
                }

            }
            catch (Exception ex)
            {
                oNewLoanType.ErrorDescription = ex.Message;
                return Ok(oNewLoanType);

            }
        }

        [Route("LoanType/UpdateLoanType"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanType(int? LoanTypeId, string RefCode, string Description, int? MaxPeriod, int? InterestRate, string InterestRateFrequency, decimal? MinAmount, decimal? MaxAmount, decimal? IncomeFactor, bool? ChargeInterestDuringGracePeriod, decimal? SharesFactor, int? MinGuarantors, int? MaxGuarantors,
        string InterestPayMethod, int? DefaultPenalty, string DefaultPenaltyFrequency, int? Moratorium, int? MinShares, string InterestCalFormula, int? MinPeriod, decimal? LoansFactor, string RepaymentFrequency, int? GracePeriod, bool? ApplyPenaltyAfterMaturity,
        bool? IsSecure, bool? Consider23rdRule, bool? PreConsiderInterest, bool? ForgoneInterest, bool? AllowPartialDisbursements, bool? AllowTopups, bool? AdjustInterestRate, bool? ConsiderLoanSeries, bool? IsMarkupBased,
         decimal? ForcedSaleValue, bool? UseOfZeroShares, decimal? MarginBaseAmount, string IncrementValue, bool? IsMobileLoan, bool? IsIncrementFactor, string NearestPrincipleRounding, string PrincipalRoundingType, string NearestInterestRounding, string InterestRoundingType,
        string Category, string Remarks, bool Delete)

        {
            LoanType oNewLoanType = new LoanType();
            oNewLoanType.IsSuccess = false;
            oNewLoanType.ErrorDescription = " ";
            if (LoanTypeId == null)
            {
                oNewLoanType.ErrorDescription = "LoanType Id is empty ";
                return Ok(oNewLoanType);
            }

            if (ApplyPenaltyAfterMaturity == null) { ApplyPenaltyAfterMaturity = false; }
            if (IsSecure == null) { IsSecure = false; }
            if (Consider23rdRule == null) { Consider23rdRule = false; }
            if (AllowTopups == null) { AllowTopups = false; }
            if (ForcedSaleValue == null) { ForcedSaleValue = 0; }
            if (UseOfZeroShares == null) { UseOfZeroShares = false; }
            if (IncrementValue == null) { IncrementValue = ""; }


            if (RefCode == null) { RefCode = ""; }
            if (Description == null)
            {
                oNewLoanType.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanType);
            }
            if (MaxPeriod == null) { MaxPeriod = 0; }
            if (InterestRate == null) { InterestRate = 0; }
            if (InterestRateFrequency == null) { InterestRateFrequency = ""; }
            if (DefaultPenalty == null) { DefaultPenalty = 0; }
            if (DefaultPenaltyFrequency == null) { DefaultPenaltyFrequency = ""; }
            if (InterestPayMethod == null) { InterestPayMethod = ""; }
            if (InterestCalFormula == null) { InterestCalFormula = ""; }
            if (IncomeFactor == null) { IncomeFactor = 0; }
            if (RepaymentFrequency == null) { RepaymentFrequency = ""; }
            if (SharesFactor == null) { SharesFactor = 0; }
            if (LoansFactor == null) { LoansFactor = 0; }
            if (MinGuarantors == null) { MinGuarantors = 0; }
            if (MaxGuarantors == null) { MaxGuarantors = 0; }
            if (MinShares == null) { MinShares = 0; }
            if (MinAmount == null) { MinAmount = 0; }
            if (MaxAmount == null) { MaxAmount = 0; }
            if (MinPeriod == null) { MinPeriod = 0; }
            if (AdjustInterestRate == null) { AdjustInterestRate = false; }
            if (ConsiderLoanSeries == null) { ConsiderLoanSeries = false; }
            if (ForgoneInterest == null) { ForgoneInterest = false; }
            if (GracePeriod == null) { GracePeriod = 0; }
            if (ChargeInterestDuringGracePeriod == null) { ChargeInterestDuringGracePeriod = false; }
            if (AllowPartialDisbursements == null) { AllowPartialDisbursements = false; }
            if (Category == null) { Category = " "; }
            if (Remarks == null) { Remarks = " "; }
            if (PreConsiderInterest == null) { PreConsiderInterest = false; }
            if (Moratorium == null) { Moratorium = 0; }
            if (NearestPrincipleRounding == null) { NearestPrincipleRounding = " "; }
            if (PrincipalRoundingType == null) { PrincipalRoundingType = " "; }
            if (NearestInterestRounding == null) { NearestInterestRounding = " "; }
            if (InterestRoundingType == null) { InterestRoundingType = " "; }
            if (IsMobileLoan == null) { IsMobileLoan = false; }
            if (MarginBaseAmount == null) { MarginBaseAmount = 0; }
            if (IsIncrementFactor == null) { IsIncrementFactor = false; }
            if (IsMarkupBased == null) { IsMarkupBased = false; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoansType(LoanTypeId, RefCode, Description, MaxPeriod, InterestRate, InterestRateFrequency, MinAmount, MaxAmount, IncomeFactor, ChargeInterestDuringGracePeriod, SharesFactor, MinGuarantors, MaxGuarantors,
                    InterestPayMethod, DefaultPenalty, DefaultPenaltyFrequency, Moratorium, MinShares, InterestCalFormula, MinPeriod, LoansFactor, RepaymentFrequency, GracePeriod, ApplyPenaltyAfterMaturity,
                    IsSecure, Consider23rdRule, PreConsiderInterest, ForgoneInterest, AllowPartialDisbursements, AllowTopups, AdjustInterestRate, ConsiderLoanSeries, IsMarkupBased,
                    ForcedSaleValue, UseOfZeroShares, MarginBaseAmount, IncrementValue, IsMobileLoan, IsIncrementFactor, NearestPrincipleRounding, PrincipalRoundingType, NearestInterestRounding, InterestRoundingType,
                    Category, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanType.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewLoanType.LoanTypeId = DbResult.LoanTypeId;
                    oNewLoanType.RefCode = DbResult.RefCode;
                    oNewLoanType.Description = DbResult.Description;
                    oNewLoanType.MaxPeriod = DbResult.MaxPeriod;
                    oNewLoanType.InterestRate = DbResult.InterestRate;
                    oNewLoanType.InterestRateFrequency = DbResult.InterestRateFrequency;
                    oNewLoanType.MinAmount = DbResult.MinAmount;
                    oNewLoanType.MaxAmount = DbResult.MaxAmount;
                    oNewLoanType.IncomeFactor = DbResult.IncomeFactor;
                    oNewLoanType.ChargeInterestDuringGracePeriod = DbResult.ChargeInterestDuringGracePeriod;
                    oNewLoanType.SharesFactor = DbResult.SharesFactor;
                    oNewLoanType.MinGuarantors = DbResult.MinGuarantors;
                    oNewLoanType.MaxGuarantors = DbResult.MaxGuarantors;
                    oNewLoanType.InterestPayMethod = DbResult.InterestPayMethod;
                    oNewLoanType.DefaultPenalty = DbResult.DefaultPenalty;
                    oNewLoanType.DefaultPenaltyFrequency = DbResult.DefaultPenaltyFrequency;
                    oNewLoanType.Moratorium = DbResult.Moratorium;
                    oNewLoanType.MinShares = DbResult.MinShares;
                    oNewLoanType.InterestCalFormula = DbResult.InterestCalFormula;
                    oNewLoanType.MinPeriod = DbResult.MinPeriod;
                    oNewLoanType.LoansFactor = DbResult.LoansFactor;
                    oNewLoanType.RepaymentFrequency = DbResult.RepaymentFrequency;
                    oNewLoanType.GracePeriod = DbResult.GracePeriod;
                    oNewLoanType.ApplyPenaltyAfterMaturity = DbResult.ApplyPenaltyAfterMaturity;
                    oNewLoanType.IsSecure = DbResult.IsSecure;
                    oNewLoanType.ChargeInterestDuringGracePeriod = DbResult.ChargeInterestDuringGracePeriod;
                    oNewLoanType.PreConsiderInterest = DbResult.PreConsiderInterest;
                    oNewLoanType.ForgoneInterest = DbResult.ForgoneInterest;
                    oNewLoanType.AllowPartialDisbursements = DbResult.AllowPartialDisbursements;
                    oNewLoanType.AllowTopups = DbResult.AllowTopups;
                    oNewLoanType.AdjustInterestRate = DbResult.AdjustInterestRate;
                    oNewLoanType.ConsiderLoanSeries = DbResult.ConsiderLoanSeries;
                    oNewLoanType.IsMarkupBased = DbResult.IsMarkupBased;
                    oNewLoanType.ForcedSaleValue = DbResult.ForcedSaleValue;
                    oNewLoanType.UseOfZeroShares = DbResult.UseOfZeroShares;
                    oNewLoanType.MarginBaseAmount = DbResult.MarginBaseAmount;
                    oNewLoanType.IncrementValue = DbResult.IncrementValue;
                    oNewLoanType.IsMobileLoan = DbResult.IsMobileLoan;
                    oNewLoanType.IsIncrementFactor = DbResult.IsIncrementFactor;
                    oNewLoanType.NearestPrincipleRounding = DbResult.NearestPrincipleRounding;
                    oNewLoanType.PrincipalRoundingType = DbResult.PrincipalRoundingType;
                    oNewLoanType.NearestInterestRounding = DbResult.NearestInterestRounding;
                    oNewLoanType.InterestRoundingType = DbResult.InterestRoundingType;
                    oNewLoanType.Category = DbResult.Category;
                    oNewLoanType.Remarks = DbResult.Remarks;

                    oNewLoanType.ErrorDescription = "";
                    oNewLoanType.IsSuccess = true;
                    return Ok(oNewLoanType);

                }

            }
            catch (Exception ex)
            {
                oNewLoanType.ErrorDescription = ex.Message;
                return Ok(oNewLoanType);

            }
        }

        [Route("LoanType/GetAllLoanTypes")]
        public IHttpActionResult GetAllLoanTypes()
        {

            LoanType oNewLoanType = new LoanType();
            oNewLoanType.IsSuccess = false;
            oNewLoanType.ErrorDescription = " ";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoansType().ToList();
                    List<LoanType> listofLoanTypes = new List<LoanType>();
                    foreach (var items in DbResult)
                    {
                        LoanType oLoanType = new LoanType();

                        oLoanType.LoanTypeId = items.LoanTypeId;
                        oLoanType.RefCode = items.RefCode;
                        oLoanType.Description = items.Description;
                        oLoanType.MaxPeriod = items.MaxPeriod;
                        oLoanType.InterestRate = items.InterestRate;
                        oLoanType.InterestRateFrequency = items.InterestRateFrequency;
                        oLoanType.MinAmount = items.MinAmount;
                        oLoanType.MaxAmount = items.MaxAmount;
                        oLoanType.IncomeFactor = items.IncomeFactor;
                        oLoanType.ChargeInterestDuringGracePeriod = items.ChargeInterestDuringGracePeriod;
                        oLoanType.SharesFactor = items.SharesFactor;
                        oLoanType.MinGuarantors = items.MinGuarantors;
                        oLoanType.MaxGuarantors = items.MaxGuarantors;
                        oLoanType.InterestPayMethod = items.InterestPayMethod;
                        oLoanType.DefaultPenalty = items.DefaultPenalty;
                        oLoanType.DefaultPenaltyFrequency = items.DefaultPenaltyFrequency;
                        oLoanType.Moratorium = items.Moratorium;
                        oLoanType.MinShares = items.MinShares;
                        oLoanType.InterestCalFormula = items.InterestCalFormula;
                        oLoanType.MinPeriod = items.MinPeriod;
                        oLoanType.LoansFactor = items.LoansFactor;
                        oLoanType.RepaymentFrequency = items.RepaymentFrequency;
                        oLoanType.GracePeriod = items.GracePeriod;
                        oLoanType.ApplyPenaltyAfterMaturity = items.ApplyPenaltyAfterMaturity;
                        oLoanType.IsSecure = items.IsSecure;
                        oLoanType.ChargeInterestDuringGracePeriod = items.ChargeInterestDuringGracePeriod;
                        oLoanType.PreConsiderInterest = items.PreConsiderInterest;
                        oLoanType.ForgoneInterest = items.ForgoneInterest;
                        oLoanType.AllowPartialDisbursements = items.AllowPartialDisbursements;
                        oLoanType.AllowTopups = items.AllowTopups;
                        oLoanType.AdjustInterestRate = items.AdjustInterestRate;
                        oLoanType.ConsiderLoanSeries = items.ConsiderLoanSeries;
                        oLoanType.IsMarkupBased = items.IsMarkupBased;
                        oLoanType.ForcedSaleValue = items.ForcedSaleValue;
                        oLoanType.UseOfZeroShares = items.UseOfZeroShares;
                        oLoanType.MarginBaseAmount = items.MarginBaseAmount;
                        oLoanType.IncrementValue = items.IncrementValue;
                        oLoanType.IsMobileLoan = items.IsMobileLoan;
                        oLoanType.IsIncrementFactor = items.IsIncrementFactor;
                        oLoanType.NearestPrincipleRounding = items.NearestPrincipleRounding;
                        oLoanType.PrincipalRoundingType = items.PrincipalRoundingType;
                        oLoanType.NearestInterestRounding = items.NearestInterestRounding;
                        oLoanType.InterestRoundingType = items.InterestRoundingType;
                        oLoanType.Category = items.Category;
                        oLoanType.Remarks = items.Remarks;

                        oLoanType.ErrorDescription = "";
                        oLoanType.IsSuccess = true;
                        listofLoanTypes.Add(oLoanType);
                    }
                    IEnumerable<LoanType> myLoanType = listofLoanTypes;
                    return Ok(myLoanType);

                }
            }
            catch (Exception ex)
            {
                oNewLoanType.ErrorDescription = ex.Message;
                return Ok(oNewLoanType);

            }

        }

        [Route("LoanType/DeleteLoanType"), HttpGet]
        public IHttpActionResult DeleteLoanType(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {
                tblLoansType loanType = db.tblLoansTypes.SingleOrDefault(x => x.LoanTypeId == id);
                db.tblLoansTypes.Remove(loanType);
                db.SaveChanges();
                return Ok(loanType);


            }
        }

        [Route("LoanType/GetLoanTypeById")]
        public IHttpActionResult GetLoanTypeById(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loantypes = (from a in db.tblLoansTypes
                                 where a.LoanTypeId == id
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
                                     a.ForcedSaleValue,
                                     a.UseOfZeroShares,
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
                return Ok(new { loantypes });


            }


        }
        [Route("LoanCharges/AddLoanTypeCharges"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanTypeCharges(int? LoanChargesListId, int? LoanTypeId, string Name, bool? IsPercentage, decimal? Value,
               decimal? Amount, int? PeriodToCharge, bool? HasLimit, decimal? LowerLimit, decimal? UpperLimit,
               bool? UseFormula, string TheFormula, bool? IsTariff, bool Delete)

        {
            LoanTypeCharge oNewLoanTypeCharges = new LoanTypeCharge();
            oNewLoanTypeCharges.IsSuccess = false;
            oNewLoanTypeCharges.ErrorDescription = "";

            if (LoanChargesListId == null) { LoanChargesListId = 0; }
            if (LoanTypeId == null) { LoanTypeId = 0; }
            if (Name == null)
            {
                oNewLoanTypeCharges.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanTypeCharges);
            }
            if (IsPercentage == null) { IsPercentage = false; }
            if (Value == null) { Value = 0; }
            if (Amount == null) { Amount = 0; }
            if (PeriodToCharge == null) { PeriodToCharge = 0; }
            if (HasLimit == null) { HasLimit = false; }
            if (LowerLimit == null) { LowerLimit = 0; }
            if (UpperLimit == null) { UpperLimit = 0; }
            if (UseFormula == null) { UseFormula = false; }
            if (TheFormula == null) { TheFormula = ""; }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanTypeCharges(0, LoanChargesListId, LoanTypeId, Name, IsTariff, IsPercentage, Value, Amount, PeriodToCharge, HasLimit,
                    LowerLimit, UpperLimit, UseFormula, TheFormula, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanTypeCharges.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewLoanTypeCharges.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanTypeCharges.LoanTypeChargesId = DbResult.LoanTypeChargesId;
                    oNewLoanTypeCharges.LoanTypeId = DbResult.LoanTypeId;
                    oNewLoanTypeCharges.Name = DbResult.Name;
                    oNewLoanTypeCharges.IsPercentage = DbResult.IsPercentage;
                    oNewLoanTypeCharges.Value = DbResult.Value;
                    oNewLoanTypeCharges.Amount = DbResult.Amount;
                    oNewLoanTypeCharges.PeriodToCharge = DbResult.PeriodToCharge;
                    oNewLoanTypeCharges.HasLimit = DbResult.HasLimit;
                    oNewLoanTypeCharges.LowerLimit = DbResult.LowerLimit;
                    oNewLoanTypeCharges.UpperLimit = DbResult.UpperLimit;
                    oNewLoanTypeCharges.UseFormula = DbResult.UseFormula;
                    oNewLoanTypeCharges.TheFormula = DbResult.TheFormula;
                    oNewLoanTypeCharges.ErrorDescription = "";
                    oNewLoanTypeCharges.IsSuccess = true;
                    return Ok(oNewLoanTypeCharges);
                }

            }
            catch (Exception ex)
            {
                oNewLoanTypeCharges.ErrorDescription = ex.Message;
                return Ok(oNewLoanTypeCharges);

            }
        }

        [Route("LoanCharges/UpdateLoanTypeCharges"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanTypeCharges(int? LoanTypeChargesId, int? LoanChargesListId, int? LoanTypeId, string Name, bool? IsPercentage, decimal? Value,
        decimal? Amount, int? PeriodToCharge, bool? HasLimit, decimal? LowerLimit, decimal? UpperLimit,
        bool? UseFormula, string TheFormula, bool? IsTariff, bool Delete)
        {
            LoanTypeCharge oNewLoanTypeCharges = new LoanTypeCharge();
            oNewLoanTypeCharges.IsSuccess = false;
            oNewLoanTypeCharges.ErrorDescription = "";

            if (LoanChargesListId == null) { LoanChargesListId = 0; }
            if (LoanTypeId == null) { LoanTypeId = 0; }
            if (Name == null)
            {
                oNewLoanTypeCharges.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanTypeCharges);
            }
            if (IsPercentage == null) { IsPercentage = false; }
            if (Value == null) { Value = 0; }
            if (Amount == null) { Amount = 0; }
            if (PeriodToCharge == null) { PeriodToCharge = 0; }
            if (HasLimit == null) { HasLimit = false; }
            if (LowerLimit == null) { LowerLimit = 0; }
            if (UpperLimit == null) { UpperLimit = 0; }
            if (UseFormula == null) { UseFormula = false; }
            if (TheFormula == null) { TheFormula = ""; }


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanTypeCharges(LoanTypeChargesId, LoanChargesListId, LoanTypeId, Name, IsTariff, IsPercentage, Value, Amount, PeriodToCharge, HasLimit,
                    LowerLimit, UpperLimit, UseFormula, TheFormula, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanTypeCharges.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewLoanTypeCharges.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanTypeCharges.LoanTypeChargesId = DbResult.LoanTypeChargesId;
                    oNewLoanTypeCharges.LoanTypeId = DbResult.LoanTypeId;
                    oNewLoanTypeCharges.Name = DbResult.Name;
                    oNewLoanTypeCharges.IsPercentage = DbResult.IsPercentage;
                    oNewLoanTypeCharges.Value = DbResult.Value;
                    oNewLoanTypeCharges.Amount = DbResult.Amount;
                    oNewLoanTypeCharges.PeriodToCharge = DbResult.PeriodToCharge;
                    oNewLoanTypeCharges.HasLimit = DbResult.HasLimit;
                    oNewLoanTypeCharges.LowerLimit = DbResult.LowerLimit;
                    oNewLoanTypeCharges.UpperLimit = DbResult.UpperLimit;
                    oNewLoanTypeCharges.UseFormula = DbResult.UseFormula;
                    oNewLoanTypeCharges.TheFormula = DbResult.TheFormula;
                    

                    oNewLoanTypeCharges.ErrorDescription = "";
                    oNewLoanTypeCharges.IsSuccess = true;
                    return Ok(oNewLoanTypeCharges);
                }

            }
            catch (Exception ex)
            {
                oNewLoanTypeCharges.ErrorDescription = ex.Message;
                return Ok(oNewLoanTypeCharges);

            }
        }

        [Route("LoanCharges/GetAllLoanTypeCharges")]
        public IHttpActionResult GetAllLoanTypesCharges()
        {

            LoanTypeCharge oNewLoanTypeCharges = new LoanTypeCharge();
            oNewLoanTypeCharges.IsSuccess = false;
            oNewLoanTypeCharges.ErrorDescription = " ";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoansTypeCharges().ToList();
                    List<LoanTypeCharge> listofLoanTypeCharges = new List<LoanTypeCharge>();
                    foreach (var items in DbResult)
                    {
                        LoanTypeCharge oLoanTypeCharges = new LoanTypeCharge();

                        oLoanTypeCharges.LoanChargesListId = items.LoanChargesListId;
                        oLoanTypeCharges.LoanTypeChargesId = items.LoanTypeChargesId;
                        oLoanTypeCharges.LoanTypeId = items.LoanTypeId;
                        oLoanTypeCharges.Name = items.Name;
                        oLoanTypeCharges.IsPercentage = items.IsPercentage;
                        oLoanTypeCharges.Value = items.Value;
                        oLoanTypeCharges.IsTariffBased = items.IsTariffBased;
                     
                        oLoanTypeCharges.Amount = items.Amount;
                        oLoanTypeCharges.PeriodToCharge = items.PeriodToCharge;
                        oLoanTypeCharges.HasLimit = items.HasLimit;
                        oLoanTypeCharges.LowerLimit = items.LowerLimit;
                        oLoanTypeCharges.UpperLimit = items.UpperLimit;
                        oLoanTypeCharges.UseFormula = items.UseFormula;
                        oLoanTypeCharges.TheFormula = items.TheFormula;

                        oLoanTypeCharges.ErrorDescription = "";
                        oLoanTypeCharges.IsSuccess = true;
                        listofLoanTypeCharges.Add(oLoanTypeCharges);
                    }
                    IEnumerable<LoanTypeCharge> myLoanTypeCharges = listofLoanTypeCharges;
                    return Ok(myLoanTypeCharges);

                }
            }
            catch (Exception ex)
            {
                oNewLoanTypeCharges.ErrorDescription = ex.Message;
                return Ok(oNewLoanTypeCharges);

            }

        }

        [Route("LoanCharges/GetAllLoanTypeChargesByLoanTypeId")]
        public IHttpActionResult GetAllLoanTypesChargesByLoanTypeId(int? id)
        {

            LoanTypeCharge oNewLoanTypeCharges = new LoanTypeCharge();
            oNewLoanTypeCharges.IsSuccess = false;
            oNewLoanTypeCharges.ErrorDescription = " ";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoanTypeChargesByLoansTypeId(id).ToList();
                    List<LoanTypeCharge> listofLoanTypeCharges = new List<LoanTypeCharge>();
                    foreach (var items in DbResult)
                    {
                        LoanTypeCharge oLoanTypeCharges = new LoanTypeCharge();

                        oLoanTypeCharges.LoanChargesListId = items.LoanChargesListId;
                        oLoanTypeCharges.LoanTypeChargesId = items.LoanTypeChargesId;
                        oLoanTypeCharges.LoanTypeId = items.LoanTypeId;
                        oLoanTypeCharges.Name = items.Name;
                        oLoanTypeCharges.IsPercentage = items.IsPercentage;
                        oLoanTypeCharges.Value = items.Value;
                        oLoanTypeCharges.Amount = items.Amount;
                        oLoanTypeCharges.PeriodToCharge = items.PeriodToCharge;
                        oLoanTypeCharges.HasLimit = items.HasLimit;
                        oLoanTypeCharges.LowerLimit = items.LowerLimit;
                        oLoanTypeCharges.UpperLimit = items.UpperLimit;
                        oLoanTypeCharges.UseFormula = items.UseFormula;
                        oLoanTypeCharges.TheFormula = items.TheFormula;
                        oLoanTypeCharges.IsTariffBased = items.IsTariffBased;
                        oLoanTypeCharges.ErrorDescription = "";
                        oLoanTypeCharges.IsSuccess = true;
                        listofLoanTypeCharges.Add(oLoanTypeCharges);
                    }
                    IEnumerable<LoanTypeCharge> myLoanTypeCharges = listofLoanTypeCharges;
                    return Ok(myLoanTypeCharges);

                }
            }
            catch (Exception ex)
            {
                oNewLoanTypeCharges.ErrorDescription = ex.Message;
                return Ok(oNewLoanTypeCharges);

            }

        }

        [Route("LoanCharges/DeleteLoanTypeCharges"), HttpGet]
        public IHttpActionResult DeleteLoanTypeCharges(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblLoanTypeCharge loanTypeCharges = db.tblLoanTypeCharges.SingleOrDefault(x => x.LoanTypeChargesId == id);
                db.tblLoanTypeCharges.Remove(loanTypeCharges);
                db.SaveChanges();
                return Ok(loanTypeCharges);
            }
        }

        [Route("LoanCharges/GetLoanTypeChargesById")]
        public IHttpActionResult GetLoanTypeChargesById(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loantypecharges = (from a in db.tblLoanTypeCharges
                                       where a.LoanTypeChargesId == id
                                       select new
                                       {
                                           a.LoanChargesListId,
                                           a.LoanTypeChargesId,
                                           a.LoanTypeId,
                                           a.Name,
                                           a.IsPercentage,
                                           a.Value,
                                           a.Amount,
                                           a.PeriodToCharge,
                                           a.HasLimit,
                                           a.LowerLimit,
                                           a.UpperLimit,
                                           a.UseFormula,
                                           a.TheFormula,
                                           a.IsTariffBased,

                                       }).FirstOrDefault();
                return Ok(new { loantypecharges });


            }

        }

        /// Loan Charges List

        [Route("LoanCharges/AddLoanChargesList"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanChargesList(string Name, bool? Recur, bool? IncludeInterest, bool? IsTariffBased, bool Delete)

        {
            LoanChargesList oNewLoanChargesList = new LoanChargesList();
            oNewLoanChargesList.IsSuccess = false;
            oNewLoanChargesList.ErrorDescription = "";


            if (Name == null)
            {
                oNewLoanChargesList.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanChargesList);
            }
            if (Recur == null) { Recur = false; }
            if (IncludeInterest == null) { IncludeInterest = false; }
            if (IsTariffBased == null) { IsTariffBased = false; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanChargesList(0, Name, Recur, IncludeInterest, IsTariffBased, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanChargesList.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewLoanChargesList.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanChargesList.Name = DbResult.Name;
                    oNewLoanChargesList.Recur = DbResult.Recur;
                    oNewLoanChargesList.IncludeInterest = DbResult.IncludeInterest;
                    oNewLoanChargesList.IsTariffBased = DbResult.IsTariffBased;



                    oNewLoanChargesList.ErrorDescription = "";
                    oNewLoanChargesList.IsSuccess = true;
                    return Ok(oNewLoanChargesList);
                }

            }
            catch (Exception ex)
            {
                oNewLoanChargesList.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargesList);

            }
        }

        [Route("LoanCharges/UpdateLoanChargesList"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanChargesList(int? LoanChargesListId, string Name, bool? Recur, bool? IncludeInterest, bool? IsTariffBased, bool Delete)
        {
            LoanChargesList oNewLoanChargesList = new LoanChargesList();
            oNewLoanChargesList.IsSuccess = false;
            oNewLoanChargesList.ErrorDescription = "";
            if (LoanChargesListId == null)
            {
                oNewLoanChargesList.ErrorDescription = "Selected user's Id is null!";
                return Ok(oNewLoanChargesList);
            }

            if (Name == null)
            {
                oNewLoanChargesList.ErrorDescription = "Name is empty!";
                return Ok(oNewLoanChargesList);
            }
            if (Recur == null) { Recur = false; }
            if (IncludeInterest == null) { IncludeInterest = false; }
            if (IsTariffBased == null) { IsTariffBased = false; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanChargesList(LoanChargesListId, Name, Recur, IncludeInterest, IsTariffBased, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanChargesList.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewLoanChargesList.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanChargesList.Name = DbResult.Name;
                    oNewLoanChargesList.Recur = DbResult.Recur;
                    oNewLoanChargesList.IncludeInterest = DbResult.IncludeInterest;
                    oNewLoanChargesList.IsTariffBased = DbResult.IsTariffBased;



                    oNewLoanChargesList.ErrorDescription = "";
                    oNewLoanChargesList.IsSuccess = true;
                    return Ok(oNewLoanChargesList);
                }

            }
            catch (Exception ex)
            {
                oNewLoanChargesList.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargesList);

            }
        }

        [Route("LoanCharges/GetAllLoanChargesList")]
        public IHttpActionResult GetAllLoanChargesList()
        {
            LoanChargesList oNewLoanChargesList = new LoanChargesList();
            oNewLoanChargesList.IsSuccess = false;
            oNewLoanChargesList.ErrorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoanChargesList().ToList();
                    List<LoanChargesList> listofLoanChargesList = new List<LoanChargesList>();
                    foreach (var items in DbResult)
                    {
                        LoanChargesList oLoanChargesList = new LoanChargesList();

                        oLoanChargesList.LoanChargesListId = items.LoanChargesListId;
                        oLoanChargesList.Name = items.Name;
                        oLoanChargesList.Recur = items.Recur;
                        oLoanChargesList.IncludeInterest = items.IncludeInterest;
                        oLoanChargesList.IsTariffBased = items.IsTariffBased;

                        oLoanChargesList.ErrorDescription = "";
                        oLoanChargesList.IsSuccess = true;
                        listofLoanChargesList.Add(oLoanChargesList);
                    }
                    IEnumerable<LoanChargesList> myLoanChargesList = listofLoanChargesList;
                    return Ok(myLoanChargesList);

                }
            }
            catch (Exception ex)
            {
                oNewLoanChargesList.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargesList);

            }

        }

        [Route("LoanCharges/DeleteLoanChargesList"), HttpGet]
        public IHttpActionResult DeleteLoanChargesList(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblLoanChargesList loanChargesList = db.tblLoanChargesLists.SingleOrDefault(x => x.LoanChargesListId == id);
                db.tblLoanChargesLists.Remove(loanChargesList);
                db.SaveChanges();
                return Ok(loanChargesList);
            }
        }

        [Route("LoanCharges/GetLoanChargesListById")]
        public IHttpActionResult GetLoanChargesListById(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loanchargeslist = (from a in db.tblLoanChargesLists
                                       where a.LoanChargesListId == id
                                       select new
                                       {

                                           a.LoanChargesListId,
                                           a.Name,
                                           a.Recur,
                                           a.IncludeInterest,
                                           a.IsTariffBased,

                                       }).FirstOrDefault();
                return Ok(new { loanchargeslist });


            }

        }


        /// Loan Charges List Tariff

        [Route("LoanCharges/AddLoanChargeListTariff"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanChargeListTariff(int? LoanChargesListId,
            decimal? FromInterval, decimal? ToInterval, decimal? Amount, bool Delete)

        {
            LoanChargeListTariff oNewLoanChargeListTariff = new LoanChargeListTariff();
            oNewLoanChargeListTariff.IsSuccess = false;
            oNewLoanChargeListTariff.ErrorDescription = "";

            if (LoanChargesListId == null)
            {
                oNewLoanChargeListTariff.ErrorDescription = "LoanChargesListId is empty!";
                return Ok(oNewLoanChargeListTariff);
            }


            if (FromInterval == null) { FromInterval = 0; }
            if (ToInterval == null) { ToInterval = 0; }
            if (Amount == null) { Amount = 0; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanChargeListTariff(0, LoanChargesListId, FromInterval, ToInterval, Amount, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanChargeListTariff.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }


                    oNewLoanChargeListTariff.LoanChargesListTariffId = DbResult.LoanChargesListTariffId;
                    oNewLoanChargeListTariff.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanChargeListTariff.FromInterval = DbResult.FromInterval;
                    oNewLoanChargeListTariff.ToInterval = DbResult.ToInterval;
                    oNewLoanChargeListTariff.Amount = DbResult.Amount;

                    oNewLoanChargeListTariff.ErrorDescription = "";
                    oNewLoanChargeListTariff.IsSuccess = true;
                    return Ok(oNewLoanChargeListTariff);
                }

            }
            catch (Exception ex)
            {
                oNewLoanChargeListTariff.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargeListTariff);

            }
        }

        [Route("LoanCharges/UpdateLoanChargeListTariff"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanChargeListTariff(int? LoanChargesListTariffId, int? LoanChargesListId,
            decimal? FromInterval, decimal? ToInterval, decimal? Amount, bool Delete)
        {
            LoanChargeListTariff oNewLoanChargeListTariff = new LoanChargeListTariff();
            oNewLoanChargeListTariff.IsSuccess = false;
            oNewLoanChargeListTariff.ErrorDescription = "";

            if (LoanChargesListId == null)
            {
                oNewLoanChargeListTariff.ErrorDescription = "LoanChargesListId is empty!";
                return Ok(oNewLoanChargeListTariff);
            }


            if (FromInterval == null) { FromInterval = 0; }
            if (ToInterval == null) { ToInterval = 0; }
            if (Amount == null) { Amount = 0; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var DbResult = db.proc_AddEditLoanChargeListTariff(LoanChargesListTariffId, LoanChargesListId, FromInterval, ToInterval, Amount, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanChargeListTariff.ErrorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewLoanChargeListTariff.LoanChargesListTariffId = DbResult.LoanChargesListTariffId;
                    oNewLoanChargeListTariff.LoanChargesListId = DbResult.LoanChargesListId;
                    oNewLoanChargeListTariff.FromInterval = DbResult.FromInterval;
                    oNewLoanChargeListTariff.ToInterval = DbResult.ToInterval;
                    oNewLoanChargeListTariff.Amount = DbResult.Amount;

                    oNewLoanChargeListTariff.ErrorDescription = "";
                    oNewLoanChargeListTariff.IsSuccess = true;
                    return Ok(oNewLoanChargeListTariff);
                }

            }
            catch (Exception ex)
            {
                oNewLoanChargeListTariff.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargeListTariff);

            }
        }

        [Route("LoanCharges/GetAllLoanChargeListTariff")]
        public IHttpActionResult GetAllLoanChargeListTariff()
        {
            LoanChargeListTariff oNewLoanChargeListTariff = new LoanChargeListTariff();
            oNewLoanChargeListTariff.IsSuccess = false;
            oNewLoanChargeListTariff.ErrorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoanChargeListTariff().ToList();
                    List<LoanChargeListTariff> listofLoanChargeListTariff = new List<LoanChargeListTariff>();
                    foreach (var items in DbResult)
                    {
                        LoanChargeListTariff oLoanChargeListTariff = new LoanChargeListTariff();

                        oLoanChargeListTariff.LoanChargesListTariffId = items.LoanChargesListTariffId;
                        oLoanChargeListTariff.LoanChargesListId = items.LoanChargesListId;
                        oLoanChargeListTariff.FromInterval = items.FromInterval;
                        oLoanChargeListTariff.ToInterval = items.ToInterval;
                        oLoanChargeListTariff.Amount = items.Amount;

                        oLoanChargeListTariff.ErrorDescription = "";
                        oLoanChargeListTariff.IsSuccess = true;
                        listofLoanChargeListTariff.Add(oLoanChargeListTariff);
                    }
                    IEnumerable<LoanChargeListTariff> myLoanChargeListTariff = listofLoanChargeListTariff;
                    return Ok(myLoanChargeListTariff);

                }
            }
            catch (Exception ex)
            {
                oNewLoanChargeListTariff.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargeListTariff);

            }

        }

        [Route("LoanCharges/GetAllLoanChargeListTariffByLoanChargesListId")]
        public IHttpActionResult GetAllLoanChargeListTariffByLoanChargesListId(int? id)
        {
            LoanChargeListTariff oNewLoanChargeListTariff = new LoanChargeListTariff();
            oNewLoanChargeListTariff.IsSuccess = false;
            oNewLoanChargeListTariff.ErrorDescription = "";

            if (id == null)
            {
                oNewLoanChargeListTariff.ErrorDescription = "LoanChargesListId passed is empty!";
                return Ok(oNewLoanChargeListTariff);
            }

            if (id == 0)
            {
                oNewLoanChargeListTariff.ErrorDescription = "LoanChargesListId passed is 0!";
                return Ok(oNewLoanChargeListTariff);
            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllLoanChargeListTariffByLoanChargesListId(id).ToList();
                    List<LoanChargeListTariff> listofLoanChargeListTariff = new List<LoanChargeListTariff>();
                    foreach (var items in DbResult)
                    {
                        LoanChargeListTariff oLoanChargeListTariff = new LoanChargeListTariff();

                        oLoanChargeListTariff.LoanChargesListTariffId = items.LoanChargesListTariffId;
                        oLoanChargeListTariff.LoanChargesListId = items.LoanChargesListId;
                        oLoanChargeListTariff.FromInterval = items.FromInterval;
                        oLoanChargeListTariff.ToInterval = items.ToInterval;
                        oLoanChargeListTariff.Amount = items.Amount;

                        oLoanChargeListTariff.ErrorDescription = "";
                        oLoanChargeListTariff.IsSuccess = true;
                        listofLoanChargeListTariff.Add(oLoanChargeListTariff);
                    }
                    IEnumerable<LoanChargeListTariff> myLoanChargeListTariff = listofLoanChargeListTariff;
                    return Ok(myLoanChargeListTariff);

                }
            }
            catch (Exception ex)
            {
                oNewLoanChargeListTariff.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargeListTariff);

            }

        }

        [Route("LoanCharges/DeleteLoanChargeListTariff"), HttpGet]
        public IHttpActionResult DeleteLoanChargeListTariff(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblLoanChargesListTariff loanChargesListTariff = db.tblLoanChargesListTariffs.SingleOrDefault(x => x.LoanChargesListTariffId == id);
                db.tblLoanChargesListTariffs.Remove(loanChargesListTariff);
                db.SaveChanges();
                return Ok(loanChargesListTariff);
            }
        }

        [Route("LoanCharges/GetLoanChargesListTariffById")]
        public IHttpActionResult GetLoanChargesListTariffById(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var loanchargeslist = (from a in db.tblLoanChargesListTariffs
                                       where a.LoanChargesListTariffId == id
                                       select new
                                       {
                                           a.LoanChargesListTariffId,
                                           a.LoanChargesListId,
                                           a.FromInterval,
                                           a.ToInterval,
                                           a.Amount,

                                       }).FirstOrDefault();
                return Ok(new { loanchargeslist });


            }

        }
        [Route("LoanType/GetLoanTariffAmount")]
        public async Task<IHttpActionResult> GetLoanTariffAmount(decimal? Amount)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Tariff = (from a in db.tblLoanChargesListTariffs

                              where Amount >= a.FromInterval && Amount <= a.ToInterval 
                              select new
                              {
                                  a.Amount,

                              }).FirstOrDefault();
                return Ok(new { Tariff });


            }
        }
             [Route("LoanType/GetLoanChargesTariffAmount")]
        public async Task<IHttpActionResult> GetLoanChargesTariffAmount(decimal? Amount, int? LoanChargesListId)
        {
            LoanChargeListTariff oNewLoanChargeListTariff = new LoanChargeListTariff();
            oNewLoanChargeListTariff.IsSuccess = false;
            oNewLoanChargeListTariff.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_GetLoanTypeChargesUsingTariff(Amount, LoanChargesListId).FirstOrDefault();
                    oNewLoanChargeListTariff.Amount = dbResult.Value;

                    oNewLoanChargeListTariff.IsSuccess = true;
                    oNewLoanChargeListTariff.ErrorDescription = "";

                    return Ok(oNewLoanChargeListTariff);
                }
            }
            catch (Exception ex)
            {
                oNewLoanChargeListTariff.ErrorDescription = ex.Message;
                return Ok(oNewLoanChargeListTariff);
            }
        }



    }
}
