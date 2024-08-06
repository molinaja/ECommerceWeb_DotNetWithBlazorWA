using ECommerceWeb.Dto;

namespace ECommerceWeb.Client.Proxy
{
    public interface IShoppingCartProxy
    {
        event Action?  RefreshView;

        Task AddShoppingCart(ShoppingCartDto shoppingCartDto);

        Task DeleteShoppingCart(int IdProduct);

        int QuantityProducts();

        Task<ICollection<ShoppingCartDto>> GetShoppingCart();

        Task CleanShoppingCart();

    }
}
