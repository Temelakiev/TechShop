namespace TechShop.Test.Services
{
    using FluentAssertions;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Admin.Implementations;
    using Xunit;

    public class AdminCategoryServiceTest
    {

        [Fact]
        public async Task ShowingAllCategories()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstCategory = new Category { Id = 1, Name = "First" };
            var secondCategory = new Category { Id = 2, Name = "Second" };
            var thirdCategory = new Category { Id = 3, Name = "Third" };

            db.AddRange(firstCategory, secondCategory, thirdCategory);

            await db.SaveChangesAsync();

            var adminCategoryService = new AdminCategoryService(db);
            // Act
            var result = await adminCategoryService.AllAsync();


            // Assert
            result
                .Should()
                .HaveCount(3);

        }

        [Fact]
        public async Task CategoryById()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstCategory = new Category { Id = 1, Name = "First" };
            var secondCategory = new Category { Id = 2, Name = "Second" };
            var thirdCategory = new Category { Id = 3, Name = "Third" };

            db.AddRange(firstCategory, secondCategory, thirdCategory);

            await db.SaveChangesAsync();

            var adminCategoryService = new AdminCategoryService(db);
            // Act
            var result = adminCategoryService.ById(3);


            // Assert
            result
                .Name
                .Should()
                .Equals("Third");

        }

        [Fact]
        public async Task CreatingCategories()
        {
            // Arrange
            var db = this.GetDatabase();


            var adminCategoryService = new AdminCategoryService(db);
            // Act
            await adminCategoryService.CreateAsync("test", "https://test");

            var result = await adminCategoryService.AllAsync();


            // Assert
            result
                .Should()
                .HaveCount(1);

        }

        [Fact]
        public async Task EditCategory()
        {
            // Arrange
            var db = this.GetDatabase();

            var category = new Category { Id = 1, Name = "test", PictureUrl = "https://test" };

            db.Add(category);

            await db.SaveChangesAsync();

            var adminCategoryService = new AdminCategoryService(db);
            // Act

            await adminCategoryService.EditAsync(1, "changed", "https://changed");

            await db.SaveChangesAsync();

            var result = adminCategoryService.ById(1);


            // Assert
            result
                .Name
                .Should()
                .Equals("changed");

        }

        [Fact]
        public async Task DeleteCategory()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstCategory = new Category { Id = 1, Name = "test1" };
            var secondCategory = new Category { Id = 2, Name = "test2" };
            var thirdCategory = new Category { Id = 3, Name = "test3" };

            db.AddRange(firstCategory,secondCategory,thirdCategory);

            await db.SaveChangesAsync();

            var adminCategoryService = new AdminCategoryService(db);
            // Act

            await adminCategoryService.Delete(1);

            await db.SaveChangesAsync();

            var result =await adminCategoryService.AllAsync();


            // Assert
            result
                .Should()
                .HaveCount(2);

        }

        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
