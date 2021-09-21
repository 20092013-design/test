using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class LoanPurpose
    {
        public int? LoanPurposeId { get; set; }
        public string Name { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class LoanApplication
    {
        public int? LoanId { get; set; }
        public int? LoanTypeId { get; set; }
        public int? MemberId { get; set; }
        public string Code { get; set; }
        public string ManualRef { get; set; }
        public decimal? LoanAmount { get; set; }
        public decimal? InterestRate { get; set; }
        public DateTime? ApplicationDate { get; set; }
        public string PeriodFrequency { get; set; }
        public int? RepayPeriod { get; set; }
        public bool? IsMarkUpBased { get; set; }
        public decimal? MarkupAmount { get; set; }
        public int? Interest { get; set; }
        public int? Status { get; set; }
        public DateTime? StatusDate { get; set; }
        public int? PurposeId { get; set; }
        public decimal? GrossPay { get; set; }
        public decimal? NetPay { get; set; }
        public string LoanSeries { get; set; }
        public decimal? TotalShares { get; set; }
        public decimal? FreeShares { get; set; }
        public bool? IsMigrated { get; set; }
        public int? CreditOfficerId { get; set; }
        public int? DonorId { get; set; }
        public int? CurrencyId { get; set; }
        public int? BranchId { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
        public int? CountRows { get; set; }
        public decimal? ApproveAmount { get; set; }
        public string ApproveBy { get; set; }
        public DateTime? AproveDate { get; set; }
        public int? PayModeId { get; set; }
        public int? BankId { get; set; }
        public string ChequeType { get; set; }
        public string ChequeNo { get; set; }
        public string RepaymentChargeMethod { get; set; }
        public decimal? ChargeAmount { get; set; }
        public Nullable<decimal> DisbursedAmount { get; set; }        
        public Nullable<System.DateTime> DisbursementDate { get; set; }
        public string DisbursedBy { get; set; }


    }
    public class LoanCollateral
    {
        public int? LoanCollateralId { get; set; }
        public int? CollateralId { get; set; }
        public string OwnerName { get; set; }
        public int? LoanId { get; set; }
        public string RegistrationDetails { get; set; }
        public decimal? ActualValue { get; set; }
        public decimal? ForcedSaleValue { get; set; }
        public string Remarks { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool? Delete { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
    public class LoanGuarator
    {
        public int? LoanGuarantorId { get; set; }
        public int? LoanId { get; set; }
        public int? MemberId { get; set; }
        public string FullName { get; set; }
        public string IdNo { get; set; }
        public int? GuarantorTypeId { get; set; }
        public string LoanSerialRef { get; set; }
        public decimal? GuaranteedAmount { get; set; }
        public bool? Delete { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }

    public class LoanStatus
    {
        public int? LoanStatusId { get; set; }
        public string LoanStatusName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class LoanDonor
    {
        public int? DonorId { get; set; }
        public string DonorName { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }
    }
    public class CompanyBranch    {        public int? CompanyBranchesId { get; set; }        public string Code { get; set; }        public string Name { get; set; }        public string errorDescription { get; set; }        public bool? isSuccess { get; set; }    }


    public partial class LoanTypeCharge
    {
        public int? LoanTypeChargesId { get; set; }
        public int? LoanChargesListId { get; set; }
        public int? LoanTypeId { get; set; }
        public string Name { get; set; }
        public bool? IsPercentage { get; set; }
        public decimal? Value { get; set; }
        public decimal? Amount { get; set; }
        public int? PeriodToCharge { get; set; }
        public bool? HasLimit { get; set; }
        public decimal? LowerLimit { get; set; }
        public decimal? UpperLimit { get; set; }
        public bool? UseFormula { get; set; }
        public bool? IsTariffBased { get; set; }
        public string TheFormula { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public partial class LoanType
    {
        public int LoanTypeId { get; set; }
        public string RefCode { get; set; }
        public string Description { get; set; }
        public int? MaxPeriod { get; set; }
        public int? InterestRate { get; set; }
        public string InterestRateFrequency { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
        public decimal? IncomeFactor { get; set; }
        public bool? ChargeInterestDuringGracePeriod { get; set; }
        public decimal? SharesFactor { get; set; }
        public int? MinGuarantors { get; set; }
        public int? MaxGuarantors { get; set; }
        public string InterestPayMethod { get; set; }
        public int? DefaultPenalty { get; set; }
        public string DefaultPenaltyFrequency { get; set; }
        public int? Moratorium { get; set; }
        public int? MinShares { get; set; }
        public string InterestCalFormula { get; set; }
        public int? MinPeriod { get; set; }
        public decimal? LoansFactor { get; set; }
        public string RepaymentFrequency { get; set; }
        public int? GracePeriod { get; set; }
        public bool? ApplyPenaltyAfterMaturity { get; set; }
        public bool? IsSecure { get; set; }
        public bool? Consider23rdRule { get; set; }
        public bool? PreConsiderInterest { get; set; }
        public bool? ForgoneInterest { get; set; }
        public bool? AllowPartialDisbursements { get; set; }
        public bool? AllowTopups { get; set; }
        public bool? AdjustInterestRate { get; set; }
        public bool? ConsiderLoanSeries { get; set; }
        public bool? IsMarkupBased { get; set; }
        public decimal? ForcedSaleValue { get; set; }
        public bool? UseOfZeroShares { get; set; }
        public decimal? MarginBaseAmount { get; set; }
        public string IncrementValue { get; set; }
        public bool? IsMobileLoan { get; set; }
        public bool? IsIncrementFactor { get; set; }
        public string NearestPrincipleRounding { get; set; }
        public string PrincipalRoundingType { get; set; }
        public string NearestInterestRounding { get; set; }
        public string InterestRoundingType { get; set; }
        public string Category { get; set; }
        public string Remarks { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }

    public class LoanChargesList
    {
        public int? LoanChargesListId { get; set; }
        public string Name { get; set; }
        public bool? Recur { get; set; }
        public bool? IncludeInterest { get; set; }
        public bool? IsTariffBased { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public partial class LoanChargeListTariff
    {
        public int? LoanChargesListTariffId { get; set; }
        public int? LoanChargesListId { get; set; }
        public decimal? FromInterval { get; set; }
        public decimal? ToInterval { get; set; }
        public decimal? Amount { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public class LoanApplicationsCharges {
        public int? LoanApplicationChargesId { get; set; }
        public int? LoanId { get; set; }
        public int? LoanTypeChargesId { get; set; }
        public int? LoanChargesListId { get; set; }
        public bool? IsPercent { get; set; }
        public bool? IsTariff { get; set; }
        public decimal? Value { get; set; }
        public decimal? Amount { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public class ErrorModel    {               public string LoanShareFactorError { get; set; }        public string ErrorDescription { get; set; }        public string LoanMinPeriodError { get; set; }        public string LoanSharesError { get; set; }        public string LoanMaxError { get; set; }        public string LoanMinError { get; set; }        public bool? IsSuccess { get; set; }    }
    public class ErrorModels
    {

        public string CollateralError { get; set; }
        public string GuarantorSecureError { get; set; }
        public string MinGuarantorsError { get; set; }
        public string MaxGuarantorsError { get; set; }
        public string LoanShareFactorError { get; set; }
        public string ErrorDescription { get; set; }
        public string LoanMinPeriodError { get; set; }
        public string LoanSharesError { get; set; }
        public string LoanMaxError { get; set; }
        public string LoanMinError { get; set; }

        public bool? IsSuccess { get; set; }
    }

    public partial class LoanGuarantors
    {
        public int? LoanGuarantorId { get; set; }
        public int? LoanId { get; set; }
        public int? MemberId { get; set; }
        public string FullName { get; set; }
        public string IdNo { get; set; }
        public int? GuarantorTypeId { get; set; }
        public string LoanSerialRef { get; set; }
        public decimal? GuaranteedAmount { get; set; }
    }

    public partial class Members
    {
        public int? MemberId { get; set; }
        public decimal? Nett { get; set; }
        public string FullName { get; set; }
    }


    public partial class Collaterals
    {
        public int? LoanCollateralId { get; set; }
        public int? CollateralId { get; set; }
        public decimal? ActualValue { get; set; }
        public decimal? ForcedSaleValue { get; set; }
    }
    public class SumLoanCharge
    {
        public decimal? TotalAmount { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public  class LoanRepayment
    {
        public int? RepaymentId { get; set; }
        public int? LoanId { get; set; }
        public int? BankId { get; set; }
        public int? CurrencyId { get; set; }
        public int? SerialId { get; set; }
        public int? BaseCurrencyId { get; set; }
        public decimal? ExchangeRate { get; set; }
        public decimal? ForeignAmount { get; set; }
        public decimal? Amount { get; set; }
        public int? RepaymentNo { get; set; }
        public DateTime? TransactionDate { get; set; }
        public DateTime? ValueDate { get; set; }
        public int? TransType { get; set; }       
        public string PaymentMode { get; set; }
        public string VoucherNo { get; set; }
        public string DocumentNo { get; set; }
        public string PaidBy { get; set; }
        public string Remarks { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }
    }
    public  class LoanRecoveryOrder
    {
        public int? LoanRecoveryOrderId { get; set; }
        public string OrderName { get; set; }
        public int?  RecoveryOrder { get; set; }
        public string ErrorDescription { get; set; }
        public bool? IsSuccess { get; set; }

    }
}