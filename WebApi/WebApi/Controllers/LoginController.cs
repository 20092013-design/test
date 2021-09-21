using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.Models;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {
        [Route("Login/LoginUser"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> LoginUser(string UserName, string Password)
        {
            Login oNewLogin = new Login();
            oNewLogin.isSuccess = false;
            oNewLogin.errorDescription = "";
            oNewLogin.OperationId = 0;

            Login orep = new Login();
            orep.isSuccess = false;
            orep.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    var usr = db.tblLogins.Where(a => a.UserName == UserName).FirstOrDefault();
                    if (usr != null)
                    {


                        oNewLogin.OperationId = usr.LoginId;
                        oNewLogin.isSuccess = true;
                        oNewLogin.errorDescription = "Login Successfully";

                        string pwd = Password;
                        if (usr.Password == pwd)
                        {
                            orep.isSuccess = true;
                            orep.errorDescription = "";
                        }
                        else
                        {

                            orep.errorDescription = "Invalid Password. Please try Again!";
                        }

                    }

                    else
                    {
                        orep.errorDescription = ("Invalid UserName. Please try again!");



                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return Ok(oNewLogin);
        }
        

    }
}
