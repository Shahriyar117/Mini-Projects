using AutoMapper;
using EmployeeDirectory.Models;
using EmployeeDirectory.ViewModel;

namespace EmployeeDirectory.Config
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
        }
    }
}
