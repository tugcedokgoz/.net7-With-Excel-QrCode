using ExcelQrProject.UI.Dtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ExcelQrProject.UI.Controllers
{

    public class ExcelQrController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ExcelQrController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7115/api/ExcelQr/getallemployees");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
           var values=     JsonConvert.DeserializeObject<List<EmployeeGetDto>>(jsonData);
                return View(values);
            }
            return View();
        }


    }
}
