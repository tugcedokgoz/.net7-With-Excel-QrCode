using ExcelQrProject.Model.Dto;
using ExcelQrProject.Model.Models;
using ExcelQrProject.Service.Interface;
using OfficeOpenXml;
using QRCoder;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace ExcelQrProject.Service.Implementation
{
    public class ExcelService : IExcelService
    {
        private readonly ExcelQrProjectContext _dbContext;
        private readonly IQrCodeService _qrCodeService; // IQrCodeService bağımlılığını ekledik

        public ExcelService(ExcelQrProjectContext dbContext, IQrCodeService qrCodeService)
        {
            _dbContext = dbContext;
            _qrCodeService = qrCodeService; // Dependency Injection ile QrCodeService'i alıyoruz
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public List<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public EmployeeGetDto GetEmployeeById(int employeeId)
        {
            var employee = _dbContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employee == null)
            {
                return null; // Employee bulunamadıysa null döndür
            }

            // Employee nesnesini EmployeeGetDto'ya dönüştür
            var employeeDto = new EmployeeGetDto
            {
                Name = employee.Name,
                Surname = employee.Surname,
                Phone = employee.Phone,
                Email = employee.Email,
                Department = employee.Department,
                Position = employee.Position
            };

            return employeeDto;
        }

        public List<Employee> ProcessExcelFile(Stream excelStream)
        {
            List<Employee> employees = new List<Employee>();

            using (var package = new ExcelPackage(excelStream))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet != null)
                {
                    for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                    {
                        var employee = new Employee
                        {
                            // Excel'deki her bir sütununuzun index'ine göre düzenleyin
                            Name = worksheet.Cells[row, 3].Value?.ToString(),
                            Surname = worksheet.Cells[row, 4].Value?.ToString(),
                            Phone = worksheet.Cells[row, 5].Value?.ToString(),
                            Email = worksheet.Cells[row, 6].Value?.ToString(),
                            Department = worksheet.Cells[row, 7].Value?.ToString(),
                            Position = worksheet.Cells[row, 8].Value?.ToString()
                        };
                        employees.Add(employee);

                        //// QR kodu oluştur ve yolunu Employee nesnesine ekle
                        //string qrCodePath = _qrCodeService.GenerateQrCode(employee); // QR kodu oluştur
                        //employee.QrcodePath = qrCodePath; // Oluşturulan QR kod yolunu Employee nesnesine ekle


                        // QR kodu oluştur ve yolunu Employee nesnesine ekle
                        // QR kodu oluştur ve yolunu Employee nesnesine ekle
                        byte[] qrCodeBytes = _qrCodeService.GenerateQRCode(employee); // QR kodu oluştur
                        string qrCodeBase64 = Convert.ToBase64String(qrCodeBytes); // Base64 formatına dönüştür
                        employee.QrcodePath = qrCodeBase64; // Oluşturulan QR kod yolunu Employee nesnesine ekle

                    }
                }
            }

            // Verileri veritabanına kaydetmek için
            _dbContext.Employees.AddRange(employees);
            _dbContext.SaveChanges();

            return employees;
        }
    }
}
