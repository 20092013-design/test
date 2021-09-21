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
    public class MemberShareController : ApiController
    {
        [Route("MemberShare/AddMemberShare"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddMemberShare(int? MemberId, int? ProductId, decimal? ContributionRate, decimal? MinBalance,
       DateTime? TransactionDate, bool? HideBalance, bool? ExemptMobileCharges, int? CurrencyId, string AccountNo, bool? Delete)
        {
            MemberShare oNewMemberShare = new MemberShare();
            oNewMemberShare.isSuccess = false;
            oNewMemberShare.errorDescription = "";

            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMembershares(0, MemberId, ProductId, ContributionRate, MinBalance, TransactionDate,
                      HideBalance, ExemptMobileCharges, CurrencyId, AccountNo, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMemberShare.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewMemberShare.MemberShareId = DbResult.MemberShareId;
                    oNewMemberShare.ProductId = DbResult.ProductId;
                    oNewMemberShare.MemberId = DbResult.MemberId;
                    oNewMemberShare.ContributionRate = DbResult.ContributionRate;
                    oNewMemberShare.MinBalance = DbResult.MinBalance;
                    oNewMemberShare.TransactionDate = DbResult.TransactionDate;
                    oNewMemberShare.HideBalance = DbResult.HideBalance;
                    oNewMemberShare.CurrencyId = DbResult.CurrencyId;
                    oNewMemberShare.ExemptMobileCharges = DbResult.ExemptMobileCharges;
                    oNewMemberShare.isSuccess = true;
                    return Ok(oNewMemberShare);

                }


            }
            catch (Exception ex)
            {
                oNewMemberShare.errorDescription = ex.Message;
                return Ok(oNewMemberShare);


            }

        }
        [Route("MemberShare/UpdateMemberShare"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateMemberShare(int? MemberShareId, int? MemberId, int? ProductId, decimal? ContributionRate, decimal? MinBalance,
         DateTime? TransactionDate, bool? HideBalance, bool? ExemptMobileCharges, int? CurrencyId, string AccountNo, bool? Delete)
        {
            MemberShare oNewMemberShare = new MemberShare();
            oNewMemberShare.isSuccess = false;
            oNewMemberShare.errorDescription = "";

            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditMembershares(MemberShareId, MemberId, ProductId, ContributionRate, MinBalance, TransactionDate,
                      HideBalance, ExemptMobileCharges, CurrencyId, AccountNo, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewMemberShare.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewMemberShare.MemberShareId = DbResult.MemberShareId;
                    oNewMemberShare.MemberId = DbResult.MemberId;
                    oNewMemberShare.ProductId = DbResult.ProductId;
                    oNewMemberShare.ContributionRate = DbResult.ContributionRate;
                    oNewMemberShare.MinBalance = DbResult.MinBalance;
                    oNewMemberShare.TransactionDate = DbResult.TransactionDate;
                    oNewMemberShare.HideBalance = DbResult.HideBalance;
                    oNewMemberShare.CurrencyId = DbResult.CurrencyId;
                    oNewMemberShare.ExemptMobileCharges = DbResult.ExemptMobileCharges;
                    oNewMemberShare.isSuccess = true;
                    return Ok(oNewMemberShare);

                }


            }
            catch (Exception ex)
            {
                oNewMemberShare.errorDescription = ex.Message;
                return Ok(oNewMemberShare);


            }

        }
        [Route("MemberShare/GetAllMemberShare")]
        public IHttpActionResult GetAllMemberShare()
        {

            MemberShare onNewMemberShare = new MemberShare();
            onNewMemberShare.isSuccess = false;
            onNewMemberShare.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetALLMembersShares().ToList();
                    List<MemberShare> listofMemberShare = new List<MemberShare>();
                    foreach (var items in dbResult)
                    {
                        MemberShare oMemberShare = new MemberShare();
                        oMemberShare.MemberShareId = items.MemberShareId;
                        oMemberShare.ProductId = items.ProductId;
                        oMemberShare.MemberId = items.MemberId;
                        oMemberShare.ContributionRate = items.ContributionRate;
                        oMemberShare.MinBalance = items.MinBalance;
                        oMemberShare.HideBalance = items.HideBalance;
                        oMemberShare.TransactionDate = items.TransactionDate;
                        oMemberShare.ExemptMobileCharges = items.ExemptMobileCharges;
                        oMemberShare.CurrencyId = items.CurrencyId;
                        oMemberShare.AccountNo = items.AccountNumber;
                        oMemberShare.isSuccess = true;
                        listofMemberShare.Add(oMemberShare);
                    }
                    IEnumerable<MemberShare> myMemberShare = listofMemberShare;
                    return Ok(myMemberShare);

                }
            }
            catch (Exception ex)
            {
                onNewMemberShare.errorDescription = ex.Message;
                return Ok(onNewMemberShare);

            }

        }
        [Route("MemberShare/GetMemberShare")]
        public async Task<IHttpActionResult> GetMemberShare(int? id)
        {
            MemberShare onNewMemberShare = new MemberShare();
            onNewMemberShare.isSuccess = false;
            onNewMemberShare.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var MemberShare = (from a in db.tblMemberShares
                                       where a.MemberShareId == id
                                       select new
                                       {
                                           a.MemberShareId,
                                           a.MemberId,
                                           a.ProductId,
                                           a.ContributionRate,
                                           a.MinBalance,
                                           a.TransactionDate,
                                           a.HideBalance,
                                           a.ExemptMobileCharges,
                                           a.CurrencyId,
                                           a.AccountNumber,
                                       }).FirstOrDefault();
                    return Ok(new { MemberShare });


                }

            }
            catch (Exception ex)
            {
                onNewMemberShare.errorDescription = ex.Message;
                return Ok(onNewMemberShare);

            }
        }
        [Route("MemberShare/DeleteMemberShare"), HttpGet]
        public IHttpActionResult DeleteMemberShare(int id)

        {
            MemberShare onNewMemberShare = new MemberShare();
            onNewMemberShare.isSuccess = false;
            onNewMemberShare.errorDescription = "";
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {

                    tblMemberShare memberShare = db.tblMemberShares.SingleOrDefault(x => x.MemberShareId == id);
                    db.tblMemberShares.Remove(memberShare);
                    db.SaveChanges();
                    return Ok(memberShare);
                }
            }
            catch (Exception ex)
            {
                onNewMemberShare.errorDescription = ex.Message;
                return Ok(onNewMemberShare);

            }

        }
        [Route("MemberShare/GetMemberSharedById")]
        public IHttpActionResult GetMemberSharedById(int? MemberShareId)
        {

            Member onNewMemberShare = new Member();
            onNewMemberShare.isSuccess = false;
            onNewMemberShare.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetMemberById(MemberShareId).ToList();
                    List<Member> listofMemberShare = new List<Member>();
                    foreach (var items in dbResult)
                    {
                        Member oMemberShare = new Member();
                        oMemberShare.MemberId = items.MemberId;
                        oMemberShare.MemberNo = items.MemberNo;
                        oMemberShare.FullName = items.FullName;
                        oMemberShare.SearchName = items.SearchName;
                        oMemberShare.PhoneNo = items.PhoneNo;
                        
                        oMemberShare.isSuccess = true;
                        listofMemberShare.Add(oMemberShare);


                    }
                    IEnumerable<Member> myProductCharge = listofMemberShare;
                    return Ok(myProductCharge);

                }
            }
            catch (Exception ex)
            {
                onNewMemberShare.errorDescription = ex.Message;
                return Ok(onNewMemberShare);

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
                    var dbResult = db.proc_GetMemberSharesByMemberId(MemberId).ToList();
                    List<MemberShare> listofMemberShare = new List<MemberShare>();

                    foreach (var items in dbResult)
                    {
                        MemberShare oMemberShare = new MemberShare();

                        oMemberShare.MemberId = items.MemberId;
                        oMemberShare.ProductId = items.ProductId;
                        oMemberShare.ContributionRate = items.ContributionRate;
                        oMemberShare.MinBalance = items.MinBalance;
                        oMemberShare.AccountNo = items.AccountNumber;

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
        [Route("MemberShare/GetAccountNumberByProductId")]
        public async Task<IHttpActionResult> GetAccountNumberByProductId(int? ProductId, int? MemberId)
        {
            MemberShare oNewMemberShare = new MemberShare();
            oNewMemberShare.isSuccess = false;
            oNewMemberShare.errorDescription = "";
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AccountNumberByProductId(ProductId, MemberId).ToList();
                    List<MemberShare> listofMemberShares = new List<MemberShare>();
                    foreach (var item in dbResult)
                    {
                        MemberShare oMemberShare = new MemberShare();

                        oMemberShare.AccountNo = item;
                        oMemberShare.isSuccess = true;
                        oMemberShare.errorDescription = "";
                        listofMemberShares.Add(oMemberShare);
                    }


                    return Ok(listofMemberShares);
                }



            }
            catch (Exception ex)
            {
                oNewMemberShare.errorDescription = ex.Message;
                return Ok(oNewMemberShare);
            }
        }
    }
}
