namespace TechShop.Services.Implementations.Categories
{
    using System.Collections.Generic;
    using System.Linq;
    using TechShop.Data;
    using TechShop.Data.Models;

    public class CategoryService : ICategoryService
    {
        private readonly TechShopDbContext db;

        public CategoryService(TechShopDbContext db)
        {
            this.db = db;
        }

        public Category ById(int id)
            =>  this.db.Categories.Where(c => c.Id == id).FirstOrDefault();

        public List<Product> GetProducts(int id)
            => this.db.Products
            .Where(p => p.CategoryId == id)
            .ToList();
    }
}
