namespace TechShop.Services.Implementations.Categories
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Models.Categories;
    using static ServiceConstants;

    public class CategoryService : ICategoryService
    {
        private readonly TechShopDbContext db;

        public CategoryService(TechShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<ProductListingsServiceModel>> Find(string searchText)
        {
            searchText = searchText ?? string.Empty;

            return await this.db
            .Products
            .OrderBy(p => p.Name)
            .Where(p => p.Name.ToLower().Contains(searchText.ToLower()) || p.Name.ToLower()==searchText.ToLower())
            .ProjectTo<ProductListingsServiceModel>()
            .ToListAsync();
        }

        public async Task<IEnumerable<ProductListingsServiceModel>> AllAsync(int id, int page)
             => await this.db
            .Products
            .Where(p => p.CategoryId == id)
            .OrderBy(p => p.Name)
            .Skip((page - 1) * CategoryProductsPageSize)
            .Take(CategoryProductsPageSize)
            .ProjectTo<ProductListingsServiceModel>()
            .ToListAsync();


        public Category ById(int id)
            => this.db.Categories.Where(c => c.Id == id).FirstOrDefault();

        public List<Product> GetProducts(int id)
            => this.db.Products
            .Where(p => p.CategoryId == id)
            .ToList();

        public async Task<int> TotalAsync(int categoryId)
            => await this.db.Products.Where(p => p.CategoryId == categoryId).CountAsync();
    }
}
