using DataAccess.Models;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IOrderService : IGenericService<Order>
    {
        Task<List<GetProductDto>> GetProductsByOrder(int orderId);
    }
}
