using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public DateTime? DOB { get; set; }
        public DateTime? DateRegistration { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }


    }
}