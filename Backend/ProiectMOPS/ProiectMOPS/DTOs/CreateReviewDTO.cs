namespace ProiectMOPS.Domain.DTOs
{
    public class CreateReviewDTO
    {
        public string Description { get; set; }
        public string UserID { get; set; }
        public int StarNumber { get; set; }
        public int ProductID { get; set; }
    }
}
