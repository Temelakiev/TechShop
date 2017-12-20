namespace TechShop.Web.Models.Product
{
    using System.Collections.Generic;
    using TechShop.Data.Models;

    public class ProductInCategoryViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
