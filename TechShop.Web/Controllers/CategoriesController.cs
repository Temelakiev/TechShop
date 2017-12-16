namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using TechShop.Services;
    using TechShop.Web.Models.Category;
    using TechShop.Web.Models.Product;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public IActionResult Details(int id)
        {
            var category = this.categories.ById(id);

            if (category==null)
            {
                return NotFound();
            }

            var products = this.categories.GetProducts(id);

            return View(new CategoryDetailsViewModel
            {
                Id=id,
                Name=category.Name,
                Products= products
            });
        }
    }
}