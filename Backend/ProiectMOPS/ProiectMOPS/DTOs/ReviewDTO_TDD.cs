using ProiectMOPS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectMOPS.Domain.DTOs
{
    public class ReviewDTO_TDD
    {
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
        public string Description { get; set; }
        public string UserID { get; set; }
        public int StarNumber { get; set; }
        public int? ProductID { get; set; }

        public ReviewDTO_TDD(Review review) { 
            CreatedTime = DateTime.Now;
            UpdatedTime = DateTime.Now;
            Description = review.Description;
            UserID = review.UserID;
            StarNumber = review.StarNumber;
            ProductID = review.ProductID;
        
        }

        public ReviewDTO_TDD() { }
    }
}
