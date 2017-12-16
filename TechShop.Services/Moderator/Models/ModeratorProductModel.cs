namespace TechShop.Services.Moderator.Models
{
    public class ModeratorProductModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public int Category { get; set; }
    }
}
