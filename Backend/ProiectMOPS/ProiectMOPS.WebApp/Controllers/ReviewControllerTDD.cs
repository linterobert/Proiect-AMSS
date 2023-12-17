using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProiectMOPS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewControllerTDD : ControllerBase
    {
        private readonly ReviewRepository _repository;
        public ReviewControllerTDD(ReviewRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _repository.GetAllReviews();

            var reviewsToReturn = new List<ReviewDTO_TDD>();

            foreach (var review in reviews)
            {
                reviewsToReturn.Add(new ReviewDTO_TDD(review));
            }

            return Ok(reviewsToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReviewById(int id)
        {
            var review = await _repository.GetReviewByID(id);

            ReviewDTO_TDD reviewToReturn = new ReviewDTO_TDD(review);

            return Ok(reviewToReturn);
        }

        [HttpDelete("UserID/{UserID}")]
        public async Task<IActionResult> GetReviewsByUserID(string UserID)
        {
            var reviews = await _repository.GetReviewsByUserID(UserID);

            var reviewsToReturn = new List<ReviewDTO_TDD>();

            foreach (var review in reviews)
            {
                reviewsToReturn.Add(new ReviewDTO_TDD(review));
            }

            return Ok(reviewsToReturn);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            var Review = await _repository.GetByIdAsync(id);

            if (Review == null)
            {
                return NotFound("Review does not exist!");
            }

            _repository.Delete(Review);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(ReviewDTO_TDD dto)
        {
            Review newReview = new Review();

            newReview.ProductID = dto.ProductID;
            newReview.UserID = dto.UserID;
            newReview.StarNumber = dto.StarNumber;
            newReview.Description = dto.Description;
            newReview.CreatedTime = DateTime.Now;
            newReview.UpdatedTime = DateTime.Now;

            _repository.Create(newReview);

            await _repository.SaveAsync();


            return Ok(new ReviewDTO_TDD(newReview));
        }

        [HttpPut("UpdateForForm")]
        public async Task<IActionResult> UpdateReview([FromBody] Review review)
        {
            var array_review = await _repository.GetAllReviews();

            var reviewIndex = array_review.FindIndex((Review _review) => _review.ReviewID.Equals(review.ReviewID));

            array_review[reviewIndex] = review;

            return Ok(array_review);
        }
    }
}
