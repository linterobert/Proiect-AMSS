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
    public class ProductControllerTDD : ControllerBase
    {
        private readonly ProductRepository _repository;
        public ProductControllerTDD(ProductRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _repository.GetAllProducts();

            var productsToReturn = new List<ProductDTO_TDD>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductDTO_TDD(product));
            }

            return Ok(productsToReturn);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _repository.GetProductByID(id);

            ProductDTO_TDD productToReturn = new ProductDTO_TDD(product);

            return Ok(productToReturn);
        }

        [HttpDelete("UserID/{UserID}")]
        public async Task<IActionResult> GetProductsByUserID(string UserID)
        {
            var products= await _repository.GetProductsByUserID(UserID);

            var productsToReturn = new List<ProductDTO_TDD>();

            foreach (var product in products)
            {
                productsToReturn.Add(new ProductDTO_TDD(product));
            }

            return Ok(productsToReturn);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
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
        public async Task<IActionResult> CreateProduct(ProductDTO_TDD dto)
        {
            Product newProduct = new Product();

            newProduct.Name = dto.Name;
            newProduct.Description = dto.Description;
            newProduct.Price = dto.Price;
            newProduct.CreateTime = DateTime.Now;
            newProduct.UpdateTime = DateTime.Now;
            newProduct.UserID = dto.UserID;

            _repository.Create(newProduct);

            await _repository.SaveAsync();


            return Ok(new ProductDTO_TDD(newProduct));
        }

        [HttpPut("UpdateForForm")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product)
        {
            var array_product = await _repository.GetAllProducts();

            var productIndex = array_product.FindIndex((Product _product) => _product.ProductID.Equals(product.ProductID));

            array_product[productIndex] = product;

            return Ok(array_product);
        }
    }
}
