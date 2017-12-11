namespace TechShop.Web.Models.AccountViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class ExternalLoginModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
