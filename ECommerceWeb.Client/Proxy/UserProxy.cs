using BlazorSpinner;
using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;
using Microsoft.JSInterop;
using System.Net.Http.Json;
using System.Text.Json;

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
            string errorBodyFor400 = string.Empty;
            try
            {
                var response = await _httpClient.PostAsJsonAsync("api/users/register", request);
                if ((int)response.StatusCode == 400)
                {
                    errorBodyFor400 = await response.Content.ReadAsStringAsync();
                }
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex) when (ex.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {         
                var Response = JsonSerializer.Deserialize<BaseResponse>(errorBodyFor400);
               
                
                if (Response != null)
                {
                    throw new InvalidOperationException(Response.msnError);
                }
                else
                {
                    throw new InvalidOperationException(ex.Message);

                }

            }
            catch (Exception ex)
            {

                throw new InvalidOperationException(ex.Message);
            }
        }

    }
}
