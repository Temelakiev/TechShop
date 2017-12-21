namespace TechShop.Web.Models.Home
{
    using System.Collections.Generic;
    using TechShop.Services.Models.Categories;

    public class SearchViewModel
    {
        public IEnumerable<ProductListingsServiceModel> Products { get; set; } = new List<ProductListingsServiceModel>();

        public string SearchText { get; set; }
    }
}
