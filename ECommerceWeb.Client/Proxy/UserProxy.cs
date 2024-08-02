using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using System.Net.Http.Json;

namespace ECommerceWeb.Client.Proxy
{
    public class UserProxy(HttpClient httpClient) : IUserProxy
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<LoginDtoResponse> Login(LoginDtoRequest request)
        {
            var response = await _httpClient.PostAsJsonAsync<LoginDtoRequest>("api/users/login", request);

            var loginResponse = await response.Content.ReadFromJsonAsync<LoginDtoResponse>();

            return loginResponse!;
        }

        public async Task Register(RegisterUserDtoRequest request)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/users/register", request);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
