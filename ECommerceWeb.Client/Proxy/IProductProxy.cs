using ECommerceWeb.Dto.Response;

namespace ECommerceWeb.Client.Proxy
{
    public interface IProductProxy
    {
        Task<ICollection<ProductDtoResponse>> ListAsync(string Filtro);

        Task<ProductDtoResponse> FindByIdAsync(int Id);

    }
}
