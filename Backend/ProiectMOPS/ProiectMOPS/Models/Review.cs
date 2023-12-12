namespace ProiectMOPS.Domain.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public DateTime CreatedTime { get; set; }  
        public DateTime UpdatedTime { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }  
        public int StarNumber { get; set; }
        public User User { get; set; }
        public int? ProductID { get; set; }
        public Product Product { get; set; }
    }
}
