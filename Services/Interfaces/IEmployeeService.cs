using EmployeeDirectory.ViewModel;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<EmployeeViewModel>> GetAllAsync();
        Task<EmployeeViewModel> GetByIdAsync(int id);
        Task AddAsync(EmployeeViewModel employee);
        Task RemoveAsync(int id);
        Task UpdateAsync(EmployeeViewModel employee);
    }
}
