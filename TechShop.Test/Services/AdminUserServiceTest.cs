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

    public class AdminUserServiceTest
    {

        [Fact]
        public async Task CategoryById()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstUser = new User { Id = "first", Name = "First" };
            var secondUser = new User { Id = "second", Name = "Second" };
            var thirdUser = new User { Id = "third", Name = "Third" };

            db.AddRange(firstUser, secondUser, thirdUser);

            await db.SaveChangesAsync();

            var adminUserService = new AdminUserService(db);
            // Act
            var result = await adminUserService.AllAsync();


            // Assert
            result
                .Should()
                .HaveCount(3);

        }

        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
