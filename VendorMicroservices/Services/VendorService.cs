using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservices.Data;
using VendorMicroservices.Models;

namespace VendorMicroservices.Services
{
    public class VendorService : IVendorService
    {
        private readonly VendorDbContext _db;

        public VendorService(VendorDbContext db)
        {
            _db = db;
        }
        public  Vendor VendorDetails(int product_Id)
        {
            Vendor result1 =_db.VendorStocks.Where(s => s.ProductId == product_Id && s.StockInHand > 0).OrderBy(s => s.Vendor.DeliveryCharges).OrderByDescending(s => s.Vendor.Rating).Select(s => s.Vendor).FirstOrDefault();
            
            return result1;
        }
    }
}
