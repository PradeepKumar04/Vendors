using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservices.Data;

namespace VendorMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private readonly VendorDbContext _db;

        public VendorController(VendorDbContext db)
        {
            _db = db;
        }
        /// <summary>
        /// Give List Of Vendors for the given Product
        /// </summary>
        /// <return>
        /// Returns List Of Vendors for the given Product
        /// </return>
        /// <remarks>
        /// Sample request
        /// GET /api/Vendor
        /// 
        /// </remarks>
        /// <response code="200">Returns List Of Vendors for the given Product</response>

        [HttpGet("{product_Id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public IActionResult GetVendorDetails(int product_Id)
        {
            var result = _db.VendorStocks.Where(s => s.ProductId == product_Id && s.StockInHand > 0).OrderBy(s => s.Vendor.DeliveryCharge).OrderByDescending(s=>s.Vendor.Rating).Select(s => s.Vendor).FirstOrDefault();
            if(result==null)
            {
                return NoContent();
            }
            return Ok(result);
        }
    }
}
