namespace TechShop.Data
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using TechShop.Data.Models;

    public class TechShopDbContext : IdentityDbContext<User>
    {
        public TechShopDbContext(DbContextOptions<TechShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
                

            builder
                .Entity<Product>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Product)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany(c => c.Orders)
                .HasForeignKey(o => o.CustomerId);

            builder
                .Entity<ProductOrder>()
                .HasKey(po => new { po.OrderId, po.ProductId });

            builder
                .Entity<ProductOrder>()
                .HasOne(po => po.Order)
                .WithMany(po => po.Products)
                .HasForeignKey(o => o.OrderId);

            builder
                .Entity<ProductOrder>()
                .HasOne(po => po.Product)
                .WithMany(po => po.Orders)
                .HasForeignKey(p => p.ProductId);

            builder
                .Entity<User>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);

            base.OnModelCreating(builder);
           
        }
    }
}
