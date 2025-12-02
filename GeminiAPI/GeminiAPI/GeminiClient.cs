using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeminiAPI
{
    internal class GeminiClient
    {
        private readonly HttpClient client = new HttpClient();
        private readonly string apiKey;

        public GeminiClient(string key)
        {
            apiKey = key;
        }

        public async Task<string> SendPromptAsync(string prompt)
        {
            var url = $"https://generativelanguage.googleapis.com/v1/models/gemini-2.5-flash:generateContent?key={apiKey}";

            var body = $@"{{
              ""contents"": [
                {{
                  ""parts"": [
                    {{""text"": ""{prompt}""}}
                  ]
                }}
              ]
            }}";

            var response = await client.PostAsync(
                url,
                new StringContent(body, Encoding.UTF8, "application/json")
            );

            return await response.Content.ReadAsStringAsync();
        }
    }
}
