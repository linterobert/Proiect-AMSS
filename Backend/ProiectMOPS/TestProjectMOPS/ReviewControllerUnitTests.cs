using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.WebApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestProjectMOPS
{
    [TestClass]
    public class ReviewControllerUnitTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly Mock<ILogger<ReviewController>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly ReviewController _controller;
        private readonly User _user;
        private readonly CreateReviewDTO _review;
        private readonly CreateReviewCommand _command;
        private readonly UpdateReviewCommand _updateCommand;
        private readonly DeleteReviewCommand _deleteCommand;
        private readonly CancellationToken _cancellationToken;
        private readonly UpdateReviewDTO _updateReview;
        private readonly IMapper _mapper;
        private readonly Review review;
        private readonly List<Review> reviews;

        public ReviewControllerUnitTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<ReviewController>>();
            _mapperMock = new Mock<IMapper>();

            _controller = new ReviewController(_mediatorMock.Object, _loggerMock.Object, _mapperMock.Object);
            _review = new CreateReviewDTO
            {
                Description = "Description",
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
                StarNumber = 1,
                ProductID = 2,
            };
            _updateReview = new UpdateReviewDTO
            {

                Description = "New Description",
                StarNumber = 1,
            };
            _command = new CreateReviewCommand(_review);
            _updateCommand = new UpdateReviewCommand
            {
                Description = "New Description",
                StarNumber = 2,
                ReviewID = 2,
            };
            _deleteCommand = new DeleteReviewCommand
            {
                ReviewID = 1,
            };
            review = new Review
            {
                ReviewID = 1,
                UserID = "96b296cc-d347-494d-ae69-dde2f61c7056",
            };
            reviews = new List<Review>();
            reviews.Add(review);

            _cancellationToken = new CancellationToken();


        }

        [TestMethod]
        public async Task CreateReview_ReturnsOkResult()
        {
            _mapperMock.Setup(m => m.Map<CreateReviewCommand>(_review)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateReviewCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(review));
            var result = await _controller.CreateReview(_review, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        /*[TestMethod]
        public async Task CreateReview_ReturnsNotFound()
        {
            _mapperMock.Setup(m => m.Map<CreateReviewCommand>(_review)).Returns(_command);
            _mediatorMock.Setup(m => m.Send(It.IsAny<CreateReviewCommand>(), It.IsAny<CancellationToken>())).Returns(Task.FromResult(review));
            var result = await _controller.CreateReview(_review, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }*/

        [TestMethod]
        public async Task UpdateReview_ValidReview_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<UpdateReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(review));

            // Act
            var result = await _controller.UpdateReview(2, _updateReview, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteReview_ValidReview_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<DeleteReviewCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(review));

            // Act
            var result = await _controller.DeleteReview(2, _cancellationToken);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetReview_ValidReview_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReviewsQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(reviews));

            // Act
            var result = await _controller.GetReviews();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetReviewById_ValidReview_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReviewByIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(review));

            // Act
            var result = await _controller.GetReviewByID(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetReviewByUserId_ValidReview_ReturnsOk()
        {



            _mediatorMock.Setup(m => m.Send(It.IsAny<GetReviewsByUserIDQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(reviews));

            // Act
            var result = await _controller.GetReviewsByUserID("96b296cc-d347-494d-ae69-dde2f61c7056");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
    }
}
