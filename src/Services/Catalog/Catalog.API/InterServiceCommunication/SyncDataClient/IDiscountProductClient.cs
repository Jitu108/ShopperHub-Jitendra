using Catalog.API.Dtos;

namespace Catalog.API.InterServiceCommunication.SyncDataClient
{
    public interface IDiscountProductClient
    {
        Task<bool> AddProductAsync(ProductDiscount product);
    }
}
