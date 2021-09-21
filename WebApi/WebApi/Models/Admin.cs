using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Prefixe
    {
        public int? AutoPrefixId { get; set; }
        public string PrefixName { get; set; }
        public string PrefixText { get; set; }
        public bool? IsSystemAssisted { get; set; }
        public bool? IsDateRelated { get; set; }
        public bool? Today { get; set; }
        public bool? Month { get; set; }
        public bool? Year { get; set; }
        public bool? BranchPrefix { get; set; }
        public string UseBranchPrefix { get; set; }
        public string UseGroupPrefix { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }


    }
    public class Numbering
    {
        public int? AutoGenNumberId { get; set; }
        public string AutoGenNumberText { get; set; }
        public int? AutoPrefixId { get; set; }
        public int? Start { get; set; }
        public bool? UsePrefix { get; set; }
        public int? Stop { get; set; }
        public int? StartFrom { get; set; }
        public bool? AllowManual { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }


    }
    public class Setup
    {
        public int? SetupId { get; set; }
        public string SetName { get; set; }
        public int? AutoGenNumberId { get; set; }
        public bool? IsManual { get; set; }
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }
        public bool? Delete { get; set; }

    }
    public class IntializeSetupName
    {
        public string errorDescription { get; set; }
        public bool? isSuccess { get; set; }

    }
}