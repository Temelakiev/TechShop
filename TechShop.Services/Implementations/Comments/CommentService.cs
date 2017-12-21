namespace TechShop.Services.Implementations.Comments
{
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Data.Models;

    public class CommentService : ICommentService
    {
        private readonly TechShopDbContext db;
        private readonly IProductService products;

        public CommentService(TechShopDbContext db, IProductService products)
        {
            this.db = db;
            this.products = products;
        }

        public async Task CreateAsync(string content, int productId, string authorId)
        {

            var comment = new Comment
            {
                AuthorId = authorId,
                ProductId = productId,
                Content = content
            };

            this.db.Add(comment);
            var product = this.products.ById(productId);
            product.Comments.Add(comment);
            await this.db.SaveChangesAsync();
        }
    }
}
