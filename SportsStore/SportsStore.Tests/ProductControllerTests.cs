﻿using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using SportsStore.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace SportsStore.Tests
{
    public class ProductControllerTests
    {
        [Fact]
        public void Can_Paginate()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "p1" },
                new Product {ProductId = 2, Name = "p2" },
                new Product {ProductId = 3, Name = "p3" },
                new Product {ProductId = 4, Name = "p4" },
                new Product {ProductId = 5, Name = "p5" },
            }).AsQueryable<Product>());

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;
            // Act
            ProductListViewModel result = controller.List(null , 2).ViewData.Model as ProductListViewModel; 

            // Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("p4", prodArray[0].Name);
            Assert.Equal("p5", prodArray[1].Name);

        }

        [Fact]
        public void Can_Send_Pagination_View_Model()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "p1" },
                new Product {ProductId = 2, Name = "p2" },
                new Product {ProductId = 3, Name = "p3" },
                new Product {ProductId = 4, Name = "p4" },
                new Product {ProductId = 5, Name = "p5" },
            }).AsQueryable<Product>());

            // Arrange
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            ProductListViewModel result = controller.List(null , 2).ViewData.Model as ProductListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;

            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages);

        }

        [Fact]
        public void Can_Filter_Products()
        {
            // Arrange
            // - create mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "p1" ,Category = "Cat1" },
                new Product {ProductId = 2, Name = "p2", Category = "Cat2" },
                new Product {ProductId = 3, Name = "p3", Category = "Cat1" },
                new Product {ProductId = 4, Name = "p4", Category = "Cat2" },
                new Product {ProductId = 5, Name = "p5", Category = "Cat3" },
            }).AsQueryable<Product>());

            // Arrange - creat a controller and make the page size 3 items
            ProductController controller = new ProductController(mock.Object) { PageSize = 3 };

            // Act
            Product[] result = (controller.List("Cat2", 1).ViewData.Model as ProductListViewModel).Products.ToArray();

            // Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "p2" && result[0].Category == "Cat2" );
            Assert.True(result[1].Name == "p4" && result[1].Category == "Cat2");

        }

        [Fact]
        public void Generate_Specific_Product_Count()
        {
            // Arrange
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns((new Product[] {
                new Product {ProductId = 1, Name = "p1" ,Category = "Cat1" },
                new Product {ProductId = 2, Name = "p2", Category = "Cat2" },
                new Product {ProductId = 3, Name = "p3", Category = "Cat1" },
                new Product {ProductId = 4, Name = "p4", Category = "Cat2" },
                new Product {ProductId = 5, Name = "p5", Category = "Cat3" },
            }).AsQueryable<Product>());

            ProductController target = new ProductController(mock.Object);
            target.PageSize = 3;

            Func<ViewResult, ProductListViewModel> GetModel = result =>
            result?.ViewData?.Model as ProductListViewModel;

            // Act
            int? res1 = GetModel(target.List("Cat1")).PagingInfo.TotalItems;
            int? res2 = GetModel(target.List("Cat2")).PagingInfo.TotalItems;
            int? res3 = GetModel(target.List("Cat3")).PagingInfo.TotalItems;
            int? resAll = GetModel(target.List(null)).PagingInfo.TotalItems;

            // Assert
            Assert.Equal(2, res1);
            Assert.Equal(2, res2);
            Assert.Equal(1, res3);
            Assert.Equal(5, resAll);

        }
    }
}
