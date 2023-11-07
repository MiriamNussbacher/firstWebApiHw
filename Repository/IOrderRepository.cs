using Entities;

namespace Repositories
{
    public interface IOrderRepository
    {
        Task<Order> createNewOrder(Order order);
    }
}