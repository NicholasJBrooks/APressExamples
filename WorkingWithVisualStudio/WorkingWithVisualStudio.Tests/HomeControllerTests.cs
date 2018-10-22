using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;
using System;
using Moq;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {

        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModuleIsComplete(Product[] products)
        {
            // Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(x => x.Products).Returns(products); 
            var controller = new HomeController() { Repository = mock.Object};

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            /// Assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }

  
        public class ModelCompleteFakeRepositoryPricesUnder50 : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "p1", Price = 5M},
                new Product { Name = "p2", Price = 48.95M},
                new Product { Name = "p3", Price = 19.50M},
                new Product { Name = "p4", Price = 34.95M}
            };

            public void AddProduct(Product product)
            {
                //do nothing not required for the test
            }
        }

        [Fact]
        public void IndexActionModuleIsCompletePricesUnder50()
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepositoryPricesUnder50();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            /// Assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }



        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(x => x.Products).Returns(new[] {new Product{ Name = "p1", Price = 100 } });
            var controller = new HomeController() { Repository = mock.Object };

            //Act
            var result = controller.Index();

            //Assert
            mock.VerifyGet(x => x.Products, Times.Once);          
        }


    }
}