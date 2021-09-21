using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class StructureController : ApiController
    {
        public static bool EmailIsValid(string email)
        {
            string expression = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expression))
            {
                if (Regex.Replace(email, expression, string.Empty).Length == 0)
                {
                    return true;
                }
            }
            return false;
        }
        [Route("Api/AddStructure"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddStructure(string Caption, string Description, int? ParentId, string Remarks, bool? Delete)

        {
            Structure structure = new Structure();
            structure.isSuccess = false;
            structure.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Caption == null)
                    {
                        Caption = "";
                    }
                    if (Description == null)
                    {
                        Description = "";
                    }
                    if (ParentId == null)
                    {
                        ParentId = 0;
                    }
                    if (Remarks == null)
                    {
                        Remarks = "";
                    }

                    var DbResult = db.proc_AddEditStructure(0, Caption, Description, ParentId, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        structure.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    structure.Caption = DbResult.Caption;
                    structure.Description = DbResult.Description;
                    structure.ParentId = DbResult.ParentId;
                    structure.Remarks = DbResult.Remarks;



                    structure.isSuccess = true;
                    return Ok(structure);
                }

            }
            catch (Exception ex)
            {
                structure.errorDescription = ex.Message;
                return Ok(structure);

            }
        }
        [Route("Api/UpdateStructure"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateStructure(int? StructureId, string Caption, string Description, int? ParentId, string Remarks, bool? Delete)

        {
            Structure structure = new Structure();
            structure.isSuccess = false;
            structure.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (Caption == null)
                    {
                        Caption = "";
                    }
                    if (Description == null)
                    {
                        Description = "";
                    }
                    if (ParentId == null)
                    {
                        ParentId = 0;
                    }
                    if (Remarks == null)
                    {
                        Remarks = "";
                    }

                    var DbResult = db.proc_AddEditStructure(StructureId, Caption, Description, ParentId, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        structure.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    structure.StructureId = DbResult.StructureId;
                    structure.Caption = DbResult.Caption;
                    structure.Description = DbResult.Description;
                    structure.ParentId = DbResult.ParentId;
                    structure.Remarks = DbResult.Remarks;

                    structure.isSuccess = true;
                    return Ok(structure);
                }

            }
            catch (Exception ex)
            {
                structure.errorDescription = ex.Message;
                return Ok(structure);

            }
        }

        [Route("Api/GetAllStructure")]
        public IHttpActionResult GetAllStructure()
        {

            Structure structure = new Structure();
            structure.isSuccess = false;
            structure.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllStructures().ToList();
                    List<Structure> listofstructure = new List<Structure>();
                    foreach (var items in dbResult)
                    {
                        Structure newStructure = new Structure();

                        newStructure.StructureId = items.StructureId;
                        newStructure.Caption = items.Caption;
                        newStructure.Description = items.Description;
                        newStructure.ParentId = items.ParentId;
                        newStructure.Remarks = items.Remarks;
                        newStructure.errorDescription = "";
                        newStructure.isSuccess = true;
                        listofstructure.Add(newStructure);
                    }
                    IEnumerable<Structure> myRelations = listofstructure;
                    return Ok(myRelations);

                }
            }
            catch (Exception ex)
            {
                structure.errorDescription = ex.Message;
                return Ok(structure);

            }

        }



        [Route("Api/GetStructure")]
        public async Task<IHttpActionResult> GetStructure(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var structure = (from a in db.tblStructures
                                 where a.StructureId == id
                                 select new
                                 {
                                     a.StructureId,
                                     a.Caption,
                                     a.Description,
                                     a.ParentId,
                                     a.Remarks,

                                 }).FirstOrDefault();
                return Ok(new { structure });


            }

        }

        [Route("Api/DeleteStructure"), HttpGet]
        public IHttpActionResult DeleteStructure(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblStructure structure = db.tblStructures.SingleOrDefault(x => x.StructureId == id);
                db.tblStructures.Remove(structure);
                db.SaveChanges();
                return Ok(structure);
            }
        }
        [Route("Api/AddStructureValue"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddStructureValue(int? StructureId, string Name, int? ParentId, bool? IsGroup, string Remarks, bool? Delete)

        {
            StructureValue structureValue = new StructureValue();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (StructureId == null)
                    {
                        StructureId = 0;
                    }
                    if (Name == null)
                    {
                        Name = "";
                    }
                    if (ParentId == null)
                    {
                        ParentId = 0;
                    }
                    if (Remarks == null)
                    {
                        Remarks = "";
                    }

                    var DbResult = db.proc_AddEditStructureValues(0, StructureId, Name, ParentId, IsGroup, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        structureValue.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    structureValue.StructureId = DbResult.StructureId;
                    structureValue.Name = DbResult.Name;
                    structureValue.ParentId = DbResult.ParentId;
                    structureValue.IsGroup = DbResult.IsGroup;
                    structureValue.Remarks = DbResult.Remarks;



                    structureValue.isSuccess = true;
                    return Ok(structureValue);
                }

            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }
        }


        [Route("Api/UpdateStructureValues"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateStructureValues(int? StructureValueId, int? StructureId, string Name, int? ParentId, bool? IsGroup, string Remarks, bool? Delete)

        {
            StructureValue structureValue = new StructureValue();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (StructureId == null)
                    {
                        StructureId = 0;
                    }
                    if (Name == null)
                    {
                        Name = "";
                    }
                    if (ParentId == null)
                    {
                        ParentId = 0;
                    }
                    if (Remarks == null)
                    {
                        Remarks = "";
                    }

                    var DbResult = db.proc_AddEditStructureValues(StructureValueId, StructureId, Name, ParentId, IsGroup, Remarks, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        structureValue.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    structureValue.StructureValueId = DbResult.StructureValueId;
                    structureValue.StructureId = DbResult.StructureId;
                    structureValue.Name = DbResult.Name;
                    structureValue.ParentId = DbResult.ParentId;
                    structureValue.IsGroup = DbResult.IsGroup;
                    structureValue.Remarks = DbResult.Remarks;



                    structureValue.isSuccess = true;
                    return Ok(structureValue);
                }

            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }
        }

        [Route("Api/GetAllStructureValues")]
        public IHttpActionResult GetAllStructureValues()
        {

            StructureValue structureValue = new StructureValue();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllStructureValues().ToList();
                    List<StructureValue> listofStructureValues = new List<StructureValue>();
                    foreach (var items in dbResult)
                    {
                        StructureValue newStructureValue = new StructureValue();

                        newStructureValue.StructureValueId = items.StructureValueId;
                        newStructureValue.StructureId = items.StructureId;
                        newStructureValue.Name = items.Name;
                        newStructureValue.ParentId = items.ParentId;
                        newStructureValue.IsGroup = items.IsGroup;
                        newStructureValue.Remarks = items.Remarks;
                        newStructureValue.errorDescription = "";
                        newStructureValue.isSuccess = true;
                        listofStructureValues.Add(newStructureValue);
                    }
                    IEnumerable<StructureValue> myStructureValues = listofStructureValues;
                    return Ok(myStructureValues);

                }
            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }

        }



        [Route("Api/GetStructureValue")]
        public async Task<IHttpActionResult> GetStructureValue(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var structureValue = (from a in db.tblStructureValues
                                      where a.StructureValueId == id
                                      select new
                                      {
                                          a.StructureValueId,
                                          a.StructureId,
                                          a.Name,
                                          a.ParentId,
                                          a.IsGroup,
                                          a.Remarks,

                                      }).FirstOrDefault();
                return Ok(new { structureValue });


            }

        }

        [Route("Api/DeleteStructureValue"), HttpGet]
        public IHttpActionResult DeleteStructureValue(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblStructureValue structureValue = db.tblStructureValues.SingleOrDefault(x => x.StructureValueId == id);
                db.tblStructureValues.Remove(structureValue);
                db.SaveChanges();
                return Ok(structureValue);
            }
        }
        [Route("Api/AddStructureGroupDetail"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddStructureGroupDetail(int? StructureValueId, string Code, string FullName,
        string Telephone1, string Telephone2, string PhoneNumber, string FaxNumber, string Email, string Address, string Retirement,
        string PostalAddress, int? NoofWeek, string EveryDayofWeek, int? DateOfMonth, int? MaximumMembership,
        decimal? ServiceCharge, int? CreditOfficerID, bool? LimitSavings, decimal? GroupLoanLimit, decimal? IndividualLoanLimit, string GroupPrefix,
        bool? Blocked, DateTime? DateBlocked, string Remarks, string Location, bool? Delete)

        {
            StructureGroupDetails groupDetails = new StructureGroupDetails();
            groupDetails.isSuccess = false;
            groupDetails.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (StructureValueId == null) { StructureValueId = 0; }
                    if (Code == null) { Code = ""; }
                    if (FullName == null) { FullName = ""; }
                    if (Telephone1 == null) { Telephone1 = ""; }
                    if (Telephone2 == null) { Telephone2 = ""; }
                    if (PhoneNumber == null) { PhoneNumber = ""; }
                    if (FaxNumber == null) { FaxNumber = ""; }
                    if (Email == null) { Email = ""; }
                    else
                    {
                        if (Email != null)
                        {
                            if (!EmailIsValid(Email))
                            {
                                groupDetails.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                                return Ok(groupDetails);
                            }
                        }
                    }
                    if (Address == null) { Address = ""; }
                    if (Retirement == null) { Retirement = ""; }
                    if (PostalAddress == null) { PostalAddress = ""; }
                    if (NoofWeek == null) { NoofWeek = 0; }
                    if (EveryDayofWeek == null) { EveryDayofWeek = ""; }
                    if (DateOfMonth == null) { DateOfMonth = 0; }
                    if (MaximumMembership == null) { MaximumMembership = 0; }
                    if (ServiceCharge == null) { ServiceCharge = 0; }
                    if (CreditOfficerID == null) { CreditOfficerID = 0; }
                    if (GroupLoanLimit == null) { GroupLoanLimit = 0; }
                    if (IndividualLoanLimit == null) { IndividualLoanLimit = 0; }
                    if (GroupPrefix == null) { GroupPrefix = ""; }
                    if (DateBlocked == null) { DateBlocked = DateTime.Parse("1900-01-01"); }
                    if (Remarks == null) { Remarks = ""; }
                    if (Location == null) { Location = ""; }


                    var DbResult = db.proc_AddEditStructureGroupDetails(0, StructureValueId, Code, FullName, Telephone1, Telephone2, PhoneNumber, FaxNumber,
                    Email, Address, Retirement, PostalAddress, NoofWeek, EveryDayofWeek, DateOfMonth,
                    MaximumMembership, ServiceCharge, CreditOfficerID, LimitSavings, GroupLoanLimit, IndividualLoanLimit, GroupPrefix,
                    Blocked, DateBlocked, Remarks, Location, Delete = false).FirstOrDefault();

                    if (DbResult == null)
                    {
                        groupDetails.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    groupDetails.StructureValueId = DbResult.StructureValueId;
                    groupDetails.Code = DbResult.Code;
                    groupDetails.FullName = DbResult.FullName;
                    groupDetails.Telephone1 = DbResult.Telephone1;
                    groupDetails.Telephone2 = DbResult.Telephone2;
                    groupDetails.PhoneNumber = DbResult.PhoneNumber;
                    groupDetails.FaxNumber = DbResult.FaxNumber;
                    groupDetails.Email = DbResult.Email;
                    groupDetails.Address = DbResult.Address;
                    groupDetails.Retirement = DbResult.Retirement;
                    groupDetails.PostalAddress = DbResult.PostalAddress;
                    groupDetails.NoofWeek = DbResult.NoofWeek;
                    groupDetails.EveryDayofWeek = DbResult.EveryDayofWeek;
                    groupDetails.DateOfMonth = DbResult.DateOfMonth;
                    groupDetails.MaximumMembership = DbResult.MaximumMembership;
                    groupDetails.ServiceCharge = DbResult.ServiceCharge;
                    groupDetails.CreditOfficerID = DbResult.CreditOfficerID;
                    groupDetails.LimitSavings = DbResult.LimitSavings;
                    groupDetails.GroupLoanLimit = DbResult.GroupLoanLimit;
                    groupDetails.IndividualLoanLimit = DbResult.IndividualLoanLimit;
                    groupDetails.GroupPrefix = DbResult.GroupPrefix;
                    groupDetails.Blocked = DbResult.Blocked;
                    groupDetails.DateBlocked = DbResult.DateBlocked;
                    groupDetails.Remarks = DbResult.Remarks;
                    groupDetails.Location = DbResult.Location;

                    groupDetails.isSuccess = true;
                    return Ok(groupDetails);
                }

            }
            catch (Exception ex)
            {
                groupDetails.errorDescription = ex.Message;
                return Ok(groupDetails);

            }
        }

        [Route("Api/UpdateStructureGroupDetail"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateStructureGroupDetail(int? StructureGroupId, int? StructureValueId, string Code, string FullName,
        string Telephone1, string Telephone2, string PhoneNumber, string FaxNumber, string Email, string Address, string Retirement,
        string PostalAddress, int? NoofWeek, string EveryDayofWeek, int? DateOfMonth, int? MaximumMembership,
        decimal? ServiceCharge, int? CreditOfficerID, bool? LimitSavings, decimal? GroupLoanLimit, decimal? IndividualLoanLimit, string GroupPrefix,
        bool? Blocked, DateTime? DateBlocked, string Remarks, string Location, bool? Delete)

        {
            StructureGroupDetails groupDetails = new StructureGroupDetails();
            groupDetails.isSuccess = false;
            groupDetails.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (StructureGroupId == null) { StructureGroupId = 0; }
                    if (StructureValueId == null) { StructureValueId = 0; }
                    if (Code == null) { Code = ""; }
                    if (FullName == null) { FullName = ""; }
                    if (Telephone1 == null) { Telephone1 = ""; }
                    if (Telephone2 == null) { Telephone2 = ""; }
                    if (PhoneNumber == null) { PhoneNumber = ""; }
                    if (FaxNumber == null) { FaxNumber = ""; }
                    if (Email == null) { Email = ""; }
                    else
                    {
                        if (Email != null)
                        {
                            if (!EmailIsValid(Email))
                            {
                                groupDetails.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                                return Ok(groupDetails);
                            }
                        }
                    }
                    if (Address == null) { Address = ""; }
                    if (Retirement == null) { Retirement = ""; }
                    if (PostalAddress == null) { PostalAddress = ""; }
                    if (NoofWeek == null) { NoofWeek = 0; }
                    if (EveryDayofWeek == null) { EveryDayofWeek = ""; }
                    if (DateOfMonth == null) { DateOfMonth = 0; }
                    if (MaximumMembership == null) { MaximumMembership = 0; }
                    if (ServiceCharge == null) { ServiceCharge = 0; }
                    if (CreditOfficerID == null) { CreditOfficerID = 0; }
                    if (GroupLoanLimit == null) { GroupLoanLimit = 0; }
                    if (IndividualLoanLimit == null) { IndividualLoanLimit = 0; }
                    if (GroupPrefix == null) { GroupPrefix = ""; }
                    if (DateBlocked == null) { DateBlocked = DateTime.Parse("2000-01-01"); }
                    if (Remarks == null) { Remarks = ""; }
                    if (Location == null) { Location = ""; }
                    if (Email != null)
                    {
                        if (!EmailIsValid(Email))
                        {
                            groupDetails.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                            return Ok(groupDetails);
                        }
                    }

                    var DbResult = db.proc_AddEditStructureGroupDetails(StructureGroupId, StructureValueId, Code, FullName, Telephone1, Telephone2, PhoneNumber, FaxNumber,
                    Email, Address, Retirement, PostalAddress, NoofWeek, EveryDayofWeek, DateOfMonth,
                    MaximumMembership, ServiceCharge, CreditOfficerID, LimitSavings, GroupLoanLimit, IndividualLoanLimit, GroupPrefix,
                    Blocked, DateBlocked, Remarks, Location, Delete = false).FirstOrDefault();

                    if (DbResult == null)
                    {
                        groupDetails.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    groupDetails.StructureGroupId = DbResult.StructureGroupId;
                    groupDetails.StructureValueId = DbResult.StructureValueId;
                    groupDetails.Code = DbResult.Code;
                    groupDetails.FullName = DbResult.FullName;
                    groupDetails.Telephone1 = DbResult.Telephone1;
                    groupDetails.Telephone2 = DbResult.Telephone2;
                    groupDetails.PhoneNumber = DbResult.PhoneNumber;
                    groupDetails.FaxNumber = DbResult.FaxNumber;
                    groupDetails.Email = DbResult.Email;
                    groupDetails.Address = DbResult.Address;
                    groupDetails.Retirement = DbResult.Retirement;
                    groupDetails.PostalAddress = DbResult.PostalAddress;
                    groupDetails.NoofWeek = DbResult.NoofWeek;
                    groupDetails.EveryDayofWeek = DbResult.EveryDayofWeek;
                    groupDetails.DateOfMonth = DbResult.DateOfMonth;
                    groupDetails.MaximumMembership = DbResult.MaximumMembership;
                    groupDetails.ServiceCharge = DbResult.ServiceCharge;
                    groupDetails.CreditOfficerID = DbResult.CreditOfficerID;
                    groupDetails.LimitSavings = DbResult.LimitSavings;
                    groupDetails.GroupLoanLimit = DbResult.GroupLoanLimit;
                    groupDetails.IndividualLoanLimit = DbResult.IndividualLoanLimit;
                    groupDetails.GroupPrefix = DbResult.GroupPrefix;
                    groupDetails.Blocked = DbResult.Blocked;
                    groupDetails.DateBlocked = DbResult.DateBlocked;
                    groupDetails.Remarks = DbResult.Remarks;
                    groupDetails.Location = DbResult.Location;

                    groupDetails.isSuccess = true;
                    return Ok(groupDetails);
                }

            }
            catch (Exception ex)
            {
                groupDetails.errorDescription = ex.Message;
                return Ok(groupDetails);

            }
        }


        [Route("Api/GetAllStructureGroupDetails")]
        public IHttpActionResult GetAllStructureGroupDetails()
        {

            StructureGroupDetails groupDetail = new StructureGroupDetails();
            groupDetail.isSuccess = false;
            groupDetail.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllStructureGroupDetails().ToList();
                    List<StructureGroupDetails> listofStructureDetails = new List<StructureGroupDetails>();
                    foreach (var items in dbResult)
                    {
                        StructureGroupDetails groupDetails = new StructureGroupDetails();

                        groupDetails.StructureGroupId = items.StructureGroupId;
                        groupDetails.StructureValueId = items.StructureValueId;
                        groupDetails.Code = items.Code;
                        groupDetails.FullName = items.FullName;
                        groupDetails.Telephone1 = items.Telephone1;
                        groupDetails.Telephone2 = items.Telephone2;
                        groupDetails.PhoneNumber = items.PhoneNumber;
                        groupDetails.FaxNumber = items.FaxNumber;
                        groupDetails.Email = items.Email;
                        groupDetails.Address = items.Address;
                        groupDetails.Retirement = items.Retirement;
                        groupDetails.PostalAddress = items.PostalAddress;
                        groupDetails.NoofWeek = items.NoofWeek;
                        groupDetails.EveryDayofWeek = items.EveryDayofWeek;
                        groupDetails.DateOfMonth = items.DateOfMonth;
                        groupDetails.MaximumMembership = items.MaximumMembership;
                        groupDetails.ServiceCharge = items.ServiceCharge;
                        groupDetails.CreditOfficerID = items.CreditOfficerID;
                        groupDetails.LimitSavings = items.LimitSavings;
                        groupDetails.GroupLoanLimit = items.GroupLoanLimit;
                        groupDetails.IndividualLoanLimit = items.IndividualLoanLimit;
                        groupDetails.GroupPrefix = items.GroupPrefix;
                        groupDetails.Blocked = items.Blocked;
                        groupDetails.DateBlocked = items.DateBlocked;
                        groupDetails.Remarks = items.Remarks;
                        groupDetails.Location = items.Location;

                        listofStructureDetails.Add(groupDetails);
                    }
                    IEnumerable<StructureGroupDetails> myStructureDetails = listofStructureDetails;
                    return Ok(myStructureDetails);

                }
            }
            catch (Exception ex)
            {
                groupDetail.errorDescription = ex.Message;
                return Ok(groupDetail);

            }

        }



        [Route("Api/GetStructureGroupDetail")]
        public async Task<IHttpActionResult> GetStructureGroupDetail(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var structureDetail = (from a in db.tblStructureGroupDetails
                                       where a.StructureGroupId == id
                                       select new
                                       {
                                           a.StructureGroupId,
                                           a.StructureValueId,
                                           a.Code,
                                           a.FullName,
                                           a.Telephone1,
                                           a.Telephone2,
                                           a.PhoneNumber,
                                           a.FaxNumber,
                                           a.Email,
                                           a.Address,
                                           a.Retirement,
                                           a.PostalAddress,
                                           a.NoofWeek,
                                           a.EveryDayofWeek,
                                           a.DateOfMonth,
                                           a.MaximumMembership,
                                           a.ServiceCharge,
                                           a.CreditOfficerID,
                                           a.LimitSavings,
                                           a.GroupLoanLimit,
                                           a.IndividualLoanLimit,
                                           a.GroupPrefix,
                                           a.Blocked,
                                           a.DateBlocked,
                                           a.Remarks,
                                           a.Location,


                                       }).FirstOrDefault();
                return Ok(new { structureDetail });


            }

        }

        [Route("Api/DeleteStructureGroupDetail"), HttpGet]
        public IHttpActionResult DeleteStructureGroupDetail(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblStructureGroupDetail structureGroupDetails = db.tblStructureGroupDetails.SingleOrDefault(x => x.StructureGroupId == id);
                db.tblStructureGroupDetails.Remove(structureGroupDetails);
                db.SaveChanges();
                return Ok(structureGroupDetails);
            }
        }
        public async Task<IHttpActionResult> GetCreditOfficerByIdNo(string IdNo)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                tblCreditOfficer CreditOfficer = db.tblCreditOfficers.FirstOrDefault(x => x.IdNo == IdNo);
                return Ok(CreditOfficer);

            }
        }
        [Route("Api/AddCreditOfficer"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddCreditOfficer(string Code, string FullName, DateTime? DateJoined, string IdNo, string PhoneNumber,
         string Email, string Address, string Remarks, bool? Delete)

        {
            CreditOfficer creditOfficer = new CreditOfficer();
            creditOfficer.isSuccess = false;
            creditOfficer.errorDescription = "";
            if (Code == null) { Code = ""; }
            if (FullName == null) { FullName = ""; }
            if (DateJoined == null)
            {
                DateJoined = DateTime.Parse("1900-01-01");
            }
            if (IdNo == null) { IdNo = ""; }
            if (PhoneNumber == null) { PhoneNumber = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        creditOfficer.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(creditOfficer);
                    }
                }
            }
            if (Address == null) { Address = ""; }
            if (Remarks == null) { Remarks = ""; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {

                    if (db.tblCreditOfficers.Any(p => p.IdNo == IdNo))
                    {
                        creditOfficer.errorDescription = ("Id Number already exist in database. Please try again!");
                        return Ok(creditOfficer);
                    }
                    else

                    {
                        var DbResult = db.proc_AddEditCreditOfficers(0, Code, FullName, DateJoined, IdNo, PhoneNumber, Email, Address, Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            creditOfficer.errorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }
                        creditOfficer.CreditOfficerId = DbResult.CreditOfficerId;
                        creditOfficer.Code = DbResult.Code;
                        creditOfficer.FullName = DbResult.FullName;
                        creditOfficer.DateJoined = DbResult.DateJoined;
                        creditOfficer.IdNo = DbResult.IdNo;
                        creditOfficer.PhoneNumber = DbResult.PhoneNumber;
                        creditOfficer.Email = DbResult.Email;
                        creditOfficer.Address = DbResult.Address;
                        creditOfficer.Remarks = DbResult.Remarks;



                        creditOfficer.isSuccess = true;
                        return Ok(creditOfficer);
                    }

                }
            }
            catch (Exception ex)
            {
                creditOfficer.errorDescription = ex.Message;
                return Ok(creditOfficer);

            }
        }


        [Route("Api/UpdateCreditOfficer"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateCreditOfficer(int? CreditOfficerId, string Code,
        string FullName, DateTime? DateJoined, string IdNo, string PhoneNumber,
        string Email, string Address, string Remarks, bool? Delete)

        {
            CreditOfficer creditOfficer = new CreditOfficer();
            creditOfficer.isSuccess = false;
            creditOfficer.errorDescription = "";
            if (CreditOfficerId == null) { CreditOfficerId = 0; }
            if (Code == null) { Code = ""; }
            if (FullName == null) { FullName = ""; }
            if (DateJoined == null) { DateJoined = DateTime.Parse("1900-01-01"); }
            if (IdNo == null) { IdNo = ""; }
            if (PhoneNumber == null) { PhoneNumber = ""; }
            if (Email == null) { Email = ""; }
            else
            {
                if (Email != null)
                {
                    if (!EmailIsValid(Email))
                    {
                        creditOfficer.errorDescription = "Please ensure your email is correct format eg. abc@example.com";
                        return Ok(creditOfficer);
                    }
                }
            }
            if (Address == null) { Address = ""; }
            if (Remarks == null) { Remarks = ""; }

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    if (IdNo != "" && db.tblCreditOfficers.Any(p => p.IdNo == IdNo))

                    {
                        var CreditOfficer = (from a in db.tblCreditOfficers
                                             where a.IdNo == IdNo
                                             select new
                                             { a.CreditOfficerId }).FirstOrDefault();

                        if (CreditOfficer.CreditOfficerId == CreditOfficerId)
                        {
                            var DbResult = db.proc_AddEditCreditOfficers(CreditOfficerId, Code, FullName, DateJoined, IdNo, PhoneNumber, Email, Address, Remarks, Delete = false).FirstOrDefault();
                            if (DbResult == null)
                            {
                                creditOfficer.errorDescription = "Process failed. Please try again!";
                                return Ok(DbResult);
                            }
                            creditOfficer.CreditOfficerId = DbResult.CreditOfficerId;
                            creditOfficer.Code = DbResult.Code;
                            creditOfficer.FullName = DbResult.FullName;
                            creditOfficer.DateJoined = DbResult.DateJoined;
                            creditOfficer.IdNo = DbResult.IdNo;
                            creditOfficer.PhoneNumber = DbResult.PhoneNumber;
                            creditOfficer.Email = DbResult.Email;
                            creditOfficer.Address = DbResult.Address;
                            creditOfficer.Remarks = DbResult.Remarks;


                            creditOfficer.isSuccess = true;
                            return Ok(creditOfficer);

                        }
                        else
                        {

                            creditOfficer.errorDescription = ("Id Number already exist in database. Please try again!");
                            return Ok(creditOfficer);


                        }

                    }
                    else
                    {
                        var DbResult = db.proc_AddEditCreditOfficers(CreditOfficerId, Code, FullName, DateJoined, IdNo, PhoneNumber, Email, Address, Remarks, Delete = false).FirstOrDefault();
                        if (DbResult == null)
                        {
                            creditOfficer.errorDescription = "Process failed. Please try again!";
                            return Ok(DbResult);
                        }
                        creditOfficer.CreditOfficerId = DbResult.CreditOfficerId;
                        creditOfficer.Code = DbResult.Code;
                        creditOfficer.FullName = DbResult.FullName;
                        creditOfficer.DateJoined = DbResult.DateJoined;
                        creditOfficer.IdNo = DbResult.IdNo;
                        creditOfficer.PhoneNumber = DbResult.PhoneNumber;
                        creditOfficer.Email = DbResult.Email;
                        creditOfficer.Address = DbResult.Address;
                        creditOfficer.Remarks = DbResult.Remarks;


                        creditOfficer.isSuccess = true;
                        return Ok(creditOfficer);

                    }


                }

            }
            catch (Exception ex)
            {
                creditOfficer.errorDescription = ex.Message;
                return Ok(creditOfficer);

            }
        }



        [Route("Api/GetAllCreditOfficers")]
        public IHttpActionResult GetAllCreditOfficers()
        {

            CreditOfficer oNewCreditOfficer = new CreditOfficer();
            oNewCreditOfficer.isSuccess = false;
            oNewCreditOfficer.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllCreditOfficers().ToList();
                    List<CreditOfficer> listofCreditOfficers = new List<CreditOfficer>();
                    foreach (var items in dbResult)
                    {
                        CreditOfficer oCreditOfficer = new CreditOfficer();

                        oCreditOfficer.CreditOfficerId = items.CreditOfficerId;
                        oCreditOfficer.FullName = items.FullName;
                        oCreditOfficer.Code = items.Code;
                        oCreditOfficer.DateJoined = items.DateJoined;
                        oCreditOfficer.IdNo = items.IdNo;
                        oCreditOfficer.PhoneNumber = items.PhoneNumber;
                        oCreditOfficer.Email = items.Email;
                        oCreditOfficer.Address = items.Address;
                        oCreditOfficer.Remarks = items.Remarks;
                        oCreditOfficer.errorDescription = "";
                        oCreditOfficer.isSuccess = true;
                        listofCreditOfficers.Add(oCreditOfficer);


                    }
                    IEnumerable<CreditOfficer> myCreditOfficer = listofCreditOfficers;
                    return Ok(myCreditOfficer);

                }
            }
            catch (Exception ex)
            {
                oNewCreditOfficer.errorDescription = ex.Message;
                return Ok(oNewCreditOfficer);

            }

        }



        [Route("Api/GetCreditOfficer")]
        public async Task<IHttpActionResult> GetCreditOfficer(int? id)
        {
            using (DBContextEntities db = new DBContextEntities())
            {
                var CreditOfficer = (from a in db.tblCreditOfficers
                                     where a.CreditOfficerId == id
                                     select new
                                     {
                                         a.CreditOfficerId,
                                         a.FullName,
                                         a.Code,
                                         a.DateJoined,
                                         a.IdNo,
                                         a.PhoneNumber,
                                         a.Email,
                                         a.Address,
                                         a.Remarks

                                     }).FirstOrDefault();
                return Ok(new { CreditOfficer });


            }

        }

        [Route("Api/DeleteCreditOfficer"), HttpGet]
        public IHttpActionResult DeleteCreditOfficer(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblCreditOfficer location = db.tblCreditOfficers.SingleOrDefault(x => x.CreditOfficerId == id);
                db.tblCreditOfficers.Remove(location);
                db.SaveChanges();
                return Ok(location);
            }
        }
        [Route("Api/GetStructureValues")]
        public IHttpActionResult GetStructureValues(int? StructureValueId)
        {

            StructureValue structureValue = new StructureValue();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Proc_GetStructure(StructureValueId).ToList();
                    List<StructureValue> listofStructureValues = new List<StructureValue>();
                    foreach (var items in dbResult)
                    {
                        StructureValue newStructureValue = new StructureValue();

                        newStructureValue.StructureValueId = items.StructureValueId;
                        newStructureValue.StructureId = items.StructureId;
                        newStructureValue.Name = items.Name;
                        newStructureValue.ParentId = items.ParentId;
                        newStructureValue.IsGroup = items.IsGroup;
                        newStructureValue.Remarks = items.Remarks;
                        newStructureValue.errorDescription = "";
                        newStructureValue.isSuccess = true;
                        listofStructureValues.Add(newStructureValue);
                    }
                    IEnumerable<StructureValue> myStructureValues = listofStructureValues;
                    return Ok(myStructureValues);

                }
            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }

        }
        [Route("Api/GetStructureParentValues")]
        public IHttpActionResult GetStructureParentValues(int? ParentId)
        {

            StructureValue structureValue = new StructureValue();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetParentUsingChild(ParentId).ToList();
                    List<StructureValue> listofStructureValues = new List<StructureValue>();
                    foreach (var items in dbResult)
                    {
                        StructureValue newStructureValue = new StructureValue();

                        newStructureValue.StructureValueId = items.StructureValueId;
                        newStructureValue.StructureId = items.StructureId;
                        newStructureValue.Name = items.Name;
                        newStructureValue.ParentId = items.ParentId;
                        newStructureValue.IsGroup = items.IsGroup;
                        newStructureValue.Remarks = items.Remarks;
                        newStructureValue.errorDescription = "";
                        newStructureValue.isSuccess = true;
                        listofStructureValues.Add(newStructureValue);
                    }
                    IEnumerable<StructureValue> myStructureValues = listofStructureValues;
                    return Ok(myStructureValues);

                }
            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }

        }
        [Route("Api/getParentStructure")]
        public async Task<IHttpActionResult> getParentStructure()
        {
            StructureValue oNewStructureValue = new StructureValue();
            oNewStructureValue.isSuccess = false;
            oNewStructureValue.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Proc_GetParentStructure().ToList();
                    List<StructureValue> listofStructureValue = new List<StructureValue>();

                    foreach (var items in dbResult)
                    {
                        StructureValue oStructureValue = new StructureValue();

                        oStructureValue.ParentId = items.ParentId;
                        oStructureValue.StructureValueId = items.StructureValueId;
                        oStructureValue.StructureId = items.StructureId;
                        oStructureValue.Name = items.Name;
                        oStructureValue.IsGroup = items.IsGroup;
                        oStructureValue.isSuccess = true;
                        oStructureValue.errorDescription = "";

                        listofStructureValue.Add(oStructureValue);
                    }
                    IEnumerable<StructureValue> myStructureValue = listofStructureValue;
                    return Ok(myStructureValue);
                }
            }
            catch (Exception ex)
            {
                oNewStructureValue.errorDescription = ex.Message;
                return Ok(oNewStructureValue);
            }
        }
        [Route("Api/GetFilterStructure")]
        public IHttpActionResult GetFilterStructure(int? StructureId)
        {

            Structure structureValue = new Structure();
            structureValue.isSuccess = false;
            structureValue.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getStractureId(StructureId).ToList();
                    List<Structure> listofStructureValues = new List<Structure>();
                    foreach (var items in dbResult)
                    {
                        Structure newStructureValue = new Structure();

                        newStructureValue.StructureId = items.StructureId;
                        newStructureValue.Caption = items.Caption;
                        newStructureValue.ParentId = items.ParentId;
                        newStructureValue.Description = items.Description;
                        newStructureValue.Remarks = items.Remarks;
                        newStructureValue.errorDescription = "";
                        newStructureValue.isSuccess = true;
                        listofStructureValues.Add(newStructureValue);
                    }
                    IEnumerable<Structure> myStructureValues = listofStructureValues;
                    return Ok(myStructureValues);

                }
            }
            catch (Exception ex)
            {
                structureValue.errorDescription = ex.Message;
                return Ok(structureValue);

            }

        }
        [Route("Api/ getStructureValueTree")]
        public IHttpActionResult getStructureValueTree(int? MemberId)
        {

            stractureValueTree structureValueTree = new stractureValueTree();
            structureValueTree.isSuccess = false;
            structureValueTree.errorDescription = "";


            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_getStructureTree(MemberId).ToList();
                    List<stractureValueTree> listofStructureValueTree = new List<stractureValueTree>();
                    foreach (var items in dbResult)
                    {
                        stractureValueTree oStructureValueTree = new stractureValueTree();
                        oStructureValueTree.Id = items.Id;
                        oStructureValueTree.StructureCaption = items.StructureCaption;
                        oStructureValueTree.CurrentName = items.CurrentName;
                        oStructureValueTree.errorDescription = "";
                        oStructureValueTree.isSuccess = true;
                        listofStructureValueTree.Add(oStructureValueTree);
                    }

                    IEnumerable<stractureValueTree> myStructureValueTree = listofStructureValueTree;
                    return Ok(myStructureValueTree);
                }
            }
            catch (Exception ex)
            {
                structureValueTree.errorDescription = ex.Message;
                return Ok(structureValueTree);

            }

        }
    }
}
