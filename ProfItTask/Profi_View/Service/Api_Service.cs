using ProfItTask.Core.Entities;
using System.Text;
using System.Text.Json;

namespace Profi_View.Service
{
    public class Api_Service
    {
        private readonly HttpClient _httpClient;

        public Api_Service(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> CreateLesson(Lesson lesson)
        {
            var jsonContent = new StringContent(
                JsonSerializer.Serialize(lesson),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync("https://localhost:7019/Lesson/Create", jsonContent);

            return response.IsSuccessStatusCode;
        }
       
        
        public async Task<List<Lesson>> GetCreate()
        {
            var response = await _httpClient.GetAsync("https://localhost:7019/Lesson/GetAll");

            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<Lesson>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            return new List<Lesson>();
        }
    }
}
