using AutoMapper;
using ExcelQrProject.UI.Dtos;
using ExcelQrProject.UI.Models;

namespace ExcelQrProject.UI.Mapping
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EmployeeViewModel, EmployeeGetDto>().ReverseMap();
        }
    }
}
