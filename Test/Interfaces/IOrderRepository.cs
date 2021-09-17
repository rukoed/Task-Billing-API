using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Models;

namespace Test.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();

        Task<Order> GetByIdAsync(int id);

        Task<Receipt> SaveOrderAsync(Order order);

        Task<bool> EditOrder(int id, Order order);

        void DeleteOrder(int id);
    }
}
