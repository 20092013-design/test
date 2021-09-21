using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
        public class Collateral
        {
            public int? CollateralId { get; set; }
            public string CollateralName { get; set; }
            public string errorDescription { get; set; }
            public bool? HasTimeLimit { get; set; }
            public bool? isSuccess { get; set; }
            public bool? Delete { get; set; }
        }
    
}