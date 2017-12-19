namespace TechShop.Services.Models.Categories
{
    using AutoMapper;
    using LearningSystem.Common.Mapping;
    using TechShop.Common.Mapping;
    using TechShop.Data.Models;

    public class ProductListingsServiceModel : IMapFrom<Product>, IHaveCustomMapping
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public void ConfigureMapping(Profile mapper)
            => mapper
            .CreateMap<Product, ProductListingsServiceModel>()
            .ForMember(p => p.CategoryId, cfg => cfg.MapFrom(p => p.CategoryId));
    }
}
