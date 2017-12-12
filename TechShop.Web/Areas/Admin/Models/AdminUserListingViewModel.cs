namespace TechShop.Web.Areas.Admin.Models
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using TechShop.Services.Admin.Models;

    public class AdminUserListingViewModel
    {
        public IEnumerable<AdminUserListingModel> Users { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}
