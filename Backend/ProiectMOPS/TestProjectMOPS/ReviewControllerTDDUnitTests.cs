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
    public class ReviewControllerTDDUnitTests
    {
        private DbContextOptions<ProiectMOPSContext> options;
        private ProiectMOPSContext context;
        private ReviewRepository repository;
        private ReviewControllerTDD controller;
        int i;

        public ReviewControllerTDDUnitTests()
        {
            options = new DbContextOptions<ProiectMOPSContext>();
            context = new ProiectMOPSContext(options);
            repository = new ReviewRepository(context);
            controller = new ReviewControllerTDD(repository);
            i = 10;
        }

        [TestMethod]
        public async Task GetReview_ValidReview_ReturnsOk()
        {
            var result = await controller.GetReviews();

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task CreateReview_ReturnsOkResult()
        {
            ReviewDTO_TDD review = new ReviewDTO_TDD();
            review.ProductID = 20;
            review.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";
            review.StarNumber = 1;
            review.Description = "Description";
            review.CreatedTime = DateTime.Now;
            review.UpdatedTime = DateTime.Now;

            var result = await controller.CreateReview(review);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task UpdateReview_ValidReview_ReturnsOk()
        {
            Review review = new Review();
            review.ReviewID = 2;
            review.ProductID = 20;
            review.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";
            review.StarNumber = 1;
            review.Description = "Description";
            review.CreatedTime = DateTime.Now;
            review.UpdatedTime = DateTime.Now;

            var result = await controller.UpdateReview(review);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task DeleteReview_ValidReview_ReturnsOk()
        {
            ReviewDTO_TDD review = new ReviewDTO_TDD();
            review.ProductID = 20;
            review.UserID = "96b296cc-d347-494d-ae69-dde2f61c7056";
            review.StarNumber = 1;
            review.Description = "Description";
            review.CreatedTime = DateTime.Now;
            review.UpdatedTime = DateTime.Now;

            await controller.CreateReview(review);

            int len = 0;

            var reviews = await repository.GetAllReviews();

            var reviewsToReturn = new List<ReviewDTO_TDD>();

            foreach (var i in reviews)
            {
                len++;
            }

            var result = await controller.DeleteReview(len);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }
        [TestMethod]
        public async Task GetReviewById_ValidReview_ReturnsOk()
        {
            var result = await controller.GetReviewById(2);

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }
        [TestMethod]
        public async Task GetReviewByUserId_ValidReview_ReturnsOk()
        {
            var result = await controller.GetReviewsByUserID("96b296cc-d347-494d-ae69-dde2f61c7056");

            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

    }
}

