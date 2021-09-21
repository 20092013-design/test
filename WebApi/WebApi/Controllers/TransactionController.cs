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
    public class TransactionController : ApiController
    {

        [Route("AccountTransaction/GetAllAccountTransaction")]
        public IHttpActionResult GetAllAccountTransaction()
        {

            AccountTransaction oNewAccountTransaction = new AccountTransaction();
            oNewAccountTransaction.isSuccess = false;
            oNewAccountTransaction.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAccountTransactionsAll().ToList();
                    List<AccountTransaction> listofAccountTransactions = new List<AccountTransaction>();
                    foreach (var items in dbResult)
                    {
                        AccountTransaction oAccountTransaction = new AccountTransaction();

                        oAccountTransaction.AccountTransactionId = items.AccountTransactionId;
                        oAccountTransaction.TransactionDate = items.TransactionDate;
                        oAccountTransaction.ValueDate = items.ValueDate;
                        oAccountTransaction.MemberNo = items.MemberNo;
                        oAccountTransaction.DocumentNo = items.DocumentNo;
                        oAccountTransaction.ProductId = items.ProductId;
                        oAccountTransaction.ModeOfPayment = items.ModeOfPayment;
                        oAccountTransaction.TransType = items.TransType;
                        oAccountTransaction.BaseCurrencyId = items.BaseCurrencyId;
                        oAccountTransaction.CurrencyId = items.CurrencyId;
                        oAccountTransaction.CurrencySymbol = items.CurrencySymbol;
                        oAccountTransaction.ExchangeRate = items.ExchangeRate;
                        oAccountTransaction.Commission = items.Commission;
                        oAccountTransaction.PaidBy = items.PaidBy;
                        oAccountTransaction.LocalCurrencyAmount = items.LocalCurrencyAmount;
                        oAccountTransaction.Amount = items.Amount;
                        oAccountTransaction.Remarks = items.Remarks;
                        oAccountTransaction.AmountBalances = items.BalanceAmount;
                        oAccountTransaction.AmountCharge = items.AmountCharge;
                        oAccountTransaction.IsBlock = items.IsBlocked;
                       
                        oNewAccountTransaction.isSuccess = true;
                     
                        oNewAccountTransaction.errorDescription = "";

                        listofAccountTransactions.Add(oAccountTransaction);


                    }
                    IEnumerable<AccountTransaction> myAccountTransaction = listofAccountTransactions;
                    return Ok(myAccountTransaction);

                }
            }
            catch (Exception ex)
            {
                oNewAccountTransaction.errorDescription = ex.Message;
                return Ok(oNewAccountTransaction);

            }

        }
        [Route("AccountTransaction/GetTariffAmount")]
        public async Task<IHttpActionResult> GetTariffAmount(decimal? Amount)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Tariff = (from a in db.tblTariffs

                              where Amount >= a.Start && Amount <= a.Stop
                              select new
                              {
                                  a.ChargeAmount,

                              }).FirstOrDefault();
                return Ok(new { Tariff });


            }
        }
        [Route("AccountTransaction/GetAccountTransaction")]
        public async Task<IHttpActionResult> GetAccountTransaction(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var AccountTransaction = (from a in db.tblAccountTransactions
                                          where a.AccountTransactionId == id
                                          select new
                                          {
                                              a.AccountTransactionId,
                                              a.TransactionDate,
                                              a.ValueDate,
                                              a.MemberNo,
                                              a.DocumentNo,
                                              a.ProductId,
                                              a.ModeOfPayment,
                                              a.TransType,
                                              a.BaseCurrencyId,
                                              a.CurrencyId,
                                              a.ExchangeRate,
                                              a.Commission,
                                              a.PaidBy,
                                              a.LocalCurrencyAmount,
                                              a.AmountCharge,
                                              a.BalanceAmount,
                                              a.Amount,
                                              a.Remarks,
                                              a.ModifiedOn,
                                              a.CreatedBy,
                                              a.ModifiedBy,
                                              a.CreatedOn,

                                          }).FirstOrDefault();
                return Ok(new { AccountTransaction });


            }

        }
        [Route("AccountTransaction/DeleteTransactionCharge"), HttpGet]
        public IHttpActionResult DeleteTransactionCharge(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {
                tblTransactionCharge transCharge = db.tblTransactionCharges.SingleOrDefault(x => x.TransactionChargesId == id);
                db.tblTransactionCharges.Remove(transCharge);
                db.SaveChanges();
                return Ok(transCharge);
            }
        }
        [Route("AccountTransaction/DeleteTransaction"), HttpGet]
        public IHttpActionResult DeleteTransaction(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {
                tblAccountTransaction trans = db.tblAccountTransactions.SingleOrDefault(x => x.AccountTransactionId == id);
                db.tblAccountTransactions.Remove(trans);
                db.SaveChanges();
                return Ok(trans);
            }
        }
        [Route("AccountTransaction/getAllTransactionCharges")]
        public async Task<IHttpActionResult> getAllTransactionCharges()
        {
            TransactionCharge oNewTransactionCharge = new TransactionCharge();
            oNewTransactionCharge.isSuccess = false;
            oNewTransactionCharge.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllTransactionCharge().ToList();

                    List<TransactionCharge> listofTransactionCharge = new List<TransactionCharge>();
                    foreach (var items in dbResult)
                    {
                        TransactionCharge OTransactionCharge = new TransactionCharge();

                        OTransactionCharge.TransactionChargesId = items.TransactionChargesId;
                        OTransactionCharge.AccountTransactionId = items.AccountTransactionId;
                        OTransactionCharge.ChargesId = items.ChargesId;
                        OTransactionCharge.IsPercent = items.IsPercent;
                        OTransactionCharge.Amount = items.Amount;
                        OTransactionCharge.Total = items.Total;
                        OTransactionCharge.TariffId = items.TariffId;

                        OTransactionCharge.isSuccess = true;
                        listofTransactionCharge.Add(OTransactionCharge);
                    }
                    IEnumerable<TransactionCharge> myTransactionCharge = listofTransactionCharge;
                    return Ok(myTransactionCharge);

                }
            }
            catch (Exception ex)
            {
                oNewTransactionCharge.errorDescription = ex.Message;
                return Ok(oNewTransactionCharge);

            }

        }

        [Route("Transaction/GetDefaultPaymentModes")]
        public IHttpActionResult GetDefaultPaymentModes()
        {

            PaymentModes oNewPaymentMode = new PaymentModes();
            oNewPaymentMode.isSuccess = false;
            oNewPaymentMode.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getDefaultPayment().ToList();
                    List<PaymentModes> listofPaymentModes = new List<PaymentModes>();
                    foreach (var items in dbResult)
                    {
                        PaymentModes oPaymentMode = new PaymentModes();

                        oPaymentMode.PaymentModeId = items.PaymentModeId;
                        oPaymentMode.Name = items.Name;
                        oPaymentMode.Description = items.Description;
                        oPaymentMode.AllowBackDated = items.AllowBackDated;
                        oPaymentMode.MaxDaysofBackDated = items.MaxDaysofBackDated;
                        oPaymentMode.CanDisburseLoan = items.CanDisburseLoan;
                        oPaymentMode.IsDefault = items.IsDefault;

                        oNewPaymentMode.isSuccess = true;
                        oNewPaymentMode.errorDescription = "";

                        listofPaymentModes.Add(oPaymentMode);


                    }
                    IEnumerable<PaymentModes> myPaymentMode = listofPaymentModes;
                    return Ok(myPaymentMode);

                }
            }
            catch (Exception ex)
            {
                oNewPaymentMode.errorDescription = ex.Message;
                return Ok(oNewPaymentMode);

            }

        }
        [Route("Transaction/getMainCurrency")]
        public async Task<IHttpActionResult> getMainCurrency()
        {

            Currency oNewCurrency = new Currency();
            oNewCurrency.isSuccess = false;
            oNewCurrency.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetMainCurrency().ToList();

                    List<Currency> listofCurrency = new List<Currency>();
                    foreach (var items in dbResult)
                    {
                        Currency OCurrency = new Currency();
                        OCurrency.CurrencyId = items.CurrencyId;
                        OCurrency.CurrencyName = items.CurrencyName;
                        OCurrency.CurrencySymbol = items.CurrencySymbol;
                        OCurrency.IsMainCurrency = items.IsMainCurrency;
                        OCurrency.isSuccess = true;
                        listofCurrency.Add(OCurrency);
                    }
                    IEnumerable<Currency> myCurrency = listofCurrency;
                    return Ok(myCurrency);

                }
            }
            catch (Exception ex)
            {
                oNewCurrency.errorDescription = ex.Message;
                return Ok(oNewCurrency);

            }

        }

        [Route("AccountTransByProductId/GetAccountTransByProductId")]
        public async Task<IHttpActionResult> GetAccountTransByProductId(int? MemberId, int? ProductId)
        {
            AccountTransaction oNewAccountTransaction = new AccountTransaction();
            oNewAccountTransaction.isSuccess = false;
            oNewAccountTransaction.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAccTransactionByMemberIdProductId(MemberId, ProductId).ToList();
                    List<AccountTransaction> listofAccountTransaction = new List<AccountTransaction>();

                    foreach (var items in dbResult)
                    {
                        AccountTransaction oAccountTransaction = new AccountTransaction();

                        oAccountTransaction.TransactionDate = items.TransactionDate;
                        oAccountTransaction.ValueDate = items.ValueDate;
                        oAccountTransaction.PaidBy = items.PaidBy;
                        oAccountTransaction.ModeOfPayment = items.ModeOfPayment;
                        oAccountTransaction.Amount = items.Amount;
                        oAccountTransaction.DocumentNo = items.DocumentNo;

                        oAccountTransaction.isSuccess = true;
                        oAccountTransaction.errorDescription = "";
                        listofAccountTransaction.Add(oAccountTransaction);
                    }
                    IEnumerable<AccountTransaction> myAccountTransaction = listofAccountTransaction;
                    return Ok(myAccountTransaction);
                }
            }
            catch (Exception ex)
            {
                oNewAccountTransaction.errorDescription = ex.Message;
                return Ok(oNewAccountTransaction);
            }
        }

        [Route("MemberEachAccount/GetMemberEachAccount")]
        public async Task<IHttpActionResult> GetMemberEachAccount(int? ProductId)
        {
            Product oNewProduct = new Product();
            oNewProduct.isSuccess = false;
            oNewProduct.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_getMemberEachAccount(ProductId).ToList();
                    List<Product> listProduct = new List<Product>();

                    foreach (var items in dbResult)
                    {
                        Product oProduct = new Product();
                        oProduct.ProductId = items.ProductId;

                        oProduct.Description = items.Description;


                        oProduct.isSuccess = true;
                        oProduct.errorDescription = "";
                        listProduct.Add(oProduct);
                    }
                    IEnumerable<Product> myProduct = listProduct;
                    return Ok(myProduct);
                }
            }
            catch (Exception ex)
            {
                oNewProduct.errorDescription = ex.Message;
                return Ok(oNewProduct);
            }
        }
        [Route("MemberShare/GetMemberShareById")]
        public async Task<IHttpActionResult> GetMemberShareById(int? MemberId)
        {
            MemberShare oNewMemberShare = new MemberShare();
            oNewMemberShare.isSuccess = false;
            oNewMemberShare.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetMemberShareByMemberId(MemberId).ToList();
                    List<MemberShare> listofMemberShare = new List<MemberShare>();

                    foreach (var items in dbResult)
                    {
                        MemberShare oMemberShare = new MemberShare();

                        oMemberShare.MemberId = items.MemberId;
                        oMemberShare.ProductId = items.ProductId;
                        oMemberShare.ContributionRate = items.ContributionRate;
                        oMemberShare.MinBalance = items.MinBalance;

                        oMemberShare.isSuccess = true;
                        oMemberShare.errorDescription = "";
                        listofMemberShare.Add(oMemberShare);
                    }
                    IEnumerable<MemberShare> myMemberShare = listofMemberShare;
                    return Ok(myMemberShare);
                }
            }
            catch (Exception ex)
            {
                oNewMemberShare.errorDescription = ex.Message;
                return Ok(oNewMemberShare);
            }
        }
        [Route("MemberDetailsByAccountTransaction/GetMemberDetailsByAccountTransaction")]
        public async Task<IHttpActionResult> GetMemberDetailsByAccountTransaction(int? MemberId)
        {
            Member oNewMember = new Member();
            oNewMember.isSuccess = false;
            oNewMember.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_getMemberEachTransactions(MemberId).ToList();
                    List<Member> listofMember = new List<Member>();

                    foreach (var items in dbResult)
                    {
                        Member oMember = new Member();
                        oMember.MemberId = items.MemberId;
                        oMember.MemberNo = items.MemberNo;
                        oMember.FullName = items.FullName;
                        oMember.IdNo = items.IdNo;

                        oMember.isSuccess = true;
                        oMember.errorDescription = "";
                        listofMember.Add(oMember);
                    }
                    IEnumerable<Member> myMember = listofMember;
                    return Ok(myMember);
                }
            }
            catch (Exception ex)
            {
                oNewMember.errorDescription = ex.Message;
                return Ok(oNewMember);
            }
        }
        [Route("AccountTransaction/GetBalanceAmount")]
        public async Task<IHttpActionResult> GetBalanceAmount(int? MemberId, int? ProductId)
        {
            AccountTransaction oNewAccountTransaction = new AccountTransaction();
            oNewAccountTransaction.isSuccess = false;
            oNewAccountTransaction.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getAllBalanceAmount(ProductId, MemberId).FirstOrDefault();
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
        [Route("AccountTransaction/GetBalancesAmount")]        public async Task<IHttpActionResult> GetBalancesAmount(int? MemberId, int? ProductId, string AccountNumber)        {            AccountTransaction oNewAccountTransaction = new AccountTransaction();            oNewAccountTransaction.isSuccess = false;            oNewAccountTransaction.errorDescription = "";            try            {                using (DBContextEntities db = new DBContextEntities())                {                    var dbResult = db.proc_getBalancesAmountAll(ProductId, MemberId, AccountNumber).FirstOrDefault();                    oNewAccountTransaction.BalanceAmount = dbResult.Value;                    oNewAccountTransaction.isSuccess = true;                    oNewAccountTransaction.errorDescription = "";                    return Ok(oNewAccountTransaction);                }            }            catch (Exception ex)            {                oNewAccountTransaction.errorDescription = ex.Message;                return Ok(oNewAccountTransaction);            }        }

        [Route("AccountTransByProductId/GetAccountTransByProductId")]
        public async Task<IHttpActionResult> GetAccountTransByProductId(int? MemberId, int? ProductId, string AccountNo)
        {
            AccountTransaction oNewAccountTransaction = new AccountTransaction();
            oNewAccountTransaction.isSuccess = false;
            oNewAccountTransaction.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAccountTransactionByMemberIdProductId(MemberId, ProductId, AccountNo).ToList();
                    List<AccountTransaction> listofAccountTransaction = new List<AccountTransaction>();

                    foreach (var items in dbResult)
                    {
                        AccountTransaction oAccountTransaction = new AccountTransaction();

                        oAccountTransaction.TransactionDate = items.TransactionDate;
                        oAccountTransaction.ValueDate = items.ValueDate;
                        oAccountTransaction.PaidBy = items.PaidBy;
                        oAccountTransaction.ModeOfPayment = items.ModeOfPayment;
                        oAccountTransaction.Amount = items.Amount;
                        oAccountTransaction.DocumentNo = items.DocumentNo;

                        oAccountTransaction.isSuccess = true;
                        oAccountTransaction.errorDescription = "";
                        listofAccountTransaction.Add(oAccountTransaction);
                    }
                    IEnumerable<AccountTransaction> myAccountTransaction = listofAccountTransaction;
                    return Ok(myAccountTransaction);
                }
            }
            catch (Exception ex)
            {
                oNewAccountTransaction.errorDescription = ex.Message;
                return Ok(oNewAccountTransaction);
            }
        }
        [Route("MemberShare/GetMemberAccountById")]        public async Task<IHttpActionResult> GetMemberAccountById(int? MemberId)        {            MemberShare oNewMemberShare = new MemberShare();            oNewMemberShare.isSuccess = false;            oNewMemberShare.errorDescription = "";            try            {                using (DBContextEntities db = new DBContextEntities())                {                    var dbResult = db.proc_GetMemberSharesByMemberId(MemberId).ToList();                    List<MemberShare> listofMemberShare = new List<MemberShare>();                    foreach (var items in dbResult)                    {                        MemberShare oMemberShare = new MemberShare();                        oMemberShare.MemberId = items.MemberId;                        oMemberShare.ProductId = items.ProductId;                        oMemberShare.ContributionRate = items.ContributionRate;                        oMemberShare.MinBalance = items.MinBalance;                        oMemberShare.AccountNo = items.AccountNumber;                        oMemberShare.isSuccess = true;                        oMemberShare.errorDescription = "";                        listofMemberShare.Add(oMemberShare);                    }                    IEnumerable<MemberShare> myMemberShare = listofMemberShare;                    return Ok(myMemberShare);                }            }            catch (Exception ex)            {                oNewMemberShare.errorDescription = ex.Message;                return Ok(oNewMemberShare);            }        }
    }
}
