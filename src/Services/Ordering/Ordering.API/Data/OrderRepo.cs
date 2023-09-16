using Microsoft.EntityFrameworkCore;
using Ordering.API.Data.Entities;

namespace Ordering.API.Data
{
    public class OrderRepo : IOrderRepo
    {
        private readonly OrderingDbContext context;

        public OrderRepo(OrderingDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> AddOrder(Order order)
        {
            order.OrderDate = DateTime.Now;
            await context.Orders.AddAsync(order);
            var status = await context.SaveChangesAsync();
            return status > 0;
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await context.Orders
                .Include(x => x.Items)
                .Include(x => x.Addresses)
                .Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Order>> GetOrderByUserId(int userId)
        {
            return await context.Orders
                .Include(x => x.Items)
                .Include(x => x.Addresses)
                .Where(x => x.UserId == userId).ToListAsync();
        }
    }
}
