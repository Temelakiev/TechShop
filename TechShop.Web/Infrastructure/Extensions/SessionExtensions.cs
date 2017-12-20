namespace TechShop.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System;

    public static class SessionExtensions
    {
        private const string ShoppingCartIdString = "Shopping_Cart_Id";

        public static string GetShoppingCartId(this ISession session)
        {
            var shoppingCartId = session.GetString(ShoppingCartIdString);

            if (shoppingCartId == null)
            {
                shoppingCartId = Guid.NewGuid().ToString();
                session.SetString(ShoppingCartIdString, shoppingCartId);
            }

            return shoppingCartId;
        }
    }
}
