using ECommerceWeb.Dto.Request;
using ECommerceWeb.Dto.Response;

namespace ECommerceWeb.Client.Proxy
{
    public interface IUserProxy
    {
        Task<LoginDtoResponse> Login (LoginDtoRequest request);
        Task Register(RegisterUserDtoRequest request); 
    }
}
