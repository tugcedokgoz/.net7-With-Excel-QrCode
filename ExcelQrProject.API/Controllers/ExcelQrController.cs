using ExcelQrProject.Model.Dto;
using ExcelQrProject.Model.Models;
using ExcelQrProject.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ExcelQrProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelQrController : ControllerBase
    {
        private readonly IExcelService _excelService;

        public ExcelQrController(IExcelService excelService)
        {
            _excelService = excelService;
        }

        [HttpPost("Upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length <= 0)
                return BadRequest("Invalid file.");

            // Create folder for uploaded Excel files if not exists
            var excelFolder = Path.Combine(Directory.GetCurrentDirectory(), "UploadedExcel");
            if (!Directory.Exists(excelFolder))
                Directory.CreateDirectory(excelFolder);

            // Path for uploaded Excel file
            var excelFilePath = Path.Combine(excelFolder, file?.FileName);
            using (var stream = new FileStream(excelFilePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);

                // Process Excel file and get employees
                var employees = _excelService.ProcessExcelFile(stream);

                return Ok(employees);
            }
        }

        [HttpGet("GetAllEmployees")]
        public IActionResult GetAllEmployees()
        {
            var employees = _excelService.GetAllEmployees();
            var employeeDtos = employees.Select(e => new EmployeeDto
            {
                Name = e.Name,
                Surname = e.Surname,
                QrcodePath = e.QrcodePath
            }).ToList();

            return Ok(employeeDtos);
        }

        [HttpGet("EmployeeInformationById")]
        public IActionResult GetEmployeeInformation(int employeeId)
        {
            var employeeInfo = _excelService.GetEmployeeById(employeeId);

            if (employeeInfo == null)
            {
                return NotFound(); // Belirtilen employeeId'ye sahip çalışan bulunamadıysa NotFound döndür
            }

            return Ok(employeeInfo);
        }
    }
}
