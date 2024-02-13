using ExcelQrProject.Model.Dto;
using ExcelQrProject.Model.Models;

namespace ExcelQrProject.Service.Interface
{
    public interface IExcelService
    {
        List<Employee> ProcessExcelFile(Stream excelStream);

        List<Employee> GetAllEmployees();
        EmployeeGetDto GetEmployeeById(int employeeId);

    }
}
