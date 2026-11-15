using LoanTracker.DTOs;

namespace LoanTracker.Services
{
    public interface ICustomerService
    {
        Task<List<CustomerResponse>> GetAllAsync();
    }
}
