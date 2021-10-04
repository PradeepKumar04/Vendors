using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VendorMicroservices.Models
{
    [Keyless]
    public class VendorStock
    {
        public int ProductId { get; set; }

        [ForeignKey("Vendor")]
        public int VendorId { get; set; }

        public int StockInHand { get; set; }

        public Vendor Vendor { get; set; }
        public DateTime ExpectedStockReplinshmentDate { get; set; }

    }
}
