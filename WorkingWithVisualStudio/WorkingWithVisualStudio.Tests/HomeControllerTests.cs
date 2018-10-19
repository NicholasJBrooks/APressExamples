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
        public class ModelCompleteFakeRepository : IRepository
        {
            public IEnumerable<Product> Products { get; } = new Product[]
            {
                new Product { Name = "p1", Price = 275M},
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
        public void IndexActionModuleIsComplete()
        {
            // Arrange
            var controller = new HomeController();
            controller.Repository = new ModelCompleteFakeRepository();

            // Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            /// Assert
            Assert.Equal(controller.Repository.Products, model, Comparer.Get<Product>((p1, p2) => p1.Name == p2.Name && p1.Price == p2.Price));
        }
    }
}