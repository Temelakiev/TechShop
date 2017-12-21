namespace TechShop.Services.Implementations.ShoppingCarts
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using TechShop.Data;
    using TechShop.Data.Models;
    using TechShop.Services.Models.ShoppingCarts;

    public class ShoppingCartManager : IShoppingCartManager
    {
        private readonly ConcurrentDictionary<string, ShoppingCart> carts;
        private readonly TechShopDbContext db;

        public ShoppingCartManager(TechShopDbContext db)
        {
            this.db = db;
            this.carts = new ConcurrentDictionary<string, ShoppingCart>();
        }

        public void AddToCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.AddToCart(productId);
        }

        public void RemoveFromCart(string id, int productId)
        {
            var shoppingCart = this.GetShoppingCart(id);

            shoppingCart.RemoveFromCart(productId);
        }

        public IEnumerable<CartItem> GetItems(string id)
        {
            var shoppingCart = this.GetShoppingCart(id);

            return new List<CartItem>(shoppingCart.Items);
        }

        public void Clear(string id)
            => this.GetShoppingCart(id).Clear();

        private ShoppingCart GetShoppingCart(string id)
            => this.carts.GetOrAdd(id, new ShoppingCart());

        public User CurrentUser(string id)
            => this.db.Users.Where(u=>u.Id == id).FirstOrDefault();
    }
}
