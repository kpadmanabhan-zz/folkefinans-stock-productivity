using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private const string json = "{\"StockDetails\":[{\"Id\":1,\"StockName\":\"Apple\",\"Price\":2.00,\"Quantity\":200,\"Percentage\":3.00,\"Years\":10,\"StockResults\":{\"0\":400.00,\"1\":412.00,\"2\":424.36,\"3\":437.09,\"4\":450.20,\"5\":463.71,\"6\":477.62,\"7\":491.95,\"8\":506.71,\"9\":521.91,\"10\":537.57}}]}";
        private readonly IFileSystem fileSystemMock = new MockFileSystem();
        private readonly Mock<IPathProvider> pathProviderMock = new Mock<IPathProvider>();

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
                .Build();

            // Act
            var result = stockDetailsController.Post(inputStockDetailsModel);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
