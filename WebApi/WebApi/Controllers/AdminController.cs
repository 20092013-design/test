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
    public class AdminController : ApiController
    {
        [Route("Admin/AddPrefixes"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddPrefixes(string PrefixName, string PrefixText, bool? IsSystemAssisted, bool? IsDateRelated, bool? Today, bool? Month, bool? Year,
        bool? BranchPrefix, string UseBranchPrefix, string UseGroupPrefix, bool? Delete)

        {
            Prefixe oNewPrefixe = new Prefixe();
            oNewPrefixe.isSuccess = false;
            oNewPrefixe.errorDescription = "";
            if (UseBranchPrefix == null)
            {
                UseBranchPrefix = "";
            }
            if (UseGroupPrefix == null)
            {
                UseGroupPrefix = "";
            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {


                    var DbResult = db.proc_AddEditAutoGenPrefixe(0, PrefixName, PrefixText, IsSystemAssisted, IsDateRelated, Today, Month, Year, BranchPrefix, UseBranchPrefix, UseGroupPrefix, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewPrefixe.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewPrefixe.PrefixName = DbResult.PrefixName;
                    oNewPrefixe.PrefixText = DbResult.PrefixText;
                    oNewPrefixe.IsSystemAssisted = DbResult.IsSystemAssisted;
                    oNewPrefixe.IsDateRelated = DbResult.IsDateRelated;
                    oNewPrefixe.Today = DbResult.Today;
                    oNewPrefixe.Month = DbResult.Month;
                    oNewPrefixe.Year = DbResult.Year;
                    oNewPrefixe.BranchPrefix = DbResult.BranchPrefix;
                    oNewPrefixe.UseBranchPrefix = DbResult.UseBranchPrefix;
                    oNewPrefixe.UseGroupPrefix = DbResult.UseGroupPrefix;

                    oNewPrefixe.isSuccess = true;
                    return Ok(oNewPrefixe);
                }

            }
            catch (Exception ex)
            {
                oNewPrefixe.errorDescription = ex.Message;
                return Ok(oNewPrefixe);

            }
        }
        [Route("Admin/UpdatePrefixes"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdatePrefixes(int? AutoPrefixId, string PrefixName, string PrefixText, bool? IsSystemAssisted, bool? IsDateRelated, bool? Today, bool? Month, bool? Year,
      bool? BranchPrefix, string UseBranchPrefix, string UseGroupPrefix, bool? Delete)

        {
            Prefixe oNewPrefixe = new Prefixe();
            oNewPrefixe.isSuccess = false;
            oNewPrefixe.errorDescription = "";
            if (UseBranchPrefix == null)
            {
                UseBranchPrefix = "";
            }
            if (UseGroupPrefix == null)
            {
                UseGroupPrefix = "";
            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {


                    var DbResult = db.proc_AddEditAutoGenPrefixe(AutoPrefixId, PrefixName, PrefixText, IsSystemAssisted, IsDateRelated, Today, Month, Year, BranchPrefix, UseBranchPrefix, UseGroupPrefix, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewPrefixe.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewPrefixe.PrefixName = DbResult.PrefixName;
                    oNewPrefixe.PrefixText = DbResult.PrefixText;
                    oNewPrefixe.IsSystemAssisted = DbResult.IsSystemAssisted;
                    oNewPrefixe.IsDateRelated = DbResult.IsDateRelated;
                    oNewPrefixe.Today = DbResult.Today;
                    oNewPrefixe.Month = DbResult.Month;
                    oNewPrefixe.Year = DbResult.Year;
                    oNewPrefixe.BranchPrefix = DbResult.BranchPrefix;
                    oNewPrefixe.UseBranchPrefix = DbResult.UseBranchPrefix;
                    oNewPrefixe.UseGroupPrefix = DbResult.UseGroupPrefix;

                    oNewPrefixe.isSuccess = true;
                    return Ok(oNewPrefixe);
                }

            }
            catch (Exception ex)
            {
                oNewPrefixe.errorDescription = ex.Message;
                return Ok(oNewPrefixe);

            }


        }
        [Route("Admin/getAllPrefixes")]
        public async Task<IHttpActionResult> getAllPrefixes()
        {

            Prefixe oNewPrefixe = new Prefixe();
            oNewPrefixe.isSuccess = false;
            oNewPrefixe.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllAutoGenPrefixes().ToList();
                    List<Prefixe> listofprefixes = new List<Prefixe>();
                    foreach (var items in dbResult)
                    {
                        Prefixe oPrefixe = new Prefixe();
                        oPrefixe.AutoPrefixId = items.AutoPrefixId;
                        oPrefixe.PrefixName = items.PrefixName;
                        oPrefixe.PrefixText = items.PrefixText;
                        oPrefixe.BranchPrefix = items.BranchPrefix;
                        oPrefixe.UseBranchPrefix = items.UseBranchPrefix;
                        oPrefixe.UseGroupPrefix = items.UseGroupPrefix;
                        oPrefixe.Today = items.Today;
                        oPrefixe.Month = items.Month;
                        oPrefixe.Year = items.Year;
                        oPrefixe.IsSystemAssisted = items.IsSystemAssisted;
                        oPrefixe.IsDateRelated = items.IsDateRelated;
                        oPrefixe.errorDescription = "";
                        oPrefixe.isSuccess = true;
                        listofprefixes.Add(oPrefixe);
                    }
                    IEnumerable<Prefixe> myPrefixes = listofprefixes;
                    return Ok(myPrefixes);

                }
            }
            catch (Exception ex)
            {
                oNewPrefixe.errorDescription = ex.Message;
                return Ok(oNewPrefixe);

            }

        }
        [Route("Admin/getPrefixe")]
        public async Task<IHttpActionResult> getPrefixe(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var prefixe = (from a in db.tblAutoGenPrefixes
                               where a.AutoPrefixId == id
                               select new
                               {
                                   a.AutoPrefixId,
                                   a.BranchPrefix,
                                   a.PrefixName,
                                   a.PrefixText,
                                   a.IsSystemAssisted,
                                   a.IsDateRelated,
                                   a.Today,
                                   a.Month,
                                   a.Year,
                                   a.UseBranchPrefix,
                                   a.UseGroupPrefix,
                               }).FirstOrDefault();
                return Ok(new { prefixe });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Admin/DeletePrefixe")]
        public IHttpActionResult DeletePrexixe(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblAutoGenPrefix prefixe = db.tblAutoGenPrefixes.SingleOrDefault(x => x.AutoPrefixId == id);
                db.tblAutoGenPrefixes.Remove(prefixe);
                db.SaveChanges();
                return Ok(prefixe);
            }


        }
        [Route("Admin/AddNumbering"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddNumbering(string AutoGenNumberText, int? AutoPrefixId, int? Start, bool? UsePrefix, int? Stop, int? StartFrom, bool? AllowManual, bool? Delete)
        {
            Numbering oNewNumbering = new Numbering();
            oNewNumbering.errorDescription = "";
            oNewNumbering.isSuccess = false;
            if (Start == Stop || Start > Stop)
            {

                oNewNumbering.errorDescription = "Start should not be greater or equal to stop";
                return Ok(oNewNumbering);
            }
            if (StartFrom == Stop || StartFrom > Stop)
            {
                oNewNumbering.errorDescription = "StartFrom should not be greater or equal to stop";
                return Ok(oNewNumbering);
            }
            if (StartFrom < Start)
            {
                oNewNumbering.errorDescription = "StartFrom should not be greater than Start";
                return Ok(oNewNumbering);

            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.pro_AddEditAutoGenNumber(0, AutoGenNumberText, AutoPrefixId, UsePrefix, Start, Stop, StartFrom, AllowManual, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewNumbering.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewNumbering.AutoGenNumberId = DbResult.AutoGenNumberId;
                    oNewNumbering.AutoGenNumberText = DbResult.AutoGenNumberText;
                    oNewNumbering.AutoPrefixId = DbResult.AutoPrefixId;
                    oNewNumbering.UsePrefix = DbResult.UsePrefix;
                    oNewNumbering.Start = DbResult.Start;
                    oNewNumbering.Stop = DbResult.Stop;
                    oNewNumbering.StartFrom = DbResult.StartFrom;
                    oNewNumbering.AllowManual = DbResult.AllowManual;
                    oNewNumbering.isSuccess = true;
                    return Ok(oNewNumbering);
                }

            }
            catch (Exception ex)
            {
                oNewNumbering.errorDescription = ex.Message;
                return Ok(oNewNumbering);

            }

        }
        [Route("Admin/UpdateNumbering"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateNumbering(int? AutoGenNumberId, string AutoGenNumberText, int? AutoPrefixId, int? Start, bool? UsePrefix, int? Stop, int? StartFrom, bool? AllowManual, bool? Delete)
        {
            Numbering oNewNumbering = new Numbering();
            oNewNumbering.errorDescription = "";
            oNewNumbering.isSuccess = false;
            if (Start == Stop || Start > Stop)
            {

                oNewNumbering.errorDescription = "Start should not be greater or equal to stop";
                return Ok(oNewNumbering);
            }
            if (StartFrom == Stop || StartFrom > Stop)
            {
                oNewNumbering.errorDescription = "StartFrom should not be greater or equal to stop";
                return Ok(oNewNumbering);
            }
            if (StartFrom < Start)
            {
                oNewNumbering.errorDescription = "StartFrom should not be greater than Start";
                return Ok(oNewNumbering);

            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.pro_AddEditAutoGenNumber(AutoGenNumberId, AutoGenNumberText, AutoPrefixId, UsePrefix, Start, Stop, StartFrom, AllowManual, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewNumbering.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }
                    oNewNumbering.AutoGenNumberId = DbResult.AutoGenNumberId;
                    oNewNumbering.AutoGenNumberText = DbResult.AutoGenNumberText;
                    oNewNumbering.AutoPrefixId = DbResult.AutoPrefixId;
                    oNewNumbering.UsePrefix = DbResult.UsePrefix;
                    oNewNumbering.Start = DbResult.Start;
                    oNewNumbering.Stop = DbResult.Stop;
                    oNewNumbering.StartFrom = DbResult.StartFrom;
                    oNewNumbering.AllowManual = DbResult.AllowManual;
                    oNewNumbering.isSuccess = true;
                    return Ok(oNewNumbering);
                }

            }
            catch (Exception ex)
            {
                oNewNumbering.errorDescription = ex.Message;
                return Ok(oNewNumbering);

            }

        }

        [Route("Admin/getAllNumbering")]
        public async Task<IHttpActionResult> getAllNumbering()
        {
            Numbering oNewNumbering = new Numbering();
            oNewNumbering.errorDescription = "";
            oNewNumbering.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllAutoGenNumbers().ToList();
                    List<Numbering> listofNumbering = new List<Numbering>();
                    foreach (var items in dbResult)
                    {
                        Numbering oNumbering = new Numbering();
                        oNumbering.AutoGenNumberId = items.AutoGenNumberId;
                        oNumbering.AutoGenNumberText = items.AutoGenNumberText;
                        oNumbering.AutoPrefixId = items.AutoPrefixId;
                        oNumbering.UsePrefix = items.UsePrefix;
                        oNumbering.Start = items.Start;
                        oNumbering.Stop = items.Stop;
                        oNumbering.StartFrom = items.StartFrom;
                        oNumbering.errorDescription = "";
                        oNumbering.isSuccess = true;
                        listofNumbering.Add(oNumbering);

                    }
                    IEnumerable<Numbering> myNumbering = listofNumbering;
                    return Ok(myNumbering);

                }

            }
            catch (Exception ex)
            {
                oNewNumbering.errorDescription = ex.Message;
                return Ok(oNewNumbering);

            }

        }
        [Route("Admin/getNumbering")]
        public async Task<IHttpActionResult> getNumbering(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var numbering = (from a in db.tblAutoGenNumbers
                                 where a.AutoGenNumberId == id
                                 select new
                                 {
                                     a.AutoGenNumberId,
                                     a.AutoGenNumberText,
                                     a.AutoPrefixId,
                                     a.UsePrefix,
                                     a.Start,
                                     a.Stop,
                                     a.StartFrom,
                                     a.AllowManual,
                                 }).FirstOrDefault();
                return Ok(new { numbering });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Admin/DeleteNumbering")]
        public IHttpActionResult DeleteNumbering(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblAutoGenNumber numbering = db.tblAutoGenNumbers.SingleOrDefault(x => x.AutoGenNumberId == id);
                db.tblAutoGenNumbers.Remove(numbering);
                db.SaveChanges();
                return Ok(numbering);
            }


        }
        [Route("Admin/AddSetup"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddSetup(string SetName, int? AutoGenNumberId, bool? IsManual, bool? Delete)
        {
            Setup oNewSetup = new Setup();
            oNewSetup.isSuccess = false;
            oNewSetup.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_AddEditAutoGenSetup(0, SetName, AutoGenNumberId, IsManual, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewSetup.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewSetup.SetupId = dbResult.SetupId;
                    oNewSetup.SetName = dbResult.SetName;
                    oNewSetup.AutoGenNumberId = dbResult.AutoGenNumberId;
                    oNewSetup.IsManual = dbResult.IsManual;
                    oNewSetup.isSuccess = true;
                    return Ok(oNewSetup);
                }

            }
            catch (Exception ex)
            {
                oNewSetup.errorDescription = ex.Message;
                return Ok(oNewSetup);

            }

        }
        [Route("Admin/UpdateSetup"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateSetup(int? SetupId, string SetName, int? AutoGenNumberId, bool? IsManual, bool? Delete)
        {
            Setup oNewSetup = new Setup();
            oNewSetup.isSuccess = false;
            oNewSetup.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_AddEditAutoGenSetup(SetupId, SetName, AutoGenNumberId, IsManual, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewSetup.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewSetup.SetupId = dbResult.SetupId;
                    oNewSetup.SetName = dbResult.SetName;
                    oNewSetup.AutoGenNumberId = dbResult.AutoGenNumberId;
                    oNewSetup.IsManual = dbResult.IsManual;
                    oNewSetup.isSuccess = true;
                    return Ok(oNewSetup);
                }

            }
            catch (Exception ex)
            {
                oNewSetup.errorDescription = ex.Message;
                return Ok(oNewSetup);

            }

        }
        [Route("Admin/getAllSetup")]
        public async Task<IHttpActionResult> getAllSetup()
        {
            Setup oNewSetup = new Setup();
            oNewSetup.errorDescription = "";
            oNewSetup.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_GetAllAutoGenSetups().ToList();
                    List<Setup> listofSetups = new List<Setup>();
                    foreach (var items in dbResult)
                    {
                        Setup oSetup = new Setup();
                        oSetup.SetupId = items.SetupId;
                        oSetup.SetName = items.SetName;
                        oSetup.AutoGenNumberId = items.AutoGenNumberId;
                        oSetup.IsManual = items.IsManual;
                        oSetup.errorDescription = "";
                        oSetup.isSuccess = true;
                        listofSetups.Add(oSetup);

                    }
                    IEnumerable<Setup> mySetups = listofSetups;
                    return Ok(mySetups);

                }

            }
            catch (Exception ex)
            {
                oNewSetup.errorDescription = ex.Message;
                return Ok(oNewSetup);

            }

        }
        [Route("Admin/getSetup")]
        public async Task<IHttpActionResult> getSetup(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var setup = (from a in db.tblAutoGenSetups
                             where a.SetupId == id
                             select new
                             {
                                 a.SetupId,
                                 a.AutoGenNumberId,
                                 a.SetName,
                                 a.IsManual,

                             }).FirstOrDefault();
                return Ok(new { setup });


            }

        }
        [HttpGet, HttpDelete]
        [Route("Admin/DeleteSetup")]
        public IHttpActionResult DeleteSetup(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblAutoGenSetup setup = db.tblAutoGenSetups.SingleOrDefault(x => x.SetupId == id);
                db.tblAutoGenSetups.Remove(setup);
                db.SaveChanges();
                return Ok(setup);
            }


        }
        [Route("Admin/InitialSetupName"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> InitialSetupName()
        {
            IntializeSetupName oNewIntializeSetupName = new IntializeSetupName();
            oNewIntializeSetupName.errorDescription = "";
            oNewIntializeSetupName.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.pro_InititializeSetupsName();
                    if (dbResult == null)
                    {
                        oNewIntializeSetupName.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(dbResult);
                    }
                    oNewIntializeSetupName.isSuccess = true;
                    return Ok(oNewIntializeSetupName);
                }

            }
            catch (Exception ex)
            {
                oNewIntializeSetupName.errorDescription = ex.Message;
                return Ok(oNewIntializeSetupName);


            }

        }
    }
}
