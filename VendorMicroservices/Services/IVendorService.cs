using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservices.Models;

namespace VendorMicroservices.Services
{
    public interface IVendorService
    {
        Vendor VendorDetails(int product_Id);
    }
}
