using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelQrProject.Model.Dto
{
    //Id ye göre employee getirme 
    public class EmployeeGetDto
    {
        public string? Name { get; set; }

        public string? Surname { get; set; }

        public string? Phone { get; set; }

        public string? Email { get; set; }

        public string? Department { get; set; }

        public string? Position { get; set; }
    }
}
