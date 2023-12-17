namespace ProiectMOPS.Domain.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string UserID { get; set; }
        public User User { get; set; }
        public List<ProductImage> Images { get; set; }
        public List<Review> Reviews { get; set; }

        public Product() { }

    }
}
