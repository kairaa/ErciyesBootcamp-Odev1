using DataAccess.Models;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Concrete
{
    public class EmployeeManager : GenericManager<Employee>, IEmployeeService
    {
        private readonly NorthwndErciyesBootcampContext _context;
        public EmployeeManager(NorthwndErciyesBootcampContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee> Add(Employee employee)
        {
            await _context.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<List<GetAllEmployeesDto>> GetAllEmployees()
        {
            return await _context.Employees.Select(e => new GetAllEmployeesDto
            {
                EmployeeId = e.EmployeeId,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title
            }).ToListAsync();
        }

        public async Task<List<GetOrderDetailsDto>> GetEmployeeOrders(int employeeId)
        {
            return await _context.Orders.Include(o => o.OrderDetails)
                .Where(o => o.EmployeeId == employeeId)
                .Select(o => new GetOrderDetailsDto
                {
                    ShipCountry = o.ShipCountry,
                    OrderId = o.OrderId,
                    OrderDate = o.OrderDate.Value,
                    Amount = o.OrderDetails.GroupBy(d => d.OrderId).Select(d => d.Sum(d => (float)(d.UnitPrice * d.Quantity) * (1 - d.Discount))).FirstOrDefault()
                }).ToListAsync();
        }

        public async Task<GetEmployeeTerritoriesDto> GetEmployeeTerritories(int employeeId)
        {
            return await _context.Employees.Include(e => e.Territories)
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => new GetEmployeeTerritoriesDto
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    GetTerritoriesDto = e.Territories.Select(t => new GetTerritoryDto
                    {
                        Id = t.TerritoryId,
                        TerritoryDescription = t.TerritoryDescription
                    }).ToList()
                }).FirstOrDefaultAsync();
        }
    }
}
