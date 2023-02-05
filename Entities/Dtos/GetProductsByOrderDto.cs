using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetProductsByOrderDto
    {
        public int OrderId { get; set; }
        public List<GetProductDto> Products { get; set; }
    }
}
