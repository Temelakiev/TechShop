namespace TechShop.Services.Moderator.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ModeratorProductModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        public int Category { get; set; }
    }
}
