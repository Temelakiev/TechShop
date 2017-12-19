namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services;
    using TechShop.Web.Models.Product;

    public class ProductsController : Controller
    {
        private readonly IProductService products;

        public ProductsController(IProductService products)
        {
            this.products = products;
        }

        public IActionResult Details(int id)
        {
            var product = this.products.ById(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(new ProductInCategoryViewModel
            {
                Id=id,
                ImageUrl=product.ImageUrl,
                Name=product.Name,
                Description=product.Description,
                Price=product.Price,
                Quantity=product.Quantity
            });
        }
    }
}