using EmployeeDirectory.DbContext;
using EmployeeDirectory.Models;
using EmployeeDirectory.Repositories.Interfaces;

namespace EmployeeDirectory.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
