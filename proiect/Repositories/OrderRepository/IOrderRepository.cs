using System;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.OrderRepository
{
	public interface IOrderRepository: IGenericRepository<Order>
	{
        Task<IEnumerable<Order>> GetOrderByClientId(Guid clientId);
        Task<IEnumerable<Order>> GetRejectedOrders();
        Task<Order> AddOrder(Order order);
        Task<Order> UpdateOrder(Guid orderId, bool status);
    }
}

