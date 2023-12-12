using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Applications.Queries.ProductQueries;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductController(IMediator mediator, ILogger<ProductController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDTO dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create product for user with ID {dto.UserID}");
            var command = _mapper.Map<CreateProductCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
            {
                _logger.LogInformation("User not found!");
                return NotFound("User not found");
            }
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDTO dto)
        {
            _logger.LogInformation($"Update product with id {id}");
            var command = new UpdateProductCommand
            {
                Description = dto.Description,
                UserID = dto.UserID,
                ProductID = id,
                Price = dto.Price,
                Name = dto.Name,
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound("Product not found!");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            _logger.LogInformation($"Delete product with ID {id}");
            var command = new DeleteProductCommand
            {
                ProductID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Product not found");
                return NotFound("Product not found");
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            _logger.LogInformation("Get products");
            var query = new GetProductsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductByID(int id)
        {
            _logger.LogInformation($"Get product with ID {id}");
            var command = new GetProductByIDQuery()
            {
                ProductID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Product not found");
                return NotFound("Product not found");
            }
            return Ok(result);
        }

        [HttpGet("UserID/{UserID}")]
        public async Task<IActionResult> GetProductsByUserID(string UserID)
        {
            _logger.LogInformation($"Get products owned by User with ID {UserID}");
            var command = new GetProductsByUserIDQuery()
            {
                UserID = UserID
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
