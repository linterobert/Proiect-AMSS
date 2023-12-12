namespace ProiectMOPS.Domain.Models
{
    public class ProductImage
    {
        public int ProductImageID { get; set; }
        public string URL { get; set; }
        public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
