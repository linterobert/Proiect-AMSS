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
using ProiectMOPS.Applications.Commands.ProductImageCommands;
using ProiectMOPS.Applications.Queries.ProductImageQueries;

namespace TestProjectMOPS
{
    [TestClass]
    public class ProductImageControllerUnitTests
    {

        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ProductImageController>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ProductImageController _controller;
        private readonly User _user;
        private readonly CreateProductImageDTO _productImage;
        private readonly CreateProductImageCommand _command;
        private readonly DeleteProductImageCommand _deleteCommand;
        private readonly CancellationToken _cancellationToken;
        private readonly IMapper _mapper;
        private readonly ProductImage productImage;
        private readonly List<ProductImage> productImages;

        public ProductImageControllerUnitTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ProductImageController>>();
            _mapperMock = new Mock<IMapper>();

            _controller = new ProductImageController(_mediatorMock.Object, _loggerMock.Object, _mapperMock.Object);
            _productImage = new CreateProductImageDTO
            {
                ProductID = 2,
                URL = string.Empty,
            };
            _command = new CreateProductImageCommand(_productImage);
            _deleteCommand = new DeleteProductImageCommand
            {
                ProductImageID = 2,
            };
            productImage = new ProductImage
            {
                ProductImageID = 1,
                URL = string.Empty,
                ProductID = 12
            };
            productImages = new List<ProductImage>();
            productImages.Add(productImage);

            _cancellationToken = new CancellationToken();


        }

        [TestMethod]
        public async Task CreateProductImage_ReturnsOkResult()
        {
            _mapperMock.Setup(m => m.Map<CreateProductImageCommand>(_productImage)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductImageCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(productImage));
            var result = await _controller.CreateProductImage(_productImage, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        /*[TestMethod]
        public async Task CreateProductImage_ReturnsNotFound()
        {
            _mapperMock.Setup(m => m.Map<CreateProductImageCommand>(_productImage)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateProductImageCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(productImage));
            var result = await _controller.CreateProductImage(_productImage, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }*/

        [TestMethod]
        public async Task DeleteProductImage_ValidProductImage_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteProductImageCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productImage));

            // Act
            var result = await _controller.DeleteProductImage(2, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductImage_ValidProductImage_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductImagesQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productImages));

            // Act
            var result = await _controller.GetProductImages();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductImageById_ValidProductImage_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductImageByIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productImage));

            // Act
            var result = await _controller.GetProductImageByID(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetProductImagesByProductID_ValidProductImage_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetProductImagesByProductIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(productImages));

            // Act
            var result = await _controller.GetProductImagesByProductID(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}
