namespace TechShop.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data.Models;
    using TechShop.Services.Admin.Models;

    public interface IAdminCategoryService
    {
        Task<IEnumerable<AdminCategoryModel>> AllAsync();

        Task CreateAsync(string name, string pictureUrl);

        Task EditAsync(int id, string name,string pictureUrl);

        bool IsExists(int id);

        Category ById(int id);

        Task Delete(int id);
    }
}
