using System;
using System.Collections.Generic;

namespace ExcelQrProject.Model.Models;

public partial class Employee
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Department { get; set; }

    public string? Position { get; set; }

    public string? QrcodePath { get; set; }


}
