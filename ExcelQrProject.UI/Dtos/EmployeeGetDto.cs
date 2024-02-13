namespace ExcelQrProject.UI.Dtos
{
    public class EmployeeGetDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Surname { get; set; }
        public string? QrcodePath { get; set; }
        public string QrcodeImageUrl => $"data:image/png;base64,{QrcodePath}";
    }
}
