using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservices.Data;
using VendorMicroservices.Services;

namespace VendorMicroservices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class VendorController : ControllerBase
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(VendorController));
        private readonly IVendorService _microservice;

        public VendorController(IVendorService microservice)
        {
            _microservice = microservice;
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
            _log4net.Info("Logger initiated");
            var result = _microservice.VendorDetails(product_Id);
            if(result==null)
            {
                _log4net.Error("Vendors List Failed");
                return NotFound();
            }
            _log4net.Info("Returned List of vendors for the given product");
            return Ok(result);
        }
    }
}
