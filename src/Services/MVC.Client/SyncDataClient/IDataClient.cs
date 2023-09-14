using MVC.Client.Models;

namespace MVC.Client.SyncDataClient
{
    public interface IDataClient
    {
        Task<IEnumerable<CatalogProduct>> GetCatalog();

        Task<ShoppingCart> AddToBasket(string userId, CartItem item);

        Task<bool> RemoveBasket(string userId, CartItem item);
    }
}
