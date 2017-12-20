namespace TechShop.Data.Models
{
    using static DataConstants;
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class Order
    {
        public int Id { get; set; }

        [Required]
        [MinLength(OrderAddressMinLength)]
        [MaxLength(OrderAddressMaxLength)]
        public string Address { get; set; }

        public decimal TotalPrice { get; set; }

        public string CustomerId { get; set; }

        public User Customer { get; set; }

        public List<ProductOrder> Products { get; set; } = new List<ProductOrder>();
    }
}
