namespace TechShop.Services.Admin.Implementations
{
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Admin.Models;

    public class AdminCategoryService : IAdminCategoryService
    {
        private readonly TechShopDbContext db;

        public AdminCategoryService(TechShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminCategoryModel>> AllAsync()
            => await this.db.Categories
            .OrderBy(c => c.Id)
            .ProjectTo<AdminCategoryModel>()
            .ToListAsync();

        public Category ById(int id)
            => this.db.Categories.Where(c => c.Id == id).FirstOrDefault();

        public async Task CreateAsync(string name,string pictureUrl)
        {
            var category = new Category
            {
                Name = name,
                PictureUrl = pictureUrl
            };

            this.db.Add(category);

            await this.db.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var category = this.ById(id);

            this.db.Categories.Remove(category);

            await this.db.SaveChangesAsync();
        }

        public async Task EditAsync(int id,string name,string pictureUrl)
        {
            var category = this.db.Categories.Where(c => c.Id == id).FirstOrDefault();

            category.Name = name;
            category.PictureUrl = pictureUrl;

            await this.db.SaveChangesAsync();
        }

        public bool IsExists(int id)
            =>  this.db.Categories.Any(c=>c.Id==id);
    }
}
