namespace TechShop.Test.Services
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Admin.Implementations;
    using TechShop.Services.Implementations.Categories;
    using TechShop.Services.Moderator.Implementations;
    using Xunit;

    public class ModeratorProductServiceTest
    {
        public ModeratorProductServiceTest()
        {
            TestStartup.Initialize();
        }

        [Fact]
        public async Task CategoryById()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First" };
            var secondProduct = new Product { Id = 2, Name = "Second" };
            var thirdProduct = new Product { Id = 3, Name = "Third" };

            db.AddRange(firstProduct, secondProduct, thirdProduct);

            await db.SaveChangesAsync();

            var categoriesService = new AdminCategoryService(db);
            var moderatorProductService = new ModeratorProductService(db,categoriesService);
            // Act
            var result = moderatorProductService.ById(3);


            // Assert
            result
                .Name
                .Should()
                .Equals("Third");

        }

        [Fact]
        public async Task CreateProduct()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 5, Name = "First" };
            var secondProduct = new Product { Id = 6, Name = "Second" };
            var thirdProduct = new Product { Id = 7, Name = "Third" };
            var category = new Category { Id = 1, Name = "category" };

            db.AddRange(firstProduct, secondProduct, thirdProduct,category);

            await db.SaveChangesAsync();

            var categoriesService = new AdminCategoryService(db);
            var moderatorProductService = new ModeratorProductService(db, categoriesService);
            // Act
             await moderatorProductService.CreateAsync("http://test","test",2.0m,"test description",5,1);

            var result = db.Products.Count();


            // Assert
            result
                .Should()
                .Equals(4);
        }

        [Fact]
        public async Task DeleteProduct()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 5, Name = "First" };
            var secondProduct = new Product { Id = 6, Name = "Second" };
            var thirdProduct = new Product { Id = 7, Name = "Third" };

            db.AddRange(firstProduct, secondProduct, thirdProduct);

            await db.SaveChangesAsync();

            var categoriesService = new AdminCategoryService(db);
            var moderatorProductService = new ModeratorProductService(db, categoriesService);
            // Act
            await moderatorProductService.Delete(5);

            var result = db.Products.Count();


            // Assert
            result
                .Should()
                .Equals(3);
        }

        [Fact]
        public async Task EditProduct()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 5, Name = "First",ImageUrl="http://test",Price =2.0m,Quantity=5,Description="test description" };

            db.AddRange(firstProduct);

            await db.SaveChangesAsync();

            var categoriesService = new AdminCategoryService(db);
            var moderatorProductService = new ModeratorProductService(db, categoriesService);
            // Act
            await moderatorProductService.Edit(5,"changed","http://changed",3.0m,10,"changed description");

            var result = moderatorProductService.ById(5);


            // Assert
            result
                .Name
                .Should()
                .Equals("changed");
        }

        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
