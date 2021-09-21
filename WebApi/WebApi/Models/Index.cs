using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Contact
    {
        public int? ContactId { get; set; }
        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool? isSuccess { get; set; }
        public string errorDescription { get; set; }
    }
}