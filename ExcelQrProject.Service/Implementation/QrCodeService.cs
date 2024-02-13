using ExcelQrProject.Model.Models;
using ExcelQrProject.Service.Interface;
using QRCoder;
using System.Drawing;
using System.IO;
namespace ExcelQrProject.Service.Implementation
{
    public class QrCodeService : IQrCodeService
    {
        //public string GenerateQrCode(Employee employee)
        //{
        //    QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    string employeeInfo = $"ID: {employee.Id}\nName: {employee.Name}\nSurname: {employee.Surname}\nPhone: {employee.Phone}\nEmail: {employee.Email}\nDepartment: {employee.Department}\nPosition: {employee.Position}";
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(employeeInfo, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);

        //    using (Bitmap qrCodeImage = qrCode.GetGraphic(5))
        //    {
        //        using (MemoryStream ms = new MemoryStream())
        //        {
        //            // QR kodu resmini MemoryStream'e kaydet
        //            qrCodeImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

        //            // MemoryStream'deki resmi byte dizisine dönüştür
        //            byte[] imageBytes = ms.ToArray();

        //            // Byte dizisini base64 stringine dönüştür
        //            string base64String = Convert.ToBase64String(imageBytes);

        //            return base64String;
        //        }
        //    }
        //}
        public byte[] GenerateQRCode(Employee employee)
        {
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            // Çalışanın adını ve soyadını birleştirerek QR kodu içeriği oluştur
            string employeeInfo = $"{employee.Name} {employee.Surname}";
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(employeeInfo, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20); // QR kod görüntüsünü oluştur

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray(); // PNG verisini döndür
            }
        }
    }
}


