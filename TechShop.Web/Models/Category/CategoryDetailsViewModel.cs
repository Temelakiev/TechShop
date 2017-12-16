namespace TechShop.Web.Models.Category
{
    using System.Collections.Generic;
    using TechShop.Data.Models;

    public class CategoryDetailsViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Product> Products { get; set; }

    }
}
