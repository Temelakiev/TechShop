using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace TechShop.Services.Admin.Implementations
{
    using System.Threading.Tasks;
    using TechShop.Data;
    using TechShop.Services.Admin.Models;

    public class AdminUserService : IAdminUserService
    {
        private readonly TechShopDbContext db;

        public AdminUserService(TechShopDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<AdminUserListingModel>> AllAsync()
            => await this.db.Users.ProjectTo<AdminUserListingModel>().ToListAsync();
    }
}
