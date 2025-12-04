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

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        base.OnModelCreating(modelBuilder);

    //        // ShoppingList
    //        modelBuilder.Entity<ShoppingList>(entity =>
    //        {
    //            entity.ToTable("ShoppingLists");
    //            entity.HasKey(x => x.Id);

    //            entity.Property(x => x.Name)
    //                .IsRequired()
    //                .HasMaxLength(200);

    //            entity.Property(x => x.CreatedAtUtc)
    //                .IsRequired();
    //        });

    //        // Product
    //        modelBuilder.Entity<Product>(entity =>
    //        {
    //            entity.ToTable("Products");
    //            entity.HasKey(x => x.Id);

    //            entity.Property(x => x.Name)
    //                .IsRequired()
    //                .HasMaxLength(200);

    //            entity.Property(x => x.Quantity)
    //                .IsRequired();

    //            // Relacja: jeden ShoppingList → wiele Products
    //            entity
    //                .HasOne(p => p.ShoppingList)
    //                .WithMany(l => l.Products)
    //                .HasForeignKey(p => p.ShoppingListId)
    //                .OnDelete(DeleteBehavior.Cascade);
    //        });
    //    }
    }
}
