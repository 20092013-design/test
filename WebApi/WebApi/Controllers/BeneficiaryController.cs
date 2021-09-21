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
    public class BeneficiaryController : ApiController
    {
        [Route("Api/AddBeneficiary"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddBeneficiary(int? MemberId, int? RelationshipId, string FullName, string IdNo, DateTime? DOB,
    string PhoneNumber, string Town, decimal? Value, string Code, string Remarks, bool Delete)

        {
            Beneficiary oNewBeneficiary = new Beneficiary();
            oNewBeneficiary.isSuccess = false;
            oNewBeneficiary.errorDescription = "";
            if (MemberId == null)
            {
                oNewBeneficiary.errorDescription = "Please member number is not selected ";
                return Ok(oNewBeneficiary);
            }
            if (RelationshipId == null)
            {
                RelationshipId = 0;
            }
            if (FullName == null)
            {
                FullName = "";
            }
            if (IdNo == null)
            {
                IdNo = "";
            }
            if (DOB == null)
            {
                DOB = DateTime.Parse("1900/01/01");
            }
            if (PhoneNumber == null)
            {
                PhoneNumber = "";
            }
            if (Town == null)
            {
                Town = "";
            }
            if (Value == null)
            {
                Value = 0;
            }
            if (Code == null)
            {
                Code = "";
            }
            if (Remarks == null)
            {
                Remarks = "";
            }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblBeneficiaries.Any(p => p.IdNo == IdNo))
                    {
                        oNewBeneficiary.errorDescription = ("Id Number already exist in database. Please try again!");
                        return Ok(oNewBeneficiary);
                    }

                    var DbResult = db.proc_AddEditBeneficiaries(0, MemberId, RelationshipId, FullName, IdNo, DOB, PhoneNumber, Town, Value, Code, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewBeneficiary.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewBeneficiary.BeneficiaryId = DbResult.BeneficiaryId;
                    oNewBeneficiary.MemberId = DbResult.MemberId;
                    oNewBeneficiary.RelationshipId = DbResult.RelationshipId;
                    oNewBeneficiary.FullName = DbResult.FullName;
                    oNewBeneficiary.Code = DbResult.Code;
                    oNewBeneficiary.PhoneNumber = DbResult.PhoneNumber;
                    oNewBeneficiary.Town = DbResult.Town;
                    oNewBeneficiary.Value = DbResult.Value;
                    oNewBeneficiary.DOB = DbResult.DOB;
                    oNewBeneficiary.IdNo = DbResult.IdNo;
                    oNewBeneficiary.Remarks = DbResult.Remarks;

                    oNewBeneficiary.isSuccess = true;
                    return Ok(oNewBeneficiary);
                }

            }
            catch (Exception ex)
            {
                oNewBeneficiary.errorDescription = ex.Message;
                return Ok(oNewBeneficiary);

            }
        }

        [Route("Api/UpdateBeneficiary"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateBeneficiary(int? BeneficiaryId, int? MemberId, int? RelationshipId, string FullName, string IdNo, DateTime? DOB,
        string PhoneNumber, string Town, decimal? Value, string Code, string Remarks, bool Delete)

        {
            Beneficiary oNewBeneficiary = new Beneficiary();
            oNewBeneficiary.isSuccess = false;
            oNewBeneficiary.errorDescription = "";
            if (MemberId == null)
            {
                oNewBeneficiary.errorDescription = "Please member number is not selected ";
                return Ok(oNewBeneficiary);
            }
            if (RelationshipId == null)
            {
                RelationshipId = 0;
            }
            if (FullName == null)
            {
                FullName = "";
            }
            if (IdNo == null)
            {
                IdNo = "";
            }
            if (DOB == null)
            {
                DOB = DateTime.Parse("1900/01/01");
            }
            if (PhoneNumber == null)
            {
                PhoneNumber = "";
            }
            if (Town == null)
            {
                Town = "";
            }
            if (Value == null)
            {
                Value = 0;
            }
            if (Code == null)
            {
                Code = "";
            }
            if (Remarks == null)
            {
                Remarks = "";
            }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblBeneficiaries.Any(p => p.IdNo == IdNo))
                    {
                        var beneficiary = (from a in db.tblBeneficiaries
                                           where a.IdNo == IdNo
                                           select new
                                           { a.BeneficiaryId }).FirstOrDefault();
                        if (beneficiary.BeneficiaryId == BeneficiaryId)
                        {
                            var DbResult = db.proc_AddEditBeneficiaries(BeneficiaryId, MemberId, RelationshipId, FullName, IdNo, DOB, PhoneNumber, Town, Value, Code, Remarks, Delete = false).FirstOrDefault();
                            if (DbResult == null)
                            {
                                oNewBeneficiary.errorDescription = "Process failed. Please try again!";
                                return Ok(DbResult);
                            }

                            oNewBeneficiary.BeneficiaryId = DbResult.BeneficiaryId;
                            oNewBeneficiary.MemberId = DbResult.MemberId;
                            oNewBeneficiary.RelationshipId = DbResult.RelationshipId;
                            oNewBeneficiary.FullName = DbResult.FullName;
                            oNewBeneficiary.Code = DbResult.Code;
                            oNewBeneficiary.PhoneNumber = DbResult.PhoneNumber;
                            oNewBeneficiary.Town = DbResult.Town;
                            oNewBeneficiary.Value = DbResult.Value;
                            oNewBeneficiary.DOB = DbResult.DOB;
                            oNewBeneficiary.IdNo = DbResult.IdNo;
                            oNewBeneficiary.Remarks = DbResult.Remarks;

                            oNewBeneficiary.isSuccess = true;
                            return Ok(oNewBeneficiary);
                        }
                        else
                        {
                            oNewBeneficiary.errorDescription = ("Id Number already exist in database. Please try again!");
                            return Ok(oNewBeneficiary);

                        }
                    }
                    else
                    {
                        var DbResult = db.proc_AddEditBeneficiaries(BeneficiaryId, MemberId, RelationshipId, FullName, IdNo, DOB, PhoneNumber, Town, Value, Code, Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            oNewBeneficiary.errorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }

                        oNewBeneficiary.BeneficiaryId = DbResult.BeneficiaryId;
                        oNewBeneficiary.MemberId = DbResult.MemberId;
                        oNewBeneficiary.RelationshipId = DbResult.RelationshipId;
                        oNewBeneficiary.FullName = DbResult.FullName;
                        oNewBeneficiary.Code = DbResult.Code;
                        oNewBeneficiary.PhoneNumber = DbResult.PhoneNumber;
                        oNewBeneficiary.Town = DbResult.Town;
                        oNewBeneficiary.Value = DbResult.Value;
                        oNewBeneficiary.DOB = DbResult.DOB;
                        oNewBeneficiary.IdNo = DbResult.IdNo;
                        oNewBeneficiary.Remarks = DbResult.Remarks;

                        oNewBeneficiary.isSuccess = true;
                        return Ok(oNewBeneficiary);

                    }


                }

            }
            catch (Exception ex)
            {
                oNewBeneficiary.errorDescription = ex.Message;
                return Ok(oNewBeneficiary);

            }
        }

        [Route("Api/GetAllBeneficiaries")]
        public IHttpActionResult GetAllBeneficiaries(int MemberId)
        {

            Beneficiary oNewBeneficiary = new Beneficiary();
            oNewBeneficiary.isSuccess = false;
            oNewBeneficiary.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_GetAllBeneficiaries(MemberId).ToList();
                    List<Beneficiary> listofBeneficiaries = new List<Beneficiary>();
                    foreach (var items in DbResult)
                    {
                        Beneficiary oBeneficiary = new Beneficiary();

                        oBeneficiary.BeneficiaryId = items.BeneficiaryId;
                        oBeneficiary.MemberId = items.MemberId;
                        oBeneficiary.RelationshipId = items.RelationshipId;
                        oBeneficiary.FullName = items.FullName;
                        oBeneficiary.Code = items.Code;
                        oBeneficiary.PhoneNumber = items.PhoneNumber;
                        oBeneficiary.Town = items.Town;
                        oBeneficiary.Value = items.Value;
                        oBeneficiary.DOB = items.DOB;
                        oBeneficiary.IdNo = items.IdNo;
                        oBeneficiary.Remarks = items.Remarks;

                        oBeneficiary.errorDescription = "";
                        oBeneficiary.isSuccess = true;
                        listofBeneficiaries.Add(oBeneficiary);
                    }
                    IEnumerable<Beneficiary> myBeneficiary = listofBeneficiaries;
                    return Ok(myBeneficiary);

                }
            }
            catch (Exception ex)
            {
                oNewBeneficiary.errorDescription = ex.Message;
                return Ok(oNewBeneficiary);

            }

        }

        [Route("Api/GetBeneficiary")]
        public async Task<IHttpActionResult> GetBeneficiary(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var beneficiary = (from a in db.tblBeneficiaries
                                   where a.BeneficiaryId == id
                                   select new
                                   {
                                       a.BeneficiaryId,
                                       a.MemberId,
                                       a.RelationshipId,
                                       a.FullName,
                                       a.Code,
                                       a.PhoneNumber,
                                       a.Town,
                                       a.Value,
                                       a.DOB,
                                       a.IdNo,
                                       a.Remarks,

                                   }).FirstOrDefault();
                return Ok(new { beneficiary });


            }

        }

        [Route("Api/DeleteBeneficiary"), HttpGet]
        public IHttpActionResult DeleteBeneficiary(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblBeneficiary beneficiary = db.tblBeneficiaries.SingleOrDefault(x => x.BeneficiaryId == id);
                db.tblBeneficiaries.Remove(beneficiary);
                db.SaveChanges();
                return Ok(beneficiary);
            }
        }
    }
}
