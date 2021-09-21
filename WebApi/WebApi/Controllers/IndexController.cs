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
    public class IndexController : ApiController
    {
        [Route("Index/AddContants"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddContants(string FullName, string PhoneNo, string Email,
      string Subject, string Message)
        {
            Contact oNewContact = new Contact();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddhomeContants(0, FullName, PhoneNo, Email, Subject, Message).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewContact.errorDescription = "We have network error to Connect to database.please check and try again";
                        return Ok(oNewContact);
                    }
                    oNewContact.ContactId = dbResult.ContactId;
                    oNewContact.FullName = dbResult.FullName;
                    oNewContact.PhoneNo = dbResult.PhoneNo;
                    oNewContact.Email = dbResult.Email;
                    oNewContact.Subject = dbResult.Subject;
                    oNewContact.Message = dbResult.Message;
                    oNewContact.isSuccess = true;
                    return Ok(oNewContact);

                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }
        }

        [Route("Index/GetUnReadMessages")]
        public IHttpActionResult GetUnReadMessages()
        {
            Contact oNewContact = new Contact();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getUnReadMessages().ToList();
                    List<Contact> listOfContants = new List<Contact>();
                    foreach (var items in dbResult)
                    {
                        Contact oContact = new Contact();
                        oContact.ContactId = items.ContactId;
                        oContact.FullName = items.FullName;
                        oContact.PhoneNo = items.PhoneNo;
                        oContact.Email = items.Email;
                        oContact.Subject = items.Subject;
                        oContact.Message = items.Message;
                        oContact.CreatedOn = items.CreateOn;
                        oContact.isSuccess = true;
                        oContact.errorDescription = "";
                        listOfContants.Add(oContact);

                    }
                    IEnumerable<Contact> myContact = listOfContants;
                    return Ok(myContact);
                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }

        }
        [Route("Index/GetReadMessages")]
        public IHttpActionResult GetReadMessages()
        {
            Contact oNewContact = new Contact();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getReadMessages().ToList();
                    List<Contact> listOfContants = new List<Contact>();
                    foreach (var items in dbResult)
                    {
                        Contact oContact = new Contact();
                        oContact.ContactId = items.ContactId;
                        oContact.FullName = items.FullName;
                        oContact.PhoneNo = items.PhoneNo;
                        oContact.Email = items.Email;
                        oContact.Subject = items.Subject;
                        oContact.Message = items.Message;
                        oContact.CreatedOn = items.CreateOn;
                        oContact.isSuccess = true;
                        oContact.errorDescription = "";
                        listOfContants.Add(oContact);

                    }
                    IEnumerable<Contact> myContact = listOfContants;
                    return Ok(myContact);
                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }

        }

        [Route("Index/GetAllMessageLimit")]
        public IHttpActionResult GetAllMessageLimit()
        {
            Contact oNewContact = new Contact();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllMessagesWithLimit().ToList();
                    List<Contact> listOfContants = new List<Contact>();
                    foreach (var items in dbResult)
                    {
                        Contact oContact = new Contact();
                        oContact.ContactId = items.ContactId;
                        oContact.FullName = items.FullName;
                        oContact.PhoneNo = items.PhoneNo;
                        oContact.Email = items.Email;
                        oContact.Subject = items.Subject;
                        oContact.Message = items.Message;
                        oContact.CreatedOn = items.CreateOn;
                        oContact.isSuccess = true;
                        oContact.errorDescription = "";
                        listOfContants.Add(oContact);

                    }
                    IEnumerable<Contact> myContact = listOfContants;
                    return Ok(myContact);
                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }

        }
        [Route("Index/UpdateMessages")]
        public IHttpActionResult UpdateMessages(int? CondactId)
        {
            Contact oNewContact = new Contact();
            oNewContact.isSuccess = false;
            oNewContact.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_UpdateMessage(CondactId);
                    return Ok(oNewContact);
                }

            }
            catch (Exception ex)
            {
                oNewContact.errorDescription = ex.Message;
                return Ok(oNewContact);

            }

        }
    }
}
