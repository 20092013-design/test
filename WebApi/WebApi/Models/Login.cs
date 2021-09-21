using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Login
    {

        public int? LoginId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }       
        public DateTime? RegistrationDate { get; set; }
        public int? OperationId { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
    }
}