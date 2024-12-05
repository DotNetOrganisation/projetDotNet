using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetFoodOrder.Models;

namespace ProjetFoodOrder.ContextDBConfig
{
    public class FoodDBContext : IdentityDbContext<ApplicationUser>
    {
        
        public FoodDBContext(DbContextOptions<FoodDBContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
