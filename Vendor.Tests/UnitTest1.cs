using Moq;
using System;
using VendorMicroservices.Controllers;
using VendorMicroservices.Services;
using Xunit;
using VendorMicroservices.Models;

namespace Vendors.Tests
{
    public class UnitTest1
    {
        Mock<IVendorService> mock = new Mock<IVendorService>();
        

        [Fact]
        public void Test_InvalidData()
        {
            var result = new Ve
            {
                Id = 1,
                VendorName = "karthik",
                DeliveryCharge=600,
                Rating = 1
            };
            //var DataStore = A.Fake<IProductMicroservice>();
            mock.Setup(p => p.VendorDetails(101)).Returns(result);
            //A.CallTo(() => DataStore.SearchProductById(1)).Returns(result);
            var controller = new VendorController(mock.Object);
            var result1 = controller.GetVendorDetails(101);
            Assert.False(result.Equals(result1));
        }
    }
}
