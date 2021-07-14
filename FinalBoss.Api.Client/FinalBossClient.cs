using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

using FinalBoss.Api.Dto;

namespace FinalBoss.Api.Client
{
    public sealed class FinalBossClient : IFinalBossClient
    {
        private const string UserAgent = "FaaSBank";

        private readonly HttpClient _httpClient = new HttpClient();

        private readonly JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = false,
            PropertyNameCaseInsensitive = true
        };

        public FinalBossClient(IFinalBossClientConfiguration configuration)
        {
            _httpClient.BaseAddress = new Uri(configuration.BaseUrl);

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _httpClient.DefaultRequestHeaders.Add("User-Agent", UserAgent);
            _httpClient.DefaultRequestHeaders.Add("X-Token", configuration.ApiToken);
        }

        public async Task<T> GetAsync<T>(string requestUri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri);

            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions);
            }
        }

        public async Task<T> PostAsync<T>(string requestUri, T dto) where T : BaseDto
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(dto))
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();

                return await JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions);
            }
        }

        public async Task<T> PutAsync<T>(string requestUri, T dto) where T : BaseDto
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(dto))
            };

            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                var stream = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<T>(stream, _jsonSerializerOptions);
            }
        }

        public async Task<bool> DeleteAsync<T>(string requestUri)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, requestUri);

            using (HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                return response.IsSuccessStatusCode;
            }
        }
    }
}