namespace TechShop.Services
{
    using System.Collections.Generic;
    using TechShop.Data.Models;

    public interface ICategoryService
    {
        Category ById(int id);

        List<Product> GetProducts(int id);
    }
}
