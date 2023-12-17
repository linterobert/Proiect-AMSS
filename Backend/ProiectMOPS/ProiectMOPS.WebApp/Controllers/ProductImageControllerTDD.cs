using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ProiectMOPS.Applications.Commands.ProductCommands;
using ProiectMOPS.Applications.Queries.ProductQueries;
using ProiectMOPS.Domain.DTOs;
using ProiectMOPS.Domain.Models;
using ProiectMOPS.Infrastructure.Repositories;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProiectMOPS.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImageControllerTDD : ControllerBase
    {
        private readonly ProductImageRepository _repository;
        public ProductImageControllerTDD(ProductImageRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProductImages()
        {
            var products = await _repository.GetAllProductImages();

            var productsToReturn = new List<ProductImageDTO_TDD>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductImageDTO_TDD(product));
            }

            return Ok(productsToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductImageById(int id)
        {
            var product = await _repository.GetProductImageById(id);

            ProductImageDTO_TDD productToReturn = new ProductImageDTO_TDD(product);

            return Ok(productToReturn);
        }

        [HttpDelete("UserID/{UserID}")]
        public async Task<IActionResult> GetProductsImagesByProductID(int ProductID)
        {
            var products = await _repository.GetProductImagesByProductID(ProductID);

            var productsToReturn = new List<ProductImageDTO_TDD>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductImageDTO_TDD(product));
            }

            return Ok(productsToReturn);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductImage(int id)
        {
            var Product = await _repository.GetByIdAsync(id);

            if (Product == null)
            {
                return NotFound("Product does not exist!");
            }

            _repository.Delete(Product);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImage(ProductImageDTO_TDD dto)
        {
            ProductImage newProductImage = new ProductImage();
            newProductImage.ProductID = dto.ProductID;
            newProductImage.URL = dto.URL;

            _repository.Create(newProductImage);

            await _repository.SaveAsync();


            return Ok(new ProductImageDTO_TDD(newProductImage));
        }
    }
}
