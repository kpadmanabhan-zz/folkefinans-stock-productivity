using System.Collections.Generic;
using Moq;
using Folkefinans.StockProductivity.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FizzWare.NBuilder;
using Folkefinans.StockProductivity.Models;
using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using Folkefinans.StockProductivity.Providers;

namespace Folkefinans.StockProductivity.Tests
{
    [TestClass]
    public class StockDetailsControllerTests
    {
        private const string json = "{\"StockDetails\":[{\"Id\":1,\"StockName\":\"Apple\",\"Price\":2.00,\"Quantity\":200,\"Percentage\":3.00,\"Years\":10,\"StockResults\":{\"0\":400.00,\"1\":412.00,\"2\":424.36,\"3\":437.09,\"4\":450.20,\"5\":463.71,\"6\":477.62,\"7\":491.95,\"8\":506.71,\"9\":521.91,\"10\":537.57}},{\"Id\":2,\"StockName\":\"HP\",\"Price\":3.00,\"Quantity\":50,\"Percentage\":4.00,\"Years\":5,\"StockResults\":{\"0\":150.00,\"1\":154.50,\"2\":159.14,\"3\":163.91,\"4\":168.83,\"5\":173.89}}]}";
        private readonly Mock<IPathProvider> pathProviderMock = new Mock<IPathProvider>();
        private readonly IFileSystem fileSystemMock = new MockFileSystem(
            new Dictionary<string, MockFileData> {
                { "TestJsonPath", new MockFileData(json) }
            });

        private readonly StockDetailsController stockDetailsController;

        public StockDetailsControllerTests()
        {
            stockDetailsController = new StockDetailsController(fileSystemMock, pathProviderMock.Object);
        }

        [TestMethod]
        public void Post_ShouldAddStockDetails()
        {
            // Arrange
            var inputStockDetailsModel = new Builder().CreateNew<StockDetailsModel>()
                .With(x => x.StockName = "Test")
                .And(x => x.Price = 2.00M)
                .And(x => x.Quantity = 200)
                .And(x => x.Percentage = 3.00M)
                .And(x => x.Years = 2)
                .Build();

            pathProviderMock.Setup(x => x.MapPath("~/App_Data/StockDetailsList.json")).Returns("TestJsonPath");

            // Act
            var result = stockDetailsController.Post(inputStockDetailsModel);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Test", result.StockName);
            Assert.IsNotNull(result.StockResults);
            Assert.AreEqual(3, result.StockResults.Count);

            Assert.AreEqual(400.00M, result.StockResults[0]);
            Assert.AreEqual(412.00M, result.StockResults[1]);
            Assert.AreEqual(424.36M, result.StockResults[2]);
        }

        [TestMethod]
        public void GetAllStocks_ShouldReturnAllStocks()
        {
            // Arrange
            pathProviderMock.Setup(x => x.MapPath("~/App_Data/StockDetailsList.json")).Returns("TestJsonPath");

            // Act
            var result = stockDetailsController.GetAllStocks();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        [TestMethod]
        public void GetStockDetails_ShouldReturnStockDetils()
        {
            // Arrange
            pathProviderMock.Setup(x => x.MapPath("~/App_Data/StockDetailsList.json")).Returns("TestJsonPath");

            // Act
            var result = stockDetailsController.GetStockDetails(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Apple", result.StockName);
            Assert.IsNotNull(result.StockResults);
            Assert.AreEqual(11, result.StockResults.Count);
        }
    }
}
