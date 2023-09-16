using Basket.API.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Basket.API.Data
{
    public class ShoppingCartRepo : IShoppingCartRepo
    {
        private readonly ShoppingCartDbContext context;

        public ShoppingCartRepo(ShoppingCartDbContext context)
        {
            this.context = context;
        }

        public async Task<ShoppingCart> GetBasket(int userId)
        {
            return await context.Carts
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();
        }

        public async Task<ShoppingCart> UpdateBasket(int userId, ShoppingCartItem item)
        {
            var basketInRepo = await context.Carts
            .Include(x => x.Items)
            .Where(x => x.UserId == userId)
            .FirstOrDefaultAsync();

            // If basket does not exist
            if (basketInRepo == null)
            {
                var basket = new ShoppingCart(userId) { Items = new List<ShoppingCartItem> { item } };
                await context.Carts.AddAsync(basket);
                await context.SaveChangesAsync();
                return basket;
            }

            // If basket exist 

            if (basketInRepo.Items.Any(x => x.ProductId == item.ProductId))
            {
                // If Item exist
                var itemToUpdate = basketInRepo.Items.Where(x => x.ProductId == item.ProductId).FirstOrDefault();
                itemToUpdate.Quantity += 1;
                context.SaveChanges();
            }
            else
            {
                // If item does not exist
                //item.Cart = basketInRepo;
                basketInRepo.Items.Add(item);
                context.SaveChanges();
            }

            return basketInRepo;
        }

        public async Task<bool> DeleteBasket(int userId)
        {
            var basket = await context.Carts.Where(x => x.UserId == userId).FirstOrDefaultAsync();
            if (basket != null)
            {
                context.Carts.Remove(basket);
                var status = context.SaveChanges();
                return status > 0;
            }
            return false;
        }

    }
}
