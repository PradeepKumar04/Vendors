using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMicroservices.Models
{
    public class Vendor
    {
        public int Id { get; set; }
        public string VendorName { get; set; }
        public double DeliveryCharges { get; set; }
        public double Rating { get; set; }
    }
}
