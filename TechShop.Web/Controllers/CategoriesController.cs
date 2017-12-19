namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechShop.Services;
    using TechShop.Web.Models.Category;

    public class CategoriesController : Controller
    {
        private readonly ICategoryService categories;

        public CategoriesController(ICategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Details(int id,int page=1)
        {
            var category = this.categories.ById(id);

            if (category==null)
            {
                return NotFound();
            }

            return View(new CategoryDetailsViewModel
            {
                Id = id,
                Name = category.Name,
                Products = await this.categories.AllAsync(id,page),
                TotalProducts = await this.categories.TotalAsync(id),
                CurrentPage=page
            });
        }
    }
}