using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace aiTherapist.Services
{
    public class ElevenLabsService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "sk_fe899086266bb3e53f84aa3b7486a4a8fc269793cbc9e87d";

        public ElevenLabsService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("xi-api-key", _apiKey);
        }

        public async Task<byte[]> GetSpeechFromTextAsync(string text)
        {
            var requestBody = new
            {
                text = text,
                voice_settings = new
                {
                    stability = 0.75,
                    similarity_boost = 0.85
                }
            };

            var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(
                "https://api.elevenlabs.io/v1/text-to-speech/VOICE_ID",
                content
            );

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsByteArrayAsync(); // MP3 audio
        }



    }
}
