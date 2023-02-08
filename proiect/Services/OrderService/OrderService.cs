using System;
using AutoMapper;
using proiect.Models;
using proiect.Models.DTOs.OrderDTO;
using proiect.Models.DTOs.ShoeDTO;
using proiect.Repositories.OrderRepository;

namespace proiect.Services.OrderService
{
	public class OrderService: IOrderservice
	{

		private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

		public OrderService(IOrderRepository orderRepository,IMapper mapper)
		{
			_orderRepository = orderRepository;
            _mapper = mapper;
		}

        public async Task<OrderDTO> CreateOrderAsync(OrderDTO order)
        {
            var orderModel = _mapper.Map<Order>(order);
            var addedOrder = await _orderRepository.AddOrder(orderModel);
            return _mapper.Map<OrderDTO>(addedOrder);
        }

        public async Task<OrderDTO> UpdateOrderStatus(OrderDTO order, bool status)
        {
            var orderUpdate = _mapper.Map<Order>(order);
            var updatedOrder = await _orderRepository.UpdateOrder(orderUpdate.Id, status);
            return _mapper.Map<OrderDTO>(updatedOrder);
        }

        public async Task<IEnumerable<OrderDTO>> GetOrderByClientId(Guid clientId)
        {
            var orders = await _orderRepository.GetOrderByClientId(clientId);
            return _mapper.Map<List<OrderDTO>>(orders);
        }

        public async Task<IEnumerable<OrderDTO>> GetRejectedOrders()
        {
            var orders = await _orderRepository.GetRejectedOrders();
            return _mapper.Map<List<OrderDTO>>(orders);
        }
    }
}

