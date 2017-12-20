namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;
    using TechShop.Data.Models;
    using TechShop.Services;
    using TechShop.Services.Html;
    using TechShop.Services.Models.Comments;
    using TechShop.Web.Infrastructure.Extensions;

    public class CommentsController : Controller
    {
        private readonly ICommentService comments;
        private readonly IProductService products;
        private readonly UserManager<User> userManager;
        private readonly IHtmlService html;

        public CommentsController(ICommentService comments, IProductService products, UserManager<User> userManager, IHtmlService html)
        {
            this.comments = comments;
            this.products = products;
            this.userManager = userManager;
            this.html = html;
        }

        public IActionResult PostComment()
            => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostComment(int id, CommentServiceModel model)
        {
            var product = this.products.ById(id);

            if (product == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.Content = this.html.Sanitize(model.Content);

            var authorId = this.userManager.GetUserId(User);

            await this.comments.CreateAsync(model.Content, id, authorId);

            TempData.AddSuccuessMessage($"You comment has been posted!");

            return RedirectToAction(nameof(ProductsController.Details), "Products", new { area = string.Empty, id = id.ToString() });
        }

    }
}