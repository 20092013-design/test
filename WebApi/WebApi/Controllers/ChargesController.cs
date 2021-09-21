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
    public class ChargesController : ApiController
    {

        [Route("Charge/AddCharge"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCharge
        (string Code, string Description, bool? IsPercent, decimal? Value, bool? Tariff, decimal? TariffAmount,
        bool? IgnoreLowLimit, decimal? LowerLimit, decimal? UpperLimit, bool? Delete)

        {
            Charge oNewCharge = new Charge();
            oNewCharge.isSuccess = false;
            oNewCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (Code == null) { Code = ""; }
                    if (Description == null) { Description = ""; }
                    if (IsPercent == null) { IsPercent = false; }
                    if (Value == null) { Value = 0; }
                    if (TariffAmount == null) { TariffAmount = 0; }
                    if (Tariff == null) { Tariff = false; }
                    if (IgnoreLowLimit == null) { IgnoreLowLimit = false; }
                    if (LowerLimit == null) { LowerLimit = 0; }
                    if (UpperLimit == null) { UpperLimit = 0; }


                    var DbResult = db.proc_AddEditFinalCharge
                    (0, Code, Description, IsPercent, Value, Tariff, TariffAmount, IgnoreLowLimit, LowerLimit,
                    UpperLimit, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCharge.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewCharge.ChargesId = DbResult.ChargesId;
                    oNewCharge.Code = DbResult.Code;
                    oNewCharge.Description = DbResult.Description;
                    oNewCharge.IsPercent = DbResult.IsPercent;
                    oNewCharge.Value = DbResult.Value;
                    oNewCharge.Tariff = DbResult.Tariff;
                    oNewCharge.TariffAmount = DbResult.TariffAmount;
                    oNewCharge.IgnoreLowLimit = DbResult.IgnoreLowLimit;
                    oNewCharge.LowerLimit = DbResult.LowerLimit;
                    oNewCharge.UpperLimit = DbResult.UpperLimit;

                    oNewCharge.isSuccess = true;
                    return Ok(oNewCharge);
                }

            }
            catch (Exception ex)
            {
                oNewCharge.errorDescription = ex.Message;
                return Ok(oNewCharge);

            }
        }
        [Route("Charge/UpdateCharge"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCharge
        (int? ChargesId, string Code, string Description, bool? IsPercent, decimal? Value, bool? Tariff, decimal? TariffAmount,
        bool? IgnoreLowLimit, decimal? LowerLimit, decimal? UpperLimit, bool? Delete)

        {
            Charge oNewCharge = new Charge();
            oNewCharge.isSuccess = false;
            oNewCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Code == null) { Code = ""; }
                    if (Description == null) { Description = ""; }
                    if (IsPercent == null) { IsPercent = false; }
                    if (Value == null) { Value = 0; }
                    if (Tariff == null) { Tariff = false; }
                    if (TariffAmount == null) { TariffAmount = 0; }
                    if (LowerLimit == null) { LowerLimit = 0; }
                    if (UpperLimit == null) { UpperLimit = 0; }
                    if (IsPercent == true)
                    {
                        if (Value < 0 && Value < 101)
                        {
                            oNewCharge.errorDescription = " Please insert Values in percentage!";
                        }
                        else
                        {
                            oNewCharge.errorDescription = " Please insert Values in Amount!";
                        }

                    }

                    var DbResult = db.proc_AddEditFinalCharge
                    (ChargesId, Code, Description, IsPercent, Value, Tariff, TariffAmount, IgnoreLowLimit, LowerLimit, UpperLimit, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCharge.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewCharge.ChargesId = DbResult.ChargesId;
                    oNewCharge.Code = DbResult.Code;
                    oNewCharge.Description = DbResult.Description;
                    oNewCharge.IsPercent = DbResult.IsPercent;
                    oNewCharge.Value = DbResult.Value;
                    oNewCharge.Tariff = DbResult.Tariff;
                    oNewCharge.TariffAmount = DbResult.TariffAmount;
                    oNewCharge.IgnoreLowLimit = DbResult.IgnoreLowLimit;
                    oNewCharge.LowerLimit = DbResult.LowerLimit;
                    oNewCharge.UpperLimit = DbResult.UpperLimit;

                    oNewCharge.isSuccess = true;
                    return Ok(oNewCharge);
                }

            }
            catch (Exception ex)
            {
                oNewCharge.errorDescription = ex.Message;
                return Ok(oNewCharge);

            }
        }



        [Route("Charge/GetAllCharges")]
        public IHttpActionResult GetAllCharges()
        {

            Charge oNewCharge = new Charge();
            oNewCharge.isSuccess = false;
            oNewCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllChargesFinal().ToList();
                    List<Charge> listofCharges = new List<Charge>();
                    foreach (var items in dbResult)
                    {
                        Charge oCharge = new Charge();

                        oCharge.ChargesId = items.ChargesId;
                        oCharge.Code = items.Code;
                        oCharge.Description = items.Description;
                        oCharge.IsPercent = items.IsPercent;
                        oCharge.Value = items.Value;
                        oCharge.Tariff = items.Tariff;
                        oCharge.TariffAmount = items.TariffAmount;
                        oCharge.IgnoreLowLimit = items.IgnoreLowLimit;
                        oCharge.LowerLimit = items.LowerLimit;
                        oCharge.UpperLimit = items.UpperLimit;

                        oNewCharge.isSuccess = true;
                        oNewCharge.errorDescription = "";

                        listofCharges.Add(oCharge);


                    }
                    IEnumerable<Charge> myCharge = listofCharges;
                    return Ok(myCharge);

                }
            }
            catch (Exception ex)
            {
                oNewCharge.errorDescription = ex.Message;
                return Ok(oNewCharge);

            }

        }



        [Route("Charge/GetCharge")]
        public async Task<IHttpActionResult> GetCharge(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Charge = (from a in db.tblCharges
                              where a.ChargesId == id
                              select new
                              {
                                  a.ChargesId,
                                  a.Code,
                                  a.Description,
                                  a.IsPercent,
                                  a.Value,
                                  a.Tariff,
                                  a.TariffAmount,
                                  a.IgnoreLowLimit,
                                  a.LowerLimit,
                                  a.UpperLimit

                              }).FirstOrDefault();
                return Ok(new { Charge });


            }

        }

        [Route("Charge/DeleteCharge"), HttpGet]
        public IHttpActionResult DeleteCharge(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblCharge charge = db.tblCharges.SingleOrDefault(x => x.ChargesId == id);
                db.tblCharges.Remove(charge);
                db.SaveChanges();
                return Ok(charge);
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

        [Route("Charge/AddTariff"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddTariff
        (int? ChargesId, decimal? Start, decimal? Stop, decimal? ChargeAmount, bool? Delete)

        {
            Tariff oNewTariff = new Tariff();
            oNewTariff.isSuccess = false;
            oNewTariff.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (ChargesId == null) { ChargesId = 0; }
                    if (Start == null) { Start = 0; }
                    if (Stop == null) { Stop = 0; }
                    if (ChargeAmount == null) { ChargeAmount = 0; }



                    var DbResult = db.proc_AddEditTariff
                    (0, ChargesId, Start, Stop, ChargeAmount, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewTariff.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewTariff.ChargesId = DbResult.ChargesId;
                    oNewTariff.Start = DbResult.Start;
                    oNewTariff.Stop = DbResult.Stop;
                    oNewTariff.ChargeAmount = DbResult.ChargeAmount;


                    oNewTariff.isSuccess = true;
                    return Ok(oNewTariff);
                }

            }
            catch (Exception ex)
            {
                oNewTariff.errorDescription = ex.Message;
                return Ok(oNewTariff);

            }
        }
        [Route("Charge/UpdateTariff"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateTariff
        (int? TariffId, int? ChargesId, decimal? Start, decimal? Stop, decimal? ChargeAmount, bool? Delete)

        {
            Tariff oNewTariff = new Tariff();
            oNewTariff.isSuccess = false;
            oNewTariff.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Start == null) { Start = 0; }
                    if (Stop == null) { Stop = 0; }
                    if (ChargeAmount == null) { ChargeAmount = 0; }


                    var DbResult = db.proc_AddEditTariff
                    (TariffId, ChargesId, Start, Stop, ChargeAmount, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewTariff.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oNewTariff.TariffId = DbResult.TariffId;
                    oNewTariff.ChargesId = DbResult.ChargesId;
                    oNewTariff.Start = DbResult.Start;
                    oNewTariff.Stop = DbResult.Stop;
                    oNewTariff.ChargeAmount = DbResult.ChargeAmount;


                    oNewTariff.isSuccess = true;
                    return Ok(oNewTariff);
                }

            }
            catch (Exception ex)
            {
                oNewTariff.errorDescription = ex.Message;
                return Ok(oNewTariff);

            }
        }



        [Route("Charge/GetAllTariffs")]
        public IHttpActionResult GetAllTariffs()
        {

            Tariff oNewTariff = new Tariff();
            oNewTariff.isSuccess = false;
            oNewTariff.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllTariff().ToList();
                    List<Tariff> listofTariffs = new List<Tariff>();
                    foreach (var items in dbResult)
                    {
                        Tariff oTariff = new Tariff();

                        oTariff.TariffId = items.TariffId;
                        oTariff.ChargesId = items.ChargesId;
                        oTariff.Start = items.Start;
                        oTariff.Stop = items.Stop;
                        oTariff.ChargeAmount = items.ChargeAmount;

                        oTariff.isSuccess = true;
                        oTariff.errorDescription = "";

                        listofTariffs.Add(oTariff);


                    }
                    IEnumerable<Tariff> myTariff = listofTariffs;
                    return Ok(myTariff);

                }
            }
            catch (Exception ex)
            {
                oNewTariff.errorDescription = ex.Message;
                return Ok(oNewTariff);

            }

        }



        [Route("Charge/GetTariff")]
        public async Task<IHttpActionResult> GetTariff(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Tariff = (from a in db.tblTariffs
                              where a.TariffId == id
                              select new
                              {
                                  a.TariffId,
                                  a.ChargesId,
                                  a.Start,
                                  a.Stop,
                                  a.ChargeAmount

                              }).FirstOrDefault();
                return Ok(new { Tariff });


            }

        }

        [Route("Charge/DeleteTariff"), HttpGet]
        public IHttpActionResult DeleteTariff(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblTariff Tariff = db.tblTariffs.SingleOrDefault(x => x.TariffId == id);
                db.tblTariffs.Remove(Tariff);
                db.SaveChanges();
                return Ok(Tariff);
            }
        }
        [Route("Charge/GetTariffByChargeId")]
        public async Task<IHttpActionResult> GetTariffByChargeId(int ChargesId)
        {
            Tariff oNewTariff = new Tariff();
            oNewTariff.isSuccess = false;
            oNewTariff.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Proc_TariffByChargesId(ChargesId).ToList();
                    List<Tariff> listofTariff = new List<Tariff>();

                    foreach (var items in dbResult)
                    {
                        Tariff oTariff = new Tariff();

                        oTariff.ChargesId = ChargesId;
                        oTariff.Start = items.Start;
                        oTariff.Stop = items.Stop;
                        oTariff.ChargeAmount = items.ChargeAmount;


                        oTariff.isSuccess = true;
                        oTariff.errorDescription = "";

                        listofTariff.Add(oTariff);
                    }
                    IEnumerable<Tariff> myTariff = listofTariff;
                    return Ok(myTariff);
                }
            }
            catch (Exception ex)
            {
                oNewTariff.errorDescription = ex.Message;
                return Ok(oNewTariff);
            }
        }
        [Route("Charge/GetDepositCharge")]
        public IHttpActionResult GetDepositCharge(string Description)
        {

            Charge oNewCharge = new Charge();
            oNewCharge.isSuccess = false;
            oNewCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.getNameofCharge(Description).ToList();
                    List<Charge> listofCharges = new List<Charge>();
                    foreach (var items in dbResult)
                    {
                        Charge oCharge = new Charge();

                        oCharge.ChargesId = items.ChargesId;
                        oCharge.Code = items.Code;
                        oCharge.Description = items.Description;
                        oCharge.IsPercent = items.IsPercent;
                        oCharge.Value = items.Value;
                        oCharge.Tariff = items.Tariff;
                        oCharge.TariffAmount = items.TariffAmount;
                        oCharge.IgnoreLowLimit = items.IgnoreLowLimit;
                        oCharge.LowerLimit = items.LowerLimit;
                        oCharge.UpperLimit = items.UpperLimit;

                        oNewCharge.isSuccess = true;
                        oNewCharge.errorDescription = "";

                        listofCharges.Add(oCharge);


                    }
                    IEnumerable<Charge> myCharge = listofCharges;
                    return Ok(myCharge);

                }
            }
            catch (Exception ex)
            {
                oNewCharge.errorDescription = ex.Message;
                return Ok(oNewCharge);

            }

        }
    }
}
