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
    public class CollateralController : ApiController
    {
        [Route("Collateral/AddCollateral"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCollateral(string CollateralName, bool? HasTimeLimit, bool? Delete)
        {
            Collateral oNewCollateral = new Collateral();
            oNewCollateral.errorDescription = "";
            oNewCollateral.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditCollaterals(0, CollateralName, HasTimeLimit, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCollateral.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCollateral.CollateralId = DbResult.ColllateralId;
                    oNewCollateral.CollateralName = DbResult.CollateralName;
                    oNewCollateral.HasTimeLimit = DbResult.HasTimeLimit;
                    oNewCollateral.isSuccess = true;
                    return Ok(oNewCollateral);

                }
            }
            catch (Exception ex)
            {
                oNewCollateral.errorDescription = ex.Message;
                return Ok(oNewCollateral);

            }
        }
        [Route("Collateral/UpdateCollateral"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCollateral(int? CollateralId, string CollateralName, bool? HasTimeLimit, bool? Delete)
        {
            Collateral oNewCollateral = new Collateral();
            oNewCollateral.errorDescription = "";
            oNewCollateral.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditCollaterals(CollateralId, CollateralName, HasTimeLimit, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewCollateral.errorDescription = "Process failed. Please confirm user detail and try again";
                        return Ok(DbResult);
                    }

                    oNewCollateral.CollateralId = DbResult.ColllateralId;
                    oNewCollateral.CollateralName = DbResult.CollateralName;
                    oNewCollateral.HasTimeLimit = DbResult.HasTimeLimit;
                    oNewCollateral.isSuccess = true;
                    return Ok(oNewCollateral);

                }
            }
            catch (Exception ex)
            {
                oNewCollateral.errorDescription = ex.Message;
                return Ok(oNewCollateral);

            }
        }
        [Route("Collateral/getAllCollateral")]
        public async Task<IHttpActionResult> getAllCollateral()
        {

            Collateral oNewCollateral = new Collateral();
            oNewCollateral.errorDescription = "";
            oNewCollateral.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetALLCollateral().ToList();
                    List<Collateral> listofCollateral = new List<Collateral>();
                    foreach (var items in dbResult)
                    {
                        Collateral oCollateral = new Collateral();
                        oCollateral.CollateralId = items.ColllateralId;
                        oCollateral.CollateralName = items.CollateralName;
                        oCollateral.HasTimeLimit = items.HasTimeLimit;
                        oCollateral.isSuccess = true;
                        listofCollateral.Add(oCollateral);
                    }
                    IEnumerable<Collateral> myCollateral = listofCollateral;
                    return Ok(myCollateral);

                }
            }
            catch (Exception ex)
            {
                oNewCollateral.errorDescription = ex.Message;
                return Ok(oNewCollateral);

            }

        }
        [Route("Collateral/getCollateral")]
        public async Task<IHttpActionResult> getCollateral(int? id)
        {
            Collateral oNewCollateral = new Collateral();
            oNewCollateral.errorDescription = "";
            oNewCollateral.isSuccess = false;
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var Collateral = (from a in db.tblCollaterals
                                      where a.ColllateralId == id
                                      select new
                                      {
                                          a.ColllateralId,
                                          a.CollateralName,
                                          a.HasTimeLimit,
                                      }).FirstOrDefault();
                    oNewCollateral.isSuccess = true;
                    return Ok(new { Collateral });


                }

            }
            catch (Exception ex)
            {
                oNewCollateral.errorDescription = ex.Message;
                return Ok(oNewCollateral);

            }


        }
        [HttpGet, HttpDelete]
        [Route("Collateral/DeleteCollateral")]
        public IHttpActionResult DeleteCollateral(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblCollateral collateral = db.tblCollaterals.SingleOrDefault(x => x.ColllateralId == id);
                db.tblCollaterals.Remove(collateral);
                db.SaveChanges();
                return Ok(collateral);

            }
        }
    }
}
