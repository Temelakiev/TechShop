namespace TechShop.Services.Implementations.Products
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
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

        public List<Comment> GetComments(int id)
            =>  this.db.Comments.Where(c => c.ProductId == id).ToList();
    }
}
