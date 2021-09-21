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
    public class RegisterController : ApiController
    {
        private DBContextEntities db = new DBContextEntities();

        // GET: api/Register
        public IQueryable<tblLogin> GettblLogins()
        {
            return db.tblLogins;
        }

        // GET: api/Register/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult GettblLogin(int id)
        {
            tblLogin tblLogin = db.tblLogins.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            return Ok(tblLogin);
        }

        // PUT: api/Register/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblLogin(int id, tblLogin tblLogin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblLogin.LoginId)
            {
                return BadRequest();
            }

            db.Entry(tblLogin).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblLoginExists(id))
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

        // POST: api/Register
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult PosttblLogin(tblLogin tblLogin)
        {
            Login oNewLogin = new Login();
            oNewLogin.isSuccess = false;
            oNewLogin.errorDescription = "";
            try
            {
                var usr = db.tblLogins.Where(a => a.UserName == tblLogin.UserName).FirstOrDefault();
                if (usr!=null)
                {
                    oNewLogin.isSuccess = true;
                    oNewLogin.errorDescription = "Login Successfully";                    
                }
                string pwd = tblLogin.Password;
                if (usr.Password == pwd)
                {
                    oNewLogin.isSuccess = true;
                    oNewLogin.errorDescription = "Invalid Password. Please try Again!";
                }
                else
                {

                    oNewLogin.errorDescription = "Invalid UserName. Please try Again!";
                }

            }         

        
            catch (Exception ex)
            {
                oNewLogin.errorDescription = ex.Message;
               
            }
            return Ok(oNewLogin);
            // return CreatedAtRoute("DefaultApi", new { id = tblLogin.LoginId }, tblLogin);
        }

        // DELETE: api/Register/5
        [ResponseType(typeof(tblLogin))]
        public IHttpActionResult DeletetblLogin(int id)
        {
            tblLogin tblLogin = db.tblLogins.Find(id);
            if (tblLogin == null)
            {
                return NotFound();
            }

            db.tblLogins.Remove(tblLogin);
            db.SaveChanges();

            return Ok(tblLogin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblLoginExists(int id)
        {
            return db.tblLogins.Count(e => e.LoginId == id) > 0;
        }
    }
}