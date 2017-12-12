namespace TechShop.Services.Admin
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Services.Admin.Models;

    public interface IAdminUserService
    {
        Task<IEnumerable<AdminUserListingModel>> AllAsync();
    }
}
