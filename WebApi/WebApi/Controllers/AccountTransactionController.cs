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
    public class AccountTransactionController : ApiController
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: api/AccountTransaction
        public IQueryable<tblAccountTransaction> GettblAccountTransactions()
        {
            return db.tblAccountTransactions;
        }

        // GET: api/AccountTransaction/5
        [ResponseType(typeof(tblAccountTransaction))]
        public IHttpActionResult GettblAccountTransaction(int id)
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
                                          a.CreatedOn,
                                          a.CreatedBy,
                                          a.ModifiedBy,
                                          a.CurrencySymbol,
                                          a.IsBlocked,
                                          a.AccountNumber,
                                          DeleteTransactionsIds = "",
                                      }).FirstOrDefault();
            var accountCharge = (from a in db.tblTransactionCharges
                                 join b in db.tblCharges on a.ChargesId equals b.ChargesId
                                 where a.AccountTransactionId == id
                                 select new
                                 {
                                     a.AccountTransactionId,
                                     a.TransactionChargesId,
                                     a.IsPercent,
                                     a.ChargesId,
                                     ChargesName = b.Description,
                                     a.Amount,
                                     a.Total,
                                 }).ToList();
            return Ok(new { AccountTransaction, accountCharge });
        }

        // PUT: api/AccountTransaction/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblAccountTransaction(int id, tblAccountTransaction tblAccountTransaction)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblAccountTransaction.AccountTransactionId)
            {
                return BadRequest();
            }

            db.Entry(tblAccountTransaction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblAccountTransactionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AccountTransaction
        [ResponseType(typeof(tblAccountTransaction))]
        public IHttpActionResult PosttblAccountTransaction(tblAccountTransaction tblAccountTransaction)
        {
            try

            {
                //add Transaction
                if (tblAccountTransaction.AccountTransactionId == 0)
                    //insert
                    //db.AddEditTransactions(tblAccountTransaction.TransactionDate,tblAccountTransaction.ValueDate)
                    db.tblAccountTransactions.Add(tblAccountTransaction);
                else
                    //update
                    db.Entry(tblAccountTransaction).State = EntityState.Modified;
                //add charges
                foreach (var items in tblAccountTransaction.tblTransactionCharges)
                {
                    //insert
                    if (items.TransactionChargesId == 0)
                        db.tblTransactionCharges.Add(items);
                    else
                        db.Entry(items).State = EntityState.Modified;


                }
                //Delete charge
                //foreach (var id in tblAccountTransaction.DeleteTransactionsIds.Split(',').Where(x => x != (""))
                //{
                //    tblTransactionCharge x = db.tblTransactionCharges.Find(Convert.ToInt64(id));
                //    db.tblTransactionCharges.Remove(x);

                // }
                foreach (var id in tblAccountTransaction.DeleteTransactionsIds.Split(',').Where(x => x != ""))
                {
                    tblTransactionCharge x = db.tblTransactionCharges.Find(Convert.ToInt64(id));
                    db.tblTransactionCharges.Remove(x);
                }


                db.SaveChanges();

                return Ok();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // DELETE: api/AccountTransaction/5
        [ResponseType(typeof(tblAccountTransaction))]
        public IHttpActionResult DeletetblAccountTransaction(int id)
        {
            tblAccountTransaction trans = db.tblAccountTransactions.Include(y => y.tblTransactionCharges).
               SingleOrDefault(x => x.AccountTransactionId == id);
            foreach (var items in trans.tblTransactionCharges.ToList())
            {
                db.tblTransactionCharges.Remove(items);

            }
            db.tblAccountTransactions.Remove(trans);
            db.SaveChanges();
            return Ok(trans);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblAccountTransactionExists(int id)
        {
            return db.tblAccountTransactions.Count(e => e.AccountTransactionId == id) > 0;
        }
    }
}