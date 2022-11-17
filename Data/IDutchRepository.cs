using DutchTreat.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DutchTreat.Data
{
    public interface IDutchRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string category);

        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);

        void AddEntity(object model);
        public bool SaveAll();
    }
}