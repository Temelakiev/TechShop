namespace TechShop.Web.Models.Category
{
    using System;
    using System.Collections.Generic;
    using TechShop.Services.Models.Categories;
    using TechShop.Web.Models.Home;
    using static Services.ServiceConstants;

    public class CategoryDetailsViewModel : SearchFormModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ProductListingsServiceModel> Products { get; set; }

        public int TotalProducts { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)this.TotalProducts / CategoryProductsPageSize);

        public int CurrentPage { get; set; }

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage <= 1 ? 1 : this.CurrentPage - 1;

    }
}
