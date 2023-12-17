using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Moq;
using ProiectMOPS.WEB.Controllers;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Collections.Generic;
using MediatR;
using AutoMapper;
using ProiectMOPS.WebApp.Controllers;
using System.Threading;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Applications.Queries.ProductQueries;

namespace TestProjectMOPS
{
    [TestClass]
    public class ProductControllerUnitTests
    {

        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ProductController>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductController _controller;
        private readonly User _user;
        private readonly CreateProductDTO _product;
        private readonly CreateProductCommand _command;
        private readonly UpdateProductCommand _updateCommand;
        private readonly DeleteProductCommand _deleteCommand;
        private readonly CancellationToken _cancellationToken;
        private readonly UpdateProductDTO _updateProduct;
        private readonly IMapper _mapper;
        private readonly Product product;
        private readonly List<Product> products;

        public ProductControllerUnitTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ProductController>>();
            _mapperMock = new Mock<IMapper>();

            _controller = new ProductController(_mediatorMock.Object, _loggerMock.Object, _mapperMock.Object);
            _product = new CreateProductDTO
            {
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
                Price = 100,
                Description= "Description",
                Name = "Product"
            };
            _updateProduct = new UpdateProductDTO
            {
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
                Name = "New Product",
                Description = "New Description",
                Price = 20
            };
            _command = new CreateProductCommand(_product);
            _updateCommand = new UpdateProductCommand
            {
                Description = "New Description",
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
                ProductID = 2,
                Price = 100,
                Name = "Name",
            };
            _deleteCommand = new DeleteProductCommand
            {
                ProductID = 2,
            };
            product = new Product
            {
                ProductID = 2,
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
            };
            products = new List<Product>();
            products.Add(product);

            _cancellationToken = new CancellationToken();
            

        }

        [TestMethod]
        public async Task CreateProduct_ReturnsOkResult()
        {
            _mapperMock.Setup(m => m.Map<CreateProductCommand>(_product)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(product));
            var result = await _controller.CreateProduct(_product, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        /*[TestMethod]
        public async Task CreateProduct_ReturnsNotFound()
        {
            _mapperMock.Setup(m => m.Map<CreateProductCommand>(_product)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(product));
            var result = await _controller.CreateProduct(_product, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }*/

        [TestMethod]
        public async Task UpdateProduct_ValidProduct_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(product));

            // Act
            var result = await _controller.UpdateProduct(2, _updateProduct, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteProduct_ValidProduct_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(product));

            // Act
            var result = await _controller.DeleteProduct(2, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProduct_ValidProduct_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(products));

            // Act
            var result = await _controller.GetProducts();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductById_ValidProduct_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(product));

            // Act
            var result = await _controller.GetProductByID(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductByUserId_ValidProduct_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductsByUserIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(products));

            // Act
            var result = await _controller.GetProductsByUserID("96b296cc-d347-494d-ae69-dde2f61c7056");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}
