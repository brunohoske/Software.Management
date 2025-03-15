using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tablefy.Order.Api.Data;
using Tablefy.Api.Infra;
using Tablefy.Order.Api.Order.Entities;
using Tablefy.Order.Api.Order.Models;

namespace Tablefy.Order.Api.Order.Services
{
    public class OrderService
    {
        private readonly TablefyOrderContext _context;
        private readonly IMapper _mapper;

        public OrderService(TablefyOrderContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<OrderCreateResponseModel> CreateOrder(OrderCreateModel order)
        {
            if (order.OrderItems.Any(i => i.Discount > i.UnitPrice * i.Quantity))
                throw new BusinessException("Item discount cannot be greater or equal the item value.");
            order.OrderItems.ForEach(i => i.Total = i.UnitPrice * i.Quantity - i.Discount);
            order.Subtotal = order.OrderItems.Sum(x => x.Total);
            if (order.Discount >= order.Subtotal)
                throw new BusinessException("Cannot apply a discount greater or equal the order value.");
            order.Total = order.Subtotal - order.Discount;
            var entity = _mapper.Map<OrderEntity>(order);
            using var transaction =_context.Database.BeginTransaction();
            var lastOrderNumber = await _context.Orders.Where(x => x.CompanyId == order.CompanyId).OrderByDescending(x => x.Id).Select(x => x.OrderNumber).FirstOrDefaultAsync();
            entity.OrderNumber = lastOrderNumber + 1 >= 1000 ? 1 : lastOrderNumber + 1;
            await _context.Orders.AddAsync(entity);
            await _context.SaveChangesAsync();
            transaction.Commit();
            return new OrderCreateResponseModel { OrderId = entity.Id, OrderTotal = order.Total, OrderNumber = entity.OrderNumber };
        }
        public async Task<List<OrderDisplayModel>> GetOrdersByTable(int companyId,int tableId)
        {
            var ordersDisplay = await _context.Orders
            .Where(o => o.TableId == tableId && o.CompanyId == companyId)
            .Select(o => new OrderDisplayModel
            {
                OrderNumber = o.OrderNumber,
                Discount = o.Discount,
                Total = o.Total,
                Items = o.OrderItems.Select(i => new OrderItemDisplayModel
                {
                    ProductName = i.ProductName,
                    ImageUrl = i.TempImage,
                    Total = i.Total,
                    Notes = i.Notes
                }).ToList()
            }).ToListAsync();
            return ordersDisplay;
        }
    }
}
