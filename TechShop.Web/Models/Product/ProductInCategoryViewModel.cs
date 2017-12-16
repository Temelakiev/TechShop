namespace TechShop.Web.Models.Product
{
    using AutoMapper;
    using Data.Models;
    using LearningSystem.Common.Mapping;
    using TechShop.Common.Mapping;

    public class ProductInCategoryViewModel 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        
    }
}
