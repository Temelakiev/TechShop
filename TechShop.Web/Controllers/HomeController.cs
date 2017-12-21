namespace TechShop.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Web.Models;
    using TechShop.Services.Admin;
    using TechShop.Web.Models.Home;
    using System.Threading.Tasks;
    using TechShop.Services;

    public class HomeController : Controller
    {
        private readonly IAdminCategoryService adminCategories;
        private readonly ICategoryService categories;

        public HomeController(IAdminCategoryService adminCategories, ICategoryService categories)
        {
            this.adminCategories = adminCategories;
            this.categories = categories;

        }

        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel
            {
                Categories = await this.adminCategories.AllAsync()
            });

        public async Task<IActionResult> Search(SearchFormModel model)
        {
            if (model.SearchText==string.Empty)
            {
                return View(model);
            }

            var products = await this.categories.Find(model.SearchText);

            var viewModel = new SearchViewModel
            {
                SearchText = model.SearchText,
                Products = products
            };


            return View(viewModel);
        }

            public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
