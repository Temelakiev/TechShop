namespace TechShop.Services
{
    using TechShop.Data.Models;

    public interface IProductService
    {
        Product ById(int id);
    }
}
