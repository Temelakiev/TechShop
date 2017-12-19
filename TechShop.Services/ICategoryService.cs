namespace TechShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data.Models;
    using TechShop.Services.Models.Categories;

    public interface ICategoryService
    {
        Category ById(int id);

        List<Product> GetProducts(int id);

        Task<int> TotalAsync(int categoryId);

        Task<IEnumerable<ProductListingsServiceModel>> AllAsync(int id,int page);
    }
}
