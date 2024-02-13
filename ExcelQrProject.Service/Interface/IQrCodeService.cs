using ExcelQrProject.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelQrProject.Service.Interface
{
    public interface IQrCodeService
    {
        //string GenerateQrCode(Employee employee);
        byte[] GenerateQRCode(Employee employee);
    }
}
