using System;
using proiect.Models;
using proiect.Models.DTOs.OrderDTO;

namespace proiect.Services.OrderService
{
	public interface IOrderservice
	{
        Task<OrderDTO> CreateOrderAsync(OrderDTO order);
        Task<OrderDTO> UpdateOrderStatus(OrderDTO order, bool status);
        Task<IEnumerable<OrderDTO>> GetOrderByClientId(Guid clientId);
        Task<IEnumerable<OrderDTO>> GetRejectedOrders();
    }
}

