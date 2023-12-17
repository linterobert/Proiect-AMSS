using ProiectMOPS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMOPS.Domain.DTOs
{
    public class ProductImageDTO_TDD
    {
        public string URL { get; set; }
        public int? ProductID { get; set; }

        public ProductImageDTO_TDD(ProductImage product)
        {
            ProductID = product.ProductID;
            URL = product.URL;
        }

        public ProductImageDTO_TDD() { }
    }
}
