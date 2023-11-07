using Entities;

namespace Services
{
    public interface IOrderService
    {
        Task<Order> createNewOrder(Order order);
    }
}