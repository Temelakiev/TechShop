namespace TechShop.Web.Models.Home
{
    using System.Collections.Generic;
    using TechShop.Services.Admin.Models;

    public class HomeIndexViewModel
    {
        public IEnumerable<AdminCategoryModel> Categories { get; set; }
    }
}
