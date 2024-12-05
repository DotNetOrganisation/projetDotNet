using Microsoft.AspNetCore.Identity;

namespace ProjetFoodOrder.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
