namespace TechShop.Services.Moderator.Implementations
{
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Admin;

    public class ModeratorProductService : IModeratorProductService
    {
        private readonly TechShopDbContext db;
        private readonly IAdminCategoryService categories;

        public ModeratorProductService(TechShopDbContext db, IAdminCategoryService categories)
        {
            this.db = db;
            this.categories = categories;
        }

        public Product ById(int id)
            => this.db.Products.Where(p => p.Id == id).FirstOrDefault();        

        public async Task CreateAsync(string imageUrl, string name, decimal price, string description, int quantity, int id)
        {
            var product = new Product
            {
                Name = name,
                ImageUrl = imageUrl,
                Price = price,
                Description = description,
                Quantity = quantity,
                CategoryId = id
            };
            this.db.Add(product);
            var category = this.categories.ById(id);
            category.Products.Add(product);
            await this.db.SaveChangesAsync();
            
        }

        public async Task Delete(int id)
        {
            var product = this.ById(id);

            this.db.Remove(product);

            await this.db.SaveChangesAsync();
        }

        public async Task Edit(int id, string name, string imageUrl, decimal price, int quantity, string description)
        {
            var product = this.ById(id);

            product.Name = name;
            product.ImageUrl = imageUrl;
            product.Price = price;
            product.Quantity = quantity;
            product.Description = description;

            this.db.Update(product);

            await this.db.SaveChangesAsync();
        }
    }
}
