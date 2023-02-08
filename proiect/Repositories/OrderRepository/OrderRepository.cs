using System;
using Microsoft.EntityFrameworkCore;
using proiect.Data;
using proiect.Models;
using proiect.Repositories.GenericRepository;

namespace proiect.Repositories.OrderRepository
{
	public class OrderRepository: GenericRepository<Order>, IOrderRepository
	{
		public OrderRepository(DataBaseContext context):base(context)
		{
		}

        public async Task<IEnumerable<Order>> GetOrderByClientId(Guid clientId)
        {
            return await _context.Orders
                .Join(_context.Users,
                      o => o.ClientId,
                      u => u.Id,
                      (o, u) => new { Order = o, User = u })
                .Where(ord => ord.Order.ClientId == clientId)
                .Select(ord => ord.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetRejectedOrders()
		{
			return await _context.Orders
				.Include(o => o.Client)
				.Where(o => o.IsConfirmed == false)
				.ToListAsync();
		}

        public async Task<Order> AddOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> UpdateOrder(Guid orderId, bool status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            order.IsConfirmed = status;
            _context.Orders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}

