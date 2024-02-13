using AutoMapper;
using ExcelQrProject.Model.Dto;
using ExcelQrProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelQrProject.Model.Mapper
{
    public class EmployeeMapper:Profile
    {
        public EmployeeMapper()
        {
            CreateMap<Employee,EmployeeDto>().ReverseMap();
            CreateMap<Employee,EmployeeGetDto>().ReverseMap();
        }
    }
}
