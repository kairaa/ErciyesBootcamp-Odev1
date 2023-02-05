using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public class GetOrderDetailsDto
    {
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCountry { get; set; }
        public float Amount { get; set; }
    }
}
