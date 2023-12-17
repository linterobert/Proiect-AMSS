using ProiectMOPS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMOPS.Domain.DTOs
{
    public class ProductDTO_TDD
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UserID { get; set; }

        public ProductDTO_TDD(Product product) { 
            ProductID = product.ProductID;
            Price = product.Price;
            Name = product.Name;
            Description = product.Description;
            CreateTime = DateTime.Now;
            UpdateTime = DateTime.Now;
            UserID = product.UserID;
        }

        public ProductDTO_TDD() { }
    }
}
