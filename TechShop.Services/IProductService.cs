namespace TechShop.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using TechShop.Data.Models;

    public interface IProductService
    {
        Product ById(int id);

        List<Comment> GetComments(int id);
    }
}
