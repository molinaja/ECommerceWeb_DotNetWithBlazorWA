using Blazored.Toast.Services;
using ECommerceWeb.Dto.Response;
using System.Net.Http.Json;

namespace ECommerceWeb.Client.Proxy
{
    public class ProductProxy(HttpClient httpClient) : IProductProxy
    {
        private readonly HttpClient _httpClient = httpClient;

        public async Task<ProductDtoResponse> FindByIdAsync(int Id)
        {

            try
            {
                var res = await httpClient.GetAsync($"api/Products/{Id}");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var productDtoResponse = await res.Content.ReadFromJsonAsync<ProductDtoResponse>();
                    if (productDtoResponse != null)
                    {
                        return productDtoResponse;
                    }
                    else
                    {
                        var errorContent = await res.Content.ReadAsStringAsync();
                        throw new HttpRequestException($"Failure in getting the product: {errorContent}");
                    }

                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failure in getting the product: {res.StatusCode} - {errorContent}");
                    throw new HttpRequestException($"Failure in getting the product: {res.StatusCode}");
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

        public async Task<ICollection<ProductDtoResponse>> ListAsync(string Filtro)
        {
            try
            {
                var res = await httpClient.GetAsync($"api/Products/filters{Filtro}");
                res.EnsureSuccessStatusCode();
                if (res.IsSuccessStatusCode)
                {
                    var productDtoResponse = await res.Content.ReadFromJsonAsync<ICollection<ProductDtoResponse>>();
                    if (productDtoResponse != null) { 
                        return productDtoResponse;
                    }
                    throw new InvalidOperationException(res.ReasonPhrase);
                }
                else
                {
                    var errorContent = await res.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failure in getting the product: {res.StatusCode} - {errorContent}");
                    throw new HttpRequestException($"Failure in getting the product:{res.StatusCode}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
                throw;
            }
        }

    }
}
