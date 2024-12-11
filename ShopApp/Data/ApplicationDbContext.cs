using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShopApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Cart> Carts { get; set; } 
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // adds admin and user roles
            modelBuilder.Entity<IdentityRole>().HasData(
                    new IdentityRole { Name = "User", NormalizedName = "User".ToUpper() },
                         new IdentityRole
                        {
                             Name = "Administrator",
                            NormalizedName = "Administrator".ToUpper()
                            });


            // User Constraints
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique(); // Ensure unique email addresses

            // Product-Category Relationship
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            // Order-User Relationship
            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.User)
            //    .WithMany()
            //    .HasForeignKey(o => o.UserId);
            //
            //// OrderItem Relationships
            //modelBuilder.Entity<OrderProduct>()
            //    .HasOne(oi => oi.Order)
            //    .WithMany(o => o.OrderProducts)
            //    .HasForeignKey(oi => oi.OrderId);
            //
            //modelBuilder.Entity<OrderProduct>()
            //    .HasOne(oi => oi.Product)
            //    .WithMany()
            //    .HasForeignKey(oi => oi.ProductId);


            //seeding data;

            //var category = new Category { Name = "Electronics" };

            //modelBuilder.Entity<Category>().HasData(
            //    category
            //);

            //modelBuilder.Entity<Product>().HasData(
            //    new Product { Name = "Laptop", Price = 1000.00m, Description = "Laptop" , CategoryId = category.Id }
            //);

        }
    }
}
