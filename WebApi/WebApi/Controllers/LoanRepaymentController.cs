using Newtonsoft.Json;
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
    public class LoanRepaymentController : ApiController
    {
        [Route("LoanRepayment/GetDisbursedLoan")]
        public async Task<IHttpActionResult> GetDisbursedLoan(int? MemberId)
        {
            LoanApplication oNewLoan = new LoanApplication();
            oNewLoan.isSuccess = false;
            oNewLoan.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResults = db.proc_GetDisbursedLoan1(MemberId).ToList();
                    List<LoanApplication> listofLoans = new List<LoanApplication>();
                    foreach (var dbResult in dbResults)
                    {
                        LoanApplication oLoan = new LoanApplication();
                        oLoan.LoanId = dbResult.LoanId;
                        oLoan.LoanTypeId = dbResult.LoanTypeId;
                        oLoan.MemberId = dbResult.MemberId;
                        oLoan.Code = dbResult.Code;
                        oLoan.ManualRef = dbResult.ManualRef;
                        oLoan.LoanAmount = dbResult.LoanAmount;
                        oLoan.InterestRate = dbResult.InterestRate;
                        oLoan.ApplicationDate = dbResult.ApplicationDate;
                        oLoan.PeriodFrequency = dbResult.PeriodFrequency;
                        oLoan.RepayPeriod = dbResult.RepayPeriod;
                        oLoan.IsMarkUpBased = dbResult.IsMarkUpBased;
                        oLoan.MarkupAmount = dbResult.MarkupAmount;
                        oLoan.Interest = dbResult.InterestType;
                        oLoan.Status = dbResult.Status;
                        oLoan.StatusDate = dbResult.StatusDate;
                        oLoan.PurposeId = dbResult.PurposeId;
                        oLoan.GrossPay = dbResult.GrossPay;
                        oLoan.NetPay = dbResult.NetPay;
                        oLoan.LoanSeries = dbResult.LoanSeries;
                        oLoan.TotalShares = dbResult.TotalShares;
                        oLoan.FreeShares = dbResult.FreeShares;
                        oLoan.IsMigrated = dbResult.IsMigrated;
                        oLoan.CreditOfficerId = dbResult.CreditOfficerId;
                        oLoan.DonorId = dbResult.DonorId;
                        oLoan.CurrencyId = dbResult.CurrencyId;
                        oLoan.BranchId = dbResult.BranchId;
                        oLoan.ApproveAmount = dbResult.ApproveAmount;
                        oLoan.ApproveBy = dbResult.ApproveBy;
                        oLoan.AproveDate = dbResult.AproveDate;
                        oLoan.PayModeId = dbResult.PayModeId;
                        oLoan.BankId = dbResult.BankId;
                        oLoan.ChequeType = dbResult.ChequeType;
                        oLoan.ChequeNo = dbResult.ChequeNo;
                        oLoan.RepaymentChargeMethod = dbResult.RepaymentChargeMethod;
                        oLoan.ChargeAmount = dbResult.ChargeAmount;
                        oLoan.DisbursedAmount = dbResult.DisbursedAmount;
                        oLoan.DisbursementDate = dbResult.DisbursementDate;
                        oLoan.DisbursedBy = dbResult.DisbursedBy;
                       
                        oLoan.errorDescription = "";
                        oLoan.isSuccess = true;
                        listofLoans.Add(oLoan);
                    }
                    IEnumerable<LoanApplication> myLoan = listofLoans;
                    return Ok(myLoan);
                }
            }
            catch (Exception ex)
            {
                oNewLoan.errorDescription = ex.Message;
                return Ok(oNewLoan);
            }
        }
        [Route("LoanRepayment/getLoanRepayment")]
        public async Task<IHttpActionResult> getLoanRepayment(int? LoanId)
        {
            LoanRepayment oNewLoanRepayment = new LoanRepayment();
            oNewLoanRepayment.IsSuccess = false;
            oNewLoanRepayment.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResults = db.proc_GetRepayedLoans(LoanId).ToList();
                    List<LoanRepayment> listofLoanRepayment = new List<LoanRepayment>();
                    foreach (var dbResult in DbResults)
                    {
                        LoanRepayment oLoanRepayment = new LoanRepayment();
                        oLoanRepayment.RepaymentId = dbResult.RepaymentId;
                        oLoanRepayment.LoanId = dbResult.LoanId;
                        oLoanRepayment.BankId = dbResult.BankId;
                        oLoanRepayment.CurrencyId = dbResult.CurrencyId;
                        oLoanRepayment.SerialId = dbResult.SerialId;
                        oLoanRepayment.BaseCurrencyId = dbResult.BaseCurrencyId;
                        oLoanRepayment.ExchangeRate = dbResult.ExchangeRate;
                        oLoanRepayment.ForeignAmount = dbResult.ForeignAmount;
                        oLoanRepayment.Amount = dbResult.Amount;
                        oLoanRepayment.RepaymentNo = dbResult.RepaymentNo;
                        oLoanRepayment.TransactionDate = dbResult.TransactionDate;
                        oLoanRepayment.ValueDate = dbResult.ValueDate;
                        oLoanRepayment.TransType = dbResult.TransType;                        
                        oLoanRepayment.PaymentMode = dbResult.PaymentMode;
                        oLoanRepayment.VoucherNo = dbResult.VoucherNo;
                        oLoanRepayment.DocumentNo = dbResult.DocumentNo;
                        oLoanRepayment.PaidBy = dbResult.PaidBy;
                        oLoanRepayment.Remarks = dbResult.Remarks;

                        oLoanRepayment.ErrorDescription = "";
                        oLoanRepayment.IsSuccess = true;
                        listofLoanRepayment.Add(oLoanRepayment);
                    }
                    IEnumerable<LoanRepayment> myLoanRepayment = listofLoanRepayment;
                    return Ok(myLoanRepayment);
                }
            }
            catch (Exception ex)
            {
                oNewLoanRepayment.ErrorDescription = ex.Message;
                return Ok(oNewLoanRepayment);
            }
        }
        [Route("LoanRepayment/getMaxRepayment")]
        public async Task<IHttpActionResult> getMaxRepayment(int? LoanId)
        {
            LoanRepayment oNewLoanRepayment = new LoanRepayment();
            oNewLoanRepayment.IsSuccess = false;
            oNewLoanRepayment.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_MaxRepayment(LoanId).FirstOrDefault();
                    oNewLoanRepayment.RepaymentNo = dbResult.Value;

                    oNewLoanRepayment.IsSuccess = true;
                    oNewLoanRepayment.ErrorDescription = "";

                    return Ok(oNewLoanRepayment);
                }
            }
            catch (Exception ex)
            {
                oNewLoanRepayment.ErrorDescription = ex.Message;
                return Ok(oNewLoanRepayment);
            }
        }
        [Route("LoanRepayment/getSumAmount")]
        public async Task<IHttpActionResult> getSumAmount(int? LoanId)
        {
            LoanRepayment oNewLoanRepayment = new LoanRepayment();
            oNewLoanRepayment.IsSuccess = false;
            oNewLoanRepayment.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getSumAmount(LoanId).FirstOrDefault();
                    oNewLoanRepayment.Amount = dbResult.Value;

                    oNewLoanRepayment.IsSuccess = true;
                    oNewLoanRepayment.ErrorDescription = "";

                    return Ok(oNewLoanRepayment);
                }
            }
            catch (Exception ex)
            {
                oNewLoanRepayment.ErrorDescription = ex.Message;
                return Ok(oNewLoanRepayment);
            }
        }
        [Route("LoanRepayment/AddLoanRepayment"), HttpGet, HttpPost]
            public async Task<IHttpActionResult> AddLoanRepayment
            ( int? LoanId, int? BankId, int? CurrencyId, int? SerialId, int? BaseCurrencyId, decimal? ExchangeRate, decimal? ForeignAmount, decimal? Amount, int? RepaymentNo, DateTime? TransactionDate, DateTime? ValueDate, int? TransType,  string PaymentMode, string VoucherNo,
            string DocumentNo, string PaidBy, string Remarks,bool? Delete)
            {
                LoanRepayment oNewLoanRepayment = new LoanRepayment();
                oNewLoanRepayment.IsSuccess = false;
                oNewLoanRepayment.ErrorDescription = "";
            if (TransactionDate == null) { TransactionDate= DateTime.Parse("1900/01/01"); }
            if (ValueDate == null) { ValueDate= DateTime.Parse("1900/01/01"); }
            if (Amount == null) { Amount = 0; }
            if (DocumentNo == null) { DocumentNo = ""; }


                try
                {

                    using (DBContextEntities db = new DBContextEntities())
                    {
                        var DbResult = db.proc_AddEditRepayedLoans(0,LoanId,BankId, CurrencyId, SerialId,  BaseCurrencyId,  ExchangeRate,  ForeignAmount,  Amount, RepaymentNo,TransactionDate,  ValueDate,  TransType,  PaymentMode,  VoucherNo,DocumentNo, PaidBy,  Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            oNewLoanRepayment.ErrorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }
                       
                        oNewLoanRepayment.LoanId = DbResult.LoanId;
                        oNewLoanRepayment.BankId = DbResult.BankId;
                        oNewLoanRepayment.CurrencyId = DbResult.CurrencyId;
                        oNewLoanRepayment.SerialId = DbResult.SerialId;
                        oNewLoanRepayment.BaseCurrencyId = DbResult.BaseCurrencyId;
                        oNewLoanRepayment.ExchangeRate = DbResult.ExchangeRate;
                        oNewLoanRepayment.ForeignAmount = DbResult.ForeignAmount;
                        oNewLoanRepayment.Amount = DbResult.Amount;
                        oNewLoanRepayment.RepaymentNo = DbResult.RepaymentNo;
                        oNewLoanRepayment.TransactionDate = DbResult.TransactionDate;
                        oNewLoanRepayment.ValueDate = DbResult.ValueDate;
                        oNewLoanRepayment.TransType = DbResult.TransType;                        
                        oNewLoanRepayment.PaymentMode = DbResult.PaymentMode;
                        oNewLoanRepayment.VoucherNo = DbResult.VoucherNo;
                        oNewLoanRepayment.DocumentNo = DbResult.DocumentNo;
                        oNewLoanRepayment.PaidBy = DbResult.PaidBy;
                        oNewLoanRepayment.Remarks = DbResult.Remarks;                      

                        oNewLoanRepayment.IsSuccess = true;
                        return Ok(oNewLoanRepayment);

                    }


                }
                catch (Exception ex)
                {
                    oNewLoanRepayment.ErrorDescription = ex.Message;
                    return Ok(oNewLoanRepayment);
                }

            }
            [Route("LoanRepayment/UpdateLoanRepayment"), HttpGet, HttpPost]
            public async Task<IHttpActionResult> UpdateLoanRepayment(int? RepaymentId, int? LoanId, int? BankId, int? CurrencyId, int? SerialId, int? BaseCurrencyId, decimal? ExchangeRate, decimal? ForeignAmount, decimal? Amount, int? RepaymentNo, DateTime? TransactionDate, DateTime? ValueDate, int? TransType, string PaymentMode, string VoucherNo,
            string DocumentNo, string PaidBy, string Remarks, bool? Delete)
            {
                LoanRepayment oNewLoanRepayment = new LoanRepayment();
                oNewLoanRepayment.IsSuccess = false;
                oNewLoanRepayment.ErrorDescription = "";

                try
                {

                    using (DBContextEntities db = new DBContextEntities())
                    {
                        var DbResult = db.proc_AddEditRepayedLoans(RepaymentId, LoanId, BankId, CurrencyId, SerialId, BaseCurrencyId, ExchangeRate, ForeignAmount, Amount, RepaymentNo, TransactionDate, ValueDate, TransType, PaymentMode, VoucherNo,DocumentNo, PaidBy, Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            oNewLoanRepayment.ErrorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }
                        oNewLoanRepayment.RepaymentId = DbResult.RepaymentId;
                    oNewLoanRepayment.LoanId = DbResult.LoanId;
                    oNewLoanRepayment.BankId = DbResult.BankId;
                    oNewLoanRepayment.CurrencyId = DbResult.CurrencyId;
                    oNewLoanRepayment.SerialId = DbResult.SerialId;
                    oNewLoanRepayment.BaseCurrencyId = DbResult.BaseCurrencyId;
                    oNewLoanRepayment.ExchangeRate = DbResult.ExchangeRate;
                    oNewLoanRepayment.ForeignAmount = DbResult.ForeignAmount;
                    oNewLoanRepayment.Amount = DbResult.Amount;
                    oNewLoanRepayment.RepaymentNo = DbResult.RepaymentNo;
                    oNewLoanRepayment.TransactionDate = DbResult.TransactionDate;
                    oNewLoanRepayment.ValueDate = DbResult.ValueDate;
                    oNewLoanRepayment.TransType = DbResult.TransType;                   
                    oNewLoanRepayment.PaymentMode = DbResult.PaymentMode;
                    oNewLoanRepayment.VoucherNo = DbResult.VoucherNo;
                    oNewLoanRepayment.DocumentNo = DbResult.DocumentNo;
                    oNewLoanRepayment.PaidBy = DbResult.PaidBy;
                    oNewLoanRepayment.Remarks = DbResult.Remarks;

                    oNewLoanRepayment.IsSuccess = true;
                        return Ok(oNewLoanRepayment);

                    }

                }
                catch (Exception ex)
                {
                    oNewLoanRepayment.ErrorDescription = ex.Message;
                    return Ok(oNewLoanRepayment);


                }
            }
        [Route("LoanRepayment/GetRepaymentLoan")]
        public async Task<IHttpActionResult> GetRepaymentLoan(int? id)
        {

            LoanRepayment oNewLoanRepayment = new LoanRepayment();
            oNewLoanRepayment.IsSuccess = false;
            oNewLoanRepayment.ErrorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var Repayment = (from a in db.tblLoanRepayments
                                     where a.RepaymentId == id
                                     select new
                                     {
                                         a.RepaymentId,
                                         a.LoanId,
                                         a.BankId,
                                         a.CurrencyId,
                                         a.SerialId,
                                         a.BaseCurrencyId,
                                         a.ExchangeRate,
                                         a.ForeignAmount,
                                         a.Amount,
                                         a.RepaymentNo,
                                         a.TransactionDate,
                                         a.ValueDate,
                                         a.TransType,
                                         a.PaymentMode,
                                         a.VoucherNo,
                                         a.DocumentNo,
                                         a.PaidBy,
                                         a.Remarks,
                                     }).FirstOrDefault();
                    return Ok(new { Repayment });
                }

            }
            catch (Exception ex)
            {
                oNewLoanRepayment.ErrorDescription = ex.Message;
                return Ok(oNewLoanRepayment);
            }

            
        }
        [HttpGet, HttpDelete]
        [Route("LoanRepayment/DeleteLoanRepayment")]
        public IHttpActionResult DeleteLoanRepayment(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {

                tblLoanRepayment LoanRepayment = db.tblLoanRepayments.SingleOrDefault(x => x.RepaymentId == id);
                db.tblLoanRepayments.Remove(LoanRepayment);
                db.SaveChanges();
                return Ok(LoanRepayment);
            }
        }
        [Route("LoanRepayment/AddLoanRecoveryOrder"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLoanRecoveryOrder(string OrderName, int? RecoveryOrder, bool? Delete)
        {
            LoanRecoveryOrder oNewLoanRecoveryOrder = new LoanRecoveryOrder();
            oNewLoanRecoveryOrder.ErrorDescription = "";
            oNewLoanRecoveryOrder.IsSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLoanRecoveryOrder(0, OrderName, RecoveryOrder, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewLoanRecoveryOrder.ErrorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewLoanRecoveryOrder.LoanRecoveryOrderId = DbResult.LoanRecoveryOrderId;
                    oNewLoanRecoveryOrder.OrderName = DbResult.OrderName;
                    oNewLoanRecoveryOrder.RecoveryOrder = DbResult.RecoveryOrder;
                    oNewLoanRecoveryOrder.IsSuccess = true;
                    return Ok(oNewLoanRecoveryOrder);

                }
            }
            catch (Exception ex)
            {
                oNewLoanRecoveryOrder.ErrorDescription = ex.Message;
                return Ok(oNewLoanRecoveryOrder);

            }
        }
        [Route("LoanRepayment/UpdateLoanRecoveryOrder"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLoanRecoveryOrder(string OrderName, int? RecoveryOrder)
        {
            LoanRecoveryOrder oNewLoanRecoveryOrder = new LoanRecoveryOrder();
            oNewLoanRecoveryOrder.ErrorDescription = "";
            oNewLoanRecoveryOrder.IsSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_EditLoanRecoveryOrder(OrderName,RecoveryOrder);
                    if (DbResult == 0)
                    {
                        oNewLoanRecoveryOrder.ErrorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    //oNewLoanRecoveryOrder.LoanRecoveryOrderId = DbResult.LoanRecoveryOrderId;
                    //oNewLoanRecoveryOrder.OrderName = DbResult.OrderName;
                    //oNewLoanRecoveryOrder.RecoveryOrder = DbResult.RecoveryOrder;
                    oNewLoanRecoveryOrder.IsSuccess = true;
                    return Ok(oNewLoanRecoveryOrder);

                }
            }
            catch (Exception ex)
            {
                oNewLoanRecoveryOrder.ErrorDescription = " Cannot insert duplicate key.Please confirm  and try again"; ;
                return Ok(oNewLoanRecoveryOrder);

            }
        }
        [Route("LoanRepayment/GetAllLoanRecoveryOrders")]
        
        public async Task<IHttpActionResult>GetAllLoanRecoveryOrders()
        {

            LoanRecoveryOrder oNewLoanRecoveryOrder = new LoanRecoveryOrder();
            oNewLoanRecoveryOrder.ErrorDescription = "";
            oNewLoanRecoveryOrder.IsSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllLoanRecoverOrders().ToList();
                    List<LoanRecoveryOrder> listofLoanRecoveryOrder = new List<LoanRecoveryOrder>();
                    foreach (var items in dbResult)
                    {
                        LoanRecoveryOrder oLoanRecoveryOrder = new LoanRecoveryOrder();

                        oLoanRecoveryOrder.LoanRecoveryOrderId = items.LoanRecoveryOrderId;
                        oLoanRecoveryOrder.OrderName = items.OrderName;
                        oLoanRecoveryOrder.RecoveryOrder = items.RecoveryOrder;
                        oLoanRecoveryOrder.IsSuccess = true;
                        listofLoanRecoveryOrder.Add(oLoanRecoveryOrder);
                    }
                    IEnumerable<LoanRecoveryOrder> myLoanRecoveryOrder = listofLoanRecoveryOrder;
                    return Ok(myLoanRecoveryOrder);

                    

                }
            }
            catch (Exception ex)
            {
                oNewLoanRecoveryOrder.ErrorDescription = ex.Message;
                return Ok(oNewLoanRecoveryOrder);
                

            }

        }
        [Route("LoanRepayment/GetLoanRecoveryOrder")]
        public async Task<IHttpActionResult> GetLoanRecoveryOrder(int? id)
        {
            LoanRecoveryOrder oNewLoanRecoveryOrder = new LoanRecoveryOrder();
            oNewLoanRecoveryOrder.ErrorDescription = "";
            oNewLoanRecoveryOrder.IsSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var LoanRecoveryOrder = (from a in db.tblLoanRecoveryOrders
                                             where a.LoanRecoveryOrderId
                                             
                                             == id
                                      select new
                                      {
                                          a.LoanRecoveryOrderId,
                                          a.OrderName,
                                          a.RecoveryOrder,
                                      }).FirstOrDefault();
                    oNewLoanRecoveryOrder.IsSuccess = true;
                    return Ok(new { LoanRecoveryOrder });

                }

            }
            catch (Exception ex)
            {
                oNewLoanRecoveryOrder.ErrorDescription = ex.Message;
                return Ok(oNewLoanRecoveryOrder);

            }
        }
        [HttpGet, HttpDelete]
        [Route("LoanRepayment/DeleteLoanRecoveryOrder")]
        public IHttpActionResult DeleteLoanRecoveryOrder(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {

                tblLoanRecoveryOrder LoanRecoveryOrder = db.tblLoanRecoveryOrders.SingleOrDefault(x => x.LoanRecoveryOrderId == id);
                db.tblLoanRecoveryOrders.Remove(LoanRecoveryOrder);
                db.SaveChanges();
                return Ok(LoanRecoveryOrder);            }
        }
        
    }
}
