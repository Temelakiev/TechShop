namespace TechShop.Test.Services
{
    using System;
    using Xunit;
    using FluentAssertions;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using TechShop.Services.Implementations.Categories;
    using TechShop.Data.Models;
    using TechShop.Data;

    public class CategoryServiceTest
    {

        [Fact]
        public async Task FindShouldReturnCorrectResults()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First" };
            var secondProduct = new Product { Id = 2, Name = "Second" };
            var thirdProduct = new Product { Id = 3, Name = "Third" };

            db.AddRange(firstProduct, secondProduct, thirdProduct);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = await categoryService.Find("t");


            // Assert
            result
                .Should()
                .HaveCount(2);

        }

        [Fact]
        public async Task FindShouldReturnCorrectResultsByFullname()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First" };
            var secondProduct = new Product { Id = 2, Name = "Second" };
            var thirdProduct = new Product { Id = 3, Name = "Third" };

            db.AddRange(firstProduct, secondProduct, thirdProduct);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = await categoryService.Find("first");


            // Assert
            result
                .Should()
                .HaveCount(1)
                .And
                .Equals("first");

        }

        [Fact]
        public async Task ProductsPerPageShouldBeEight()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First" ,CategoryId=1};
            var secondProduct = new Product { Id = 2, Name = "Second", CategoryId = 1 };
            var thirdProduct = new Product { Id = 3, Name = "Third" , CategoryId = 1 };
            var fourthProduct = new Product { Id = 4, Name = "Fourth", CategoryId = 1 };
            var fivthProduct = new Product { Id = 5, Name = "Fiveth", CategoryId = 1 };
            var sixthProduct = new Product { Id = 6, Name = "Sixth", CategoryId = 1 };
            var seventhProduct = new Product { Id = 7, Name = "Seventh", CategoryId = 1 };
            var eightProduct = new Product { Id = 8, Name = "Eight", CategoryId = 1 };
            var ninethProduct = new Product { Id = 9, Name = "Nineth", CategoryId = 1 };

            var category = new Category { Id = 1, Name = "firstCategory" };

            db.AddRange(firstProduct, secondProduct, thirdProduct,fourthProduct,fivthProduct,sixthProduct,seventhProduct,eightProduct,ninethProduct,category);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = await categoryService.AllAsync(1,1);


            // Assert
            result
                .Should()
                .HaveCount(8);
        }

        [Fact]
        public async Task PagingTesting()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First", CategoryId = 1 };
            var secondProduct = new Product { Id = 2, Name = "Second", CategoryId = 1 };
            var thirdProduct = new Product { Id = 3, Name = "Third", CategoryId = 1 };
            var fourthProduct = new Product { Id = 4, Name = "Fourth", CategoryId = 1 };
            var fivthProduct = new Product { Id = 5, Name = "Fiveth", CategoryId = 1 };
            var sixthProduct = new Product { Id = 6, Name = "Sixth", CategoryId = 1 };
            var seventhProduct = new Product { Id = 7, Name = "Seventh", CategoryId = 1 };
            var eightProduct = new Product { Id = 8, Name = "Eight", CategoryId = 1 };
            var ninethProduct = new Product { Id = 9, Name = "Nineth", CategoryId = 1 };

            var category = new Category { Id = 1, Name = "firstCategory" };

            db.AddRange(firstProduct, secondProduct, thirdProduct, fourthProduct, fivthProduct, sixthProduct, seventhProduct, eightProduct, ninethProduct, category);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = await categoryService.AllAsync(1, 2);


            // Assert
            result
                .Should()
                .HaveCount(1);
        }

        [Fact]
        public async Task GetProductsForGivenCategory()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First", CategoryId = 1 };
            var secondProduct = new Product { Id = 2, Name = "Second", CategoryId = 1 };
            var thirdProduct = new Product { Id = 3, Name = "Third", CategoryId = 1 };
            var fourthProduct = new Product { Id = 4, Name = "Fourth", CategoryId = 2 };
            var fivthProduct = new Product { Id = 5, Name = "Fiveth", CategoryId = 2 };
            var sixthProduct = new Product { Id = 6, Name = "Sixth", CategoryId = 2 };
            var seventhProduct = new Product { Id = 7, Name = "Seventh", CategoryId = 2 };
            var eightProduct = new Product { Id = 8, Name = "Eight", CategoryId = 2 };
            var ninethProduct = new Product { Id = 9, Name = "Nineth", CategoryId = 2 };

            var firstCategory = new Category { Id = 1, Name = "firstCategory" };
            var secondCategory = new Category { Id = 2, Name = "secondCategory" };

            db.AddRange
                (firstProduct, 
                secondProduct,
                thirdProduct,
                fourthProduct, 
                fivthProduct,
                sixthProduct, 
                seventhProduct,
                eightProduct,
                ninethProduct,
                firstCategory,
                secondCategory);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = categoryService.GetProducts(1);


            // Assert
            result
                .Should()
                .HaveCount(3);
        }

        [Fact]
        public async Task TotalProductsByGivenCategory()
        {
            // Arrange
            var db = this.GetDatabase();

            var firstProduct = new Product { Id = 1, Name = "First", CategoryId = 1 };
            var secondProduct = new Product { Id = 2, Name = "Second", CategoryId = 1 };
            var thirdProduct = new Product { Id = 3, Name = "Third", CategoryId = 1 };
            var fourthProduct = new Product { Id = 4, Name = "Fourth", CategoryId = 2 };
            var fivthProduct = new Product { Id = 5, Name = "Fiveth", CategoryId = 2 };
            var sixthProduct = new Product { Id = 6, Name = "Sixth", CategoryId = 2 };
            var seventhProduct = new Product { Id = 7, Name = "Seventh", CategoryId = 2 };
            var eightProduct = new Product { Id = 8, Name = "Eight", CategoryId = 2 };
            var ninethProduct = new Product { Id = 9, Name = "Nineth", CategoryId = 2 };

            var firstCategory = new Category { Id = 1, Name = "firstCategory" };
            var secondCategory = new Category { Id = 2, Name = "secondCategory" };

            db.AddRange
                (firstProduct,
                secondProduct,
                thirdProduct,
                fourthProduct,
                fivthProduct,
                sixthProduct,
                seventhProduct,
                eightProduct,
                ninethProduct,
                firstCategory,
                secondCategory);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result = await categoryService.TotalAsync(2);


            // Assert
            result
                .Should()
                .Equals(6);
        }

        [Fact]
        public async Task CategotyBYID()
        {
            // Arrange
            var db = this.GetDatabase();

           

            var firstCategory = new Category { Id = 1, Name = "firstCategory" };
            var secondCategory = new Category { Id = 2, Name = "secondCategory" };

            db.AddRange( firstCategory,secondCategory);

            await db.SaveChangesAsync();

            var categoryService = new CategoryService(db);
            // Act
            var result =  categoryService.ById(2);


            // Assert
            result
                .Should()
                .NotBeNull()
                .And
                .Equals(secondCategory);
        }

        private TechShopDbContext GetDatabase()
        {
            var dbOptions = new DbContextOptionsBuilder<TechShopDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            return new TechShopDbContext(dbOptions);
        }
    }
}
