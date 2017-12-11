namespace TechShop.Data.Models
{
    using static DataConstants;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MinLength(CategoryNameMinLength)]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; }

        [MinLength(PictureUrlMinLength)]
        [MaxLength(PictureUrlMaxLength)]
        public string PictureUrl { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
    }
}
