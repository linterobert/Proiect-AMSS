using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectMOPS.Applications.Commands.ReviewCommands;
using ProiectMOPS.Applications.Queries.ReviewQueries;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ReviewController(IMediator mediator, ILogger<ReviewController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewDTO dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create review for product with ID {dto.ProductID} by user with ID {dto.UserID}");
            var command = _mapper.Map<CreateReviewCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
            {
                _logger.LogInformation("User not found!");
                return NotFound("User not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            _logger.LogInformation($"Delete review with ID {id}");
            var command = new DeleteReviewCommand
            {
                ReviewID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Review not found");
                return NotFound("Review not found");
            }
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] UpdateReviewDTO dto)
        {
            _logger.LogInformation($"Update product with id {id}");
            var command = new UpdateReviewCommand
            {
                Description = dto.Description,
                StarNumber = dto.StarNumber,
                ReviewID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound("Review not found!");
            }
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetReviews()
        {
            _logger.LogInformation("Get reviews");
            var query = new GetReviewsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetReviewByID(int id)
        {
            _logger.LogInformation($"Get review with ID {id}");
            var command = new GetReviewByIDQuery()
            {
                ReviewID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Review not found");
                return NotFound("Review not found");
            }
            return Ok(result);
        }

        [HttpGet("UserID/{UserID}")]
        public async Task<IActionResult> GetReviewsByUserID(string UserID)
        {
            _logger.LogInformation($"Get reviews writed by User with ID {UserID}");
            var command = new GetReviewsByUserIDQuery()
            {
                UserID = UserID
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("ProductID/{ProductID}")]
        public async Task<IActionResult> GetReviewsByProductID(int ProductID)
        {
            _logger.LogInformation($"Get reviews for product with ID {ProductID}");
            var command = new GetReviewsByProductIDQuery()
            {
                ProductID = ProductID
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
