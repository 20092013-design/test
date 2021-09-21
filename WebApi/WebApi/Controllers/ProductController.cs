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
    public class ProductController : ApiController
    {
        [Route("Product/AddProduct"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddProduct(string Code, string Description, decimal? MinDeposit, bool? MaxAmount,
         decimal? UpperLimit, bool? EarnDividends, decimal? DividendRate, bool? Withdrawn, bool? FixedDeposit,
         bool? Transferred, bool? GuaranteeLoan, string Frequency, bool? EarnInterest, bool? ChargeDefaulters,
         bool? MultAccounts, bool? CallDeposit, decimal? MinBalance, bool? AccrueInterestDaily, bool? Delete, bool? CanBeOverdrawn)
        {
            Product oNewProduct = new Product();
            oNewProduct.isSuccess = false;
            oNewProduct.errorDescription = "";
            if (Code == null) { Code = ""; }
            if (Description == null) { Description = ""; }
            if (MinDeposit == null) { MinDeposit = 0; }
            if (UpperLimit == null) { UpperLimit = 0; }
            if (DividendRate == null) { DividendRate = 0; }
            if (Frequency == null) { Frequency = ""; }
            if (MinBalance == null) { MinBalance = 0; }
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditProducts(0, Code, Description, MinDeposit, MaxAmount, UpperLimit, EarnDividends,
                        DividendRate, Withdrawn, FixedDeposit, Transferred, GuaranteeLoan, Frequency, EarnInterest, ChargeDefaulters, MultAccounts, CallDeposit, MinBalance, CanBeOverdrawn, AccrueInterestDaily, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewProduct.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewProduct.Code = DbResult.Code;
                    oNewProduct.Description = DbResult.Description;
                    oNewProduct.MinDeposit = DbResult.MinDeposit;
                    oNewProduct.MaxAmount = DbResult.MaxAmount;
                    oNewProduct.UpperLimit = DbResult.UpperLimit;
                    oNewProduct.EarnDividends = DbResult.EarnDividends;
                    oNewProduct.DividendRate = DbResult.DividendRate;
                    oNewProduct.Withdrawn = DbResult.Withdrawn;
                    oNewProduct.FixedDeposit = DbResult.FixedDeposit;
                    oNewProduct.Transferred = DbResult.Transferred;
                    oNewProduct.GuaranteeLoan = DbResult.GuaranteeLoan;
                    oNewProduct.Frequency = DbResult.Frequency;
                    oNewProduct.EarnInterest = DbResult.EarnInterest;
                    oNewProduct.ChargeDefaulters = DbResult.ChargeDefaulters;
                    oNewProduct.MultAccounts = DbResult.MultAccounts;
                    oNewProduct.CallDeposit = DbResult.CallDeposit;
                    oNewProduct.MinBalance = DbResult.MinBalance;
                    oNewProduct.AccrueInterestDaily = DbResult.AccrueInterestDaily;
                    oNewProduct.isSuccess = true;
                    return Ok(oNewProduct);

                }


            }
            catch (Exception ex)
            {
                oNewProduct.errorDescription = ex.Message;
                return Ok(oNewProduct);


            }

        }
        [Route("Product/UpdateProduct"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateProduct(int? ProductId, string Code, string Description, decimal? MinDeposit, bool? MaxAmount,
           decimal? UpperLimit, bool? EarnDividends, decimal? DividendRate, bool? Withdrawn, bool? FixedDeposit,
           bool? Transferred, bool? GuaranteeLoan, string Frequency, bool? EarnInterest, bool? ChargeDefaulters,
           bool? MultAccounts, bool? CallDeposit, decimal? MinBalance, bool? AccrueInterestDaily, bool? Delete, bool? CanBeOverdrawn)
        {
            Product oNewProduct = new Product();
            oNewProduct.isSuccess = false;
            oNewProduct.errorDescription = "";
            if (Code == null) { Code = ""; }
            if (Description == null) { Description = ""; }
            if (MinDeposit == null) { MinDeposit = 0; }
            if (UpperLimit == null) { UpperLimit = 0; }
            if (DividendRate == null) { DividendRate = 0; }
            if (Frequency == null) { Frequency = ""; }
            if (MinBalance == null) { MinBalance = 0; }
            try
            {

                using (DBContextEntities db = new DBContextEntities())
                {
                    var DbResult = db.proc_AddEditProduct(ProductId, Code, Description, MinDeposit, MaxAmount, UpperLimit, EarnDividends,
                        DividendRate, Withdrawn, FixedDeposit, Transferred, GuaranteeLoan, Frequency, EarnInterest, ChargeDefaulters, MultAccounts, CallDeposit, MinBalance, CanBeOverdrawn, AccrueInterestDaily, Delete = false).FirstOrDefault();
                    if (DbResult == null)
                    {
                        oNewProduct.errorDescription = "Process failed. Please try again!";
                        return Ok(DbResult);
                    }
                    oNewProduct.ProductId = DbResult.ProductId;
                    oNewProduct.Code = DbResult.Code;
                    oNewProduct.Description = DbResult.Description;
                    oNewProduct.MinDeposit = DbResult.MinDeposit;
                    oNewProduct.MaxAmount = DbResult.MaxAmount;
                    oNewProduct.UpperLimit = DbResult.UpperLimit;
                    oNewProduct.EarnDividends = DbResult.EarnDividends;
                    oNewProduct.DividendRate = DbResult.DividendRate;
                    oNewProduct.Withdrawn = DbResult.Withdrawn;
                    oNewProduct.FixedDeposit = DbResult.FixedDeposit;
                    oNewProduct.Transferred = DbResult.Transferred;
                    oNewProduct.GuaranteeLoan = DbResult.GuaranteeLoan;
                    oNewProduct.Frequency = DbResult.Frequency;
                    oNewProduct.EarnInterest = DbResult.EarnInterest;
                    oNewProduct.ChargeDefaulters = DbResult.ChargeDefaulters;
                    oNewProduct.MultAccounts = DbResult.MultAccounts;
                    oNewProduct.CallDeposit = DbResult.CallDeposit;
                    oNewProduct.MinBalance = DbResult.MinBalance;
                    oNewProduct.AccrueInterestDaily = DbResult.AccrueInterestDaily;
                    oNewProduct.isSuccess = true;
                    return Ok(oNewProduct);

                }


            }
            catch (Exception ex)
            {
                oNewProduct.errorDescription = ex.Message;
                return Ok(oNewProduct);


            }
        }
        [Route("Product/GetAllProduct")]
        public IHttpActionResult GetAllProduct()
        {

            Product onNewProduct = new Product();
            onNewProduct.isSuccess = false;
            onNewProduct.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.Sp_GetALLProduct().ToList();
                    List<Product> listofProduct = new List<Product>();
                    foreach (var items in dbResult)
                    {
                        Product oProduct = new Product();
                        oProduct.ProductId = items.ProductId;
                        oProduct.Code = items.Code;
                        oProduct.Description = items.Description;
                        oProduct.MinDeposit = items.MinDeposit;
                        oProduct.MaxAmount = items.MaxAmount;
                        oProduct.UpperLimit = items.UpperLimit;
                        oProduct.EarnDividends = items.EarnDividends;
                        oProduct.DividendRate = items.DividendRate;
                        oProduct.Withdrawn = items.Withdrawn;
                        oProduct.FixedDeposit = items.FixedDeposit;
                        oProduct.Transferred = items.Transferred;
                        oProduct.GuaranteeLoan = items.GuaranteeLoan;
                        oProduct.Frequency = items.Frequency;
                        oProduct.EarnInterest = items.EarnInterest;
                        oProduct.ChargeDefaulters = items.ChargeDefaulters;
                        oProduct.MultAccounts = items.MultAccounts;
                        oProduct.CallDeposit = items.CallDeposit;
                        oProduct.MinBalance = items.MinBalance;
                        oProduct.CanBeOverdrawn = items.CanBeOverdrawn;
                        oProduct.AccrueInterestDaily = items.AccrueInterestDaily;
                        oProduct.isSuccess = true;
                        listofProduct.Add(oProduct);
                    }
                    IEnumerable<Product> myProduct = listofProduct;
                    return Ok(myProduct);

                }
            }
            catch (Exception ex)
            {
                onNewProduct.errorDescription = ex.Message;
                return Ok(onNewProduct);

            }

        }
        [Route("Product/GetProduct")]
        public async Task<IHttpActionResult> GetProduct(int? id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {
                var Product = (from a in db.tblProducts
                               where a.ProductId == id
                               select new
                               {
                                   a.ProductId,
                                   a.Code,
                                   a.Description,
                                   a.MinDeposit,
                                   a.MaxAmount,
                                   a.UpperLimit,
                                   a.EarnDividends,
                                   a.DividendRate,
                                   a.Withdrawn,
                                   a.FixedDeposit,
                                   a.Transferred,
                                   a.GuaranteeLoan,
                                   a.Frequency,
                                   a.EarnInterest,
                                   a.ChargeDefaulters,
                                   a.MultAccounts,
                                   a.CallDeposit,
                                   a.MinBalance,

                                   a.CanBeOverdrawn,
                                   a.AccrueInterestDaily,



                               }).FirstOrDefault();
                return Ok(new { Product });


            }

        }
        [Route("Product/DeleteProduct"), HttpGet]
        public IHttpActionResult DeleteProduct(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblProduct product = db.tblProducts.SingleOrDefault(x => x.ProductId == id);
                db.tblProducts.Remove(product);
                db.SaveChanges();
                return Ok(product);
            }
        }

        [Route("Api/GetChargeById")]
        public IHttpActionResult GetChargeById()
        {

            Charge oNewCharge = new Charge();
            oNewCharge.isSuccess = false;
            oNewCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllChargesFinal().ToList();
                    List<Charge> listofCharges = new List<Charge>();
                    foreach (var items in dbResult)
                    {
                        Charge oCharge = new Charge();

                        oCharge.ChargesId = items.ChargesId;
                        oCharge.Code = items.Code;
                        oCharge.Description = items.Description;
                        oCharge.Tariff = items.Tariff;
                        oNewCharge.Value = items.Value;
                        oNewCharge.IsPercent = items.IsPercent;
                        oCharge.IgnoreLowLimit = items.IgnoreLowLimit;
                        oCharge.LowerLimit = items.LowerLimit;
                        oCharge.UpperLimit = items.UpperLimit;
                        oNewCharge.TariffAmount = items.TariffAmount;
                        oNewCharge.isSuccess = true;
                        oNewCharge.errorDescription = "";

                        listofCharges.Add(oCharge);


                    }
                    IEnumerable<Charge> myCharge = listofCharges;
                    return Ok(myCharge);

                }
            }
            catch (Exception ex)
            {
                oNewCharge.errorDescription = ex.Message;
                return Ok(oNewCharge);

            }

        }
        [Route("Product/AddProductCharge"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> AddProductCharge(int? ProductId, int? ChargeId, int? ChargeType, bool? Delete)
        {
            Productcharge oNewProductCharge = new Productcharge();
            oNewProductCharge.isSuccess = false;
            oNewProductCharge.errorDescription = "";
            if (ProductId == null)
            {
                oNewProductCharge.errorDescription = "Product name is required *****";
                return Ok(oNewProductCharge);
            }
            if (ChargeId == null)
            {
                oNewProductCharge.errorDescription = "Charge is required for this product *****";
                return Ok(oNewProductCharge);
            }
            if (ChargeType == null)
            {
                oNewProductCharge.errorDescription = "Charge type is required for this product *****";
                return Ok(oNewProductCharge);
            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditProductCharge(0, ProductId, ChargeId, ChargeType, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewProductCharge.errorDescription = "Process failed. Please try again!";
                        return Ok(dbResult);
                    }
                    oNewProductCharge.ProductChargeId = dbResult.ProductChargeId;
                    oNewProductCharge.ProductId = dbResult.ProductId;
                    oNewProductCharge.ChargeId = dbResult.ChargeId;
                    oNewProductCharge.ChargeType = dbResult.ChargeType;
                    oNewProductCharge.isSuccess = true;
                    return Ok(oNewProductCharge);

                }


            }
            catch (Exception ex)
            {
                oNewProductCharge.errorDescription = ex.Message;
                return Ok(oNewProductCharge);

            }

        }
        [Route("Product/UpdateProductCharge"), HttpGet, HttpPost]
        public async Task<IHttpActionResult> UpdateProductCharge(int? ProductChargeId, int? ProductId, int? ChargeId, int? ChargeType, bool? Delete)
        {
            Productcharge oNewProductCharge = new Productcharge();
            oNewProductCharge.isSuccess = false;
            oNewProductCharge.errorDescription = "";
            if (ProductId == null)
            {
                oNewProductCharge.errorDescription = "Product name is required *****";
                return Ok(oNewProductCharge);
            }
            if (ChargeId == null)
            {
                oNewProductCharge.errorDescription = "Charge is required for this product *****";
                return Ok(oNewProductCharge);
            }
            if (ChargeType == null)
            {
                oNewProductCharge.errorDescription = "Charge type is required for this product *****";
                return Ok(oNewProductCharge);
            }
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_AddEditProductCharge(ProductChargeId, ProductId, ChargeId, ChargeType, Delete = false).FirstOrDefault();
                    if (dbResult == null)
                    {
                        oNewProductCharge.errorDescription = "Process failed. Please try again!";
                        return Ok(dbResult);
                    }
                    oNewProductCharge.ProductChargeId = dbResult.ProductChargeId;
                    oNewProductCharge.ProductId = dbResult.ProductId;
                    oNewProductCharge.ChargeId = dbResult.ChargeId;
                    oNewProductCharge.ChargeType = dbResult.ChargeType;
                    oNewProductCharge.isSuccess = true;
                    return Ok(oNewProductCharge);

                }


            }
            catch (Exception ex)
            {
                oNewProductCharge.errorDescription = ex.Message;
                return Ok(oNewProductCharge);

            }

        }
        [Route("Product/GetAllProductCharge")]
        public IHttpActionResult GetAllProductCharge(int? ProductId)
        {

            Productcharge oNewProductCharge = new Productcharge();
            oNewProductCharge.isSuccess = false;
            oNewProductCharge.errorDescription = "";

            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var dbResult = db.proc_GetAllProductChargeById(ProductId).ToList();
                    List<Productcharge> listofProductCharges = new List<Productcharge>();
                    foreach (var items in dbResult)
                    {
                        Productcharge oProductCharge = new Productcharge();

                        oProductCharge.ProductChargeId = items.ProductChargeId;
                        oProductCharge.ProductId = items.ProductId;
                        oProductCharge.ChargeId = items.ChargeId;
                        oProductCharge.ChargeType = items.ChargeType;

                        oProductCharge.isSuccess = true;
                        oProductCharge.errorDescription = "";

                        listofProductCharges.Add(oProductCharge);


                    }
                    IEnumerable<Productcharge> myProductCharge = listofProductCharges;
                    return Ok(myProductCharge);

                }
            }
            catch (Exception ex)
            {
                oNewProductCharge.errorDescription = ex.Message;
                return Ok(oNewProductCharge);

            }

        }
        [Route("Product/GetProductCharge")]
        public async Task<IHttpActionResult> GetProductCharge(int? id)
        {
            Productcharge oNewProductCharge = new Productcharge();
            oNewProductCharge.isSuccess = false;
            oNewProductCharge.errorDescription = "";
            try
            {
                using (DBContextEntities db = new DBContextEntities())
                {
                    var Product = (from a in db.tblProductCharges
                                   where a.ProductChargeId == id
                                   select new
                                   {
                                       a.ProductChargeId,
                                       a.ProductId,
                                       a.ChargeId,
                                       a.ChargeType
                                   }).FirstOrDefault();
                    oNewProductCharge.isSuccess = true;
                    return Ok(new { Product });


                }

            }
            catch (Exception ex)
            {
                oNewProductCharge.errorDescription = ex.Message;
                return Ok(oNewProductCharge);


            }
        }
        [Route("Product/DeleteProductCharge"), HttpGet]
        public IHttpActionResult DeleteProductCharge(int id)
        {

            using (DBContextEntities db = new DBContextEntities())
            {

                tblProductCharge productCharge = db.tblProductCharges.SingleOrDefault(x => x.ProductChargeId == id);
                db.tblProductCharges.Remove(productCharge);
                db.SaveChanges();
                return Ok(productCharge);
            }
        }
    }
}
