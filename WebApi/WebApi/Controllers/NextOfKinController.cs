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
    public class NextOfKinController : ApiController
    {
        [Route("Api/AddRelation"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddRelation(string RelationName, bool? Delete)

        {
            Relation relation = new Relation();
            relation.isSuccess = false;
            relation.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (RelationName == null)
                    {
                        RelationName = "";
                    }





                    var DbResult = db.proc_AddEditRelations(0, RelationName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        relation.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    relation.RelationName = DbResult.RelationName;

                    relation.isSuccess = true;
                    return Ok(relation);
                }

            }
            catch (Exception ex)
            {
                relation.errorDescription = ex.Message;
                return Ok(relation);

            }
        }


        [Route("Api/UpdateRelation"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateRelation(int? RelationId, string RelationName, bool? Delete)

        {
            Relation relation = new Relation();
            relation.isSuccess = false;
            relation.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (RelationName == null)
                    {
                        RelationName = "";
                    }


                    var DbResult = db.proc_AddEditRelations(RelationId, RelationName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        relation.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    relation.RelationId = DbResult.RelationId;
                    relation.RelationName = DbResult.RelationName;

                    relation.isSuccess = true;
                    return Ok(relation);
                }

            }
            catch (Exception ex)
            {
                relation.errorDescription = ex.Message;
                return Ok(relation);

            }
        }

        [Route("Api/GetAllRelations")]
        public IHttpActionResult GetAllRelations()
        {

            Relation relation = new Relation();
            relation.isSuccess = false;
            relation.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllRelations().ToList();
                    List<Relation> listofrelations = new List<Relation>();
                    foreach (var items in dbResult)
                    {
                        Relation newRelation = new Relation();

                        newRelation.RelationId = items.RelationId;
                        newRelation.RelationName = items.RelationName;
                        newRelation.errorDescription = "";
                        newRelation.isSuccess = true;
                        listofrelations.Add(newRelation);
                    }
                    IEnumerable<Relation> myRelations = listofrelations;
                    return Ok(myRelations);

                }
            }
            catch (Exception ex)
            {
                relation.errorDescription = ex.Message;
                return Ok(relation);

            }

        }



        [Route("Api/GetRelation")]
        public async Task<IHttpActionResult> GetRelation(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var relation = (from a in db.tblRelations
                                where a.RelationId == id
                                select new
                                {
                                    a.RelationId,
                                    a.RelationName,

                                }).FirstOrDefault();
                return Ok(new { relation });


            }

        }

        [Route("Api/DeleteRelation"), HttpGet]
        public IHttpActionResult DeleteRelation(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblRelation relation = db.tblRelations.SingleOrDefault(x => x.RelationId == id);
                db.tblRelations.Remove(relation);
                db.SaveChanges();
                return Ok(relation);
            }
        }
        [Route("Api/AddKin"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddKin(int? MemberId, int? RelationId, string FullName, string Address, string PhoneNumber, string Town, DateTime? DOB, string IdNo, string Remarks, bool Delete)

        {
            Kin oKin = new Kin();
            oKin.isSuccess = false;
            oKin.errorDescription = "";
            if (MemberId == null)
            {
                MemberId = 0;
            }
            if (RelationId == null)
            {
                RelationId = 0;
            }
            if (FullName == null)
            {
                FullName = "";
            }
            if (Address == null)
            {
                Address = "";
            }
            if (PhoneNumber == null)
            {
                PhoneNumber = "";
            }
            if (Town == null)
            {
                Town = "";
            }
            if (DOB == null)
            {
                oKin.errorDescription = "Date Of Birth is Required";
                return Ok(oKin);
            }
            if (IdNo == null)
            {
                IdNo = "";
            }
            if (Remarks == null)
            {
                Remarks = "";
            }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {


                    if (IdNo != "" && db.tblKins.Any(p => p.IdNo == IdNo))
                    {
                        oKin.errorDescription = ("Id Number already exist in database. Please try again!");
                        return Ok(oKin);
                    }

                    var DbResult = db.proc_AddEditKin(0, MemberId, RelationId, FullName, Address, PhoneNumber, Town, DOB, IdNo, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oKin.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }

                    oKin.MemberId = DbResult.MemberId;
                    oKin.RelationId = DbResult.RelationId;
                    oKin.FullName = DbResult.FullName;
                    oKin.Address = DbResult.Address;
                    oKin.PhoneNumber = DbResult.PhoneNumber;
                    oKin.Town = DbResult.Town;
                    oKin.DOB = DbResult.DOB;
                    oKin.IdNo = DbResult.IdNo;
                    oKin.Remarks = DbResult.Remarks;

                    oKin.isSuccess = true;
                    return Ok(oKin);
                }

            }
            catch (Exception ex)
            {
                oKin.errorDescription = ex.Message;
                return Ok(oKin);

            }
        }



        [Route("Api/UpdateKin"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateKin(int? KinId, int? MemberId, int? RelationId, string FullName, string Address, string PhoneNumber, string Town, DateTime? DOB, string IdNo, string Remarks, bool Delete)

        {
            Kin oKin = new Kin();
            oKin.isSuccess = false;
            oKin.errorDescription = "";
            if (MemberId == null)
            {
                MemberId = 0;
            }
            if (RelationId == null)
            {
                RelationId = 0;
            }
            if (FullName == null)
            {
                FullName = "";
            }
            if (Address == null)
            {
                Address = "";
            }
            if (PhoneNumber == null)
            {
                PhoneNumber = "";
            }
            if (Town == null)
            {
                Town = "";
            }

            if (DOB == null)
            {
                oKin.errorDescription = "Date Of Birth is Required";
                return Ok(oKin);
            }
            if (IdNo == null)
            {
                IdNo = "";
            }
            if (Remarks == null)
            {
                Remarks = "";
            }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (IdNo != "" && db.tblKins.Any(p => p.IdNo == IdNo))
                    {
                        var nextKin = (from a in db.tblKins
                                       where a.IdNo == IdNo
                                       select new
                                       { a.KinId }).FirstOrDefault();
                        if (nextKin.KinId == KinId)
                        {
                            var DbResult = db.proc_AddEditKin(KinId, MemberId, RelationId, FullName, Address, PhoneNumber, Town, DOB, IdNo, Remarks, Delete = false).FirstOrDefault();
                            if (DbResult == null)
                            {
                                oKin.errorDescription = "Process failed. Please try again!";
                                return Ok(DbResult);
                            }

                            oKin.KinId = DbResult.KinId;
                            oKin.MemberId = DbResult.MemberId;
                            oKin.RelationId = DbResult.RelationId;
                            oKin.FullName = DbResult.FullName;
                            oKin.Address = DbResult.Address;
                            oKin.PhoneNumber = DbResult.PhoneNumber;
                            oKin.Town = DbResult.Town;
                            oKin.DOB = DbResult.DOB;
                            oKin.IdNo = DbResult.IdNo;
                            oKin.Remarks = DbResult.Remarks;

                            oKin.isSuccess = true;
                            return Ok(oKin);

                        }
                        else
                        {
                            oKin.errorDescription = ("Id Number already exist in database. Please try again!");
                            return Ok(oKin);

                        }
                    }
                    else
                    {

                        var DbResult = db.proc_AddEditKin(KinId, MemberId, RelationId, FullName, Address, PhoneNumber, Town, DOB, IdNo, Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            oKin.errorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }

                        oKin.KinId = DbResult.KinId;
                        oKin.MemberId = DbResult.MemberId;
                        oKin.RelationId = DbResult.RelationId;
                        oKin.FullName = DbResult.FullName;
                        oKin.Address = DbResult.Address;
                        oKin.PhoneNumber = DbResult.PhoneNumber;
                        oKin.Town = DbResult.Town;
                        oKin.DOB = DbResult.DOB;
                        oKin.IdNo = DbResult.IdNo;
                        oKin.Remarks = DbResult.Remarks;

                        oKin.isSuccess = true;
                        return Ok(oKin);

                    }



                }

            }
            catch (Exception ex)
            {
                oKin.errorDescription = ex.Message;
                return Ok(oKin);

            }
        }



        [Route("Api/GetAllKins")]
        public IHttpActionResult GetAllKins(int MemberId)
        {

            Kin oKin = new Kin();
            oKin.isSuccess = false;
            oKin.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllKins(MemberId).ToList();
                    List<Kin> listofkins = new List<Kin>();
                    foreach (var items in dbResult)
                    {
                        Kin newKin = new Kin();

                        newKin.KinId = items.KinId;
                        newKin.MemberId = items.MemberId;
                        newKin.RelationId = items.RelationId;
                        newKin.FullName = items.FullName;
                        newKin.Address = items.Address;
                        newKin.PhoneNumber = items.PhoneNumber;
                        newKin.Town = items.Town;
                        newKin.DOB = items.DOB;
                        newKin.IdNo = items.IdNo;
                        newKin.Remarks = items.Remarks;

                        newKin.errorDescription = "";
                        newKin.isSuccess = true;
                        listofkins.Add(newKin);
                    }
                    IEnumerable<Kin> myKins = listofkins;
                    return Ok(myKins);

                }
            }
            catch (Exception ex)
            {
                oKin.errorDescription = ex.Message;
                return Ok(oKin);

            }

        }



        [Route("Api/GetKin")]
        public async Task<IHttpActionResult> GetKin(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var kin = (from a in db.tblKins
                           where a.KinId == id
                           select new
                           {
                               a.KinId,
                               a.MemberId,
                               a.RelationId,
                               a.FullName,
                               a.Address,
                               a.PhoneNumber,
                               a.Town,
                               a.DOB,
                               a.IdNo,
                               a.Remarks,


                           }).FirstOrDefault();
                return Ok(new { kin });


            }

        }

        [Route("Api/DeleteKin"), HttpGet]
        public IHttpActionResult DeleteKin(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblKin kin = db.tblKins.SingleOrDefault(x => x.KinId == id);
                db.tblKins.Remove(kin);
                db.SaveChanges();
                return Ok(kin);
            }
        }
    }
}
