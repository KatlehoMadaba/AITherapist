using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace aiTherapist.Services
{
    public class IAiTherapistService
    {
        private readonly HttpClient _httpClient;
        private readonly string _openAiApiKey = "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"
        public IAiTherapistService(HttpClient httpClient, string openAiApiKey)
        {
            _httpClient = httpClient;
            _openAiApiKey = openAiApiKey;
        }

        public async Task<string> GetTherapistResponseAsync(string userMessage)
        {
            var requestBody = new
            {
                model = "gpt-3.5-turbo",
                messages = new[]
                {
                new { role = "system", content = "You are a compassionate therapist offering emotional support." },
                new { role = "user", content = userMessage }
            }
            };
            var requestContent = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
            );
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_openAiApiKey}");

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", requestContent);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync();
            using var document = JsonDocument.Parse(jsonResponse);
            var aiReply = document.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

            return aiReply;

        }

    }

}
