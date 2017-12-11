namespace TechShop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using static DataConstants;

    public class User : IdentityUser
    {

        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(NameMinLength)]
        [MaxLength(NameMaxLength)]
        public override string Email { get; set; }

        [Range(5,99)]
        public int Age { get; set; }

        [MinLength(AddressMinLength)]
        [MaxLength(AddressMaxLength)]
        public string Address { get; set; }

        public List<Order> Orders { get; set; } = new List<Order>();

        public List<Comment> Comments { get; set; } = new List<Comment>();

    }
}
