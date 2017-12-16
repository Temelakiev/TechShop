namespace TechShop.Web.Controllers
{
    using System.Diagnostics;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Web.Models;
    using TechShop.Services.Admin;
    using TechShop.Web.Models.Home;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        private readonly IAdminCategoryService categories;

        public HomeController(IAdminCategoryService categories)
        {
            this.categories = categories;
        }

        public async Task<IActionResult> Index()
            => View(new HomeIndexViewModel
            {
                Categories = await this.categories.AllAsync()
            });
        
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
