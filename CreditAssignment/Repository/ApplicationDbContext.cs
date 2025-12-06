using CreditAssignment.Models;
using Microsoft.EntityFrameworkCore;

namespace CreditAssignment.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
        
        }

        public DbSet<ShoppingList> ShoppingLists { get; init; }
        public DbSet<Product> Products { get; init; }
    }
}
