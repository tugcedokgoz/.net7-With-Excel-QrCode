using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelQrProject.Model.Dto
{
    //Qr ekranında listelenen employee
    public class EmployeeDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }
        public string? QrcodePath { get; set; }
    }
}
