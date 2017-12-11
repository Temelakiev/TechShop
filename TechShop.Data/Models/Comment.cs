namespace TechShop.Data.Models
{
    using static DataConstants;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        public int Id { get; set; }

        [Required]
        [MinLength(ContentMinLength)]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string AuthorId { get; set; }

        public User Author { get; set; }
    }
}
