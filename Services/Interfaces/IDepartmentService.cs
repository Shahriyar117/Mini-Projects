﻿using EmployeeDirectory.ViewModel;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task AddAsync(DepartmentViewModel department);
        Task RemoveAsync(int id);
        Task UpdateAsync(DepartmentViewModel department);
    }
}
