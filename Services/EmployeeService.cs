using AutoMapper;
using EmployeeDirectory.Models;
using EmployeeDirectory.Repositories.Interfaces;
using EmployeeDirectory.Services.Interfaces;
using EmployeeDirectory.ViewModel;

namespace EmployeeDirectory.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _EmployeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _EmployeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<List<EmployeeViewModel>> GetAllAsync()
        {
            var employees = await _EmployeeRepository.GetAll();
            return _mapper.Map<List<EmployeeViewModel>>(employees);
        }

        public async Task<EmployeeViewModel> GetByIdAsync(int id)
        {
            var employees = await _EmployeeRepository.GetById(id);
            if (employees == null)
                return null;
            return _mapper.Map<EmployeeViewModel>(employees);
        }

        public async Task RemoveAsync(int id)
        {
            var employees = await _EmployeeRepository.GetById(id);
            _EmployeeRepository.Remove(employees);
            await _EmployeeRepository.SaveChangingAsync();
        }

        public async Task AddAsync(EmployeeViewModel employee)
        {
            var dbEmployee = _mapper.Map<Employee>(employee);
            _EmployeeRepository.Add(dbEmployee);
            await _EmployeeRepository.SaveChangingAsync();
        }
        public async Task UpdateAsync(EmployeeViewModel employee)
        {
            var dbEmployee = _mapper.Map<Employee>(employee);
            _EmployeeRepository.Update(dbEmployee);
            await _EmployeeRepository.SaveChangingAsync();
        }
    }
}
