using EmployeeDirectory.Models;

namespace EmployeeDirectory.Repositories.Interfaces
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        public IList<Department> GetAllDepartments();
    }
}
