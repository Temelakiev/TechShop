namespace TechShop.Test.Services
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Implementations.Comments;
    using TechShop.Services.Implementations.Products;
    using Xunit;

    public class CommentServiceTest
    {

        [Fact]
        public async Task CreatingComments()
        {
            // Arrange

            var db = this.GetDatabase();

            var product = new Product { Id = 1, Name = "product" };
            var author = new User { Id = "first", Name = "author" };

            db.AddRange(product, author);
            await db.SaveChangesAsync();

            var productService = new ProductService(db);
            var commentService = new CommentService(db,productService);

            // Act

            var createdProduct = commentService.CreateAsync("test", product.Id, author.Id);
            var result = db.Comments.Select(c=>c.Content).FirstOrDefault();

            // Assert

            result
                .Should()
                .Equals("test");
        }

        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
