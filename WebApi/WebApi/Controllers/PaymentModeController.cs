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
    public class PaymentModeController : ApiController
    {
        [Route("PaymentMode/AddPaymentMode"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddPaymentMode
(string Name, string Description, bool? AllowBackDated, int? MaxDaysofBackDated, bool? CanDisburseLoan, bool? IsDefault, bool? Delete)

        {
            PaymentModes oNewPaymentMode = new PaymentModes();
            oNewPaymentMode.isSuccess = false;
            oNewPaymentMode.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (Name == null) { Name = ""; }
                    if (Description == null) { Description = ""; }
                    if (AllowBackDated == null) { AllowBackDated = false; }
                    if (MaxDaysofBackDated == null) { MaxDaysofBackDated = 0; }
                    if (CanDisburseLoan == null) { CanDisburseLoan = false; }
                    if (IsDefault == null) { IsDefault = false; }


                    var DbResult = db.proc_AddEditPayModes
                    (0, Name, Description, AllowBackDated, MaxDaysofBackDated, CanDisburseLoan, IsDefault, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewPaymentMode.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewPaymentMode.Name = DbResult.Name;
                    oNewPaymentMode.Description = DbResult.Description;
                    oNewPaymentMode.AllowBackDated = DbResult.AllowBackDated;
                    oNewPaymentMode.MaxDaysofBackDated = DbResult.MaxDaysofBackDated;
                    oNewPaymentMode.CanDisburseLoan = DbResult.CanDisburseLoan;
                    oNewPaymentMode.IsDefault = DbResult.IsDefault;

                    oNewPaymentMode.isSuccess = true;
                    return Ok(oNewPaymentMode);
                }

            }
            catch (Exception ex)
            {
                oNewPaymentMode.errorDescription = ex.Message;
                return Ok(oNewPaymentMode);

            }
        }
        [Route("PaymentMode/UpdatePaymentMode"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdatePaymentMode
        (int? PaymentModeId, string Name, string Description, bool? AllowBackDated, int? MaxDaysofBackDated, bool? CanDisburseLoan, bool? IsDefault, bool? Delete)

        {

            PaymentModes oNewPaymentMode = new PaymentModes();
            oNewPaymentMode.isSuccess = false;
            oNewPaymentMode.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Name == null) { Name = ""; }
                    if (Description == null) { Description = ""; }
                    if (AllowBackDated == null) { AllowBackDated = false; }
                    if (MaxDaysofBackDated == null) { MaxDaysofBackDated = 0; }
                    if (CanDisburseLoan == null) { CanDisburseLoan = false; }
                    if (IsDefault == null) { IsDefault = false; }

                    var DbResult = db.proc_AddEditPayModes
                    (PaymentModeId, Name, Description, AllowBackDated, MaxDaysofBackDated, CanDisburseLoan, IsDefault, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewPaymentMode.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewPaymentMode.PaymentModeId = DbResult.PaymentModeId;
                    oNewPaymentMode.Name = DbResult.Name;
                    oNewPaymentMode.Description = DbResult.Description;
                    oNewPaymentMode.AllowBackDated = DbResult.AllowBackDated;
                    oNewPaymentMode.MaxDaysofBackDated = DbResult.MaxDaysofBackDated;
                    oNewPaymentMode.CanDisburseLoan = DbResult.CanDisburseLoan;
                    oNewPaymentMode.IsDefault = DbResult.IsDefault;

                    oNewPaymentMode.isSuccess = true;
                    return Ok(oNewPaymentMode);
                }

            }
            catch (Exception ex)
            {
                oNewPaymentMode.errorDescription = ex.Message;
                return Ok(oNewPaymentMode);

            }
        }



        [Route("PaymentMode/GetAllPaymentModes")]
        public IHttpActionResult GetAllPaymentModes()
        {

            PaymentModes oNewPaymentMode = new PaymentModes();
            oNewPaymentMode.isSuccess = false;
            oNewPaymentMode.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllPayModes().ToList();
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




        [Route("PaymentMode/GetDefaultPaymentModes")]
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

        [Route("PaymentMode/GetPaymentMode")]
        public async Task<IHttpActionResult> GetPaymentMode(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var PaymentMode = (from a in db.tblPaymentModes
                                   where a.PaymentModeId == id
                                   select new
                                   {
                                       a.PaymentModeId,
                                       a.Name,
                                       a.Description,
                                       a.AllowBackDated,
                                       a.MaxDaysofBackDated,
                                       a.CanDisburseLoan,
                                       a.IsDefault,

                                   }).FirstOrDefault();
                return Ok(new { PaymentMode });


            }

        }

        [Route("PaymentMode/DeletePaymentMode"), HttpGet]
        public IHttpActionResult DeletePaymentMode(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblPaymentMode PaymentMode = db.tblPaymentModes.SingleOrDefault(x => x.PaymentModeId == id);
                db.tblPaymentModes.Remove(PaymentMode);
                db.SaveChanges();
                return Ok(PaymentMode);
            }
        }
        [Route("ExchangeRate/GetExchangeRateByCurrencyId")]
        public async Task<IHttpActionResult> GetExchangeRateByCurrencyId(int? CurrencyId)
        {
            CurrencyRate oNewCurrencyRate = new CurrencyRate();
            oNewCurrencyRate.isSuccess = false;
            oNewCurrencyRate.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Proc_getExRateByCurrencyId(CurrencyId).FirstOrDefault();
                    var BaseCurrency = (from a in db.tblCurrencies where a.IsMainCurrency == true select a).FirstOrDefault();
                    if (BaseCurrency == null)
                    {
                        oNewCurrencyRate.errorDescription = "BaseCurrency not found";
                        return Ok(oNewCurrencyRate);
                    }
                    if (dbResult == null)
                    {

                        oNewCurrencyRate.errorDescription = "Exchangerate not found";
                        return Ok(oNewCurrencyRate);
                    }
                    //List<CurrencyRate> listofCurrencyRate = new List<CurrencyRate>();
                    //CurrencyRate oCurrencyRate = new CurrencyRate();

                    oNewCurrencyRate.BuyRate = dbResult.BuyRate;
                    oNewCurrencyRate.SellRate = dbResult.SellRate;
                    oNewCurrencyRate.CurrencyId = dbResult.CurrencyId;
                    oNewCurrencyRate.ExchangeRateId = dbResult.ExchangeRateId;
                    oNewCurrencyRate.BaseCurrencyId = BaseCurrency.CurrencyId;
                    oNewCurrencyRate.isSuccess = true;
                    oNewCurrencyRate.errorDescription = "";
                    //listofCurrencyRate.Add(oCurrencyRate);
                    //IEnumerable<CurrencyRate> myCurrencyRate = listofCurrencyRate;
                    return Ok(oNewCurrencyRate);
                }
            }
            catch (Exception ex)
            {
                oNewCurrencyRate.errorDescription = ex.Message;
                return Ok(oNewCurrencyRate);
            }
        }

        protected override void Dispose(bool disposing)
        {
            DBContextEntities db = new DBContextEntities();
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
