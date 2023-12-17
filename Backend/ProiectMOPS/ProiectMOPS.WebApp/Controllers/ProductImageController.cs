using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectMOPS.Applications.Commands.ProductImageCommands;
using ProiectMOPS.Applications.Queries.ProductImageQueries;
using ProiectMOPS.Domain.DTOs;

namespace ProiectMOPS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageController: ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public ProductImageController(IMediator mediator, ILogger<ProductImageController> logger, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDTO dto, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Create image for product with ID {dto.ProductID}");
            var command = _mapper.Map<CreateProductImageCommand>(dto);
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
            {
                _logger.LogInformation("Product not found!");
                return NotFound("Product not found");
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Delete product image with ID {id}");
            var command = new DeleteProductImageCommand
            {
                ProductImageID = id
            };
            var result = await _mediator.Send(command, cancellationToken);
            if (result == null)
            {
                _logger.LogError("Product image not found");
                return NotFound("Product image not found");
            }
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetProductImages()
        {
            _logger.LogInformation("Get product images");
            var query = new GetProductImagesQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByID(int id)
        {
            _logger.LogInformation($"Get product image with ID {id}");
            var command = new GetProductImageByIDQuery()
            {
                ProductImageID = id
            };
            var result = await _mediator.Send(command);
            if (result == null)
            {
                _logger.LogError("Product image not found");
                return NotFound("Product image not found");
            }
            return Ok(result);
        }

        [HttpGet("ProductID/{ProductID}")]
        public async Task<IActionResult> GetProductImagesByProductID(int ProductID)
        {
            _logger.LogInformation($"Get product images for Product with ID {ProductID}");
            var command = new GetProductImagesByProductIDQuery()
            {
                ProductID = ProductID
            };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
