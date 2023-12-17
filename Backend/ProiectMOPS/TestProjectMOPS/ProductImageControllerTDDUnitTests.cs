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
    public class ProductImageControllerTDDUnitTests
    {
        private DbContextOptions<ProiectMOPSContext> options;
        private ProiectMOPSContext context;
        private ProductImageRepository repository;
        private ProductImageControllerTDD controller;
        int i;

        public ProductImageControllerTDDUnitTests()
        {
            options = new DbContextOptions<ProiectMOPSContext>();
            context = new ProiectMOPSContext(options);
            repository = new ProductImageRepository(context);
            controller = new ProductImageControllerTDD(repository);
            i = 10;
        }

        [TestMethod]
        public async Task GetProductImage_ValidProductImage_ReturnsOk()
        {
            var result = await controller.GetProductImages();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateProductImage_ReturnsOkResult()
        {
            ProductImageDTO_TDD newProductImage = new ProductImageDTO_TDD();
            newProductImage.ProductID = 20;
            newProductImage.URL = "http";

            var result = await controller.CreateProductImage(newProductImage);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteProductImage_ValidProductImage_ReturnsOk()
        {
            ProductImageDTO_TDD newProductImage = new ProductImageDTO_TDD();
            newProductImage.ProductID = 20;
            newProductImage.URL = "http";

            await controller.CreateProductImage(newProductImage);

            int len = 0;

            var products = await repository.GetAllProductImages();

            var productsToReturn = new List<ProductImageDTO_TDD>();

            foreach (var i in products)
            {
                len++;
            }

            var result = await controller.DeleteProductImage(len);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        [TestMethod]
        public async Task GetProductImageById_ValidProductImage_ReturnsOk()
        {
            var result = await controller.GetProductImageById(1);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductImageByProductId_ValidProductImage_ReturnsOk()
        {
            var result = await controller.GetProductsImagesByProductID(20);
                                                                                        
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}

