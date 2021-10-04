using Moq;
using System;
using VendorMicroservices.Controllers;
using VendorMicroservices.Services;
using Xunit;
using VendorMicroservices.Models;
using Microsoft.AspNetCore.Mvc;

namespace Vendors.Tests
{
    public class UnitTest1
    {
        Mock<IVendorService> mock = new Mock<IVendorService>();


        [Fact]
        public void Test_ValidData()
        {
            var result = new Vendor()
            {
                Id = 1,
                VendorName = "karthik",
                DeliveryCharges = 600,
                Rating = 1
            };
            //var DataStore = A.Fake<IProductMicroservice>();
            mock.Setup(p => p.VendorDetails(101)).Returns(result);
            //A.CallTo(() => DataStore.SearchProductById(1)).Returns(result);
            var controller = new VendorController(mock.Object);
            OkObjectResult result1 = (OkObjectResult)controller.GetVendorDetails(101);
            Assert.True(result.Equals(result1.Value));
        }

        [Fact]
        public void Test_InvalidData()
        {
            Vendor result = null;
            //var DataStore = A.Fake<IProductMicroservice>();
            mock.Setup(p => p.VendorDetails(104)).Returns(result);
            //A.CallTo(() => DataStore.SearchProductById(1)).Returns(result);
            var controller = new VendorController(mock.Object);
            var result1 = controller.GetVendorDetails(104);
            var okResult = result1 as StatusCodeResult;
            Assert.Equal("404", okResult.StatusCode.ToString());
        }

        
    }
}