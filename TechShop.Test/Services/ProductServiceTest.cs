namespace TechShop.Test.Services
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Implementations.Products;
    using Xunit;

    public class ProductServiceTest
    {

        [Fact]
        public async Task GetComments()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstComment = new Comment { Id = 1, Content = "First",ProductId=1 };
            var secondComment = new Comment { Id = 2, Content = "Second",ProductId=2 };
            var thirdComment = new Comment { Id = 3, Content = "Third",ProductId=1 };

            var product = new Product { Id = 1, Name = "product" };

            db.AddRange(firstComment, secondComment, thirdComment,product);

            await db.SaveChangesAsync();

            var productService = new ProductService(db);
            // Act
            var result = productService.GetComments(1);


            // Assert
            result
                .Should()
                .HaveCount(2);
        }

        [Fact]
        public async Task ById()
        {
            // Arrange
            var db = this.GetDatabase();


            var firstProduct = new Product { Id = 1, Name = "firstProduct" };
            var secondProduct = new Product { Id = 2, Name = "secondProduct" };

            db.AddRange(firstProduct,secondProduct);

            await db.SaveChangesAsync();

            var productService = new ProductService(db);
            // Act
            var result = productService.ById(1);


            // Assert
            result.Name
                .Should()
                .Equals("firstProduct");
        }


        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
