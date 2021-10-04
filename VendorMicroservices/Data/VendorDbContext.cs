using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendorMicroservices.Models;

namespace VendorMicroservices.Data
{
    
    public class VendorDbContext : DbContext
    {
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorStock> VendorStocks { get; set; }

        public VendorDbContext(DbContextOptions<VendorDbContext> options) : base(options)
        {

        }
    }
}
