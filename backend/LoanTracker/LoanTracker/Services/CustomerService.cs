using LoanTracker.Data;
using LoanTracker.DTOs;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace LoanTracker.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly LoanTrackerContext _context;

        public CustomerService(LoanTrackerContext context)
        {
            _context = context;
        }

        public async Task<List<CustomerResponse>> GetAllAsync()
        {
            List<CustomerResponse> customers = await _context.Customers
                .Select(c => new CustomerResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Nik = c.Nik,
                    Income = c.Income
                })
                .ToListAsync();
            return customers;
        }
    }
}
