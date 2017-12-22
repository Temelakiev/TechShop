namespace TechShop.Services.Admin.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AdminCategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string PictureUrl { get; set; }
    }
}
