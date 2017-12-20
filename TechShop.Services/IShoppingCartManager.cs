namespace TechShop.Services
{
    using System.Collections.Generic;
    using TechShop.Data.Models;
    using TechShop.Services.Models.ShoppingCarts;

    public interface IShoppingCartManager
    {
        void AddToCart(string id, int productId);

        void RemoveFromCart(string id, int productId);

        IEnumerable<CartItem> GetItems(string id);

        void Clear(string id);

        User CurrentUser(string id);
    }
}
