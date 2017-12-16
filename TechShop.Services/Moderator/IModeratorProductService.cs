namespace TechShop.Services.Moderator
{
    using System.Threading.Tasks;
    using TechShop.Data.Models;

    public interface IModeratorProductService
    {
        Task CreateAsync(string imageUrl, string name, decimal price, string description, int quantity, int id);

        Product ById(int id);
    }
}
