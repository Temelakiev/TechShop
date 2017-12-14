namespace TechShop.Web.Areas.Admin.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Services.Admin;
    using TechShop.Services.Admin.Models;

    public class CategoriesController : BaseAdminController
    {
        private readonly IAdminCategoryService categoties;

        public CategoriesController(IAdminCategoryService categoties)
        {
            this.categoties = categoties;
        }

        public async Task<IActionResult> Index()
            => View(await categoties.AllAsync());

        public IActionResult Create()
            => View();

        [HttpPost]
        public async Task<IActionResult> Create(AdminCategoryModel model)
        {
            await this.categoties.CreateAsync(model.Name, model.PictureUrl);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            if (!this.categoties.IsExists(id))
            {
                return NotFound();
            }

            var category = this.categoties.ById(id);

            return View(new AdminCategoryModel
            {
                Id=id,
                Name=category.Name,
                PictureUrl=category.PictureUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id,AdminCategoryModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            await this.categoties.EditAsync(id, model.Name,model.PictureUrl);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id) => View(id);
        
        public async Task<IActionResult> Remove(int id)
        {
            var category = this.categoties.ById(id);

            if (category == null)
            {
                return NotFound();
            }

            await this.categoties.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}