using AZ_AI_Translate_Text.Interfaces;
using AZ_AI_Translate_Text.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace AZ_AI_Translate_Text.Services
{
    public class TranslateService(HttpClient httpClient, IConfiguration config) : ITranslateService
    {
        public async Task<List<TranslationResult>> TranslateAsync(TranslateRequest translateRequest)
        {
            string endpoint = config["Translator:Endpoint"]!;
            string key = config["Translator:Key"]!;
            string region = config["Translator:Region"]!;

            string route = $"/translate?api-version=3.0&to={translateRequest.To}";

            var body = new object[] { new { Text = translateRequest.Text } };
            var requestBody = JsonSerializer.Serialize(body);

            using var httpRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(endpoint + route),
                Content = new StringContent(requestBody, Encoding.UTF8, "application/json")
            };

            httpRequest.Headers.Add("Ocp-Apim-Subscription-Key", key);
            httpRequest.Headers.Add("Ocp-Apim-Subscription-Region", region);

            var response = await httpClient.SendAsync(httpRequest);
            response.EnsureSuccessStatusCode();

            string result = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<TranslationResult>>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true })!;
        }
    }
}
