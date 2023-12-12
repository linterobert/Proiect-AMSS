using Microsoft.AspNetCore.Identity;

namespace ProiectMOPS.Domain.Models
{
    public class User : IdentityUser
    {
        public List<Product> Products { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
