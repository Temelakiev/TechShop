namespace TechShop.Web.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services;
    using Infrastructure.Extensions;
    using System.Linq;
    using System;
    using System.Collections.Generic;
    using TechShop.Services.Models.ShoppingCarts;
    using TechShop.Web.Models.ShoppingCart;
    using Microsoft.AspNetCore.Authorization;

    public class ShoppingCartController : Controller
    {
        private readonly IShoppingCartManager shoppingCartManager;
        private readonly TechShopDbContext db;
        private readonly UserManager<User> userManager;

        public ShoppingCartController(IShoppingCartManager shoppingCartManager, TechShopDbContext db, UserManager<User> userManager)
        {
            this.shoppingCartManager = shoppingCartManager;
            this.db = db;
            this.userManager = userManager;
        }

        public IActionResult Items()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemIds = items.Select(i => i.ProductId);

            var itemsWithDetails = this.GetCartItems(items);

            return View(itemsWithDetails);
        }

        public IActionResult AddToCart(int id)
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            this.shoppingCartManager.AddToCart(shoppingCartId, id);

            return RedirectToAction(nameof(Items));
        }

        [Authorize]
        public IActionResult FinishOrder()
        {
            var shoppingCartId = this.HttpContext.Session.GetShoppingCartId();

            var items = this.shoppingCartManager.GetItems(shoppingCartId);

            var itemsWithDetails = this.GetCartItems(items);

            var customer = this.shoppingCartManager.CurrentUser(this.userManager.GetUserId(User));

            var order = new Order
            {
                CustomerId = customer.Id,
                Address = customer.Address,
                TotalPrice = itemsWithDetails.Sum(i => i.Price * i.Quantity)
            };

            foreach (var item in itemsWithDetails)
            {
                order.Products.Add(new ProductOrder
                {
                    ProductId = item.ProductId,
                    ProductPrice = item.Price,
                    Quantity = item.Quantity,
                });
            }

            this.db.Add(order);
            this.db.SaveChanges();

            shoppingCartManager.Clear(shoppingCartId);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        private List<CartItemViewModel> GetCartItems(IEnumerable<CartItem> items)
        {
            var itemIds = items.Select(i => i.ProductId);

            var itemsWithDetails = this.db
                .Products
                .Where(p => itemIds.Contains(p.Id))
                .Select(p => new CartItemViewModel
                {
                    ProductId = p.Id,
                    Title = p.Name,
                    Price = p.Price
                })
                .ToList();

            var itemQuantities = items.ToDictionary(i => i.ProductId, i => i.Quantity);

            itemsWithDetails.ForEach(i => i.Quantity = itemQuantities[i.ProductId]);

            return itemsWithDetails;
        }
    }
}