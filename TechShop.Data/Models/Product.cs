namespace TechShop.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class Product
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ProductNameMinLength)]
        [MaxLength(ProductNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(ProductDescriptionMinLength)]
        [MaxLength(ProductDescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [Range(5,10000)]
        public decimal Price { get; set; }

        [Required]
        [Range(0,1000)]
        public int Quantity { get; set; }

        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<Comment> Comments { get; set; } = new List<Comment>();

        public List<ProductOrder> Orders { get; set; } = new List<ProductOrder>();
    }
}
