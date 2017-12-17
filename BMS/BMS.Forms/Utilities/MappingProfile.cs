using AutoMapper;
using BMS.Models;
using WpfApp1.ViewModels;

namespace WpfApp1.Utilities
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, LoginPageViewModel>();
        }
    }
}
