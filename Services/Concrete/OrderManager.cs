using DataAccess.Models;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class OrderManager : GenericManager<Order>, IOrderService
    {
        private readonly NorthwndErciyesBootcampContext _context;
        public OrderManager(NorthwndErciyesBootcampContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<GetProductDto>> GetProductsByOrder(int orderId)
        {
            //var query = (from o in _context.OrderDetails
            //             join p in _context.Products
            //             on o.ProductId equals p.ProductId
            //             where o.OrderId == orderId
            //             select new GetProductDto
            //             {
            //                 Quantity = o.Quantity,
            //                 ProductName = p.ProductName
            //             }).ToListAsync();
            //return query;
            return await _context.OrderDetails.Include(a => a.Product)
                .Where(o => o.OrderId == orderId)
                .Select(o => new GetProductDto
                {
                    ProductName = o.Product.ProductName,
                    Quantity = o.Quantity
                }).ToListAsync();
        }
    }
}
