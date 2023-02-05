using DataAccess.Models;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Abstract
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        Task<Employee> Add(Employee employee);
        Task<List<GetAllEmployeesDto>> GetAllEmployees();
        Task<GetEmployeeTerritoriesDto> GetEmployeeTerritories(int employeeId);
        Task<List<GetOrderDetailsDto>> GetEmployeeOrders(int employeeId);
    }
}
