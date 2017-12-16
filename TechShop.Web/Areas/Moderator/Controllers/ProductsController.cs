namespace TechShop.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechShop.Services.Admin;
    using TechShop.Services.Moderator;
    using TechShop.Services.Moderator.Models;
    using TechShop.Web.Controllers;
    using TechShop.Web.Infrastructure.Extensions;

    public class ProductsController : BaseModeratorController
    {
        private readonly IModeratorProductService products;
        private readonly IAdminCategoryService categories;

        public ProductsController(IModeratorProductService products, IAdminCategoryService categories)
        {
            this.products = products;
            this.categories = categories;
        }

        public IActionResult CreateProduct()
            => View();

        [HttpPost]
        public async Task<IActionResult> CreateProduct(int id,ModeratorProductModel model)
        {
            var category = this.categories.ById(id);

            if (category==null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
             await this.products
                .CreateAsync(model.ImageUrl, model.Name, model.Price, model.Description, model.Quantity, id);
            TempData.AddSuccuessMessage($"You successfuly create {model.Name} product!");

            return RedirectToAction(nameof(CategoriesController.Details),"Categories",new { area=string.Empty,id = id.ToString() });
        }

        public IActionResult Details(int id)
        {
            var product = this.products.ById(id);

            if (product==null)
            {
                return NotFound();
            }

            return View(new ModeratorProductModel
            {
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                ImageUrl = product.ImageUrl,
                Quantity = product.Quantity,
                Category = product.CategoryId
            });
        }

    }
}