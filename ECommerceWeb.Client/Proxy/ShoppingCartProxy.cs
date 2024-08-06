using Blazored.LocalStorage;
using Blazored.Toast.Services;
using ECommerceWeb.Dto;

namespace ECommerceWeb.Client.Proxy
{
    public class ShoppingCartProxy(
        ILocalStorageService localStorageService
        , ISyncLocalStorageService syncLocalStorageService
        , IToastService toastService
        ) : IShoppingCartProxy
    {
        private readonly ILocalStorageService _localStorageService = localStorageService;
        private readonly ISyncLocalStorageService _syncLocalStorageService = syncLocalStorageService;
        private readonly IToastService _toastService = toastService;
        private readonly string _LocalStorageNameShoppingCart = "ShoppingCart";


        public event Action? RefreshView;

        public async Task AddShoppingCart(ShoppingCartDto newProduct)
        {
            try
            {
                var shoppingCart = await _localStorageService.GetItemAsync<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart)
                    ?? new List<ShoppingCartDto>();
                var oldProduct = shoppingCart.FirstOrDefault<ShoppingCartDto>(x => x.Product.Id == newProduct.Product.Id);
                if (oldProduct != null)
                {
                    shoppingCart.Remove(oldProduct);
                }
                shoppingCart.Add(newProduct);
                await _localStorageService.SetItemAsync<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart, shoppingCart);
                var msn = oldProduct != null ? "Product updated successfully" : "Prucduct added sucessfuly";
                _toastService.ShowSuccess(msn);
                RefreshView?.Invoke();

            }
            catch (Exception ex)
            {
                _toastService.ShowError($"failure in add item in shopping cart: {ex.Message} ");
            }
        }

        public int QuantityProducts()
        {
            var shoppingCart = _syncLocalStorageService.GetItem<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart); 
            return shoppingCart?.Count ?? 0;
        }

        public async Task CleanShoppingCart()
        {
            await _localStorageService.RemoveItemAsync(_LocalStorageNameShoppingCart);
            RefreshView?.Invoke();
        }

        public async Task DeleteShoppingCart(int IdProduct)
        {
            try
            {
                var shoppingCart = await _localStorageService.GetItemAsync<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart)
                    ?? new List<ShoppingCartDto>();
                var oldProduct = shoppingCart.FirstOrDefault<ShoppingCartDto>(x => x.Product.Id == IdProduct);
                if (oldProduct != null)
                {
                    shoppingCart.Remove(oldProduct);
                    await _localStorageService.SetItemAsync<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart, shoppingCart);
                    _toastService.ShowSuccess("Product Removed");
                    RefreshView?.Invoke();
                }
            }
            catch (Exception ex)
            {

                _toastService.ShowError($"failure in remove item in shopping cart: {ex.Message} ");

            }
        }

        public async Task<ICollection<ShoppingCartDto>> GetShoppingCart()
        {
            return await _localStorageService.GetItemAsync<ICollection<ShoppingCartDto>>(_LocalStorageNameShoppingCart)
                ?? new List<ShoppingCartDto>();
        }
    }
}
