namespace TechShop.Web.Areas.Moderator.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using static WebConstants;

    [Area("Moderator")]
    [Authorize(Roles = ModeratorRole)]
    public class BaseModeratorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}