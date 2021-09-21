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
    public class OtherSettingController : ApiController
    {
        [Route("OtherSetting/AddTitle"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddTitle(string TitleName, bool? Delete)
        {
            Title oNewTitle = new Title();
            oNewTitle.errorDescription = "";
            oNewTitle.isSuccess = false;
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditTitle(0, TitleName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewTitle.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewTitle.TitleId = DbResult.TitleId;
                    oNewTitle.TitleName = DbResult.TitleName;
                    oNewTitle.isSuccess = true;
                    return Ok(oNewTitle);

                }
            }
            catch (Exception ex)
            {
                oNewTitle.errorDescription = ex.Message;
                return Ok(oNewTitle);

            }
        }
        [Route("OtherSetting/UpdateTitle"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateTitle(int? TitleId, string TitleName, bool? Delete)
        {
            Title oNewTitle = new Title();
            oNewTitle.errorDescription = "";
            oNewTitle.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditTitle(TitleId, TitleName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewTitle.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewTitle.TitleId = DbResult.TitleId;
                    oNewTitle.TitleName = DbResult.TitleName;
                    oNewTitle.isSuccess = true;
                    return Ok(oNewTitle);

                }
            }
            catch (Exception ex)
            {
                oNewTitle.errorDescription = ex.Message;
                return Ok(oNewTitle);

            }
        }

        [Route("OtherSetting/getAllTitles")]
        public async Task<IHttpActionResult> getAllTitles()
        {

            Title oNewTitle = new Title();
            oNewTitle.isSuccess = false;
            oNewTitle.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllTitle().ToList();
                    List<Title> listofTitle = new List<Title>();
                    foreach (var items in dbResult)
                    {
                        Title oTitle = new Title();
                        oTitle.TitleId = items.TitleId;
                        oTitle.TitleName = items.TitleName;
                        oTitle.isSuccess = true;
                        listofTitle.Add(oTitle);
                    }
                    IEnumerable<Title> myTitle = listofTitle;
                    return Ok(myTitle);

                }
            }
            catch (Exception ex)
            {
                oNewTitle.errorDescription = ex.Message;
                return Ok(oNewTitle);

            }

        }
        [Route("OtherSetting/getTitle")]
        public async Task<IHttpActionResult> getTitle(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var title = (from a in db.tblTitles
                             where a.TitleId == id
                             select new
                             {
                                 a.TitleId,
                                 a.TitleName,
                             }).FirstOrDefault();
                return Ok(new { title });


            }

        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteTitle")]
        public IHttpActionResult DeleteTitle(int? id)
        {
            Title oNewTitle = new Title();
            oNewTitle.isSuccess = false;
            oNewTitle.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                
                    if (db.tblMembers.Any(p => p.TitleId == id))
                    {
                        oNewTitle.errorDescription = "This title cannot delete since it being used else where ***";
                        return Ok(oNewTitle);

                    }
                    else
                    {
                        tblTitle title = db.tblTitles.SingleOrDefault(x => x.TitleId == id);
                        db.tblTitles.Remove(title);
                        db.SaveChanges();
                        oNewTitle.isSuccess = true;
                        return Ok(title);

                    }
                }

            }
            catch(Exception ex)
            {
                oNewTitle.errorDescription = ex.Message;
                return Ok(oNewTitle);


            }
           
        }
        [Route("OtherSetting/AddNationality"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddNationality(string NationalityName, bool? Delete)
        {
            Nationality oNewNationality = new Nationality();
            oNewNationality.errorDescription = "";
            oNewNationality.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditNationality(0, NationalityName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewNationality.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewNationality.NationalityId = DbResult.NationalityId;
                    oNewNationality.NationalityName = DbResult.NationalityName;
                    oNewNationality.isSuccess = true;
                    return Ok(oNewNationality);

                }
            }
            catch (Exception ex)
            {
                oNewNationality.errorDescription = ex.Message;
                return Ok(oNewNationality);

            }
        }
        [Route("OtherSetting/UpdateNationality"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateNationality(int? NationalityId, string NationalityName, bool? Delete)
        {
            Nationality oNewNationality = new Nationality();
            oNewNationality.errorDescription = "";
            oNewNationality.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditNationality(NationalityId, NationalityName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewNationality.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewNationality.NationalityId = DbResult.NationalityId;
                    oNewNationality.NationalityName = DbResult.NationalityName;
                    oNewNationality.isSuccess = true;
                    return Ok(oNewNationality);

                }
            }
            catch (Exception ex)
            {
                oNewNationality.errorDescription = ex.Message;
                return Ok(oNewNationality);

            }
        }
        [Route("OtherSetting/getNationality")]
        public async Task<IHttpActionResult> getNationality(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Nationality = (from a in db.tblNationalitys
                                   where a.NationalityId == id
                                   select new
                                   {
                                       a.NationalityId,
                                       a.NationalityName,
                                   }).FirstOrDefault();
                return Ok(new { Nationality });


            }

        }

        [Route("OtherSetting/getAllNationalities")]
        public async Task<IHttpActionResult> getAllNationalities()
        {

            Nationality oNewNationality = new Nationality();
            oNewNationality.isSuccess = false;
            oNewNationality.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllNationality().ToList();
                    List<Nationality> listofNationality = new List<Nationality>();
                    foreach (var items in dbResult)
                    {
                        Nationality oNationality = new Nationality();
                        oNationality.NationalityId = items.NationalityId;
                        oNationality.NationalityName = items.NationalityName;
                        oNationality.isSuccess = true;
                        listofNationality.Add(oNationality);
                    }
                    IEnumerable<Nationality> myNationality = listofNationality;
                    return Ok(myNationality);

                }
            }
            catch (Exception ex)
            {
                oNewNationality.errorDescription = ex.Message;
                return Ok(oNewNationality);

            }

        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteNationatity")]
        public IHttpActionResult DeleteNationatity(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblNationality Nationality = db.tblNationalitys.SingleOrDefault(x => x.NationalityId == id);
                db.tblNationalitys.Remove(Nationality);
                db.SaveChanges();
                return Ok(Nationality);


            }
        }
        [Route("OtherSetting/AddGender"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddGender(string GenderName, bool? Delete)
        {
            Gender oNewGender = new Gender();
            oNewGender.errorDescription = "";
            oNewGender.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditGender(0, GenderName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewGender.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewGender.GenderId = DbResult.GenderId;
                    oNewGender.GenderName = DbResult.GenderName;
                    oNewGender.isSuccess = true;
                    return Ok(oNewGender);

                }
            }
            catch (Exception ex)
            {
                oNewGender.errorDescription = ex.Message;
                return Ok(oNewGender);

            }
        }
        [Route("OtherSetting/UpdateGender"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateGender(int? GenderId, string GenderName, bool? Delete)
        {
            Gender oNewGender = new Gender();
            oNewGender.errorDescription = "";
            oNewGender.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditGender(GenderId, GenderName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewGender.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewGender.GenderId = DbResult.GenderId;
                    oNewGender.GenderName = DbResult.GenderName;
                    oNewGender.isSuccess = true;
                    return Ok(oNewGender);

                }
            }
            catch (Exception ex)
            {
                oNewGender.errorDescription = ex.Message;
                return Ok(oNewGender);

            }
        }
        [Route("OtherSetting/getAllGenders")]
        public async Task<IHttpActionResult> getAllGenders()
        {

            Gender oNewGender = new Gender();
            oNewGender.isSuccess = false;
            oNewGender.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllGender().ToList();
                    List<Gender> listofGender = new List<Gender>();
                    foreach (var items in dbResult)
                    {
                        Gender oGender = new Gender();
                        oGender.GenderId = items.GenderId;
                        oGender.GenderName = items.GenderName;
                        oGender.isSuccess = true;
                        listofGender.Add(oGender);
                    }
                    IEnumerable<Gender> myGender = listofGender;
                    return Ok(myGender);

                }
            }
            catch (Exception ex)
            {
                oNewGender.errorDescription = ex.Message;
                return Ok(oNewGender);

            }

        }
        [Route("OtherSetting/getGender")]
        public async Task<IHttpActionResult> getGender(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var gender = (from a in db.tblGenders
                              where a.GenderId == id
                              select new
                              {
                                  a.GenderId,
                                  a.GenderName,
                              }).FirstOrDefault();
                return Ok(new { gender });


            }

        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteGender")]
        public IHttpActionResult DeleteGender(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblGender gender = db.tblGenders.SingleOrDefault(x => x.GenderId == id);
                db.tblGenders.Remove(gender);
                db.SaveChanges();
                return Ok(gender);


            }
        }
        [Route("OtherSetting/AddMaritalStatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddMaritalStatus(string MaritalStatusName, bool? Delete)
        {
            Marital oNewMarital = new Marital();
            oNewMarital.errorDescription = "";
            oNewMarital.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMaritals(0, MaritalStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMarital.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewMarital.MaritalStatusId = DbResult.MaritalStatusId;
                    oNewMarital.MaritalStatusName = DbResult.MaritalStatusName;
                    oNewMarital.isSuccess = true;
                    return Ok(oNewMarital);

                }
            }
            catch (Exception ex)
            {
                oNewMarital.errorDescription = ex.Message;
                return Ok(oNewMarital);

            }
        }
        [Route("OtherSetting/UpdateMaritalStatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateMaritalStatus(int? MaritalStatusId, string MaritalStatusName, bool? Delete)
        {
            Marital oNewMarital = new Marital();
            oNewMarital.errorDescription = "";
            oNewMarital.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMaritals(MaritalStatusId, MaritalStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMarital.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewMarital.MaritalStatusId = DbResult.MaritalStatusId;
                    oNewMarital.MaritalStatusName = DbResult.MaritalStatusName;
                    oNewMarital.isSuccess = true;
                    return Ok(oNewMarital);

                }
            }
            catch (Exception ex)
            {
                oNewMarital.errorDescription = ex.Message;
                return Ok(oNewMarital);

            }
        }
        [Route("OtherSetting/getAllMaritalStatus")]
        public async Task<IHttpActionResult> getAllMaritalStatus()
        {

            Marital oNewMarital = new Marital();
            oNewMarital.isSuccess = false;
            oNewMarital.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllMaritials().ToList();
                    List<Marital> listofMarital = new List<Marital>();
                    foreach (var items in dbResult)
                    {
                        Marital oMarital = new Marital();
                        oMarital.MaritalStatusId = items.MaritalStatusId;
                        oMarital.MaritalStatusName = items.MaritalStatusName;
                        oMarital.isSuccess = true;
                        listofMarital.Add(oMarital);
                    }
                    IEnumerable<Marital> myMarital = listofMarital;
                    return Ok(myMarital);

                }
            }
            catch (Exception ex)
            {
                oNewMarital.errorDescription = ex.Message;
                return Ok(oNewMarital);

            }

        }
        [Route("OtherSetting/getMaritalStatus")]
        public async Task<IHttpActionResult> getMaritalStatus(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var marital = (from a in db.tblMaritalStatus
                               where a.MaritalStatusId == id
                               select new
                               {
                                   a.MaritalStatusId,
                                   a.MaritalStatusName,
                               }).FirstOrDefault();
                return Ok(new { marital });


            }

        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteMaritalStatus")]
        public IHttpActionResult DeleteMaritalStatus(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblMaritalStatu marital = db.tblMaritalStatus.SingleOrDefault(x => x.MaritalStatusId == id);
                db.tblMaritalStatus.Remove(marital);
                db.SaveChanges();
                return Ok(marital);


            }
        }
        [Route("OtherSetting/AddLevelofEducation"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddLevelofEducation(string LevelofEducationName, bool? Delete)
        {
            Education oNewEducation = new Education();
            oNewEducation.errorDescription = "";
            oNewEducation.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLevelofEducations(0, LevelofEducationName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewEducation.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewEducation.LevelofEducationId = DbResult.LevelofEducationId;
                    oNewEducation.LevelofEducationName = DbResult.LevelofEducationName;
                    oNewEducation.isSuccess = true;
                    return Ok(oNewEducation);

                }
            }
            catch (Exception ex)
            {
                oNewEducation.errorDescription = ex.Message;
                return Ok(oNewEducation);

            }
        }
        [Route("OtherSetting/getAllLevelofEducation")]
        public async Task<IHttpActionResult> getAllLevelofEducation()
        {

            Education oNewEducation = new Education();
            oNewEducation.isSuccess = false;
            oNewEducation.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllLevelofEducations().ToList();
                    List<Education> listofLevelofEducation = new List<Education>();
                    foreach (var items in dbResult)
                    {
                        Education oEducation = new Education();
                        oEducation.LevelofEducationId = items.LevelofEducationId;
                        oEducation.LevelofEducationName = items.LevelofEducationName;
                        oEducation.isSuccess = true;
                        listofLevelofEducation.Add(oEducation);
                    }
                    IEnumerable<Education> myEducation = listofLevelofEducation;
                    return Ok(myEducation);

                }
            }
            catch (Exception ex)
            {
                oNewEducation.errorDescription = ex.Message;
                return Ok(oNewEducation);

            }

        }
        [Route("OtherSetting/getLevelofEducation")]
        public async Task<IHttpActionResult> getLevelofEducation(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var education = (from a in db.tblLevelofEducations
                                 where a.LevelofEducationId == id
                                 select new
                                 {
                                     a.LevelofEducationId,
                                     a.LevelofEducationName,
                                 }).FirstOrDefault();
                return Ok(new { education });


            }

        }
        [Route("OtherSetting/UpdateLevelofEducation"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateLevelofEducation(int? LevelofEducationId, string LevelofEducationName, bool? Delete)
        {
            Education oNewEducation = new Education();
            oNewEducation.errorDescription = "";
            oNewEducation.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditLevelofEducations(LevelofEducationId, LevelofEducationName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewEducation.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewEducation.LevelofEducationId = DbResult.LevelofEducationId;
                    oNewEducation.LevelofEducationName = DbResult.LevelofEducationName;
                    oNewEducation.isSuccess = true;
                    return Ok(oNewEducation);

                }
            }
            catch (Exception ex)
            {
                oNewEducation.errorDescription = ex.Message;
                return Ok(oNewEducation);

            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteLevelofEducation")]
        public IHttpActionResult DeleteLevelofEducation(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblLevelofEducation education = db.tblLevelofEducations.SingleOrDefault(x => x.LevelofEducationId == id);
                db.tblLevelofEducations.Remove(education);
                db.SaveChanges();
                return Ok(education);


            }
        }
        [Route("OtherSetting/AddMemberstatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddMemberstatus(string MemberStatusName, bool? Delete)
        {
            Member_Status oNewMemberstatus = new Member_Status();
            oNewMemberstatus.errorDescription = "";
            oNewMemberstatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMemberStatus(0, MemberStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMemberstatus.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewMemberstatus.MemberStatusId = DbResult.MemberStatusId;
                    oNewMemberstatus.MemberStatusName = DbResult.MemberStatusName;
                    oNewMemberstatus.isSuccess = true;
                    return Ok(oNewMemberstatus);

                }
            }
            catch (Exception ex)
            {
                oNewMemberstatus.errorDescription = ex.Message;
                return Ok(oNewMemberstatus);

            }
        }
        [Route("OtherSetting/getAllMemberStatus")]
        public async Task<IHttpActionResult> getAllMemberStatus()
        {

            Member_Status oNewMemberstatus = new Member_Status();
            oNewMemberstatus.errorDescription = "";
            oNewMemberstatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllMemberStatus().ToList();
                    List<Member_Status> listofMemberStatus = new List<Member_Status>();
                    foreach (var items in dbResult)
                    {
                        Member_Status oMemberStatus = new Member_Status();
                        oMemberStatus.MemberStatusId = items.MemberStatusId;
                        oMemberStatus.MemberStatusName = items.MemberStatusName;
                        oMemberStatus.isSuccess = true;
                        listofMemberStatus.Add(oMemberStatus);
                    }
                    IEnumerable<Member_Status> myMemberStatus = listofMemberStatus;
                    return Ok(myMemberStatus);

                }
            }
            catch (Exception ex)
            {
                oNewMemberstatus.errorDescription = ex.Message;
                return Ok(oNewMemberstatus);

            }


        }
        [Route("OtherSetting/getMemberStatus")]
        public async Task<IHttpActionResult> getMemberStatus(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var memberstatus = (from a in db.tblMemberStatus
                                    where a.MemberStatusId == id
                                    select new
                                    {
                                        a.MemberStatusId,
                                        a.MemberStatusName,
                                    }).FirstOrDefault();
                return Ok(new { memberstatus });


            }
        }



        [Route("OtherSetting/UpdateMemberstatus"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateMemberstatus(int? MemberStatusId, string MemberStatusName, bool? Delete)
        {
            Member_Status oNewMemberstatus = new Member_Status();
            oNewMemberstatus.errorDescription = "";
            oNewMemberstatus.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMemberStatus(MemberStatusId, MemberStatusName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMemberstatus.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewMemberstatus.MemberStatusId = DbResult.MemberStatusId;
                    oNewMemberstatus.MemberStatusName = DbResult.MemberStatusName;
                    oNewMemberstatus.isSuccess = true;
                    return Ok(oNewMemberstatus);

                }
            }
            catch (Exception ex)
            {
                oNewMemberstatus.errorDescription = ex.Message;
                return Ok(oNewMemberstatus);

            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteMemberStatus")]
        public IHttpActionResult DeleteMemberStatus(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblMemberStatu mstatus = db.tblMemberStatus.SingleOrDefault(x => x.MemberStatusId == id);
                db.tblMemberStatus.Remove(mstatus);
                db.SaveChanges();
                return Ok(mstatus);


            }
        }
        [Route("OtherSetting/AddBank"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddBank(string BankName, bool? Delete)
        {
            Bank oNewBank = new Bank();
            oNewBank.errorDescription = "";
            oNewBank.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditBanks(0, BankName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewBank.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewBank.BankId = DbResult.BankId;
                    oNewBank.BankName = DbResult.BankName;
                    oNewBank.isSuccess = true;
                    return Ok(oNewBank);

                }
            }
            catch (Exception ex)
            {
                oNewBank.errorDescription = ex.Message;
                return Ok(oNewBank);

            }
        }
        [Route("OtherSetting/getAllBank")]
        public async Task<IHttpActionResult> getAllBank()
        {

            Bank oNewBank = new Bank();
            oNewBank.isSuccess = false;
            oNewBank.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllBanks().ToList();
                    List<Bank> listofBank = new List<Bank>();
                    foreach (var items in dbResult)
                    {
                        Bank oBank = new Bank();
                        oBank.BankId = items.BankId;
                        oBank.BankName = items.BankName;
                        oBank.isSuccess = true;
                        listofBank.Add(oBank);
                    }
                    IEnumerable<Bank> myBank = listofBank;
                    return Ok(myBank);

                }
            }
            catch (Exception ex)
            {
                oNewBank.errorDescription = ex.Message;
                return Ok(oNewBank);

            }

        }
        [Route("OtherSetting/getBank")]
        public async Task<IHttpActionResult> getBank(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var bank = (from a in db.tblBanks
                            where a.BankId == id
                            select new
                            {
                                a.BankId,
                                a.BankName,
                            }).FirstOrDefault();
                return Ok(new { bank });


            }
        }
        [Route("OtherSetting/UpdateBank"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateBank(int? BankId, string BankName, bool? Delete)
        {
            Bank oNewBank = new Bank();
            oNewBank.errorDescription = "";
            oNewBank.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditBanks(BankId, BankName, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewBank.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewBank.BankId = DbResult.BankId;
                    oNewBank.BankName = DbResult.BankName;
                    oNewBank.isSuccess = true;
                    return Ok(oNewBank);

                }
            }
            catch (Exception ex)
            {
                oNewBank.errorDescription = ex.Message;
                return Ok(oNewBank);

            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteBank")]
        public IHttpActionResult DeleteBank(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblBank bank = db.tblBanks.SingleOrDefault(x => x.BankId == id);
                db.tblBanks.Remove(bank);
                db.SaveChanges();
                return Ok(bank);


            }
        }
        [Route("OtherSetting/AddBankBranches"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddBankBranches(string BranchName, int? BankId, bool? Delete)
        {
            Bank_Branches oNewBranches = new Bank_Branches();
            oNewBranches.errorDescription = "";
            oNewBranches.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditBankBranches(0, BranchName, BankId, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewBranches.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewBranches.BranchId = DbResult.BranchId;
                    oNewBranches.BranchName = DbResult.BranchName;
                    oNewBranches.isSuccess = true;
                    return Ok(oNewBranches);

                }
            }
            catch (Exception ex)
            {
                oNewBranches.errorDescription = ex.Message;
                return Ok(oNewBranches);

            }
        }
        [Route("OtherSetting/getAllBranches")]
        public System.Object getAllBranches()
        {
            Bank_Branches oNewBranches = new Bank_Branches();
            oNewBranches.isSuccess = false;
            oNewBranches.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllBankBranches().ToList();
                    List<Bank_Branches> listofBranches = new List<Bank_Branches>();
                    foreach (var items in dbResult)
                    {
                        Bank_Branches OBranches = new Bank_Branches();
                        OBranches.BranchId = items.BranchId;
                        OBranches.BankId = items.BankId;
                        OBranches.BranchName = items.BranchName;
                        OBranches.isSuccess = true;
                        listofBranches.Add(OBranches);
                    }
                    IEnumerable<Bank_Branches> myBranches = listofBranches;
                    return Ok(myBranches);

                }
            }
            catch (Exception ex)
            {
                oNewBranches.errorDescription = ex.Message;
                return Ok(oNewBranches);

            }


        }
        [Route("OtherSetting/getBranch")]
        public async Task<IHttpActionResult> getBranch(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var banch = (from a in db.tblBankBranches
                             where a.BranchId == id
                             select new
                             {
                                 a.BranchId,
                                 a.BankId,
                                 a.BranchName,
                             }).FirstOrDefault();
                return Ok(new { banch });


            }
        }
        [Route("OtherSetting/UpdateBankBranches"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateBankBranches(int? BranchId, string BranchName, int? BankId, bool? Delete)
        {
            Bank_Branches oNewBranches = new Bank_Branches();
            oNewBranches.errorDescription = "";
            oNewBranches.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditBankBranches(BranchId, BranchName, BankId, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewBranches.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewBranches.BranchId = DbResult.BranchId;
                    oNewBranches.BranchName = DbResult.BranchName;
                    oNewBranches.isSuccess = true;
                    return Ok(oNewBranches);

                }
            }
            catch (Exception ex)
            {
                oNewBranches.errorDescription = ex.Message;
                return Ok(oNewBranches);

            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteBranch")]
        public IHttpActionResult DeleteBranch(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {


                tblBankBranch banch = db.tblBankBranches.SingleOrDefault(x => x.BranchId == id);
                db.tblBankBranches.Remove(banch);
                db.SaveChanges();
                return Ok(banch);


            }
        }
        [Route("OtherSetting/AddCurrency"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCurrency(string CurrencyName, string CurrencySymbol, bool? IsMainCurrency, bool? Delete)
        {
            Currency oNewCurrency = new Currency();
            oNewCurrency.errorDescription = "";
            oNewCurrency.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditCurrency(0, CurrencyName, CurrencySymbol, IsMainCurrency, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCurrency.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCurrency.CurrencyId = DbResult.CurrencyId;
                    oNewCurrency.CurrencyName = DbResult.CurrencyName;
                    oNewCurrency.IsMainCurrency = DbResult.IsMainCurrency;
                    oNewCurrency.CurrencySymbol = DbResult.CurrencySymbol;
                    oNewCurrency.isSuccess = true;
                    return Ok(oNewCurrency);

                }
            }
            catch (Exception ex)
            {
                oNewCurrency.errorDescription = ex.Message;
                return Ok(oNewCurrency);

            }
        }
        [Route("OtherSetting/UpdateCurrency"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCurrency(int? CurrencyId, string CurrencyName, string CurrencySymbol, bool? IsMainCurrency, bool? Delete)
        {
            Currency oNewCurrency = new Currency();
            oNewCurrency.errorDescription = "";
            oNewCurrency.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditCurrency(CurrencyId, CurrencyName, CurrencySymbol, IsMainCurrency, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCurrency.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCurrency.CurrencyId = DbResult.CurrencyId;
                    oNewCurrency.CurrencyName = DbResult.CurrencyName;
                    oNewCurrency.IsMainCurrency = DbResult.IsMainCurrency;
                    oNewCurrency.CurrencySymbol = DbResult.CurrencySymbol;
                    oNewCurrency.isSuccess = true;
                    return Ok(oNewCurrency);

                }
            }
            catch (Exception ex)
            {
                oNewCurrency.errorDescription = ex.Message;
                return Ok(oNewCurrency);

            }
        }
        [Route("OtherSetting/getAllCurrency")]
        public async Task<IHttpActionResult> getAllCurrency()
        {

            Currency oNewCurrency = new Currency();
            oNewCurrency.isSuccess = false;
            oNewCurrency.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllCurrency().ToList();
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
        [Route("OtherSetting/getCurrency")]
        public async Task<IHttpActionResult> getCurrency(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var currency = (from a in db.tblCurrencies
                                where a.CurrencyId == id
                                select new
                                {
                                    a.CurrencyId,
                                    a.CurrencyName,
                                    a.CurrencySymbol,
                                    a.IsMainCurrency,
                                }).FirstOrDefault();
                return Ok(new { currency });


            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteCurrency")]
        public IHttpActionResult DeleteCurrency(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblCurrency currency = db.tblCurrencies.SingleOrDefault(x => x.CurrencyId == id);
                db.tblCurrencies.Remove(currency);
                db.SaveChanges();
                return Ok(currency);
            }
        }
        [Route("OtherSetting/AddCurrencyRate"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCurrencyRate(decimal? BuyRate, decimal? SellRate, int? CurrencyId, bool? Delete)
        {
            CurrencyRate oNewCurrencyRate = new CurrencyRate();
            oNewCurrencyRate.errorDescription = "";
            oNewCurrencyRate.isSuccess = false;

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditExchangeRate(0, BuyRate, SellRate, CurrencyId, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCurrencyRate.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCurrencyRate.ExchangeRateId = DbResult.ExchangeRateId;
                    oNewCurrencyRate.BuyRate = DbResult.BuyRate;
                    oNewCurrencyRate.SellRate = DbResult.SellRate;
                    oNewCurrencyRate.CurrencyId = DbResult.CurrencyId;
                    oNewCurrencyRate.isSuccess = true;
                    return Ok(oNewCurrencyRate);

                }
            }
            catch (Exception ex)
            {
                oNewCurrencyRate.errorDescription = ex.Message;
                return Ok(oNewCurrencyRate);

            }
        }
        [Route("OtherSetting/UpdateCurrencyRate"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCurrencyRate(int? ExchangeRateId, decimal? BuyRate, decimal? SellRate, int? CurrencyId, bool? Delete)
        {
            CurrencyRate oNewCurrencyRate = new CurrencyRate();
            oNewCurrencyRate.errorDescription = "";
            oNewCurrencyRate.isSuccess = false;

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditExchangeRate(ExchangeRateId, BuyRate, SellRate, CurrencyId, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCurrencyRate.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCurrencyRate.ExchangeRateId = DbResult.ExchangeRateId;
                    oNewCurrencyRate.BuyRate = DbResult.BuyRate;
                    oNewCurrencyRate.SellRate = DbResult.SellRate;
                    oNewCurrencyRate.CurrencyId = DbResult.CurrencyId;
                    oNewCurrencyRate.isSuccess = true;
                    return Ok(oNewCurrencyRate);

                }
            }
            catch (Exception ex)
            {
                oNewCurrencyRate.errorDescription = ex.Message;
                return Ok(oNewCurrencyRate);

            }
        }
        [Route("OtherSetting/getAllCurrencyRate")]
        public System.Object getAllCurrencyRate()
        {

            using (DBContextEntities db = new DBContextEntities())
            {
                var exchangeRate = (from a in db.tblExchangeRates
                                    join b in db.tblCurrencies on a.CurrencyId equals b.CurrencyId
                                    select new
                                    {
                                        a.ExchangeRateId,
                                        a.BuyRate,
                                        a.SellRate,
                                        currency = b.CurrencyName,
                                    })
                               .ToList();
                return exchangeRate;

            }



        }
        [Route("OtherSetting/getExchangeRate")]
        public async Task<IHttpActionResult> getExchangeRate(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var exchangeRate = (from a in db.tblExchangeRates
                                    where a.ExchangeRateId == id
                                    select new
                                    {
                                        a.ExchangeRateId,
                                        a.BuyRate,
                                        a.SellRate,
                                        a.CurrencyId
                                    }).FirstOrDefault();
                return Ok(new { exchangeRate });


            }
        }
        [HttpGet, HttpDelete]
        [Route("OtherSetting/DeleteCurrencyRate")]
        public IHttpActionResult DeleteCurrencyRate(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblExchangeRate currencyrate = db.tblExchangeRates.SingleOrDefault(x => x.ExchangeRateId == id);
                db.tblExchangeRates.Remove(currencyrate);
                db.SaveChanges();
                return Ok(currencyrate);
            }
        }
        [Route("OtherSetting/getBranchType")]
        public async Task<IHttpActionResult> getBranchType(int BankId)
        {
            Bank_Branches oNewBranches = new Bank_Branches();
            oNewBranches.isSuccess = false;
            oNewBranches.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Proc_GetAllBackBranch(BankId).ToList();
                    List<Bank_Branches> listofBranches = new List<Bank_Branches>();

                    foreach (var items in dbResult)
                    {
                        Bank_Branches oBranches = new Bank_Branches();
                        oBranches.BankId = BankId;
                        oBranches.BranchId = items.BranchId;
                        oBranches.BranchName = items.BranchName;
                        oBranches.isSuccess = true;
                        oBranches.errorDescription = "";

                        listofBranches.Add(oBranches);
                    }
                    IEnumerable<Bank_Branches> myBranches = listofBranches;
                    return Ok(myBranches);
                }
            }
            catch (Exception ex)
            {
                oNewBranches.errorDescription = ex.Message;
                return Ok(oNewBranches);
            }
        }
        [Route("OtherSetting/getDefaultNationality")]
        public async Task<IHttpActionResult> getDefaultyNationality()
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var Nationality = (from a in db.tblNationalitys
                                   where a.NationalityName == "Kenyan"
                                   select new
                                   {
                                       a.NationalityId,
                                       a.NationalityName
                                   }).FirstOrDefault();
                return Ok(new { Nationality });


            }

        }
        [Route("OtherSetting/getDefaultMemberStatus")]
        public async Task<IHttpActionResult> getDefaultMemberStatus()
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var memberStatus = (from a in db.tblMemberStatus
                                   where a.MemberStatusName == "active"
                                   select new
                                   {
                                       a.MemberStatusName,
                                       a.MemberStatusId
                                   }).FirstOrDefault();
                return Ok(new { memberStatus });


            }

        }
    }
}
