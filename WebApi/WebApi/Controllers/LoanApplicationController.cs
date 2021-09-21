using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoanApplicationController : ApiController
    {
        private DBContextEntities db = new DBContextEntities();

       
        // POST:7 api/LoanApplication
        [ResponseType(typeof(tblLoan))]
        public IHttpActionResult PosttblLoan(tblLoan tblLoan)
        {
            LoanApplication oNewLoan = new LoanApplication();
            oNewLoan.isSuccess = false;
            oNewLoan.errorDescription = "";

            try
            {


                if (tblLoan.LoanId == 0)
                {
                    if (tblLoan.Status == 0)
                    {
                        tblLoan.Status = db.proc_getDefaultLoanStatus().FirstOrDefault();
                    }
                    tblLoan.Code = db.proc_GenerateLoanCode().FirstOrDefault();
                    //insert

                    db.tblLoans.Add(tblLoan);
                }
                else
                {
                    if (tblLoan.Status == 0)
                    {
                        tblLoan.Status = db.proc_getDefaultLoanStatus().FirstOrDefault();
                    }
                    //update
                    db.Entry(tblLoan).State = EntityState.Modified;
                }
                //add charges
                foreach (var items in tblLoan.LoanApplicationCharges)
                {
                    //insert
                    if (items.LoanApplicationChargesId == 0)
                    {
                        if (items.ModifiedBy == null)
                        {
                            items.ModifiedBy = "Admin";
                        }
                        if (items.CreatedBy == null)
                        {
                            items.CreatedBy = "Admin";
                        }
                        if (items.CreatedOn==null) {
                            items.CreatedOn = DateTime.Now;
                        }
                        if (items.ModifiedOn == null)
                        {
                            items.ModifiedOn = DateTime.Now;
                        }
                        if (items.IsPercentage == null)
                        {
                            items.IsPercentage = false;
                        }
                        if (items.IsTariffBased == null)
                        {
                            items.IsTariffBased = false;
                        }


                        if (items.IsPercentage == true)
                        {
                            items.Amount = (tblLoan.LoanAmount * items.Value) / 100;
                        }
                        if (items.IsPercentage == false && items.IsTariffBased == false)
                        {
                            items.Amount = items.Value;
                        }
                        if (items.IsTariffBased == true && items.IsPercentage == false)
                        {
                            var dbResult = db.pro_GetLoanTypeChargesUsingTariff(tblLoan.LoanAmount, items.LoanChargesListId).FirstOrDefault();
                            if (dbResult == null)
                            {
                                oNewLoan.errorDescription = "Tariff For this loan charge does not exist **";
                                return Ok(dbResult);

                            }
                            items.Amount = dbResult.Value;

                        }

                        db.LoanApplicationCharges.Add(items);
                    }


                    else
                    {
                           
                        
                        if (items.IsPercentage == true)
                        {
                            items.Amount = (tblLoan.LoanAmount * items.Value) / 100;
                        }
                        if (items.IsPercentage == false && items.IsTariffBased == false)
                        {
                            items.Amount = items.Value;
                        }
                        if (items.IsTariffBased == true && items.IsPercentage == false)
                        {
                            var dbResult = db.pro_GetLoanTypeChargesUsingTariff(tblLoan.LoanAmount, items.LoanChargesListId).FirstOrDefault();
                            if (dbResult == null)
                            {
                                oNewLoan.errorDescription = "Tariff For this loan charge does not exist **";
                                return Ok(dbResult);

                            }
                            items.Amount = dbResult.Value;

                        }
                        db.Entry(items).State = EntityState.Modified;

                    }
                }
                db.SaveChanges();
                oNewLoan.isSuccess = true;
                oNewLoan.errorDescription = "";


                return Ok(oNewLoan);

            }
            catch (Exception ex)
            {
                oNewLoan.errorDescription = ex.Message;                return Ok(oNewLoan);

            }
        }

        // DELETE: api/LoanApplication/5
        [ResponseType(typeof(tblLoan))]
        public IHttpActionResult DeletetblLoan(int id)
        {
            tblLoan loans = db.tblLoans.Include(y => y.LoanApplicationCharges).SingleOrDefault(x => x.LoanId == id);
            foreach (var items in loans.LoanApplicationCharges.ToList())
            {
                db.LoanApplicationCharges.Remove(items);

            }
            db.tblLoans.Remove(loans);
            db.SaveChanges();
            return Ok(loans);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblLoanExists(int id)
        {
            return db.tblLoans.Count(e => e.LoanId == id) > 0;
        }
    }
}