namespace TechShop.Services
{
    using System.Threading.Tasks;

    public interface ICommentService
    {
        Task CreateAsync(string content, int productId, string authorId);
    }
}
