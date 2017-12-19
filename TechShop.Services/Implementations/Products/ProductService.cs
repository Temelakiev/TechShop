namespace TechShop.Services.Implementations.Products
{
    using System.Linq;
    using TechShop.Data;
    using TechShop.Data.Models;

    public class ProductService : IProductService
    {
        private readonly TechShopDbContext db;

        public ProductService(TechShopDbContext db)
        {
            this.db = db;
        }

        public Product ById(int id)
            => this.db.Products.Where(p => p.Id == id).FirstOrDefault();
    }
}
