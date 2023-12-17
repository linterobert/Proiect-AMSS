using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Data;
using ProiectMOPS.Infrastructure.Repositories;
using ProiectMOPS.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Moq;

namespace TestProjectMOPS
{
    [TestClass]
    public class ProductControllerTDDUnitTests
    {
        private DbContextOptions<ProiectMOPSContext> options;
        private ProiectMOPSContext context;
        private ProductRepository repository;
        private ProductControllerTDD controller;
        int i;

        public ProductControllerTDDUnitTests()
        {
            options = new DbContextOptions<ProiectMOPSContext>();
            context = new ProiectMOPSContext(options);
            repository = new ProductRepository(context);
            controller = new ProductControllerTDD(repository);
            i = 10;
        }

        [TestMethod]
        public async Task GetProduct_ValidProduct_ReturnsOk()
        {
            var result = await controller.GetProducts();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateProduct_ReturnsOkResult()
        {
            var product = new ProductDTO_TDD();
            product.Name = "Product";
            product.Description = "Description";
            product.Price = 1;
            product.CreateTime = DateTime.Now;
            product.UpdateTime = DateTime.Now;
            product.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";

            var result = await controller.CreateProduct(product);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateProduct_ValidProduct_ReturnsOk()
        {
            var product = new Product();
            product.ProductID = i + 1;
            product.Name = "Product";
            product.Description = "Description";
            product.Price = 1;
            product.CreateTime = DateTime.Now;
            product.UpdateTime = DateTime.Now;
            product.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";

            var result = await controller.UpdateProduct(product);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteProduct_ValidProduct_ReturnsOk()
        {
            var product = new ProductDTO_TDD();
            product.Name = "Product";
            product.Description = "Description";
            product.Price = 1;
            product.CreateTime = DateTime.Now;
            product.UpdateTime = DateTime.Now;
            product.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";

            await controller.CreateProduct(product);

            int len = 0;

            var products = await repository.GetAllProducts();

            var productsToReturn = new List<ProductDTO_TDD>();

            foreach (var i in products)
            {
                len++;
            }

            var result = await controller.DeleteProduct(len);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        [TestMethod]
        public async Task GetProductById_ValidProduct_ReturnsOk()
        {
            var result = await controller.GetProductById(20);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductByUserId_ValidProduct_ReturnsOk()
        {
            var result = await controller.GetProductsByUserID("96b296cc-d347-494d-ae69-dde2f61c7056");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}

