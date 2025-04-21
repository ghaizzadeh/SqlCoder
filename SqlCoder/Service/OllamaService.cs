using System.Text.Json;
using System.Text;

namespace WebApplication1.Services
{
   public class OllamaService
   {
      private readonly HttpClient _httpClient;

      public OllamaService(HttpClient httpClient)
      {
         _httpClient = httpClient;
      }

      public async Task<string> GenerateSqlAsync(string prompt)
      {
         var requestBody = new
         {
            model = "sqlcoder",
            prompt = prompt,
            stream = false
         };

         var content = new StringContent(
             JsonSerializer.Serialize(requestBody),
             Encoding.UTF8,
             "application/json");

         var response = await _httpClient.PostAsync("http://localhost:11434/api/generate", content);
         response.EnsureSuccessStatusCode();
         var responseString = await response.Content.ReadAsStringAsync();
         var json = JsonDocument.Parse(responseString);
         return json.RootElement.GetProperty("response").GetString();
      }
   }
}
